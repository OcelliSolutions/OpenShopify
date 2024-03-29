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

        
        [JsonPropertyName("total_duties_set")]
        public PriceSet? TotalDutiesSet { get; set; }
    }
}
