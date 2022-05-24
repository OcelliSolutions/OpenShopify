using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Models;

public partial record ApplicationChargeBase
{
    [JsonPropertyName("api_client_id")]
    public int ApiClientId { get; set; }
    [JsonPropertyName("status")]
    public new ApplicationChargeStatus? Status { get; set; }
    [JsonPropertyName("charge_type")]
    public string? ChargeType { get; set; }
    [JsonPropertyName("decorated_return_url")]
    public string? DecoratedReturnUrl { get; set; }
}