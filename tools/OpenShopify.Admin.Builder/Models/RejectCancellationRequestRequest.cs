using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record RejectCancellationRequestRequest
{
    [JsonPropertyName("cancellation_request")]
    public MessageDetail MessageDetail { get; set; } = null!;
}