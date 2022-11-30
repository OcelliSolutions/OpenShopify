using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record ApplyFulfillmentHoldOnOpenFulfillmentOrderRequest
{
    [Required, JsonPropertyName("fulfillment_hold")]
    public FulfillmentHoldRequestDetail FulfillmentHold { get; set; } = null!;
}