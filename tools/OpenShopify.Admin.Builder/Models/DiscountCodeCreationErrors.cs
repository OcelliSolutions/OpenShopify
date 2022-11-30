using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record DiscountCodeCreationErrors
{
    [JsonPropertyName("code")] 
    public IEnumerable<string>? Code { get; set; }
}