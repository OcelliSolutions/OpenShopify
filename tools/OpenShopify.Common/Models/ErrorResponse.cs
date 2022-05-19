using System.Text.Json.Serialization;

namespace OpenShopify.Common.Models;

public class ErrorResponse
{
    [JsonPropertyName("errors")]
    public string? Message { get; set; }
}