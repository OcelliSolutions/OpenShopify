using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public class SetDeadlineForFulfillmentOrdersRequest
{
    [JsonPropertyName("fulfillment_order_ids")]
    public ICollection<long> FulfillmentOrderIds { get; set; } = null!;

    [JsonPropertyName("fulfillment_deadline")]
    public DateTimeOffset FulfillmentDeadline { get; set; }
}
