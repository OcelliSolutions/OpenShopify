using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record RescheduleFulfillAtTimeOfScheduledFulfillmentOrderRequest
{
    [JsonPropertyName("fulfillment_order"), Required]
    public RescheduleFulfillAtTimeOfScheduledFulfillmentOrderDetailRequest FulfillmentOrder { get; set; } = null!;
}