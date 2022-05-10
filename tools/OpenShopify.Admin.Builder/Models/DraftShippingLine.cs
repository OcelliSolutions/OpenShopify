

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class DraftShippingLine
    {
        /// <summary>
        /// Whether this is a regular shipping line or custom shipping line.
        /// </summary>
        [JsonPropertyName("custom")]
        public bool? Custom { get; set; }

        /// <summary>
        /// The handle of the shipping rate which was selected and applied. Required for regular shipping lines.
        /// </summary>
        [JsonPropertyName("handle")]
        public string? Handle { get; set; }

        /// <summary>
        /// The title of the shipping method. Required for custom shipping lines. (maximum: 255 characters)
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// The price of the shipping method. Required for custom shipping lines.
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; } 
    }
}