using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public class Report : ShopifyObject
{
    [JsonPropertyName("category")]
    public string? Category { get; set; } = null!;
    [JsonPropertyName("name"), MaxLength(255)]
    public string? Name { get; set; } = null!;
    [JsonPropertyName("shopify_ql")]
    public string? ShopifyQl { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}

