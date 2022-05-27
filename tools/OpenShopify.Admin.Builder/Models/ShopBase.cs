using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record ShopBase
{
    [JsonPropertyName("visitor_tracking_consent_preference")]
    public string? VisitorTrackingConsentPreference { get; set; }
}
