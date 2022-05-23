using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify transaction.
    /// </summary>
    public partial record Transaction
    {
        /// <inheritdoc cref="TransactionOrig.PaymentDetails"/>
        [JsonPropertyName("payment_details")]
        public new PaymentDetails? PaymentDetails { get; set; }

        /// <summary>
        /// The maximum amount that can be refunded
        /// </summary>
        [JsonPropertyName("maximum_refundable")]
        public decimal? MaximumRefundable { get; set; }

        /// <inheritdoc cref="TransactionOrig.CurrencyExchangeAdjustment"/>
        [JsonPropertyName("currency_exchange_adjustment")]
        public new CurrencyExchangeAdjustment? CurrencyExchangeAdjustment { get; set; }
    }
}
