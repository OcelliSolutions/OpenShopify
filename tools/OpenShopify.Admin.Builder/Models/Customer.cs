using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record Customer
{
    /// <inheritdoc cref="CustomerOrig.Addresses"/>
    [JsonPropertyName("addresses")]
    public new IEnumerable<CustomerAddress>? Addresses { get; set; }

    /// <inheritdoc cref="CustomerOrig.DefaultAddress"/>
    [JsonPropertyName("default_address")]
    public new CustomerAddress? DefaultAddress { get; set; }

    /// <summary>
    /// Additional metadata about the <see cref="Customer"/>. Note: This is not naturally returned with a <see cref="Customer"/> response, as
    /// Shopify will not return <see cref="Customer"/> metafields unless specified. Instead, you need to query metafields with <see cref="MetafieldService"/>. 
    /// Uses include: Creating, updating, and deserializing webhook bodies that include them.
    /// </summary>
    [JsonPropertyName("metafields")]
    public IEnumerable<Metafield>? Metafields { get; set; }

    /// <inheritdoc cref="CustomerOrig.AcceptsMarketingUpdatedAt"/>
    [JsonPropertyName("accepts_marketing_updated_at"), Obsolete]
    public new DateTimeOffset? AcceptsMarketingUpdatedAt { get; set; }

    /// <inheritdoc cref="CustomerOrig.EmailMarketingConsent"/>
    [JsonPropertyName("email_marketing_consent")]
    public new EmailMarketingConsent? EmailMarketingConsent { get; set; }

    /// <inheritdoc cref="CustomerOrig.SmsMarketingConsent"/>
    [JsonPropertyName("sms_marketing_consent")]
    public new SmsMarketingConsent? SmsMarketingConsent { get; set; }
}

public partial record SmsMarketingConsent
{
    /// <summary>
    /// The current SMS marketing state for the customer.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// The marketing subscription opt-in level, as described in the M3AAWG Sender Best Common Practices, that the customer gave when they consented to receive marketing material by SMS.
    /// </summary>
    [JsonPropertyName("opt_in_level")]
    public string? OptInLevel { get; set; }

    /// <summary>
    /// The date and time when the customer consented to receive marketing material by SMS. If no date is provided, then the date and time when the consent information was sent is used.
    /// </summary>
    [JsonPropertyName("consent_updated_at")]
    public DateTimeOffset? ConsentUpdatedAt { get; set; }

    /// <summary>
    /// The source for whether the customer has consented to receive marketing material by SMS.
    /// </summary>
    [JsonPropertyName("consent_collected_from")]
    public string? ConsentCollectedFrom { get; set; }
}
public partial record EmailMarketingConsent
{
    /// <summary>
    /// The current email marketing state for the customer.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }
    /// <summary>
    /// The marketing subscription opt-in level, as described in the M3AAWG Sender Best Common Practices, that the customer gave when they consented to receive marketing material by email.
    /// </summary>
    [JsonPropertyName("opt_in_level")] 
    public string? OptInLevel { get; set; }

    /// <summary>
    /// The date and time when the customer consented to receive marketing material by email. If no date is provided, then the date and time when the consent information was sent is used.
    /// </summary>
    [JsonPropertyName("consent_updated_at")]
    public DateTimeOffset? ConsentUpdatedAt { get; set; }
}