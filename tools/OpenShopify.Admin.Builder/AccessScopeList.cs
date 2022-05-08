using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder;

public class AccessScopeList
{
    [JsonPropertyName("access_scopes")]
    public AccessScope[]? AccessScopes { get; set; }
}
