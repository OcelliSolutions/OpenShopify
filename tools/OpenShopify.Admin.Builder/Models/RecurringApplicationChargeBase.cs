using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record RecurringApplicationChargeBase
{
    [JsonPropertyName("api_client_id")]
    public long ApiClientId { get; set; }
    [JsonPropertyName("decorated_return_url")]
    public string? DecoratedReturnUrl { get; set; }
}

