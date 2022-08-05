using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public partial record RecurringApplicationChargeBase
{
    [JsonPropertyName("api_client_id")]
    public long ApiClientId { get; set; }
    [JsonPropertyName("decorated_return_url")]
    public string? DecoratedReturnUrl { get; set; }

    [JsonPropertyName("status")] 
    public new RecurringApplicationChargeStatus Status { get; set; }

    [JsonPropertyName("balance_used")] 
    public decimal? BalanceUsed { get; set; }

    [JsonPropertyName("balance_remaining")]
    public decimal? BalanceRemaining { get; set; }

    [JsonPropertyName("risk_level")]
    public decimal? RiskLevel { get; set; }
}

