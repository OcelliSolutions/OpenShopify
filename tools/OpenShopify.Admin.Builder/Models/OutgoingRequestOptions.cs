

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record OutgoingRequestOptions
    {
        [JsonPropertyName("notify_customer")]
        public bool? NotifyCustomer { get; set; }
    }
}