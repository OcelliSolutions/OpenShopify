using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record AcceptFulfillmentRequestRequest
{
    [JsonPropertyName("fulfillment_request"), Required]
    public MessageDetail FulfillmentRequest { get; set; } = null!;
}
