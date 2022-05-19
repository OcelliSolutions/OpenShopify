using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class CollectionBase
    {
        /// <summary>
        /// A description of the collection, complete with HTML markup. Many templates display this on their collection pages. 
        /// </summary>
        [JsonPropertyName("body_html")]
        public string? BodyHtml { get; set; }
        
        /// <summary>
        /// A unique, human-readable string for the collection automatically generated from its title. This is used in themes by the Liquid templating language to refer to the collection. (limit: 255 characters)
        /// </summary>
        [JsonPropertyName("handle")]
        public string? Handle { get; set; }
        
        /// <summary>
        /// Image associated with the collection. 
        /// </summary>
        [JsonPropertyName("image")]
        public CollectionImage Image { get; set; }
        
        /// <summary>
        /// The time and date (ISO 8601 format) when the collection was made visible. Returns null for a hidden collection. 
        /// </summary>
        [JsonPropertyName("published_at")]
        public DateTimeOffset? PublishedAt { get; set; }
        
        /// <summary>
        ///  Whether the collection is published to the Point of Sale channel. Valid values: `web`, `global`
        /// </summary>
        [JsonPropertyName("published_scope")]
        public string? PublishedScope { get; set; }
        
        /// <summary>
        /// The order in which products in the collection appear. Valid values: `alpha-asc`, `alpha-desc`, `best-selling`,
        /// `created`, `created-desc`, `manual`, `price-asc`, `price-desc`
        /// </summary>
        [JsonPropertyName("sort_order")]
        public string? SortOrder { get; set; }
        
        /// <summary>
        /// The suffix of the liquid template being used. For example, if the value is custom, then the collection is
        /// using the collection.custom.liquid template. If the value is null, then the collection is using the default collection.liquid.
        /// </summary>
        [JsonPropertyName("template_suffix")]
        public string? TemplateSuffix { get; set; }
        
        /// <summary>
        /// The name of the collection. (limit: 255 characters)
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        
        /// <summary>
        /// The date and time (ISO 8601 format) when the collection was last modified.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}