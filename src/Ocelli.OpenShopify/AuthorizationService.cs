using System.Collections.Specialized;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Primitives;
using Ocelli.OpenShopify.Extensions;

namespace Ocelli.OpenShopify;
public static class AuthorizationService
{
    private static readonly Regex QueryStringRegex = new(@"[?|&]([\w\.]+)=([^?|^&]+)", RegexOptions.Compiled);

    /// <remarks>
    /// Source for this method: https://stackoverflow.com/a/22046389
    /// </remarks>
    public static IDictionary<string, string> ParseRawQuerystring(string qs)
    {
        // Must use an absolute uri, else Uri.Query throws an InvalidOperationException
        var uri = new UriBuilder("http://localhost:3000")
        {
            Query = Uri.UnescapeDataString(qs)
        }.Uri;
        var match = QueryStringRegex.Match(uri.PathAndQuery);
        var parameters = new Dictionary<string, string>();
        while (match.Success)
        {
            parameters.Add(match.Groups[1].Value, match.Groups[2].Value);
            match = match.NextMatch();
        }
        return parameters;
    }

    private static string EncodeQuery(string key, StringValues values, bool isKey)
    {
        string? result;

        if (isKey)
        {
            result = key;
        }
        else
        {
            //array parameters are handled differently: see https://community.shopify.com/c/Shopify-APIs-SDKs/HMAC-calculation-vs-ids-arrays/td-p/261154
            result = values.Count <= 1 && !key.EndsWith("[]") ?
                        values.FirstOrDefault() :
                        '[' + string.Join(", ", values.Select(v => '"' + v + '"')) + ']';
        }

        if (string.IsNullOrEmpty(result))
        {
            return "";
        }

        //Important: Replace % before replacing &. Else second replace will replace those %25s.
        result = result.Replace("%", "%25").Replace("&", "%26");

        if (isKey)
        {
            result = result.Replace("=", "%3D").Replace("[]", "");
        }

        return result;
    }

    private static string PrepareQuerystring(IEnumerable<KeyValuePair<string, StringValues>> querystring, string joinWith)
    {
        var kvps = querystring.Select(kvp => new {
            Key = EncodeQuery(kvp.Key, kvp.Value, true),
            Value = EncodeQuery(kvp.Key, kvp.Value, false)
        })
            .Where(kvp => kvp.Key != "signature" && kvp.Key != "hmac")
            .OrderBy(kvp => kvp.Key, StringComparer.Ordinal)
            .Select(kvp => $"{kvp.Key}={kvp.Value}");

        return string.Join(joinWith, kvps);
    }

    /// <summary>
    /// Determines if an incoming request is authentic.
    /// </summary>
    /// <param name="querystring">The collection of querystring parameters from the request. Hint: use Request.QueryString if you're calling this from an ASP.NET MVC controller.</param>
    /// <param name="shopifySecretKey">Your application's secret key.</param>
    /// <returns>A boolean indicating whether the request is authentic or not.</returns>
    public static bool IsAuthenticRequest(IEnumerable<KeyValuePair<string, StringValues>> querystring, string shopifySecretKey)
    {
        // To calculate HMAC signature:
        // 1. Cast querystring to KVP pairs.
        // 2. Remove `signature` and `hmac` keys.
        // 3. Replace & with %26, % with %25 in keys and values.
        // 4. Replace = with %3D in keys only.
        // 5. Join each key and value with = (key=value).
        // 6. Sort kvps alphabetically.
        // 7. Join kvps together with & (key=value&key=value&key=value).
        // 8. Compute the kvps with an HMAC-SHA256 using the secret key.
        // 9. Request is authentic if the computed string equals the `hash` in query string.
        // Reference: https://docs.shopify.com/api/guides/authentication/oauth#making-authenticated-requests
        var hmacValues = querystring.FirstOrDefault(kvp => kvp.Key == "hmac").Value;

        if (string.IsNullOrEmpty(hmacValues) || !hmacValues.Any())
        {
            return false;
        }

        var hmac = hmacValues.First();
        var kvps = PrepareQuerystring(querystring, "&");
        var hmacHasher = new HMACSHA256(Encoding.UTF8.GetBytes(shopifySecretKey));
        var hash = hmacHasher.ComputeHash(Encoding.UTF8.GetBytes(string.Join("&", kvps)));

        //Convert bytes back to string, replacing dashes, to get the final signature.
        var calculatedSignature = BitConverter.ToString(hash).Replace("-", "");

        //Request is valid if the calculated signature matches the signature from the querystring.
        return calculatedSignature.ToUpper() == hmac.ToUpper();
    }

