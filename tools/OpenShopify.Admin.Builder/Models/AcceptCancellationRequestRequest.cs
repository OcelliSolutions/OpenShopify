using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record AcceptCancellationRequestRequest
{
    [JsonPropertyName("cancellation_request")]
    public MessageDetail MessageDetail { get; set; } = null!;
}