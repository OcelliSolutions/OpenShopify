
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record TrackingInfo
    {
        /// <summary>
        /// The tracking number.
        /// </summary>
        [JsonPropertyName("number")]
        public string? Number { get; set; }

        /// <summary>
        /// The public URL to the tracking company.
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// The tracking company name.
        /// </summary>
        [JsonPropertyName("company")]
        public string? Company { get; set; }
    }
}
