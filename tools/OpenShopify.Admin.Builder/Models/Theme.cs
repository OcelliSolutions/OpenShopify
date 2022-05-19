using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An entity representing a Shopify theme.
    /// </summary>
    public class ThemeBase
    {
        /// <summary>
        /// The date and time when the theme was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The name of the theme.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        /// <summary>
        /// Specifies how the theme is being used within the shop. Known values are 'main', 'mobile' and 'unpublished'.
        /// </summary>
        [JsonPropertyName("role")]
        public string? Role { get; set; }

        /// <summary>
        /// The date and time when the theme was last updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Indicates if the theme can currently be previewed.
        /// </summary>
        [JsonPropertyName("previewable")]
        public bool? Previewable { get; set; }

        /// <summary>
        /// Indicates if files are still being copied into place for this theme.
        /// </summary>
        [JsonPropertyName("processing")]
        public bool? Processing { get; set; }

        /// <summary>
        /// The theme's store id. Can be null if not published in the store.
        /// </summary>
        [JsonPropertyName("theme_store_id")]
        public long? ThemeStoreId { get; set; }
    }
}
