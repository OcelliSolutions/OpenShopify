

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// Sent via the shop/redacted GDPR webhook, indicating that you should purge the shop's data from your systems.
    /// </summary>
    public class ShopRedactedWebhook
    {
        /// <summary>
        /// The shop's id.
        /// </summary>
        [JsonPropertyName("shop_id")]
        public long ShopId { get; set; }

        /// <summary>
        /// The shop's *.myshopify.com domain.
        /// </summary>
        [JsonPropertyName("shop_domain")]
        public string? ShopDomain { get; set; }
    }
}