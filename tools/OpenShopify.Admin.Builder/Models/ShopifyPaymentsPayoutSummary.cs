
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify payments payout summary.
    /// </summary>
    public class ShopifyPaymentsPayoutSummary
    {
        [JsonPropertyName("adjustments_fee_amount")]
        public decimal? AdjustmentsFeeAmount { get; set; }

        [JsonPropertyName("adjustments_gross_amount")]
        public decimal? AdjustmentsGrossAmount { get; set; }

        [JsonPropertyName("charges_fee_amount")]
        public decimal? ChargesFeeAmount { get; set; }

        [JsonPropertyName("charges_gross_amount")]
        public decimal? ChargesGrossAmount { get; set; }

        [JsonPropertyName("refunds_fee_amount")]
        public decimal? RefundsFeeAmount { get; set; }

        [JsonPropertyName("refunds_gross_amount")]
        public decimal? RefundsGrossAmount { get; set; }

        [JsonPropertyName("reserved_funds_fee_amount")]
        public decimal? ReservedFundsFeeAmount { get; set; }

        [JsonPropertyName("reserved_funds_gross_amount")]
        public decimal? ReservedFundsGrossAmount { get; set; }

        [JsonPropertyName("retried_payouts_fee_amount")]
        public decimal? RetriedPayoutsFeeAmount { get; set; }

        [JsonPropertyName("retried_payouts_gross_amount")]
        public decimal? RetriedPayoutsGrossAmount { get; set; }
    }
}
