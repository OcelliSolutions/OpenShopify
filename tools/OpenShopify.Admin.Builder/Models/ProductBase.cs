using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record ProductBase
    {
        /// <inheritdoc cref="ProductOrig.Variants"/>
        [JsonPropertyName("variants")]
        public new IEnumerable<ProductVariant>? Variants { get; set; }

        /// <inheritdoc cref="ProductOrig.Options"/>
        [JsonPropertyName("options")]
        public new IEnumerable<ProductOption>? Options { get; set; }

        /// <inheritdoc cref="ProductOrig.Images"/>
        [JsonPropertyName("images")]
        public new IEnumerable<ProductImage>? Images { get; set; }

        /// <summary>
        /// A [product image](/docs/admin-api/rest/reference/products/product-image) object, representing an image associated with the product.
        /// </summary>
        [JsonPropertyName("image")]
        public ProductImage? Image { get; set; }

        /// <summary>
        /// Additional metadata about the <see cref="ProductBase"/>. Note: This is not naturally returned with a <see cref="ProductBase"/> response, as
        /// Shopify will not return <see cref="ProductBase"/> metafields unless specified. Instead, you need to query metafields with <see cref="MetafieldService"/>. 
        /// Uses include: Creating, updating, and deserializing webhook bodies that include them.
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<Metafield>? Metafields { get; set; }
    }
}
