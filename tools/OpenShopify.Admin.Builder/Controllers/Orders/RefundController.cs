//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
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

namespace OpenShopify.Admin.Builder
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]

    public abstract class RefundControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of refunds for an order
        /// </summary>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <param name="in_shop_currency">Show amounts in the shop currency for the underlying transaction.</param>
        /// <param name="limit">The maximum number of results to retrieve.</param>
        /// <returns>Retrieves a list of refunds for an order</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/orders/{order_id}/refunds.json")]
        public abstract System.Threading.Tasks.Task RetrieveListOfRefundsForOrder(string order_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? in_shop_currency = "false", [Microsoft.AspNetCore.Mvc.FromQuery] string? limit = "50");

        /// <summary>
        /// Creates a refund
        /// </summary>
        /// <param name="currency">&lt;p&gt;The three-letter code (&lt;a href="https://en.wikipedia.org/wiki/ISO_4217" target="_blank"&gt;ISO 4217&lt;/a&gt; format) for the currency used for the refund.&lt;/p&gt;</param>
        /// <param name="discrepancy_reason">An optional comment that explains a discrepancy between calculated and actual refund amounts. Used to populate the &lt;code&gt;reason&lt;/code&gt; property of the resulting &lt;code&gt;order_adjustment&lt;/code&gt; object attached to the refund. Valid values: &lt;code&gt;restock&lt;/code&gt;, &lt;code&gt;damage&lt;/code&gt;, &lt;code&gt;customer&lt;/code&gt;, and &lt;code&gt;other&lt;/code&gt;.</param>
        /// <param name="note">An optional note attached to a refund.</param>
        /// <param name="notify">Whether to send a refund notification to the customer.</param>
        /// <param name="refund_line_items">A list of line item IDs, quantities to refund, and restock instructions. Each entry has the following properties:</param>
        /// <param name="restock">Whether to add the line items back to the store inventory. Use &lt;code&gt;restock_type&lt;/code&gt; for refund line items instead.</param>
        /// <param name="shipping">Specify how much shipping to refund. It has the following properties:</param>
        /// <param name="transactions">A list of &lt;a href="/api/admin-rest/current/resources/transaction"&gt;transactions&lt;/a&gt;
        /// <br/>          to process as refunds. Use the &lt;code&gt;calculate&lt;/code&gt; endpoint to obtain these transactions.</param>
        /// <returns>Creates a refund</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/orders/{order_id}/refunds.json")]
        public abstract System.Threading.Tasks.Task CreateRefund(string order_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? currency = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? discrepancy_reason = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? note = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? notify = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? refund_line_items = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? restock = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? shipping = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? transactions = null);

        /// <summary>
        /// Retrieves a specific refund
        /// </summary>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <param name="in_shop_currency">Show amounts in the shop currency for the underlying transaction.</param>
        /// <returns>Retrieves a specific refund</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/orders/{order_id}/refunds/{refund_id}.json")]
        public abstract System.Threading.Tasks.Task RetrieveSpecificRefund(string order_id, string refund_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? in_shop_currency = "false");

        /// <summary>
        /// Calculates a refund
        /// </summary>
        /// <param name="currency">&lt;p&gt;The three-letter code (&lt;a href="https://en.wikipedia.org/wiki/ISO_4217" target="_blank"&gt;ISO 4217&lt;/a&gt; format) for the
        /// <br/>          currency used for the refund. &lt;strong&gt;Note:&lt;/strong&gt; Required whenever the shipping &lt;code&gt;amount&lt;/code&gt; property is provided.&lt;/p&gt;</param>
        /// <param name="refund_line_items">A list of line item IDs, quantities to refund, and restock instructions. Each entry has the following properties:</param>
        /// <param name="shipping">Specify how much shipping to refund. It has the following properties:</param>
        /// <returns>Calculates a refund</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/orders/{order_id}/refunds/calculate.json")]
        public abstract System.Threading.Tasks.Task CalculateRefund(string order_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? currency = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? refund_line_items = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? shipping = null);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Refund
    {
        /// <summary>
        /// The date and time (ISO 8601  format) when the refund was created.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("created_at")]
        public string? Created_at { get; set; } = default!;

        /// <summary>
        /// A list of duties that have been reimbursed as part of the refund.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("duties")]
        public string? Duties { get; set; } = default!;

        /// <summary>
        /// The unique identifier for the refund.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string? Id { get; set; } = default!;

        /// <summary>
        /// An optional note attached to a refund.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("note")]
        public string? Note { get; set; } = default!;

        /// <summary>
        /// A list of order adjustments attached to the refund. Order adjustments are generated to account for refunded shipping costs and differences between calculated and actual refund amounts. Each entry has the following properties:
        /// <br/> 
        /// <br/> id: The unique identifier for the order adjustment.
        /// <br/> order_id: The unique identifier for the order that the order adjustment is associated with.
        /// <br/> refund_id: The unique identifier for the refund that the order adjustment is associated with.
        /// <br/> amount: The value of the discrepancy between the calculated refund and the actual refund. If the kind property's value is shipping_refund, then amount returns the value of shipping charges refunded to the customer.
        /// <br/> tax_amount: The taxes that are added to amount, such as applicable shipping taxes added to a shipping refund.
        /// <br/> kind: The order adjustment type. Valid values: shipping_refund and refund_discrepancy.
        /// <br/> reason: The reason for the order adjustment. To set this value, include discrepancy_reason when you create a refund.
        /// <br/> amount_set: The amount of the order adjustment in shop and presentment currencies.
        /// <br/> tax_amount_set: The tax amount of the order adjustment in shop and presentment currencies.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("order_adjustments")]
        public string? Order_adjustments { get; set; } = default!;

        /// <summary>
        /// The date and time (ISO 8601 format) when the refund was imported. This value can be set to a date in the past when importing from other systems. If no value is provided, then it will be auto-generated as the current time in Shopify. Public apps need to be granted permission by Shopify to import orders with the processed_at timestamp set to a value earlier the created_at timestamp. Private apps can't be granted permission by Shopify.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("processed_at")]
        public string? Processed_at { get; set; } = default!;

        /// <summary>
        /// A list of refunded duties. Each entry has the following properties:
        /// <br/> 
        /// <br/> duty_id: The unique identifier of the duty.
        /// <br/> refund_type: Specifies how you want the duty refunded. Valid values:
        /// <br/> 
        /// <br/> FULL: Refunds all the duties associated with a duty ID. You do not need to include refund line items if you are using the full refund type.
        /// <br/> PROPORTIONAL: Refunds duties in proportion to the line item quantity that you want to refund. If you choose the proportional refund type, then you must also pass the refund line items to calculate the portion of duties to refund.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("refund_duties")]
        public string? Refund_duties { get; set; } = default!;

        /// <summary>
        /// A list of refunded line items. Each entry has the following properties:
        /// <br/> 
        /// <br/> id: The unique identifier of the line item in the refund.
        /// <br/> line_item: A line item being refunded.
        /// <br/> line_item_id: The ID of the related line item in the order.
        /// <br/> quantity: The refunded quantity of the associated line item.
        /// <br/> restock_type: How this refund line item affects inventory levels. Valid values:
        /// <br/> 
        /// <br/> no_restock: Refunding these items won't affect inventory. The number of fulfillable units for this line item will remain unchanged. For example, a refund payment can be issued but no items will be refunded or made available for sale again.
        /// <br/> cancel: The items have not yet been fulfilled. The canceled quantity will be added back to the available count. The number of fulfillable units for this line item will decrease.
        /// <br/> return: The items were already delivered, and will be returned to the merchant. The refunded quantity will be added back to the available count. The number of fulfillable units for this line item will remain unchanged.
        /// <br/> legacy_restock: The deprecated restock property was used for this refund. These items were made available for sale again. This value is not accepted when creating new refunds.
        /// <br/> 
        /// <br/> 
        /// <br/> location_id: The unique identifier of the location where the items will be restocked. Required when restock_type has the value return or cancel.
        /// <br/> subtotal: The subtotal of the refund line item.
        /// <br/> total_tax: The total tax on the refund line item.
        /// <br/> subtotal_set: The subtotal of the refund line item in shop and presentment currencies.
        /// <br/> total_tax_set: The total tax of the line item in shop and presentment currencies.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("refund_line_items")]
        public string? Refund_line_items { get; set; } = default!;

        /// <summary>
        /// Whether to add the line items back to the store's inventory.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("restock")]
        public string? Restock { get; set; } = default!;

        /// <summary>
        /// A list of transactions involved in the refund. A single order can have multiple transactions associated with it. For more information, see the    Transaction resource.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("transactions")]
        public string? Transactions { get; set; } = default!;

        /// <summary>
        /// The unique identifier of the user who performed the refund.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("user_id")]
        public string? User_id { get; set; } = default!;

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
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