

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class OutgoingRequestOptions
    {
        [JsonPropertyName("notify_customer")]
        public bool? NotifyCustomer { get; set; }
    }
}