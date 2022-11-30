using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record SendFulfillmentRequestItem
{
    [JsonPropertyName("original_fulfillment_order")]
    public FulfillmentOrderWithOrigin OriginalFulfillmentOrder { get; set; } = null!;

    [JsonPropertyName("submitted_fulfillment_order")]
    public FulfillmentOrderWithOrigin SubmittedFulfillmentOrder { get; set; } = null!;

    [JsonPropertyName("unsubmitted_fulfillment_order")]
    public FulfillmentOrderWithOrigin? UnsubmittedFulfillmentOrder { get; set; }
}