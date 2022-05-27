using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record CancellationRequest
{
    /// <summary>
    /// An optional reason for rejecting the cancellation request.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}