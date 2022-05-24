using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public class WebhookErrorResponse
{
    [JsonPropertyName("errors")]
    public WebhookError Error { get; set; } = null!;
}

public class WebhookError
{
    [JsonPropertyName("topic")]
    public IEnumerable<string>? Topic { get; set; }
    [JsonPropertyName("address")]
    public IEnumerable<string>? Address { get; set; }
}
