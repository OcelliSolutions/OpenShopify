using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record Balance
{
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = null!;

    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
}
