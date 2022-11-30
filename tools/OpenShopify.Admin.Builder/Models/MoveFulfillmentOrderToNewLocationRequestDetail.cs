using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record MoveFulfillmentOrderToNewLocationRequestDetail
{
    [JsonPropertyName("new_location_id")] public long NewLocationId { get; set; }
}