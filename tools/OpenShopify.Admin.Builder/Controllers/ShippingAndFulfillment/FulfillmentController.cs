//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

#nullable enable

using System.Text.Json;

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"

namespace OpenShopify.Admin.Builder.Models
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]

    public abstract class FulfillmentControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves fulfillments associated with an order
        /// </summary>
        /// <remarks>
        /// Retrieves fulfillments associated with an order. **Note:** As of version 2019-10, this endpoint implements pagination by using links that are provided in the response header. Sending the `page` parameter will return an error. To learn more, see [*Make paginated requests to the REST Admin API*](/api/usage/pagination-rest).
        /// </remarks>
        /// <param name="created_at_max">Show fulfillments created before date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="created_at_min">Show fulfillments created after date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="fields">A comma-separated list of fields to include in the response.</param>
        /// <param name="limit">Limit the amount of results.</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        /// <param name="since_id">Restrict results to after the specified ID.</param>
        /// <param name="updated_at_max">Show fulfillments last updated before date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="updated_at_min">Show fulfillments last updated after date (format: 2014-04-25T16:15:47-04:00).</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments.json")]
        public abstract System.Threading.Tasks.Task GetFulfillmentsAssociatedWithOrder(long order_id, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? created_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? created_at_min = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit = null, string? page_info = null, [Microsoft.AspNetCore.Mvc.FromQuery] long? since_id = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_min = null);

        /// <summary>
        /// Retrieves fulfillments associated with a fulfillment order
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("fulfillment_orders/{fulfillment_order_id}/fulfillments.json")]
        public abstract System.Threading.Tasks.Task GetFulfillmentsAssociatedWithFulfillmentOrder(long fulfillment_order_idPath);

        /// <summary>
        /// Retrieves a count of fulfillments associated with a specific order
        /// </summary>
        /// <param name="created_at_max">Count fulfillments created before date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="created_at_min">Count fulfillments created after date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="updated_at_max">Count fulfillments last updated before date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="updated_at_min">Count fulfillments last updated after date (format: 2014-04-25T16:15:47-04:00).</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments/count.json")]
        public abstract System.Threading.Tasks.Task CountFulfillmentsAssociatedWithSpecificOrder(long? order_id = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? created_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? created_at_min = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_min = null);

        /// <summary>
        /// Receive a single Fulfillment
        /// </summary>
        /// <remarks>
        /// Retrieve a specific fulfillment
        /// </remarks>
        /// <param name="fields">Comma-separated list of fields to include in the response.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/fulfillments/{fulfillment_id}.json")]
        public abstract System.Threading.Tasks.Task GetFulfillment(long fulfillment_id, long order_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

        /// <summary>
        /// Creates a fulfillment for one or many fulfillment orders
        /// </summary>
        /// <remarks>
        /// Creates a fulfillment for one or many fulfillment orders. The fulfillment orders are associated with the same order and are assigned to the same location.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillments.json")]
        public abstract System.Threading.Tasks.Task CreateFulfillmentForOneOrManyFulfillmentOrders([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateFulfillmentForOneOrManyFulfillmentOrdersRequest request);

        /// <summary>
        /// Updates the tracking information for a fulfillment
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillments/{fulfillment_id}/update_tracking.json")]
        public abstract System.Threading.Tasks.Task UpdateTrackingInformationForFulfillment([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateTrackingInformationForFulfillmentRequest request, long fulfillment_id);

        /// <summary>
        /// Cancels a fulfillment
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("fulfillments/{fulfillment_id}/cancel.json")]
        public abstract System.Threading.Tasks.Task CancelFulfillment([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CancelFulfillmentRequest request, long fulfillment_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record FulfillmentOrig
    {
        /// <summary>
        /// A list of the fulfillment's line items, which includes:
        /// 
        /// *   **id**: The ID of the line item within the fulfillment. 
        /// *   **variant_id**: The ID of the product variant being fulfilled. 
        /// *   **title**: The title of the product. 
        /// *   **quantity**: The number of items in the fulfillment. 
        /// *   **price**: The price of the item. 
        /// *   **grams**: The weight of the item in grams. 
        /// *   **sku**: The unique identifier of the item in the fulfillment. 
        /// *   **variant_title**: The title of the product variant being fulfilled. 
        /// *   **vendor**: The name of the supplier of the item. 
        /// *   **fulfillment_service**: The service provider who is doing the fulfillment. This field will be deprecated. Use the `assigned_location` property on the `FulfillmentOrder` resource instead. 
        /// *   **product_id**: The unique numeric identifier for the product in the fulfillment. 
        /// *   **requires_shipping**: Whether a customer needs to provide a shipping address when placing an order for this product variant. 
        /// *   **taxable**: Whether the line item is taxable. 
        /// *   **gift_card**: Whether the line item is a [gift card](https://help.shopify.com/manual/products/gift-card-products). 
        /// *   **name**: The name of the product variant. 
        /// *   **variant_inventory_management**: The name of the inventory management system. 
        /// *   **properties**: Any additional properties associated with the line item. 
        /// *   **product_exists**: Whether the product exists. 
        /// *   **fulfillable_quantity**: The amount available to fulfill. This is the quantity - max (refunded_quantity, fulfilled_quantity) - pending_fulfilled_quantity - open_fulfilled_quantity. This field will be deprecated. Use the `fulfillable_quantity` property of the `line_item` property on the `FulfillmentOrder` resource instead. 
        /// *   **total_discount**: The total of any discounts applied to the line item. 
        /// *   **fulfillment_status**: The status of an order in terms of the line items being fulfilled. Valid values: `fulfilled`, `null`, or `partial`. This field will be deprecated. Use the `status` property on the `FulfillmentOrder` resource instead. 
        /// *   **fulfillment_line_item_id**: A unique identifier for a quantity of items within a single fulfillment. An order can have multiple fulfillment line items. 
        /// *   **tax_lines**: The `title`, `price`, and `rate` of any taxes applied to the line item. 
        /// *   **duties**: A list of duty objects, each containing information about a duty on the line item.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("line_items")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? LineItems { get; set; } = default!;

        /// <summary>
        /// The unique identifier of the location that the fulfillment was processed at. To find the ID of the location, use the [Location resource](/docs/admin-api/rest/reference/inventory/location).
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("location_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public long? LocationId { get; set; } = default!;

        /// <summary>
        /// The uniquely identifying fulfillment name, consisting of two parts separated by a `.`. The first part represents the order name and the second part represents the fulfillment number. The fulfillment number automatically increments depending on how many fulfillments are in an order (e.g. `#1001.1`, `#1001.2`).
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Name { get; set; } = default!;

        /// <summary>
        /// Whether the customer should be notified. If set to `true`, then an email will be sent when the fulfillment is created or updated. For orders that were initially created using the API, the default value is `false`. For all other orders, the default value is `true`.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("notify_customer")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public bool? NotifyCustomer { get; set; } = default!;

        /// <summary>
        /// The unique numeric identifier for the order.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("order_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public long? OrderId { get; set; } = default!;

        /// <summary>
        /// The address from which the fulfillment occurred:
        /// 
        /// *   **address1**: The street address of the fulfillment location. 
        /// *   **address2**: The second line of the address. Typically the number of the apartment, suite, or unit. 
        /// *   **city**: The city of the fulfillment location. 
        /// *   **country_code**: The country of the fulfillment location. 
        /// *   **province_code**: The province of the fulfillment location. 
        /// *   **zip**: The zip code of the fulfillment location.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("origin_address")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? OriginAddress { get; set; } = default!;

        /// <summary>
        /// A text field that provides information about the receipt:
        /// 
        /// *   **testcase**: Whether the fulfillment was a testcase. 
        /// *   **authorization**: The authorization code.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("receipt")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Receipt { get; set; } = default!;

        /// <summary>
        /// The fulfillment service associated with the fulfillment.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("service")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Service { get; set; } = default!;

        /// <summary>
        /// The current shipment status of the fulfillment. Valid values:
        /// 
        /// *   **label_printed**: A label for the shipment was purchased and printed. 
        /// *   **label_purchased**: A label for the shipment was purchased, but not printed. 
        /// *   **attempted_delivery**: Delivery of the shipment was attempted, but unable to be completed. 
        /// *   **ready_for_pickup**: The shipment is ready for pickup at a shipping depot. 
        /// *   **confirmed**: The carrier is aware of the shipment, but hasn't received it yet. 
        /// *   **in_transit**: The shipment is being transported between shipping facilities on the way to its destination. 
        /// *   **out_for_delivery**: The shipment is being delivered to its final destination. 
        /// *   **delivered**: The shipment was succesfully delivered. 
        /// *   **failure**: Something went wrong when pulling tracking information for the shipment, such as the tracking number was invalid or the shipment was canceled.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("shipment_status")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? ShipmentStatus { get; set; } = default!;

        /// <summary>
        /// The status of the fulfillment. Valid values:
        /// 
        /// *   **pending**: Shopify has created the fulfillment and is waiting for the third-party fulfillment service to transition it to 'open' or 'success'. 
        /// *   **open**: The fulfillment has been acknowledged by the service and is in processing. 
        /// *   **success**: The fulfillment was successful. 
        /// *   **cancelled**: The fulfillment was cancelled. 
        /// *   **error**: There was an error with the fulfillment request. 
        /// *   **failure**: The fulfillment request failed.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("status")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Status { get; set; } = default!;

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
        /// *   **China**: Anjun Logistics, China Post, DHL eCommerce Asia, FSC, SFC Fulfillment, WanbExpress, YunExpress 
        /// 
        ///  &lt;div class="note"&gt; 
        /// 
        /// #### Important
        /// 
        /// When creating a fulfillment for a supported carrier, send the `tracking_company` exactly as written in the list above. If the tracking company doesn't match one of the supported entries, then the shipping status might not be updated properly during the fulfillment process.
        ///  &lt;/div&gt;
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tracking_company")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
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

        [System.Text.Json.Serialization.JsonPropertyName("tracking_numbers")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public System.Collections.Generic.List<string>? TrackingNumbers { get; set; } = default!;

        /// <summary>
        /// The URLs of tracking pages for the fulfillment.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tracking_urls")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public System.Collections.Generic.List<string>? TrackingUrls { get; set; } = default!;

        /// <summary>
        /// The name of the inventory management service.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("variant_inventory_management")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? VariantInventoryManagement { get; set; } = default!;

        private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603