using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record UsageChargeBase
{
    [JsonPropertyName("billing_on")]
    public DateTime? BillingOn { get; set; }

    [JsonPropertyName("balance_used")]
    public decimal? BalanceUsed { get; set; }

    [JsonPropertyName("balance_remaining")]
    public decimal? BalanceRemaining { get; set; }

    [JsonPropertyName("risk_level")]
    public decimal? RiskLevel { get; set; }
}
