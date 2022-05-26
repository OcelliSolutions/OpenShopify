using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record RefundBase
    {
        /// <summary>
        /// The unique identifier of the order.
        /// </summary>
        [JsonPropertyName("order_id")]
        public long? OrderId { get; set; }

        ///<summary>
        /// Whether to send a refund notification to the customer
        /// </summary>
        [JsonPropertyName("notify")]
        public bool? Notify { get; set; }

        /// <summary>
        /// Specify how much shipping to refund.
        /// </summary>
        [JsonPropertyName("shipping")]
        public Shipping? Shipping { get; set; }

        /// <summary>
        /// The three-letter code (ISO 4217 format) for the currency used for the refund. Note: Required whenever the shipping amount property is provided.
        /// </summary>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        /// <inheritdoc cref="RefundOrig.OrderAdjustments"/>
        [JsonPropertyName("order_adjustments")]
        public new IEnumerable<RefundOrderAdjustment>? OrderAdjustments { get; set; }

        /// <inheritdoc cref="RefundOrig.RefundLineItems"/>
        [JsonPropertyName("refund_line_items")]
        public new IEnumerable<RefundLineItem>? RefundLineItems { get; set; }

        /// <inheritdoc cref="RefundOrig.Transactions"/>
        [JsonPropertyName("transactions")]
        public new IEnumerable<Transaction>? Transactions { get; set; }

        /// <inheritdoc cref="RefundOrig.Duties"/>
        [JsonPropertyName("duties")]
        public new IEnumerable<RefundDuty>? Duties { get; set; }

        /// <inheritdoc cref="RefundOrig.RefundDuties"/>
        [JsonPropertyName("refund_duties")]
        public new IEnumerable<RefundDutyType>? RefundDuties { get; set; }
    }

    public partial record Shipping
    {
        /// <summary>
        /// Whether to refund all remaining shipping.
        /// </summary>
        [JsonPropertyName("full_refund")]
        public bool? FullRefund { get; set; }

        /// <summary>
        /// Set a specific amount to refund for shipping. Takes precedence over full_refund.
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// The maximum amount that can be refunded
        /// </summary>
        [JsonPropertyName("maximum_refundable")]
        public decimal? MaximumRefundable { get; set; }
    }
}
