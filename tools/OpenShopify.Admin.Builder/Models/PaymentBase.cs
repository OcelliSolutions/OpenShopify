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

public record PaymentRequestDetail
{
    [JsonPropertyName("ip_address")]
    public string? IpAddress { get; set; }
    [JsonPropertyName("accept_language")]
    public string? AcceptLanguage { get; set; }
    [JsonPropertyName("user_agent")]
    public string? UserAgent { get; set; }
}
