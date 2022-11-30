using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;
//TODO: create Payment
public partial record PaymentBase
{
    [JsonPropertyName("request_details")] 
    public PaymentRequestDetail? RequestDetails { get; set; }

    [JsonPropertyName("amount")]
    public decimal? Amount { get; set; }

    [JsonPropertyName("session_id")] 
    public string? SessionId { get; set; }
}