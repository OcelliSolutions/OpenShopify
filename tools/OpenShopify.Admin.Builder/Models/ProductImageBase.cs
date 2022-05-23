using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a product image.
    /// </summary>
    public partial record ProductImageBase
    {
        /// <summary>
        /// Additional metadata about the <see cref="ProductImageBase"/>. Note: This is not naturally returned with a <see cref="ProductImageBase"/> response, as
        /// Shopify will not return <see cref="ProductImageBase"/> metafields unless specified. Instead, you need to query metafields with <see cref="MetafieldService"/>. 
        /// Uses include: Creating, updating, and deserializing webhook bodies that include them.
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<Metafield>? Metafields { get; set; }
    }
}
