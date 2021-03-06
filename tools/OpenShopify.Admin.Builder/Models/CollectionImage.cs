using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record CollectionImage 
    {
        /// <summary>
        /// An image attached to a collection returned as Base64-encoded binary data.
        /// </summary>
        [JsonPropertyName("attachment")]
        public string? Attachment { get; set; }
        
        /// <summary>
        /// The source URL that specifies the location of the image.
        /// </summary>
        [JsonPropertyName("src")]
        public string? Src { get; set; }
        
        /// <summary>
        /// The alternative text that describes the collection image.
        /// </summary>
        [JsonPropertyName("alt")]
        public string? Alt { get; set; }
        
        /// <summary>
        /// The time and date (ISO 8601 format) when the image was added to the collection.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }
        
        /// <summary>
        /// The width of the image in pixels.
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; }
        
        /// <summary>
        /// The height of the image in pixels.
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; set; }
    }
}