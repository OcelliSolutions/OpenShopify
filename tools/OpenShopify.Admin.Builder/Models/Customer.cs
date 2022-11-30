using System.Text.Json.Serialization;
//using OpenShopify.Admin.Builder.Data;

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

    /// <inheritdoc cref="CustomerOrig.State"/>
    [JsonPropertyName("state")]
    public new CustomerState? State { get; set; }


    /// <inheritdoc cref="CustomerOrig.TaxExemptions"/>
    [JsonPropertyName("tax_exemptions")]
    public new List<CustomerTaxExemptions>? TaxExemptions { get; set; }

}