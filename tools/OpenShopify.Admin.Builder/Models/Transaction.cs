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

    public record ExtendedAuthorizationAttributes
    {
        /// <summary>
        /// The date and time (ISO 8601 format) when the standard authorization period expires. After expiry, an extended authorization fee is applied upon capturing the payment.
        /// </summary>
        [JsonPropertyName("standard_authorization_expires_at")]
        public DateTimeOffset? StandardAuthorizationExpiresAt { get; set; }

        /// <summary>
        /// The date and time (ISO 8601 format) when the extended authorization period expires. After expiry, the merchant can't capture the payment.
        /// </summary>
        [JsonPropertyName("extended_authorization_expires_at")]
        public DateTimeOffset? ExtendedAuthorizationExpiresAt { get; set; }
    }

    public record PaymentsRefundAttributes
    {

        /// <summary>
        /// The current status of the refund. Valid values: pending, failure, success, and error.
        /// </summary>
        [JsonPropertyName("status")]
        public PaymentsRefundAttributeStatus? Status { get; set; }

        /// <summary>
        /// A unique number associated with the transaction that can be used to track the refund. This property has a value only for transactions completed with Visa or Mastercard.
        /// </summary>
        [JsonPropertyName("acquirer_reference_number")]
        public string? AcquirerReferenceNumber { get; set; }
    }
}
