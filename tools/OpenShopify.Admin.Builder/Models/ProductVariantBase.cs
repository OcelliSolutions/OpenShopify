using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record ProductVariantBase
    {

        /// <summary>
        /// Additional metadata about the <see cref="ProductVariantBase"/>. Note: This is not naturally returned with a <see cref="ProductVariantBase"/> response, as
        /// Shopify will not return <see cref="ProductVariantBase"/> metafields unless specified. Instead, you need to query metafields with <see cref="MetafieldService"/>.
        /// Uses include: Creating, updating, and deserializing webhook bodies that include them.
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<Metafield>? Metafields { get; set; }

        /// <inheritdoc cref="ProductVariantOrig.PresentmentPrices"/>
        [JsonPropertyName("presentment_prices")]
        public new IEnumerable<PresentmentPrice>? PresentmentPrices { get; set; }


        /// <summary>
        /// Custom properties that a shop owner can use to define product variants.
        /// </summary>
        [JsonPropertyName("option1")]
        public string? Option1 { get; set; }

        /// <summary>
        /// Custom properties that a shop owner can use to define product variants.
        /// </summary>
        [JsonPropertyName("option2")]
        public string? Option2 { get; set; }

        /// <summary>
        /// Custom properties that a shop owner can use to define product variants.
        /// </summary>
        [JsonPropertyName("option3")]
        public string? Option3 { get; set; }
    }
}
