using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// Sent via the GDPR customers/data_request webhook, indicating that a customer has requested all data that you may have stored related to them. It's your responsibility to provide this data to the store owner directly. 
    /// </summary>
    public partial record CustomerDataRequestWebhook : ShopRedactedWebhook
    {
        /// <summary>
        /// The customer who has been redacted.
        /// </summary>
        [JsonPropertyName("customer")]
        public RedactedCustomer? Customer { get; set; }

        /// <summary>
        /// A list of order ids placed by the customer that they are requesting information on.
        /// </summary>
        [JsonPropertyName("orders_requested")]
        public IEnumerable<long>? OrdersRequested { get; set; }
    }
}