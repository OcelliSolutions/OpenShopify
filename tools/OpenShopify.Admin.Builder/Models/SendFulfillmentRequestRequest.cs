using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record SendFulfillmentRequestRequest
{
    [JsonPropertyName("fulfillment_request"), Required]
    public SendFulfillmentRequestDetail FulfillmentRequest { get; set; } = null!;
}