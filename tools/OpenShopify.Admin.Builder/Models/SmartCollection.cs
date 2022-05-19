using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An entity representing a Shopify Smart Collection Object.
    /// </summary>
    public class SmartCollectionBase
    {
        /// <summary>
        /// The description of the smart collection, complete with HTML markup. Many templates display this on their smart collection page.
        /// </summary>
        [JsonPropertyName("body_html")]
        public string? BodyHtml { get; set; }

        /// <summary>
        /// A human-friendly unique string for the smart collection automatically generated from its title. This is used in shop themes by the Liquid templating language to refer to the smart collection. Limit of 255 characters.
        /// </summary>
        [JsonPropertyName("handle")]
        public string? Handle { get; set; }

        /// <summary>
        /// The collection image.
        /// </summary>
        [JsonPropertyName("image")]
        public SmartCollectionImage Image { get; set; }

        /// <summary>
        /// This can have two different types of values, depending on whether the smart collection has been published (i.e., made visible to customers):
        /// If the smart collection is published, this value is the date and time when it was published.The API returns this value in ISO 8601 format.
        /// If the smart collection is hidden (i.e., not published), this value is null. Changing a smart collection's status from published to hidden changes its published_at property to null.
        /// </summary>
        [JsonPropertyName("published_at")]
        public DateTimeOffset? PublishedAt { get; set; }

        /// <summary>
        /// The sales channels in which the smart collection is visible. The only currently known value is 'global'.
        /// </summary>
        [JsonPropertyName("published_scope")]
        public string? PublishedScope { get; set; }

        /// <summary>
        /// The list of rules that define what products go into the smart collection.        
        /// </summary>
        [JsonPropertyName("rules")]
        public IEnumerable<SmartCollectionRules> Rules { get; set; }

        /// <summary>
        /// If false, products must match all of the rules to be included in the collection. If true, products can only match one of the rules.
        /// </summary>
        [JsonPropertyName("disjunctive")]
        public bool? Disjunctive { get; set; }

        /// <summary>
        /// The order in which products in the smart collection appear. Known values are 'alpha-asc', 'alpha-desc', 'best-selling', 'created', 'created-desc', 'manual', 'price-asc', 'price-desc'.
        /// </summary>
        [JsonPropertyName("sort_order")]
        public string? SortOrder { get; set; }

        /// <summary>
        /// The suffix of the template you are using. By default, the original template is called product.liquid, without any suffix. Any additional templates will be: product.suffix.liquid.
        /// </summary>
        [JsonPropertyName("template_suffix")]
        public string? TemplateSuffix { get; set; }

        /// <summary>
        /// The name of the smart collection. Limit of 255 characters.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// The date and time when the smart collection was last modified. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Additional metadata about the <see cref="SmartCollection"/>. Note: This is not naturally returned with a <see cref="SmartCollection"/> response, as
        /// Shopify will not return <see cref="SmartCollection"/> metafields unless specified. Instead, you need to query metafields with <see cref="MetafieldControllerBase"/>. 
        /// Uses include: Creating, updating, & deserializing webhook bodies that include them.
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<SmartCollectionMetafield> Metafields { get; set; }
    }

    public class SmartCollectionMetafield : Metafield
    {
    }
}
