using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record EventBase
    {
        /// <summary>
        /// Undocumented by Shopify
        /// </summary>
        [JsonPropertyName("author")]
        public string? Author { get; set; }
    }
}
