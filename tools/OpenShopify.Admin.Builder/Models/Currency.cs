using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record Currency
{
    /// <summary>
    /// This property is undocumented by Shopify.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }
}
