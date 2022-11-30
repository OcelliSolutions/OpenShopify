using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record TransactionBase
    {
        /// <inheritdoc cref="TransactionOrig.PaymentDetails"/>
        [JsonPropertyName("payment_details")]
        public new PaymentDetails? PaymentDetails { get; set; }

        /// <inheritdoc cref="TransactionOrig.PaymentsRefundAttributes"/>
        [JsonPropertyName("payments_refund_attributes")]
        public new PaymentsRefundAttributes? PaymentsRefundAttributes { get; set; }

        /// <inheritdoc cref="TransactionOrig.ErrorCode"/>
        [JsonPropertyName("error_code")]
        public new TransactionErrorCode? ErrorCode { get; set; }

        /// <inheritdoc cref="TransactionOrig.Kind"/>
        [JsonPropertyName("kind")]
        public new TransactionKind? Kind { get; set; }

        /// <inheritdoc cref="TransactionOrig.ExtendedAuthorizationAttributes"/>
        [JsonPropertyName("extended_authorization_attributes")]
        public new ExtendedAuthorizationAttributes? ExtendedAuthorizationAttributes { get; set; } = default!;

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
