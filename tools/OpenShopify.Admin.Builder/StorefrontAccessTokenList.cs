using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder;

public class StorefrontAccessTokenList
{
    [JsonPropertyName("storefront_access_tokens")]
    public StorefrontAccessToken[]? StorefrontAccessTokens { get; set; }
}
