using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record MoveLocation
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}