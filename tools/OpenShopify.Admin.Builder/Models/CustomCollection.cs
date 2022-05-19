using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An entity representing a Shopify Custom Collection Object.
    /// </summary>
    public class CustomCollection : ShopifyObject
    {
        /// <summary>
        /// The description of the Custom collection, complete with HTML markup. Many templates display this on their Custom collection page.
        /// </summary>
        [JsonPropertyName("body_html")]
        public string? BodyHtml { get; set; }


        /// <summary>
        /// A human-friendly unique string for the Custom collection automatically generated from its title. This is used in shop themes by the Liquid templating language to refer to the Custom collection. Limit of 255 characters.
        /// </summary>
        [JsonPropertyName("handle")]
        public string? Handle { get; set; }

        /// <summary>
        /// The collection image.
        /// </summary>
        [JsonPropertyName("image")]
        public CustomCollectionImage Image { get; set; }

        /// <summary>
        /// Whether the collection is published or not.
        /// </summary>
        [JsonPropertyName("published")]
        public bool? Published { get; set; }

        /// <summary>
        /// This can have two different types of values, depending on whether the Custom collection has been published (i.e., made visible to customers):
        /// If the Custom collection is published, this value is the date and time when it was published.The API returns this value in ISO 8601 format.
        /// If the Custom collection is hidden (i.e., not published), this value is null. Changing a Custom collection's status from published to hidden changes its published_at property to null.
        /// </summary>
        [JsonPropertyName("published_at")]
        public DateTimeOffset? PublishedAt { get; set; }

        /// <summary>
        /// The sales channels in which the Custom collection is visible.
        /// </summary>
        [JsonPropertyName("published_scope")]
        public string? PublishedScope { get; set; }

        /// <summary>
        /// The order in which products in the Custom collection appear
        /// </summary>
        [JsonPropertyName("sort_order")]
        public string? SortOrder { get; set; }

        /// <summary>
        /// The suffix of the template you are using. By default, the original template is called product.liquid, without any suffix. Any additional templates will be: product.suffix.liquid.
        /// </summary>
        [JsonPropertyName("template_suffix")]
        public string? TemplateSuffix { get; set; }

        /// <summary>
        /// The name of the Custom collection. Limit of 255 characters.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// The date and time when the Custom collection was last modified. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }


        /// <summary>
        /// The collection of collects associated to this custom collection
        /// </summary>
        [JsonPropertyName("collects")]
        public IEnumerable<Collect> Collects { get; set; }

        /// <summary>
        /// Additional metadata about the <see cref="CustomCollection"/>. Note: This is not naturally returned with a <see cref="CustomCollection"/> response, as
        /// Shopify will not return <see cref="CustomCollection"/> metafields unless specified. Instead, you need to query metafields with <see cref="MetafieldService"/>. 
        /// Uses include: Creating, updating, & deserializing webhook bodies that include them.
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<CustomCollectionMetafield> Metafields { get; set; }
    }

    public class CustomCollectionMetafield:Metafield
    {
    }
}
