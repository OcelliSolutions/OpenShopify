using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify event.
    /// </summary>
    public class Event : ShopifyObject
    {
        /// <summary>
        /// Refers to a certain event and its resources.
        /// </summary>
        [JsonPropertyName("arguments")]
        public IEnumerable<string> Arguments { get; set; }

        /// <summary>
        /// A text field containing information about the event.
        /// </summary>
        [JsonPropertyName("body")]
        public string? Body { get; set; }

        /// <summary>
        /// The date and time when the event was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// A relative URL to the resource the event is for (may be null)
        /// </summary>
        [JsonPropertyName("path")]
        public string? Path { get; set; }

        /// <summary>
        /// Human readable text that describes the event (may contain limited HTML formatting).
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// The id of the resource that generated the event.
        /// </summary>
        [JsonPropertyName("subject_id")]
        public long? SubjectId { get; set; }

        /// <summary>
        /// The type of the resource that generated the event.
        /// </summary>
        [JsonPropertyName("subject_type")]
        public string? SubjectType { get; set; }

        /// <summary>
        /// The type of event that took place.
        /// </summary>
        [JsonPropertyName("verb")]
        public string? Verb { get; set; }

        /// <summary>
        /// Undocumented by Shopify
        /// </summary>
        [JsonPropertyName("author")]
        public string? Author { get; set; }
    }
}
