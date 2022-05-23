
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// Represents the image for a <see cref="CustomCollection"/>
    /// </summary>
    public partial record CustomCollectionImage
    {
        /// <summary>
        /// An image attached to a shop's theme returned as Base64-encoded binary data.
        /// </summary>
        [JsonPropertyName("attachment")]
        public string? Attachment { get; set; }

        /// <summary>
        /// Source URL that specifies the location of the image.
        /// </summary>
        [JsonPropertyName("src")]
        public string? Src { get; set; }

        /// <summary>
        /// Alternative text that describes the collection image.
        /// </summary>
        [JsonPropertyName("alt")]
        public string? Alt { get; set; }

        /// <summary>
        /// The date the image was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

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
    }
}
