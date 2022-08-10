using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record OrderBase
    {
        #region Property Override

        /// <inheritdoc cref="OrderOrig.CancelReason"/>
        [JsonPropertyName("cancel_reason")]
        public new CancelReason? CancelReason { get; set; }

        /// <inheritdoc cref="OrderOrig.FulfillmentStatus"/>
        [JsonPropertyName("fulfillment_status")]
        public new OrderFulfillmentStatus? FulfillmentStatus { get; set; }

        /// <inheritdoc cref="OrderOrig.FinancialStatus"/>
        [JsonPropertyName("financial_status")]
        public new FinancialStatus? FinancialStatus { get; set; }

        /// <inheritdoc cref="OrderOrig.ProcessingMethod"/>
        [JsonPropertyName("processing_method")]
        public new ProcessingMethod? ProcessingMethod { get; set; }

        /// <inheritdoc cref="OrderOrig.BillingAddress"/>
        [JsonPropertyName("billing_address")]
        public new Address? BillingAddress { get; set; }

        /// <inheritdoc cref="OrderOrig.ClientDetails"/>
        [JsonPropertyName("client_details")]
        public new ClientDetails? ClientDetails { get; set; }

        /// <inheritdoc cref="OrderOrig.Customer"/>
        [JsonPropertyName("customer")]
        public new Customer? Customer { get; set; }

        /// <inheritdoc cref="OrderOrig.DiscountCodes"/>
        [JsonPropertyName("discount_codes")]
        public new IEnumerable<DiscountCode>? DiscountCodes { get; set; }

        /// <inheritdoc cref="OrderOrig.DiscountApplications"/>
        [JsonPropertyName("discount_applications")]
        public new IEnumerable<DiscountApplication>? DiscountApplications { get; set; }

        /// <inheritdoc cref="OrderOrig.Fulfillments"/>
        [JsonPropertyName("fulfillments")]
        public new IEnumerable<Fulfillment>? Fulfillments { get; set; }

        /// <inheritdoc cref="OrderOrig.LineItems"/>
        [JsonPropertyName("line_items")]
        public new IEnumerable<LineItem>? LineItems { get; set; }

        /// <inheritdoc cref="OrderOrig.NoteAttributes"/>
        [JsonPropertyName("note_attributes")]
        public new IEnumerable<NoteAttribute>? NoteAttributes { get; set; }

        /// <inheritdoc cref="OrderOrig.Refunds"/>
        [JsonPropertyName("refunds")]
        public new IEnumerable<Refund>? Refunds { get; set; }

        /// <inheritdoc cref="OrderOrig.ShippingAddress"/>
        [JsonPropertyName("shipping_address")]
        public new Address? ShippingAddress { get; set; }

        /// <inheritdoc cref="OrderOrig.ShippingLines"/>
        [JsonPropertyName("shipping_lines")]
        public new IEnumerable<ShippingLine>? ShippingLines { get; set; }

        /// <inheritdoc cref="OrderOrig.TaxLines"/>
        [JsonPropertyName("tax_lines")]
        public new IEnumerable<TaxLine>? TaxLines { get; set; }

        /// <inheritdoc cref="OrderOrig.CurrentTotalDiscountsSet"/>
        [JsonPropertyName("current_total_discounts_set")]
        public new PriceSet? CurrentTotalDiscountsSet { get; set; }

        /// <inheritdoc cref="OrderOrig.CurrentSubtotalPriceSet"/>
        [JsonPropertyName("current_subtotal_price_set")]
        public new PriceSet? CurrentSubtotalPriceSet { get; set; }

        /// <inheritdoc cref="OrderOrig.CurrentTotalPriceSet"/>
        [JsonPropertyName("current_total_price_set")]
        public new PriceSet? CurrentTotalPriceSet { get; set; }

        /// <inheritdoc cref="OrderOrig.CurrentTotalDutiesSet"/>
        [JsonPropertyName("current_total_duties_set")]
        public new PriceSet? CurrentTotalDutiesSet { get; set; }

        /// <inheritdoc cref="OrderOrig.OriginalTotalDutiesSet"/>
        [JsonPropertyName("original_total_duties_set")]
        public new PriceSet? OriginalTotalDutiesSet { get; set; }

        /// <inheritdoc cref="OrderOrig.TotalLineItemsPriceSet"/>
        [JsonPropertyName("total_line_items_price_set")]
        public new PriceSet? TotalLineItemsPriceSet { get; set; }

        /// <inheritdoc cref="OrderOrig.TotalDiscountsSet"/>
        [JsonPropertyName("total_discounts_set")]
        public new PriceSet? TotalDiscountsSet { get; set; }

        /// <inheritdoc cref="OrderOrig.TotalShippingPriceSet"/>
        [JsonPropertyName("total_shipping_price_set")]
        public new PriceSet? TotalShippingPriceSet { get; set; }

        /// <inheritdoc cref="OrderOrig.SubtotalPriceSet"/>
        [JsonPropertyName("subtotal_price_set")]
        public new PriceSet? SubtotalPriceSet { get; set; }

        /// <inheritdoc cref="OrderOrig.TotalPriceSet"/>
        [JsonPropertyName("total_price_set")]
        public new PriceSet? TotalPriceSet { get; set; }

        /// <inheritdoc cref="OrderOrig.TotalTaxSet"/>
        [JsonPropertyName("total_tax_set")]
        public new PriceSet? TotalTaxSet { get; set; }

        /// <inheritdoc cref="OrderOrig.CurrentTotalTaxSet"/>
        [JsonPropertyName("current_total_tax_set")]
        public new PriceSet? CurrentTotalTaxSet { get; set; }

        #endregion Property Override

        #region Undocumented properties

        /// <summary>
        /// An array of <see cref="Transaction"/> objects that detail all of the transactions in
        /// this order.
        /// </summary>
        [JsonPropertyName("transactions")]
        public IEnumerable<Transaction>? Transactions { get; set; }

        /// <summary>
        /// Additional metadata about the <see cref="OrderBase"/>. Note: This is not naturally returned with a <see cref="OrderBase"/> response, as
        /// Shopify will not return <see cref="OrderBase"/> metafields unless specified. Instead, you need to query metafields with <see cref="MetafieldService"/>. 
        /// Uses include: Creating, updating, and deserializing webhook bodies that include them.
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<Metafield>? Metafields { get; set; }

        [JsonPropertyName("checkout_id")] 
        public long? CheckoutId { get; set; }

        [JsonPropertyName("confirmed")]
        public bool? Confirmed { get; set; }

        [JsonPropertyName("contact_email")]
        public string? ContactEmail { get; set; }

        [JsonPropertyName("total_price_usd")]
        public decimal? TotalPriceUsd { get; set; }

        #endregion Undocumented Properties
    }
}
