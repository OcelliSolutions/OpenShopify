using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing an application charge.
    /// </summary>
    public class Charge : ShopifyObject
    {
        /// <summary>
        /// The URL that the customer should be sent to, to accept or decline the application charge.
        /// </summary>
        [JsonPropertyName("confirmation_url")]
        public string? ConfirmationUrl { get; set; }

        /// <summary>
        /// The date and time when the application charge was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The name of the application charge.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The price of the application charge.
        /// </summary>
        /// <remarks>Shopify returns this as a string, but JSON.net should be able to convert it to a decimal.</remarks>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// The URL the customer is sent to once they accept/decline a charge.
        /// </summary>
        [JsonPropertyName("return_url")]
        public string? ReturnUrl { get; set; }

        /// <summary>
        /// The status of the charged. Known values are 'pending', 'accepted', 'active', 'cancelled', 'declined' and 'expired'.
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// States whether or not the application charge is a test transaction.
        /// </summary>
        /// <remarks>Valid values are 'true' or null. Needs a special converter to convert null to false and vice-versa.</remarks>
        [JsonPropertyName("test")]
        public bool? Test { get; set; }

        /// <summary>
        /// The date and time when the recurring application charge was last updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
