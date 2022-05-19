using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify collect.
    /// </summary>
    public class CollectBase
    {
        /// <summary>
        /// The id of the custom collection containing the product.
        /// </summary>
        [JsonPropertyName("collection_id")]
        public long? CollectionId { get; set; }

        /// <summary>
        /// The unique numeric identifier for the product in the custom collection.
        /// </summary>
        [JsonPropertyName("product_id")]
        public long? ProductId { get; set; }

        /// <summary>
        /// States whether or not the collect is featured.
        /// </summary>
        [Obsolete]
        [JsonPropertyName("featured")]
        public bool? Featured { get; set; }

        /// <summary>
        /// The date and time when the collect was created. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The date and time when the collect was last updated. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// A number specifying the manually sorted position of this product in a custom collection. The first position is 1. This value only applies when the custom collection is viewed using the Manual sort order.
        /// </summary>
        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// This is the same value as position but padded with leading zeroes to make it alphanumeric-sortable.
        /// </summary>
        [JsonPropertyName("sort_value")]
        public string? SortValue { get; set; }
    }
}
