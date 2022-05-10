using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class RefundDutyType
    {
        [JsonPropertyName("duty_id")]
        public long? DutyId { get; set; }

        [JsonPropertyName("refund_type")]
        public string? RefundType { get; set; }
    }
}
