using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record AssetBase
{
    [JsonPropertyName("warnings")]
    public IEnumerable<string>? Warnings { get; set; }
}
