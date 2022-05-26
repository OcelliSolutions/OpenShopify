using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public partial record OrderRiskBase
{
    /// <inheritdoc cref="OrderRiskOrig.Recommendation"/>
    [JsonPropertyName("recommendation")]
    public new RiskRecommendation? Recommendation { get; set; }
}
