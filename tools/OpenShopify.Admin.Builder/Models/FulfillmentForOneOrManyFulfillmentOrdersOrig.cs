using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record FulfillmentForOneOrManyFulfillmentOrdersOrig
{
    [JsonPropertyName("line_items_by_fulfillment_order")]
    public ICollection<LineItemsByFulfillmentOrder> LineItemsByFulfillmentOrder { get; set; } = default!;

    /// <inheritdoc cref="FulfillmentOrig.NotifyCustomer"/>

    [JsonPropertyName("notify_customer")]
    public bool? NotifyCustomer { get; set; } = default!;

    /// <summary>
    /// The unique numeric identifier for the fulfillment order.
    /// </summary>

    [JsonPropertyName("fulfillment_order_id")]
    public long? FulfillmentOrderId { get; set; } = default!;

    /// <summary>
    /// The fulfillment service associated with the fulfillment.
    /// </summary>

    [JsonPropertyName("service")]

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Service { get; set; } = default!;

    /// <summary>
    /// The name of the tracking company. The following tracking companies display for shops located in any country: 
    /// 
    /// *   **4PX** 
    /// *   **Amazon Logistics UK** 
    /// *   **Amazon Logistics US** 
    /// *   **Anjun Logistics** 
    /// *   **APC** 
    /// *   **Australia Post** 
    /// *   **Bluedart** 
    /// *   **Canada Post** 
    /// *   **Canpar** 
    /// *   **China Post** 
    /// *   **Chukou1** 
    /// *   **Correios** 
    /// *   **Couriers Please** 
    /// *   **Delhivery** 
    /// *   **DHL eCommerce** 
    /// *   **DHL eCommerce Asia** 
    /// *   **DHL Express** 
    /// *   **DPD** 
    /// *   **DPD Local** 
    /// *   **DPD UK** 
    /// *   **Eagle** 
    /// *   **FedEx** 
    /// *   **FSC** 
    /// *   **Asendia USA** 
    /// *   **GLS** 
    /// *   **GLS (US)** 
    /// *   **Japan Post** 
    /// *   **La Poste** 
    /// *   **New Zealand Post** 
    /// *   **Newgistics** 
    /// *   **PostNL** 
    /// *   **PostNord** 
    /// *   **Purolator** 
    /// *   **Royal Mail** 
    /// *   **Sagawa** 
    /// *   **Sendle** 
    /// *   **SF Express** 
    /// *   **SFC Fulfilllment** 
    /// *   **Singapore Post** 
    /// *   **StarTrack** 
    /// *   **TNT** 
    /// *   **Toll IPEC** 
    /// *   **UPS** 
    /// *   **USPS** 
    /// *   **Whistl** 
    /// *   **Yamato** 
    /// *   **YunExpress**  
    /// 
    /// The following tracking companies are displayed for shops located in specific countries:
    /// 
    /// *   **Germany**: Deutsche Post (DE), Deutsche Post (EN), DHL 
    /// *   **Ireland**: An Post, Fastway 
    /// *   **Australia**: Aramex Australia, Australia Post, Sendle 
    /// *   **Japan**: エコ配, 西濃運輸, 西濃スーパーエキスプレス, 福山通運, 日本通運, 名鉄運輸, 第一貨物 
    /// *   **China**: Anjun Logistics, China Post, DHL eCommerce Asia, FSC, SFC Fulfillment, WanbExpress, YunExpress  &lt;div class="note"&gt; 
    /// 
    /// #### Important
    /// 
    /// When creating a fulfillment for a supported carrier, send the `tracking_company` exactly as written in the list above. If the tracking company doesn't match one of the supported entries, then the shipping status might not be updated properly during the fulfillment process.
    ///  &lt;/div&gt;
    /// </summary>

    [JsonPropertyName("tracking_company")]
    public string? TrackingCompany { get; set; } = default!;

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

    [JsonPropertyName("tracking_numbers")]
    public List<string>? TrackingNumbers { get; set; } = default!;

    /// <summary>
    /// The URLs of tracking pages for the fulfillment.
    /// </summary>

    [JsonPropertyName("tracking_urls")]

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? TrackingUrls { get; set; } = default!;
}
