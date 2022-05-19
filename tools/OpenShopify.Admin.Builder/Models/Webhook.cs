using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An entity representing a Shopify webhook.
    /// </summary>
    public class WebhookBase
    {
        /// <summary>
        /// The URL where the webhook should send the POST request when the event occurs.
        /// </summary>
        [JsonPropertyName("address")]
        public string? Address { get; set; }

        /// <summary>
        /// The date and time when the webhook was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// An optional array of fields which should be included in webhooks.
        /// </summary>
        [JsonPropertyName("fields")]
        public IEnumerable<string> Fields { get; set; }

        /// <summary>
        /// The format in which the webhook should send the data. Valid values are json and xml.
        /// </summary>
        [JsonPropertyName("format")]
        public string? Format { get; set; }

        /// <summary>
        /// An optional array of namespaces for metafields that should be included in webhooks.
        /// </summary>
        [JsonPropertyName("metafield_namespaces")]
        public IEnumerable<string> MetafieldNamespaces { get; set; }

        /// <summary>
        /// The event that will trigger the webhook, e.g. 'orders/create' or 'app/uninstalled'. A full list of webhook topics can be found at https://help.shopify.com/api/reference/webhook.
        /// </summary>
        [JsonPropertyName("topic")]
        public string? Topic { get; set; }

        /// <summary>
        /// The date and time when the webhook was updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
