using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record AuthorList
{
    [JsonPropertyName("authors")] public IEnumerable<string>? Authors { get; set; }
}
