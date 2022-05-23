using System.Text.Json.Serialization;

namespace OpenShopify.Common.Models;

public partial record ErrorResponse
{
    [JsonPropertyName("errors")]
    public string? Message { get; set; }
}