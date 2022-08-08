using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record CollectionBase
    {
        /// <inheritdoc cref="CollectionOrig.Image"/>
        [JsonPropertyName("image")]
        public new CollectionImage? Image { get; set; }

        [JsonPropertyName("products_count")] 
        public int? ProductsCount { get; set; }

        [JsonPropertyName("collection_type")]
        public string? CollectionType { get; set; }

        [JsonPropertyName("disjunctive")]
        public bool? Disjunctive { get; set; }

        [JsonPropertyName("rules")]
        public IEnumerable<CollectionRules>? Rules { get; set; }
    }
}