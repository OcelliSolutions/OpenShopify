using System.Text.Json.Serialization;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Models;

public class RecurringApplicationCharge
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("api_client_id")]
    public long ApiClientId { get; set; }
    [JsonPropertyName("price")]
    public decimal? Price { get; set; }
    [JsonPropertyName("status")]
    public RecurringApplicationChargeStatus? Status { get; set; }
    [JsonPropertyName("return_url")]
    public string? ReturnUrl { get; set; }
    [JsonPropertyName("billing_on")]
    public DateTimeOffset? BillingOn { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    [JsonPropertyName("test")]
    public bool? Test { get; set; }
    [JsonPropertyName("activated_on")]
    public DateTimeOffset? ActivatedOn { get; set; }
    [JsonPropertyName("cancelled_on")]
    public DateTimeOffset? CancelledOn { get; set; }
    [JsonPropertyName("trial_days")]
    public int? TrialDays { get; set; }
    [JsonPropertyName("trial_ends_on")]
    public DateTimeOffset? TrialEndsOn { get; set; }
    [JsonPropertyName("decorated_return_url")]
    public string? DecoratedReturnUrl { get; set; }
}

