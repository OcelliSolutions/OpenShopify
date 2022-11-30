using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public class SendFulfillmentRequestDetail
{
    [JsonPropertyName("message")] public string? Message { get; set; }
    [JsonPropertyName("fulfillment_order_line_items")]
    public IEnumerable<FulfillmentOrderLineItem>? FulfillmentOrderLineItems { get; set; }

}