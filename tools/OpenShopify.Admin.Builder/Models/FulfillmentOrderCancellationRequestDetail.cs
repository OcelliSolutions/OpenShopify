using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record FulfillmentOrderCancellationRequestDetail
{
    /// <summary>
    /// An optional reason for marking the fulfillment order as incomplete.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}