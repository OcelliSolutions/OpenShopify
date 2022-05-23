using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record CustomCollectionBase
    {
        /// <inheritdoc cref="CustomCollectionOrig.Image"/>
        [JsonPropertyName("image")]
        public new CustomCollectionImage? Image { get; set; }

        /// <summary>
        /// The collection of collects associated to this custom collection
        /// </summary>
        [JsonPropertyName("collects")]
        public IEnumerable<Collect>? Collects { get; set; }

        [JsonPropertyName("products_count")]
        public int? ProductsCount { get; set; }

        /// <summary>
        /// Additional metadata about the <see cref="CustomCollection"/>. Note: This is not naturally returned with a <see cref="CustomCollection"/> response, as
        /// Shopify will not return <see cref="CustomCollection"/> metafields unless specified. Instead, you need to query metafields with <see cref="MetafieldService"/>. 
        /// Uses include: Creating, updating, and deserializing webhook bodies that include them.
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<Metafield>? Metafields { get; set; }
    }
}
