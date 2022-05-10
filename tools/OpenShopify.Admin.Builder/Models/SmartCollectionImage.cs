
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing the image for a <see cref="SmartCollection"/>.
    /// </summary>
    public class SmartCollectionImage
    {
        /// <summary>
        /// The date the image was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The image's source URL.
        /// </summary>
        [JsonPropertyName("src")]
        public string? Src { get; set; }

        /// <summary>
        /// The image's base64 attachment, used when creating an image.
        /// </summary>
        [JsonPropertyName("attachment")]
        public string? Attachment { get; set; }

        /// <summary>
        /// Width of the image in pixels.
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Height of the image in pixels.
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Alternative text that describes the collection image.
        /// </summary>
        [JsonPropertyName("alt")]
        public string? Alt { get; set; }
    }
}
