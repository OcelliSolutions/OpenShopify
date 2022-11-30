using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record FulfillmentOrderWithOrigin : FulfillmentOrder
{
    [JsonPropertyName("origin")]
    public new AssignedLocation? AssignedLocation { get; set; }
}