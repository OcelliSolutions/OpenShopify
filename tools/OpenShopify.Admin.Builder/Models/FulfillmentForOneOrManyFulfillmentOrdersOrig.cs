using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record FulfillmentForOneOrManyFulfillmentOrdersOrig
{
    [JsonPropertyName("message")]
    public string? Message { get; set; } = default!;

    [JsonPropertyName("line_items_by_fulfillment_order")]
    public ICollection<LineItemsByFulfillmentOrder> LineItemsByFulfillmentOrder { get; set; } = default!;

    /// <inheritdoc cref="FulfillmentOrig.NotifyCustomer"/>

    [JsonPropertyName("notify_customer")]
    public bool? NotifyCustomer { get; set; } = default!;

    /// <summary>
    /// A list of tracking numbers, provided by the shipping company. &lt;div class="note"&gt; 
    /// 
    /// #### Important
    /// 
    /// It is highly recommended that you send the tracking company and the tracking URL as well. If neither one of these is sent, then the tracking company will be determined automatically. This can result in an invalid tracking URL.
    /// 
    /// The tracking URL is displayed in the shipping confirmation email, which can optionally be sent to the customer. When accounts are enabled, it is also displayed in the customer's order history.
    ///  &lt;/div&gt;
    /// </summary>

    [JsonPropertyName("tracking_info")]
    public TrackingInfo? TrackingInfo { get; set; } = default!;
}
