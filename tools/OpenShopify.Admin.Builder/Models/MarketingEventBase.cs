using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

//TODO: create MarketingEvent
public partial record MarketingEventBase
{
    /// <inheritdoc cref="MarketingEventOrig.EventType"/>
    [JsonPropertyName("event_type")]
    public new EventType? EventType { get; set; }

    /// <inheritdoc cref="MarketingEventOrig.MarketingChannel"/>
    [JsonPropertyName("marketing_channel")]
    public new MarketingChannel? MarketingChannel { get; set; }

    /// <inheritdoc cref="MarketingEventOrig.BudgetType"/>
    [JsonPropertyName("budget_type")]
    public new BudgetType? BudgetType { get; set; }

    /// <inheritdoc cref="MarketingEventOrig.MarketedResources"/>
    [JsonPropertyName("marketed_resources")]
    public new IEnumerable<MarketedResource>? MarketedResources { get; set; }

    [JsonPropertyName("utm_campaign")]
    public string? UtmCampaign { get; set; }
    [JsonPropertyName("utm_source")]
    public string? UtmSource { get; set; }
    [JsonPropertyName("utm_medium")]
    public string? UtmMedium { get; set; }

    [JsonPropertyName("marketing_activity_id")]
    public long? MarketingActivityId { get; set; }
}
