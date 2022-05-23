
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// Represents a Shopify article's image.
    /// </summary>
    public partial record ArticleImage
    {
        /// <summary>
        /// A base64 image string only used when creating an image. It will be converted to the <see cref="Src"/> property.
        /// </summary>
        [JsonPropertyName("attachment")]
        public string? Attachment { get; set; }

        /// <summary>
        /// The date and time the image was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The image's src URL.
        /// </summary>
        [JsonPropertyName("src")]
        public string? Src { get; set; }
    }
}
