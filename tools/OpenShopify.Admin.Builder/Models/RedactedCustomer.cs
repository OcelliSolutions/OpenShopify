

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// Represents a customer that should be purged from your database after receiving a GDPR webhook.
    /// In some cases, a customer record contains only the customer's email address
    /// </summary>
    public class RedactedCustomer
    {
        /// <summary>
        /// The customer's id.
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        /// <summary>
        /// The customer's email address.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// The customer's phone number.
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }
    }
}