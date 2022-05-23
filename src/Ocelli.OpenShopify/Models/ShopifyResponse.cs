using System.Text.RegularExpressions;

namespace Ocelli.OpenShopify;
public partial record ShopifyResponse
{
    public int StatusCode { get; private set; }

    public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; }

    public ShopifyResponse(int statusCode, IReadOnlyDictionary<string, IEnumerable<string>> headers)
    {
        StatusCode = statusCode;
        Headers = headers;
    }
}

public partial record ShopifyResponse<TResult> : ShopifyResponse
{
    private static readonly Regex _regexPrevLink = new(@"<(https://[^>]*)>\s*;\s*rel=""previous""", RegexOptions.Compiled | RegexOptions.CultureInvariant);
    private static readonly Regex _regexNextLink = new(@"<(https://[^>]*)>\s*;\s*rel=""next""", RegexOptions.Compiled | RegexOptions.CultureInvariant);
    private readonly IReadOnlyDictionary<string, IEnumerable<string>> _headers;
    public TResult Result { get; }
    public RateLimit RateLimit { get; }
    public Pagination Pagination { get; }
    public string? ShopId { get; }
    public string? ShardId { get; }
    public string? UserId { get; }
    public string? ApiClientId { get; }
    public string? ApiPermissionId { get; }
    public string? ApiVersion { get; }
    public string? Stage { get; }

    public ShopifyResponse(int statusCode, IReadOnlyDictionary<string, IEnumerable<string>> headers, TResult result)
        : base(statusCode, headers)
    {
        Result = result;
        _headers = headers;
        RateLimit = new RateLimit(0, 0);
        var rateLimit = GetHeaderValue("Link");
        if (!string.IsNullOrWhiteSpace(rateLimit))
        {
            var rateSplit = rateLimit.Split('/');
            _ = int.TryParse(rateSplit[0], out var used);
            _ = int.TryParse(rateSplit[1], out var remaining);
            RateLimit = new RateLimit(used, remaining);
        }

        Pagination = new Pagination();
        var link = GetHeaderValue("Link");
        if (!string.IsNullOrWhiteSpace(link))
        {
            var prevLink = GetPageInfoParam(link, _regexPrevLink);
            var nextLink = GetPageInfoParam(link, _regexNextLink);
            var prevPageInfo = GetQueryParam(prevLink, "page_info");
            var nextPageInfo = GetQueryParam(nextLink, "page_info");
            var fields = GetQueryParam(nextLink, "fields");
            _ = int.TryParse(GetQueryParam(nextLink, "limit"), out var limit);
            Pagination = new Pagination(prevPageInfo, nextPageInfo, limit, fields);
        }

        ShopId = GetHeaderValue("X-ShopId");
        ShardId = GetHeaderValue("X-ShardId");
        UserId = GetHeaderValue("X-Stats-UserId");
        ApiClientId = GetHeaderValue("X-Stats-ApiClientId");
        ApiPermissionId = GetHeaderValue("X-Stats-ApiPermissionId");
        ApiVersion = GetHeaderValue("X-Shopify-API-Version");
        Stage = GetHeaderValue("X-Shopify-Stage");
    }

    private string? GetHeaderValue(string key) =>
        _headers.Keys.Contains(key) ? _headers[key].FirstOrDefault() : null;

    private static string? GetPageInfoParam(string? linkHeaderValue, Regex linkRegex)
    {
        if (linkHeaderValue == null) return null;
        var match = linkRegex.Match(linkHeaderValue);

        if (!match.Success || match.Groups.Count < 2 || !match.Groups[1].Success)
        {
            return null;
        }

        var matchedUrl = match.Groups[1].Value;

        Uri.TryCreate(matchedUrl, UriKind.Absolute, out var uri);

        return uri?.Query == null ? null : Uri.UnescapeDataString(uri.Query);
    }
    private string? GetQueryParam(string? decodedUriQuery, string name) =>
        decodedUriQuery?.Split('?', '&')
            .FirstOrDefault(p => p.StartsWith($"{name}="))
            ?.Substring($"{name}=".Length);
}

public record RateLimit(int Used, int Remaining);

public partial record Pagination
{
    public Pagination()
    {
        PreviousPageInfo = null;
        NextPageInfo = null;
        Limit = null;
        Fields = null;
    }
    public Pagination(string? previousPageInfo, string? nextPageInfo, int? limit, string? fields)
    {
        PreviousPageInfo = previousPageInfo;
        NextPageInfo = nextPageInfo;
        Limit = limit;
        Fields = fields;
    }
    /// <summary>
    /// Pass this value back into the `page_info` parameter to get the previous page of data.
    /// </summary>
    public string? PreviousPageInfo { get; }
    /// <summary>
    /// Pass this value back into the `page_info` parameter to get the next page of data.
    /// </summary>
    public string? NextPageInfo { get; }

    public int? Limit { get; }
    public string? Fields { get; }
    public bool HasPreviousPage => !string.IsNullOrWhiteSpace(PreviousPageInfo);
    public bool HasNextPage => !string.IsNullOrWhiteSpace(NextPageInfo);
}