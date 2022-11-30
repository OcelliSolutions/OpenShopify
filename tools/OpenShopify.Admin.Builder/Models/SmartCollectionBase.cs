using System.Text.Json.Serialization;
//using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record SmartCollectionBase
    {
        /// <inheritdoc cref="SmartCollectionOrig.Image"/>
        [JsonPropertyName("image")]
        public new SmartCollectionImage? Image { get; set; }

        /// <inheritdoc cref="SmartCollectionOrig.Rules"/>
        [JsonPropertyName("rules")]
        public new IEnumerable<SmartCollectionRules>? Rules { get; set; }

        /// <inheritdoc cref="SmartCollectionOrig.PublishedScope"/>
        [JsonPropertyName("published_scope")]
        public new SmartCollectionPublishedScope? PublishedScope { get; set; }

        /// <inheritdoc cref="SmartCollectionOrig.SortOrder"/>
        [JsonPropertyName("sort_order")]
        public new SmartCollectionSortOrder? SortOrder { get; set; }

        [JsonPropertyName("products_count")] 
        public int? ProductsCount { get; set; }

        /// <summary>
        /// Additional metadata about the <see cref="SmartCollection"/>. Note: This is not naturally returned with a <see cref="SmartCollection"/> response, as
        /// Shopify will not return <see cref="SmartCollection"/> metafields unless specified. Instead, you need to query metafields with <see cref="MetafieldControllerBase"/>. 
        /// Uses include: Creating, updating, and deserializing webhook bodies that include them.
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<Metafield>? Metafields { get; set; }
    }
}
