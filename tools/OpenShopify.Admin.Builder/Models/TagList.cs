using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record TagList
{
    [JsonPropertyName("Tags")] public IEnumerable<string>? Tags { get; set; }
}