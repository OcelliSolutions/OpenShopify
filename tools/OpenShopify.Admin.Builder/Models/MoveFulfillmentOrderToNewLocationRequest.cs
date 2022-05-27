using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record MoveFulfillmentOrderToNewLocationRequest
{
    [Required, JsonPropertyName("fulfillment_order")]
    public MoveFulfillmentOrderToNewLocationRequestDetail FulfillmentOrder { get; set; } = null!;
}

public record MoveFulfillmentOrderToNewLocationRequestDetail
{
    [JsonPropertyName("new_location_id")] public long NewLocationId { get; set; }
}