    /// <summary>
    /// Determines if an incoming request is authentic.
    /// </summary>
    /// <param name="querystring">A dictionary containing the keys and values from the request's querystring.</param>
    /// <param name="shopifySecretKey">Your application's secret key.</param>
    /// <returns>A boolean indicating whether the request is authentic or not.</returns>
    public static bool IsAuthenticRequest(IDictionary<string, string> querystring, string shopifySecretKey)
    {
        var qs = querystring.Select(kvp => new KeyValuePair<string, StringValues>(kvp.Key, kvp.Value));

        return IsAuthenticRequest(qs, shopifySecretKey);
    }

    /// <summary>
    /// Determines if an incoming request is authentic.
    /// </summary>
    /// <param name="querystring">The request's raw querystring.</param>
    /// <param name="shopifySecretKey">Your application's secret key.</param>
    /// <returns>A boolean indicating whether the request is authentic or not.</returns>
    public static bool IsAuthenticRequest(string querystring, string shopifySecretKey)
    {
        return IsAuthenticRequest(ParseRawQuerystring(querystring), shopifySecretKey);
    }

    /// <summary>
    /// Determines if an incoming proxy page request is authentic. Conceptually similar to <see cref="IsAuthenticRequest(NameValueCollection, string)"/>,
    /// except that proxy requests use HMACSHA256 rather than MD5.
    /// </summary>
    /// <param name="querystring">The collection of querystring parameters from the request. Hint: use Request.QueryString if you're calling this from an ASP.NET MVC controller.</param>
    /// <param name="shopifySecretKey">Your application's secret key.</param>
    /// <returns>A boolean indicating whether the request is authentic or not.</returns>
    public static bool IsAuthenticProxyRequest(IEnumerable<KeyValuePair<string, StringValues>> querystring, string shopifySecretKey)
    {
        // To calculate signature, order all querystring parameters by alphabetical (exclude the
        // signature itself). Then, hash it with the secret key.
        var signatureValues = querystring.FirstOrDefault(kvp => kvp.Key == "signature").Value;

        if (string.IsNullOrEmpty(signatureValues) || !signatureValues.Any())
        {
            return false;
        }

        var signature = signatureValues.First();
        var kvps = PrepareQuerystring(querystring, string.Empty);
        var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(shopifySecretKey));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(string.Join(null, kvps)));

        //Convert bytes back to string, replacing dashes, to get the final signature.
        var calculatedSignature = BitConverter.ToString(hash).Replace("-", "");

        //Request is valid if the calculated signature matches the signature from the querystring.
        return calculatedSignature.ToUpper() == signature.ToUpper();
    }

    /// <summary>
    /// Determines if an incoming proxy page request is authentic. Conceptually similar to <see cref="IsAuthenticRequest(NameValueCollection, string)"/>,
    /// except that proxy requests use HMACSHA256 rather than MD5.
    /// </summary>
    /// <param name="querystring">A dictionary containing the keys and values from the request's querystring.</param>
    /// <param name="shopifySecretKey">Your application's secret key.</param>
    /// <returns>A boolean indicating whether the request is authentic or not.</returns>
    public static bool IsAuthenticProxyRequest(IDictionary<string, string> querystring, string shopifySecretKey)
    {
        var qs = querystring.Select(kvp => new KeyValuePair<string, StringValues>(kvp.Key, kvp.Value));

        return IsAuthenticProxyRequest(qs, shopifySecretKey);
    }

    /// <summary>
    /// Determines if an incoming proxy page request is authentic. Conceptually similar to <see cref="IsAuthenticRequest(NameValueCollection, string)"/>,
    /// except that proxy requests use HMACSHA256 rather than MD5.
    /// </summary>
    /// <param name="querystring">The request's raw querystring.</param>
    /// <param name="shopifySecretKey">Your application's secret key.</param>
    /// <returns>A boolean indicating whether the request is authentic or not.</returns>
    public static bool IsAuthenticProxyRequest(string querystring, string shopifySecretKey)
    {
        return IsAuthenticProxyRequest(ParseRawQuerystring(querystring), shopifySecretKey);
    }

    /// <summary>
    /// Determines if an incoming webhook request is authentic.
    /// </summary>
    /// <param name="requestHeaders">The request's headers. Hint: use Request.Headers if you're calling this from an ASP.NET MVC controller.</param>
    /// <param name="inputStream">The request's input stream. This method does NOT dispose the stream.
    /// Hint: use Request.InputStream if you're calling this from an ASP.NET MVC controller.</param>
    /// <param name="shopifySecretKey">Your application's secret key.</param>
    /// <returns>A boolean indicating whether the webhook is authentic or not.</returns>
    public static async Task<bool> IsAuthenticWebhook(IEnumerable<KeyValuePair<string, StringValues>> requestHeaders, Stream inputStream, string shopifySecretKey)
    {
        //Input stream may have already been read when a controller determines parameters to
        //pass to an action. Reset position to 0.
        inputStream.Position = 0;

        //We do not dispose the StreamReader because disposing it will also dispose the input stream,
        //and disposing a request's input stream can cause major headaches for the developer.
        var requestBody = await new StreamReader(inputStream).ReadToEndAsync();

        return IsAuthenticWebhook(requestHeaders, requestBody, shopifySecretKey);
    }

    /// <summary>
    /// Determines if an incoming webhook request is authentic.
    /// </summary>
    /// <param name="requestHeaders">The request's headers. Hint: use Request.Headers if you're calling this from an ASP.NET MVC controller.</param>
    /// <param name="requestBody">The body of the request.</param>
    /// <param name="shopifySecretKey">Your application's secret key.</param>
    /// <returns>A boolean indicating whether the webhook is authentic or not.</returns>
    public static bool IsAuthenticWebhook(IEnumerable<KeyValuePair<string, StringValues>> requestHeaders, string requestBody, string shopifySecretKey)
    {
        var hmacHeaderValues = requestHeaders.FirstOrDefault(kvp => kvp.Key.Equals("X-Shopify-Hmac-SHA256", StringComparison.OrdinalIgnoreCase)).Value;

        if (string.IsNullOrEmpty(hmacHeaderValues) || !hmacHeaderValues.Any())
        {
            return false;
        }

        //Compute a hash from the apiKey and the request body
        var hmacHeader = hmacHeaderValues.First();
        var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(shopifySecretKey));
        var hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(requestBody)));

        //Webhook is valid if computed hash matches the header hash
        return hash == hmacHeader;
    }

    /// <summary>
    /// Determines if an incoming webhook request is authentic.
    /// </summary>
    /// <param name="requestHeaders">The request's headers.</param>
    /// <param name="requestBody">The body of the request.</param>
    /// <param name="shopifySecretKey">Your application's secret key.</param>
    /// <returns>A boolean indicating whether the webhook is authentic or not.</returns>
    public static bool IsAuthenticWebhook(HttpRequestHeaders requestHeaders, string requestBody, string shopifySecretKey)
    {
        var hmacHeaderValue = requestHeaders.FirstOrDefault(kvp => kvp.Key.Equals("X-Shopify-Hmac-SHA256", StringComparison.OrdinalIgnoreCase)).Value.FirstOrDefault();

        if (string.IsNullOrEmpty(hmacHeaderValue))
        {
            return false;
        }

        //Compute a hash from the apiKey and the request body
        var hmacHeader = hmacHeaderValue;
        var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(shopifySecretKey));
        var hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(requestBody)));

        //Webhook is valid if computed hash matches the header hash
        return hash == hmacHeader;
    }

    /// <summary>
    /// A convenience function that tries to ensure that a given URL is a valid Shopify domain. It does this by making a HEAD request to the given domain, and returns true if the response contains an X-ShopId header.
    ///
    /// **Warning**: a domain could fake the response header, which would cause this method to return true.
    ///
    /// **Warning**: this method of validation is not officially supported by Shopify and could break at any time.
    /// </summary>
    /// <param name="url">The URL of the shop to check.</param>
    /// <returns>A boolean indicating whether the URL is valid.</returns>
    public static async Task<bool> IsValidShopDomainAsync(string url)
    {
        var uri = BuildShopUri(url, false);

        using var handler = new HttpClientHandler
        {
            AllowAutoRedirect = false
        };
        using var client = new HttpClient(handler);
        using var msg = new HttpRequestMessage(HttpMethod.Head, uri);
        var version = typeof(AuthorizationService).GetTypeInfo().Assembly.GetName().Version;
        msg.Headers.Add("User-Agent", $"OpenShopify v{version} (https://github.com/codecooper/OpenShopify)");

        try
        {
            var response = await client.SendAsync(msg);

            return response.Headers.Any(h => h.Key.Equals("X-ShopId", StringComparison.OrdinalIgnoreCase));
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }

    /// <summary>
    /// Builds an authorization URL for Shopify OAuth integration.
    /// </summary>
    /// <param name="scopes">An array of <see cref="ShopifyAuthorizationScope"/> — the permissions that your app needs to run.</param>
    /// <param name="myShopifyUrl">The shop's *.myshopify.com URL.</param>
    /// <param name="shopifyApiKey">Your application's public API key.</param>
    /// <param name="redirectUrl">URL to redirect the user to after integration.</param>
    /// <param name="state">An optional, random string value provided by your application which is unique for each authorization request. During the OAuth callback phase, your application should check that this value matches the one you provided to this method.</param>
    /// <param name="grants">Requested grant types, which will change the type of access token granted upon OAuth completion. Only known grant type is "per-user", which will give an access token restricted to the permissions of the user accepting OAuth integration and will expire when that user logs out. Leave the grants array empty or null to receive a full access token that doesn't expire.</param>
    /// <returns>The authorization url.</returns>
    public static Uri BuildAuthorizationUrl(IEnumerable<AuthorizationScope> scopes, string myShopifyUrl, string shopifyApiKey, string redirectUrl, string? state = null, IEnumerable<string>? grants = null)
    {
        return BuildAuthorizationUrl(scopes.Select(s => s.ToSerializedString()), myShopifyUrl, shopifyApiKey, redirectUrl, state, grants);
    }

    /// <summary>
    /// Builds an authorization URL for Shopify OAuth integration.
    /// </summary>
    /// <param name="scopes">An array of Shopify permission strings, e.g. 'read_orders' or 'write_script_tags'. These are the permissions that your app needs to run.</param>
    /// <param name="myShopifyUrl">The shop's *.myshopify.com URL.</param>
    /// <param name="shopifyApiKey">Your application's public API key.</param>
    /// <param name="redirectUrl">URL to redirect the user to after integration.</param>
    /// <param name="state">An optional, random string value provided by your application which is unique for each authorization request. During the OAuth callback phase, your application should check that this value matches the one you provided to this method.</param>
    /// <param name="grants">Requested grant types, which will change the type of access token granted upon OAuth completion. Only known grant type is "per-user", which will give an access token restricted to the permissions of the user accepting OAuth integration and will expire when that user logs out. Leave the grants array empty or null to receive a full access token that doesn't expire.</param>
    /// <returns>The authorization url.</returns>
    public static Uri BuildAuthorizationUrl(IEnumerable<string> scopes, string myShopifyUrl, string shopifyApiKey, string redirectUrl, string? state = null, IEnumerable<string>? grants = null)
    {
        //Prepare a uri builder for the shop URL
        var builder = new UriBuilder(BuildShopUri(myShopifyUrl, false));

        //Build the querystring
        var qs = new List<KeyValuePair<string, string?>>()
            {
                new ("client_id", shopifyApiKey),
                new ("scope", string.Join(",", scopes)),
                new ("redirect_uri", redirectUrl),
            };

        if (string.IsNullOrEmpty(state) == false)
        {
            qs.Add(new KeyValuePair<string, string?>("state", state));
        }

        if (grants != null && grants.Any())
        {
            qs.AddRange(grants.Select(grant => new KeyValuePair<string, string?>("grant_options[]", grant)));
        }

        builder.Path = "admin/oauth/authorize";
        builder.Query = string.Join("&", qs.Select(s => $"{s.Key}={s.Value}"));

        return builder.Uri;
    }

    /// <summary>
    /// Authorizes an application installation, generating an access token for the given shop.
    /// </summary>
    /// <param name="code">The authorization code generated by Shopify, which should be a parameter named 'code' on the request querystring.</param>
    /// <param name="myShopifyUrl">The store's *.myshopify.com URL, which should be a parameter named 'shop' on the request querystring.</param>
    /// <param name="shopifyApiKey">Your application's public API key.</param>
    /// <param name="shopifySecretKey">Your application's secret key.</param>
    /// <returns>The shop access token.</returns>
    public static async Task<string> Authorize(string code, string myShopifyUrl, string shopifyApiKey, string shopifySecretKey)
    {
        return (await AuthorizeWithResult(code, myShopifyUrl, shopifyApiKey, shopifySecretKey)).AccessToken;
    }

    /// <summary>
    /// Authorizes an application installation, generating an access token for the given shop.
    /// </summary>
    /// <param name="code">The authorization code generated by Shopify, which should be a parameter named 'code' on the request querystring.</param>
    /// <param name="myShopifyUrl">The store's *.myshopify.com URL, which should be a parameter named 'shop' on the request querystring.</param>
    /// <param name="shopifyApiKey">Your application's public API key.</param>
    /// <param name="shopifySecretKey">Your application's secret key.</param>
    /// <returns>The authorization result.</returns>
    internal static async Task<AuthorizationResult> AuthorizeWithResult(string code, string myShopifyUrl, string shopifyApiKey, string shopifySecretKey)
    {
        var ub = new UriBuilder(BuildShopUri(myShopifyUrl, false))
        {
            Path = "admin/oauth/access_token"
        };
        var content = new
        {
            client_id = shopifyApiKey,
            client_secret = shopifySecretKey,
            code,
        };
        var json = JsonSerializer.Serialize(content);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        using var client = new HttpClient();
        var response = await client.PostAsync(ub.Uri, data);
        var result = await response.Content.ReadAsStringAsync();
        var jsonResult = JsonSerializer.Deserialize<Dictionary<string, string>>(result);

        Debug.Assert(jsonResult != null, nameof(jsonResult) + " != null");
        var accessToken = jsonResult["access_token"];
        var scopes = jsonResult["scope"];
        return new AuthorizationResult(accessToken, scopes.Split(','));
    }

    /// <summary>
    /// Attempts to build a shop API <see cref="Uri"/> for the given shop. Will throw a <see cref="ShopifyException"/> if the URL cannot be formatted.
    /// </summary>
    /// <param name="myShopifyUrl">The shop's *.myshopify.com URL.</param>
    /// <param name="withAdminPath"></param>
    /// <exception cref="ShopifyException">Thrown if the given URL cannot be converted into a well-formed URI.</exception>
    /// <returns>The shop's API <see cref="Uri"/>.</returns>
    internal static Uri BuildShopUri(string myShopifyUrl, bool withAdminPath)
    {
        if (Uri.IsWellFormedUriString(myShopifyUrl, UriKind.Absolute) == false)
        {
            //Shopify typically returns the shop URL without a scheme. If the user is storing that as-is, the uri will not be well formed.
            //Try to fix that by adding a scheme and checking again.
            if (Uri.IsWellFormedUriString("https://" + myShopifyUrl, UriKind.Absolute) == false)
            {
                throw new Exception($"The given {nameof(myShopifyUrl)} cannot be converted into a well-formed URI.");
            }

            myShopifyUrl = "https://" + myShopifyUrl;
        }

        var builder = new UriBuilder(myShopifyUrl)
        {
            Scheme = "https:",
            Port = 443, //SSL port
            Path = withAdminPath ? "admin" : ""
        };

        return builder.Uri;
    }
}
