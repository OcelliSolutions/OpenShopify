using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record AcceptFulfillmentRequestItem
{
    [JsonPropertyName("fulfillment_order")]
    public FulfillmentOrderWithOrigin FulfillmentOrder { get; set; } = null!;
}