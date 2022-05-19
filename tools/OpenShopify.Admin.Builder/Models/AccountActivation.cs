using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;
//TODO: create AccountActivation
public class AccountActivation
{
    [JsonPropertyName("account_activation_url")]
    public string AccountActivationUrl { get; set; } = null!;
}
