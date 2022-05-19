using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An entity representing a Shopify redirect.
    /// </summary>
    public class RedirectBase
    {
        /// <summary>
        /// The "before" path to be redirected. When the user navigates to this path, they will be redirected to the path specified by target.
        /// </summary>
        [JsonPropertyName("path")]
        public string? Path { get; set; }

        /// <summary>
        /// The "after" path or URL to be redirected to. This property can be set to any path on the shop's site, or any URL, even one on a 
        /// completely different domain.
        /// </summary>
        [JsonPropertyName("target")]
        public string? Target { get; set; }
    }
}
