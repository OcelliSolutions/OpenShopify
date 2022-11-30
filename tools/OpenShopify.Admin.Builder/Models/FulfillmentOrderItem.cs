using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record FulfillmentOrderItem
{
    [JsonPropertyName("replacement_fulfillment_order"), Required]
    public FulfillmentOrder ReplacementFulfillmentOrder { get; set; } = null!;
}
