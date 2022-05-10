using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class PaymentDetails
    {
        [JsonPropertyName("avs_result_code")]
        public string? AvsResultCode { get; set; }

        [JsonPropertyName("credit_card_bin")]
        public string? CreditCardBin { get; set; }

        [JsonPropertyName("cvv_result_code")]
        public string? CvvResultCode { get; set; }

        [JsonPropertyName("credit_card_number")]
        public string? CreditCardNumber { get; set; }

        [JsonPropertyName("credit_card_company")]
        public string? CreditCardCompany { get; set; }
    }
}
