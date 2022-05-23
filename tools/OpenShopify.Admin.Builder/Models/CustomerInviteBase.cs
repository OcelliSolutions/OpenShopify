
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record CustomerInviteBase
    {
        /// <summary>
        /// The email address of the customer to be invited
        /// </summary>
        [JsonPropertyName("to")]
        public string? To { get; set; }

        /// <summary>
        /// The sender of the email
        /// </summary>
        [JsonPropertyName("from")]
        public string? From { get; set; }

        /// <summary>
        /// the subject
        /// </summary>
        [JsonPropertyName("subject")]
        public string? Subject { get; set; }

        /// <summary>
        /// a custom message to include
        /// </summary>
        [JsonPropertyName("custom_message")]
        public string? CustomMessage { get; set; }

        /// <summary>
        /// blind copy addresses
        /// </summary>
        [JsonPropertyName("bcc")]
        public IEnumerable<string>? Bcc { get; set; }

    }
    public partial record CustomerInviteOrig { }
}
