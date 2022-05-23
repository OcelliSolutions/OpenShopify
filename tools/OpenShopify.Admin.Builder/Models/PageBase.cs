using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An entity representing a Shopify product.
    /// </summary>
    public partial record PageBase
    {
        /// <summary>
        /// Additional metadata about the <see cref="PageBase"/>. Note: This is not naturally returned with a <see cref="PageBase"/> response, as
        /// Shopify will not return <see cref="PageBase"/> metafields unless specified. Instead, you need to query metafields with <see cref="MetafieldService"/>. 
        /// Uses include: Creating, updating, and deserializing webhook bodies that include them.
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<Metafield>? Metafields { get; set; }
    }
}
