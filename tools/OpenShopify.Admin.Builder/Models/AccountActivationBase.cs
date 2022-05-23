using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;
public partial record AccountActivationBase
{
    [JsonPropertyName("account_activation_url")]
    public string AccountActivationUrl { get; set; } = null!;
}
