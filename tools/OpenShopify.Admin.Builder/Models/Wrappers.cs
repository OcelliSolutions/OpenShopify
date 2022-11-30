using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;
// ReSharper disable All

public partial record StorefrontAccessTokenItem
{
    [JsonPropertyName("storefront_access_token"), Required]
    public StorefrontAccessToken StorefrontAccessToken { get; set; } = null!;
}

public partial record StorefrontAccessTokenList
{
    [JsonPropertyName("storefront_access_tokens"), Required]
    public IEnumerable<StorefrontAccessToken> StorefrontAccessTokens { get; set; } = null!;
}
public partial record CreateStorefrontAccessTokenRequest
{
    [JsonPropertyName("storefront_access_token"), Required]
    public CreateStorefrontAccessToken StorefrontAccessToken { get; set; } = null!;
}

/// <inheritdoc cref="StorefrontAccessTokenBase"/>
public partial record CreateStorefrontAccessToken : StorefrontAccessTokenBase {}
public partial record UpdateStorefrontAccessTokenRequest
{
    [JsonPropertyName("storefront_access_token"), Required]
    public UpdateStorefrontAccessToken StorefrontAccessToken { get; set; } = null!;
}

/// <inheritdoc cref="StorefrontAccessToken"/>
public partial record UpdateStorefrontAccessToken : StorefrontAccessToken
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="StorefrontAccessTokenBase"/>
public partial record StorefrontAccessToken : StorefrontAccessTokenBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="StorefrontAccessTokenOrig"/>
public partial record StorefrontAccessTokenBase : StorefrontAccessTokenOrig{}

	
public partial record ReportItem
{
    [JsonPropertyName("report"), Required]
    public Report Report { get; set; } = null!;
}

public partial record ReportList
{
    [JsonPropertyName("reports"), Required]
    public IEnumerable<Report> Reports { get; set; } = null!;
}
public partial record CreateReportRequest
{
    [JsonPropertyName("report"), Required]
    public CreateReport Report { get; set; } = null!;
}

/// <inheritdoc cref="ReportBase"/>
public partial record CreateReport : ReportBase {}
public partial record UpdateReportRequest
{
    [JsonPropertyName("report"), Required]
    public UpdateReport Report { get; set; } = null!;
}

/// <inheritdoc cref="Report"/>
public partial record UpdateReport : Report
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ReportBase"/>
public partial record Report : ReportBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ReportOrig"/>
public partial record ReportBase : ReportOrig{}

	
public partial record ApplicationChargeItem
{
    [JsonPropertyName("application_charge"), Required]
    public ApplicationCharge ApplicationCharge { get; set; } = null!;
}

public partial record ApplicationChargeList
{
    [JsonPropertyName("application_charges"), Required]
    public IEnumerable<ApplicationCharge> ApplicationCharges { get; set; } = null!;
}
public partial record CreateApplicationChargeRequest
{
    [JsonPropertyName("application_charge"), Required]
    public CreateApplicationCharge ApplicationCharge { get; set; } = null!;
}

/// <inheritdoc cref="ApplicationChargeBase"/>
public partial record CreateApplicationCharge : ApplicationChargeBase {}
public partial record UpdateApplicationChargeRequest
{
    [JsonPropertyName("application_charge"), Required]
    public UpdateApplicationCharge ApplicationCharge { get; set; } = null!;
}

/// <inheritdoc cref="ApplicationCharge"/>
public partial record UpdateApplicationCharge : ApplicationCharge
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ApplicationChargeBase"/>
public partial record ApplicationCharge : ApplicationChargeBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ApplicationChargeOrig"/>
public partial record ApplicationChargeBase : ApplicationChargeOrig{}

	
public partial record ApplicationCreditItem
{
    [JsonPropertyName("application_credit"), Required]
    public ApplicationCredit ApplicationCredit { get; set; } = null!;
}

public partial record ApplicationCreditList
{
    [JsonPropertyName("application_credits"), Required]
    public IEnumerable<ApplicationCredit> ApplicationCredits { get; set; } = null!;
}
public partial record CreateApplicationCreditRequest
{
    [JsonPropertyName("application_credit"), Required]
    public CreateApplicationCredit ApplicationCredit { get; set; } = null!;
}

/// <inheritdoc cref="ApplicationCreditBase"/>
public partial record CreateApplicationCredit : ApplicationCreditBase {}
public partial record UpdateApplicationCreditRequest
{
    [JsonPropertyName("application_credit"), Required]
    public UpdateApplicationCredit ApplicationCredit { get; set; } = null!;
}

/// <inheritdoc cref="ApplicationCredit"/>
public partial record UpdateApplicationCredit : ApplicationCredit
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ApplicationCreditBase"/>
public partial record ApplicationCredit : ApplicationCreditBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ApplicationCreditOrig"/>
public partial record ApplicationCreditBase : ApplicationCreditOrig{}

	
public partial record RecurringApplicationChargeItem
{
    [JsonPropertyName("recurring_application_charge"), Required]
    public RecurringApplicationCharge RecurringApplicationCharge { get; set; } = null!;
}

public partial record RecurringApplicationChargeList
{
    [JsonPropertyName("recurring_application_charges"), Required]
    public IEnumerable<RecurringApplicationCharge> RecurringApplicationCharges { get; set; } = null!;
}
public partial record CreateRecurringApplicationChargeRequest
{
    [JsonPropertyName("recurring_application_charge"), Required]
    public CreateRecurringApplicationCharge RecurringApplicationCharge { get; set; } = null!;
}

/// <inheritdoc cref="RecurringApplicationChargeBase"/>
public partial record CreateRecurringApplicationCharge : RecurringApplicationChargeBase {}
public partial record UpdateRecurringApplicationChargeRequest
{
    [JsonPropertyName("recurring_application_charge"), Required]
    public UpdateRecurringApplicationCharge RecurringApplicationCharge { get; set; } = null!;
}

/// <inheritdoc cref="RecurringApplicationCharge"/>
public partial record UpdateRecurringApplicationCharge : RecurringApplicationCharge
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="RecurringApplicationChargeBase"/>
public partial record RecurringApplicationCharge : RecurringApplicationChargeBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="RecurringApplicationChargeOrig"/>
public partial record RecurringApplicationChargeBase : RecurringApplicationChargeOrig{}

	
public partial record UsageChargeItem
{
    [JsonPropertyName("usage_charge"), Required]
    public UsageCharge UsageCharge { get; set; } = null!;
}

public partial record UsageChargeList
{
    [JsonPropertyName("usage_charges"), Required]
    public IEnumerable<UsageCharge> UsageCharges { get; set; } = null!;
}
public partial record CreateUsageChargeRequest
{
    [JsonPropertyName("usage_charge"), Required]
    public CreateUsageCharge UsageCharge { get; set; } = null!;
}

/// <inheritdoc cref="UsageChargeBase"/>
public partial record CreateUsageCharge : UsageChargeBase {}
public partial record UpdateUsageChargeRequest
{
    [JsonPropertyName("usage_charge"), Required]
    public UpdateUsageCharge UsageCharge { get; set; } = null!;
}

/// <inheritdoc cref="UsageCharge"/>
public partial record UpdateUsageCharge : UsageCharge
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="UsageChargeBase"/>
public partial record UsageCharge : UsageChargeBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="UsageChargeOrig"/>
public partial record UsageChargeBase : UsageChargeOrig{}

	
public partial record CustomerItem
{
    [JsonPropertyName("customer"), Required]
    public Customer Customer { get; set; } = null!;
}

public partial record CustomerList
{
    [JsonPropertyName("customers"), Required]
    public IEnumerable<Customer> Customers { get; set; } = null!;
}
public partial record CreateCustomerRequest
{
    [JsonPropertyName("customer"), Required]
    public CreateCustomer Customer { get; set; } = null!;
}

/// <inheritdoc cref="CustomerBase"/>
public partial record CreateCustomer : CustomerBase {}
public partial record UpdateCustomerRequest
{
    [JsonPropertyName("customer"), Required]
    public UpdateCustomer Customer { get; set; } = null!;
}

/// <inheritdoc cref="Customer"/>
public partial record UpdateCustomer : Customer
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CustomerBase"/>
public partial record Customer : CustomerBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CustomerOrig"/>
public partial record CustomerBase : CustomerOrig{}

	
public partial record CustomerSavedSearchItem
{
    [JsonPropertyName("customer_saved_search"), Required]
    public CustomerSavedSearch CustomerSavedSearch { get; set; } = null!;
}

public partial record CustomerSavedSearchList
{
    [JsonPropertyName("customer_saved_searches"), Required]
    public IEnumerable<CustomerSavedSearch> CustomerSavedSearches { get; set; } = null!;
}
public partial record CreateCustomerSavedSearchRequest
{
    [JsonPropertyName("customer_saved_search"), Required]
    public CreateCustomerSavedSearch CustomerSavedSearch { get; set; } = null!;
}

/// <inheritdoc cref="CustomerSavedSearchBase"/>
public partial record CreateCustomerSavedSearch : CustomerSavedSearchBase {}
public partial record UpdateCustomerSavedSearchRequest
{
    [JsonPropertyName("customer_saved_search"), Required]
    public UpdateCustomerSavedSearch CustomerSavedSearch { get; set; } = null!;
}

/// <inheritdoc cref="CustomerSavedSearch"/>
public partial record UpdateCustomerSavedSearch : CustomerSavedSearch
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CustomerSavedSearchBase"/>
public partial record CustomerSavedSearch : CustomerSavedSearchBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CustomerSavedSearchOrig"/>
public partial record CustomerSavedSearchBase : CustomerSavedSearchOrig{}

	
public partial record DeprecatedApiCallItem
{
    [JsonPropertyName("deprecated_api_call"), Required]
    public DeprecatedApiCall DeprecatedApiCall { get; set; } = null!;
}

public partial record DeprecatedApiCallList
{
    [JsonPropertyName("deprecated_api_calls"), Required]
    public IEnumerable<DeprecatedApiCall> DeprecatedApiCalls { get; set; } = null!;
}
		
/// <inheritdoc cref="DeprecatedAPIcallsBase"/>
public partial record DeprecatedApiCall : DeprecatedAPIcallsBase
{
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="DeprecatedAPIcallsOrig"/>
public partial record DeprecatedAPIcallsBase : DeprecatedAPIcallsOrig{}

	
public partial record DiscountCodeItem
{
    [JsonPropertyName("discount_code"), Required]
    public DiscountCode DiscountCode { get; set; } = null!;
}

public partial record DiscountCodeList
{
    [JsonPropertyName("discount_codes"), Required]
    public IEnumerable<DiscountCode> DiscountCodes { get; set; } = null!;
}
public partial record CreateDiscountCodeRequest
{
    [JsonPropertyName("discount_code"), Required]
    public CreateDiscountCode DiscountCode { get; set; } = null!;
}

/// <inheritdoc cref="DiscountCodeBase"/>
public partial record CreateDiscountCode : DiscountCodeBase {}
public partial record UpdateDiscountCodeRequest
{
    [JsonPropertyName("discount_code"), Required]
    public UpdateDiscountCode DiscountCode { get; set; } = null!;
}

/// <inheritdoc cref="DiscountCode"/>
public partial record UpdateDiscountCode : DiscountCode
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="DiscountCodeBase"/>
public partial record DiscountCode : DiscountCodeBase
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="DiscountCodeOrig"/>
public partial record DiscountCodeBase : DiscountCodeOrig{}

	
public partial record PriceRuleItem
{
    [JsonPropertyName("price_rule"), Required]
    public PriceRule PriceRule { get; set; } = null!;
}

public partial record PriceRuleList
{
    [JsonPropertyName("price_rules"), Required]
    public IEnumerable<PriceRule> PriceRules { get; set; } = null!;
}
public partial record CreatePriceRuleRequest
{
    [JsonPropertyName("price_rule"), Required]
    public CreatePriceRule PriceRule { get; set; } = null!;
}

/// <inheritdoc cref="PriceRuleBase"/>
public partial record CreatePriceRule : PriceRuleBase {}
public partial record UpdatePriceRuleRequest
{
    [JsonPropertyName("price_rule"), Required]
    public UpdatePriceRule PriceRule { get; set; } = null!;
}

/// <inheritdoc cref="PriceRule"/>
public partial record UpdatePriceRule : PriceRule
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="PriceRuleBase"/>
public partial record PriceRule : PriceRuleBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="PriceRuleOrig"/>
public partial record PriceRuleBase : PriceRuleOrig{}

	
public partial record EventItem
{
    [JsonPropertyName("event"), Required]
    public Event Event { get; set; } = null!;
}

public partial record EventList
{
    [JsonPropertyName("events"), Required]
    public IEnumerable<Event> Events { get; set; } = null!;
}
public partial record CreateEventRequest
{
    [JsonPropertyName("event"), Required]
    public CreateEvent Event { get; set; } = null!;
}

/// <inheritdoc cref="EventBase"/>
public partial record CreateEvent : EventBase {}
public partial record UpdateEventRequest
{
    [JsonPropertyName("event"), Required]
    public UpdateEvent Event { get; set; } = null!;
}

/// <inheritdoc cref="Event"/>
public partial record UpdateEvent : Event
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="EventBase"/>
public partial record Event : EventBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="EventOrig"/>
public partial record EventBase : EventOrig{}

	
public partial record WebhookItem
{
    [JsonPropertyName("webhook"), Required]
    public Webhook Webhook { get; set; } = null!;
}

public partial record WebhookList
{
    [JsonPropertyName("webhooks"), Required]
    public IEnumerable<Webhook> Webhooks { get; set; } = null!;
}
public partial record CreateWebhookRequest
{
    [JsonPropertyName("webhook"), Required]
    public CreateWebhook Webhook { get; set; } = null!;
}

/// <inheritdoc cref="WebhookBase"/>
public partial record CreateWebhook : WebhookBase {}
public partial record UpdateWebhookRequest
{
    [JsonPropertyName("webhook"), Required]
    public UpdateWebhook Webhook { get; set; } = null!;
}

/// <inheritdoc cref="Webhook"/>
public partial record UpdateWebhook : Webhook
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="WebhookBase"/>
public partial record Webhook : WebhookBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="WebhookOrig"/>
public partial record WebhookBase : WebhookOrig{}

	
public partial record InventoryItemItem
{
    [JsonPropertyName("inventory_item"), Required]
    public InventoryItem InventoryItem { get; set; } = null!;
}

public partial record InventoryItemList
{
    [JsonPropertyName("inventory_items"), Required]
    public IEnumerable<InventoryItem> InventoryItems { get; set; } = null!;
}
public partial record CreateInventoryItemRequest
{
    [JsonPropertyName("inventory_item"), Required]
    public CreateInventoryItem InventoryItem { get; set; } = null!;
}

/// <inheritdoc cref="InventoryItemBase"/>
public partial record CreateInventoryItem : InventoryItemBase {}
public partial record UpdateInventoryItemRequest
{
    [JsonPropertyName("inventory_item"), Required]
    public UpdateInventoryItem InventoryItem { get; set; } = null!;
}

/// <inheritdoc cref="InventoryItem"/>
public partial record UpdateInventoryItem : InventoryItem
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="InventoryItemBase"/>
public partial record InventoryItem : InventoryItemBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="InventoryItemOrig"/>
public partial record InventoryItemBase : InventoryItemOrig{}

	
public partial record InventoryLevelItem
{
    [JsonPropertyName("inventory_level"), Required]
    public InventoryLevel InventoryLevel { get; set; } = null!;
}

public partial record InventoryLevelList
{
    [JsonPropertyName("inventory_levels"), Required]
    public IEnumerable<InventoryLevel> InventoryLevels { get; set; } = null!;
}
public partial record CreateInventoryLevelRequest
{
    [JsonPropertyName("inventory_level"), Required]
    public CreateInventoryLevel InventoryLevel { get; set; } = null!;
}

/// <inheritdoc cref="InventoryLevelBase"/>
public partial record CreateInventoryLevel : InventoryLevelBase {}
public partial record UpdateInventoryLevelRequest
{
    [JsonPropertyName("inventory_level"), Required]
    public UpdateInventoryLevel InventoryLevel { get; set; } = null!;
}

/// <inheritdoc cref="InventoryLevel"/>
public partial record UpdateInventoryLevel : InventoryLevel
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="InventoryLevelBase"/>
public partial record InventoryLevel : InventoryLevelBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="InventoryLevelOrig"/>
public partial record InventoryLevelBase : InventoryLevelOrig{}

	
public partial record LocationItem
{
    [JsonPropertyName("location"), Required]
    public Location Location { get; set; } = null!;
}

public partial record LocationList
{
    [JsonPropertyName("locations"), Required]
    public IEnumerable<Location> Locations { get; set; } = null!;
}
public partial record CreateLocationRequest
{
    [JsonPropertyName("location"), Required]
    public CreateLocation Location { get; set; } = null!;
}

/// <inheritdoc cref="LocationBase"/>
public partial record CreateLocation : LocationBase {}
public partial record UpdateLocationRequest
{
    [JsonPropertyName("location"), Required]
    public UpdateLocation Location { get; set; } = null!;
}

/// <inheritdoc cref="Location"/>
public partial record UpdateLocation : Location
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="LocationBase"/>
public partial record Location : LocationBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="LocationOrig"/>
public partial record LocationBase : LocationOrig{}

	
public partial record MarketingEventItem
{
    [JsonPropertyName("marketing_event"), Required]
    public MarketingEvent MarketingEvent { get; set; } = null!;
}

public partial record MarketingEventList
{
    [JsonPropertyName("marketing_events"), Required]
    public IEnumerable<MarketingEvent> MarketingEvents { get; set; } = null!;
}
public partial record CreateMarketingEventRequest
{
    [JsonPropertyName("marketing_event"), Required]
    public CreateMarketingEvent MarketingEvent { get; set; } = null!;
}

/// <inheritdoc cref="MarketingEventBase"/>
public partial record CreateMarketingEvent : MarketingEventBase {}
public partial record UpdateMarketingEventRequest
{
    [JsonPropertyName("marketing_event"), Required]
    public UpdateMarketingEvent MarketingEvent { get; set; } = null!;
}

/// <inheritdoc cref="MarketingEvent"/>
public partial record UpdateMarketingEvent : MarketingEvent
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="MarketingEventBase"/>
public partial record MarketingEvent : MarketingEventBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="MarketingEventOrig"/>
public partial record MarketingEventBase : MarketingEventOrig{}

	
public partial record MetafieldItem
{
    [JsonPropertyName("metafield"), Required]
    public Metafield Metafield { get; set; } = null!;
}

public partial record MetafieldList
{
    [JsonPropertyName("metafields"), Required]
    public IEnumerable<Metafield> Metafields { get; set; } = null!;
}
public partial record CreateMetafieldRequest
{
    [JsonPropertyName("metafield"), Required]
    public CreateMetafield Metafield { get; set; } = null!;
}

/// <inheritdoc cref="MetafieldBase"/>
public partial record CreateMetafield : MetafieldBase {}
public partial record UpdateMetafieldRequest
{
    [JsonPropertyName("metafield"), Required]
    public UpdateMetafield Metafield { get; set; } = null!;
}

/// <inheritdoc cref="Metafield"/>
public partial record UpdateMetafield : Metafield
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="MetafieldBase"/>
public partial record Metafield : MetafieldBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="MetafieldOrig"/>
public partial record MetafieldBase : MetafieldOrig{}

	
public partial record ArticleItem
{
    [JsonPropertyName("article"), Required]
    public Article Article { get; set; } = null!;
}

public partial record ArticleList
{
    [JsonPropertyName("articles"), Required]
    public IEnumerable<Article> Articles { get; set; } = null!;
}
public partial record CreateArticleRequest
{
    [JsonPropertyName("article"), Required]
    public CreateArticle Article { get; set; } = null!;
}

/// <inheritdoc cref="ArticleBase"/>
public partial record CreateArticle : ArticleBase {}
public partial record UpdateArticleRequest
{
    [JsonPropertyName("article"), Required]
    public UpdateArticle Article { get; set; } = null!;
}

/// <inheritdoc cref="Article"/>
public partial record UpdateArticle : Article
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ArticleBase"/>
public partial record Article : ArticleBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ArticleOrig"/>
public partial record ArticleBase : ArticleOrig{}

	
public partial record AssetItem
{
    [JsonPropertyName("asset"), Required]
    public Asset Asset { get; set; } = null!;
}

public partial record AssetList
{
    [JsonPropertyName("assets"), Required]
    public IEnumerable<Asset> Assets { get; set; } = null!;
}
public partial record CreateAssetRequest
{
    [JsonPropertyName("asset"), Required]
    public CreateAsset Asset { get; set; } = null!;
}

/// <inheritdoc cref="AssetBase"/>
public partial record CreateAsset : AssetBase {}
public partial record UpdateAssetRequest
{
    [JsonPropertyName("asset"), Required]
    public UpdateAsset Asset { get; set; } = null!;
}

/// <inheritdoc cref="Asset"/>
public partial record UpdateAsset : Asset
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="AssetBase"/>
public partial record Asset : AssetBase
{
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="AssetOrig"/>
public partial record AssetBase : AssetOrig{}

	
public partial record BlogItem
{
    [JsonPropertyName("blog"), Required]
    public Blog Blog { get; set; } = null!;
}

public partial record BlogList
{
    [JsonPropertyName("blogs"), Required]
    public IEnumerable<Blog> Blogs { get; set; } = null!;
}
public partial record CreateBlogRequest
{
    [JsonPropertyName("blog"), Required]
    public CreateBlog Blog { get; set; } = null!;
}

/// <inheritdoc cref="BlogBase"/>
public partial record CreateBlog : BlogBase {}
public partial record UpdateBlogRequest
{
    [JsonPropertyName("blog"), Required]
    public UpdateBlog Blog { get; set; } = null!;
}

/// <inheritdoc cref="Blog"/>
public partial record UpdateBlog : Blog
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="BlogBase"/>
public partial record Blog : BlogBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="BlogOrig"/>
public partial record BlogBase : BlogOrig{}

	
public partial record CommentItem
{
    [JsonPropertyName("comment"), Required]
    public Comment Comment { get; set; } = null!;
}

public partial record CommentList
{
    [JsonPropertyName("comments"), Required]
    public IEnumerable<Comment> Comments { get; set; } = null!;
}
public partial record CreateCommentRequest
{
    [JsonPropertyName("comment"), Required]
    public CreateComment Comment { get; set; } = null!;
}

/// <inheritdoc cref="CommentBase"/>
public partial record CreateComment : CommentBase {}
public partial record UpdateCommentRequest
{
    [JsonPropertyName("comment"), Required]
    public UpdateComment Comment { get; set; } = null!;
}

/// <inheritdoc cref="Comment"/>
public partial record UpdateComment : Comment
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CommentBase"/>
public partial record Comment : CommentBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CommentOrig"/>
public partial record CommentBase : CommentOrig{}

	
public partial record CommentForArticleItem
{
    [JsonPropertyName("comment"), Required]
    public Comment CommentForArticle { get; set; } = null!;
}

public partial record CommentForArticleList
{
    [JsonPropertyName("comments"), Required]
    public IEnumerable<Comment> CommentsForArticle { get; set; } = null!;
}
public partial record CreateCommentForArticleRequest
{
    [JsonPropertyName("comment"), Required]
    public CreateCommentForArticle CommentForArticle { get; set; } = null!;
}

/// <inheritdoc cref="CommentBase"/>
public partial record CreateCommentForArticle : CommentBase {}
public partial record UpdateCommentForArticleRequest
{
    [JsonPropertyName("comment"), Required]
    public UpdateCommentForArticle CommentForArticle { get; set; } = null!;
}

/// <inheritdoc cref="Comment"/>
public partial record UpdateCommentForArticle : Comment
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CommentBase"/>
public partial record CommentForArticle : CommentBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CommentOrig"/>
public partial record CommentBase : CommentOrig{}

	
public partial record CommentOfArticleItem
{
    [JsonPropertyName("comment"), Required]
    public Comment CommentOfArticle { get; set; } = null!;
}

public partial record CommentOfArticleList
{
    [JsonPropertyName("comments"), Required]
    public IEnumerable<Comment> CommentsOfArticle { get; set; } = null!;
}
public partial record CreateCommentOfArticleRequest
{
    [JsonPropertyName("comment"), Required]
    public CreateCommentOfArticle CommentOfArticle { get; set; } = null!;
}

/// <inheritdoc cref="CommentBase"/>
public partial record CreateCommentOfArticle : CommentBase {}
public partial record UpdateCommentOfArticleRequest
{
    [JsonPropertyName("comment"), Required]
    public UpdateCommentOfArticle CommentOfArticle { get; set; } = null!;
}

/// <inheritdoc cref="Comment"/>
public partial record UpdateCommentOfArticle : Comment
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CommentBase"/>
public partial record CommentOfArticle : CommentBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CommentOrig"/>
public partial record CommentBase : CommentOrig{}

	
public partial record PageItem
{
    [JsonPropertyName("page"), Required]
    public Page Page { get; set; } = null!;
}

public partial record PageList
{
    [JsonPropertyName("pages"), Required]
    public IEnumerable<Page> Pages { get; set; } = null!;
}
public partial record CreatePageRequest
{
    [JsonPropertyName("page"), Required]
    public CreatePage Page { get; set; } = null!;
}

/// <inheritdoc cref="PageBase"/>
public partial record CreatePage : PageBase {}
public partial record UpdatePageRequest
{
    [JsonPropertyName("page"), Required]
    public UpdatePage Page { get; set; } = null!;
}

/// <inheritdoc cref="Page"/>
public partial record UpdatePage : Page
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="PageBase"/>
public partial record Page : PageBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="PageOrig"/>
public partial record PageBase : PageOrig{}

	
public partial record RedirectItem
{
    [JsonPropertyName("redirect"), Required]
    public Redirect Redirect { get; set; } = null!;
}

public partial record RedirectList
{
    [JsonPropertyName("redirects"), Required]
    public IEnumerable<Redirect> Redirects { get; set; } = null!;
}
public partial record CreateRedirectRequest
{
    [JsonPropertyName("redirect"), Required]
    public CreateRedirect Redirect { get; set; } = null!;
}

/// <inheritdoc cref="RedirectBase"/>
public partial record CreateRedirect : RedirectBase {}
public partial record UpdateRedirectRequest
{
    [JsonPropertyName("redirect"), Required]
    public UpdateRedirect Redirect { get; set; } = null!;
}

/// <inheritdoc cref="Redirect"/>
public partial record UpdateRedirect : Redirect
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="RedirectBase"/>
public partial record Redirect : RedirectBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="RedirectOrig"/>
public partial record RedirectBase : RedirectOrig{}

	
public partial record ScriptTagItem
{
    [JsonPropertyName("script_tag"), Required]
    public ScriptTag ScriptTag { get; set; } = null!;
}

public partial record ScriptTagList
{
    [JsonPropertyName("script_tags"), Required]
    public IEnumerable<ScriptTag> ScriptTags { get; set; } = null!;
}
public partial record CreateScriptTagRequest
{
    [JsonPropertyName("script_tag"), Required]
    public CreateScriptTag ScriptTag { get; set; } = null!;
}

/// <inheritdoc cref="ScriptTagBase"/>
public partial record CreateScriptTag : ScriptTagBase {}
public partial record UpdateScriptTagRequest
{
    [JsonPropertyName("script_tag"), Required]
    public UpdateScriptTag ScriptTag { get; set; } = null!;
}

/// <inheritdoc cref="ScriptTag"/>
public partial record UpdateScriptTag : ScriptTag
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ScriptTagBase"/>
public partial record ScriptTag : ScriptTagBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ScriptTagOrig"/>
public partial record ScriptTagBase : ScriptTagOrig{}

	
public partial record ThemeItem
{
    [JsonPropertyName("theme"), Required]
    public Theme Theme { get; set; } = null!;
}

public partial record ThemeList
{
    [JsonPropertyName("themes"), Required]
    public IEnumerable<Theme> Themes { get; set; } = null!;
}
public partial record CreateThemeRequest
{
    [JsonPropertyName("theme"), Required]
    public CreateTheme Theme { get; set; } = null!;
}

/// <inheritdoc cref="ThemeBase"/>
public partial record CreateTheme : ThemeBase {}
public partial record UpdateThemeRequest
{
    [JsonPropertyName("theme"), Required]
    public UpdateTheme Theme { get; set; } = null!;
}

/// <inheritdoc cref="Theme"/>
public partial record UpdateTheme : Theme
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ThemeBase"/>
public partial record Theme : ThemeBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ThemeOrig"/>
public partial record ThemeBase : ThemeOrig{}

	
public partial record AbandonedCheckoutItem
{
    [JsonPropertyName("checkout"), Required]
    public AbandonedCheckout AbandonedCheckout { get; set; } = null!;
}

public partial record AbandonedCheckoutList
{
    [JsonPropertyName("checkouts"), Required]
    public IEnumerable<AbandonedCheckout> AbandonedCheckouts { get; set; } = null!;
}
public partial record CreateAbandonedCheckoutRequest
{
    [JsonPropertyName("checkout"), Required]
    public CreateAbandonedCheckout AbandonedCheckout { get; set; } = null!;
}

/// <inheritdoc cref="AbandonedCheckoutBase"/>
public partial record CreateAbandonedCheckout : AbandonedCheckoutBase {}
public partial record UpdateAbandonedCheckoutRequest
{
    [JsonPropertyName("checkout"), Required]
    public UpdateAbandonedCheckout AbandonedCheckout { get; set; } = null!;
}

/// <inheritdoc cref="AbandonedCheckout"/>
public partial record UpdateAbandonedCheckout : AbandonedCheckout
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="AbandonedCheckoutBase"/>
public partial record AbandonedCheckout : AbandonedCheckoutBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CheckoutBase"/>
public partial record AbandonedCheckoutBase : CheckoutBase{}

	
public partial record DraftOrderItem
{
    [JsonPropertyName("draft_order"), Required]
    public DraftOrder DraftOrder { get; set; } = null!;
}

public partial record DraftOrderList
{
    [JsonPropertyName("draft_orders"), Required]
    public IEnumerable<DraftOrder> DraftOrders { get; set; } = null!;
}
public partial record CreateDraftOrderRequest
{
    [JsonPropertyName("draft_order"), Required]
    public CreateDraftOrder DraftOrder { get; set; } = null!;
}

/// <inheritdoc cref="DraftOrderBase"/>
public partial record CreateDraftOrder : DraftOrderBase {}
public partial record UpdateDraftOrderRequest
{
    [JsonPropertyName("draft_order"), Required]
    public UpdateDraftOrder DraftOrder { get; set; } = null!;
}

/// <inheritdoc cref="DraftOrder"/>
public partial record UpdateDraftOrder : DraftOrder
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="DraftOrderBase"/>
public partial record DraftOrder : DraftOrderBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="DraftOrderOrig"/>
public partial record DraftOrderBase : DraftOrderOrig{}

	
public partial record DraftOrderInvoiceItem
{
    [JsonPropertyName("draft_order_invoice"), Required]
    public DraftOrderInvoice DraftOrderInvoice { get; set; } = null!;
}

public partial record DraftOrderInvoiceList
{
    [JsonPropertyName("draft_order_invoices"), Required]
    public IEnumerable<DraftOrderInvoice> DraftOrderInvoices { get; set; } = null!;
}
		
/// <inheritdoc cref="DraftOrderInvoiceBase"/>
public partial record DraftOrderInvoice : DraftOrderInvoiceBase
{
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="DraftOrderInvoiceOrig"/>
public partial record DraftOrderInvoiceBase : DraftOrderInvoiceOrig{}

	
public partial record OrderItem
{
    [JsonPropertyName("order"), Required]
    public Order Order { get; set; } = null!;
}

public partial record OrderList
{
    [JsonPropertyName("orders"), Required]
    public IEnumerable<Order> Orders { get; set; } = null!;
}
public partial record CreateOrderRequest
{
    [JsonPropertyName("order"), Required]
    public CreateOrder Order { get; set; } = null!;
}

/// <inheritdoc cref="OrderBase"/>
public partial record CreateOrder : OrderBase {}
public partial record UpdateOrderRequest
{
    [JsonPropertyName("order"), Required]
    public UpdateOrder Order { get; set; } = null!;
}

/// <inheritdoc cref="Order"/>
public partial record UpdateOrder : Order
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="OrderBase"/>
public partial record Order : OrderBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="OrderOrig"/>
public partial record OrderBase : OrderOrig{}

	
public partial record OrderRiskItem
{
    [JsonPropertyName("risk"), Required]
    public OrderRisk OrderRisk { get; set; } = null!;
}

public partial record OrderRiskList
{
    [JsonPropertyName("risks"), Required]
    public IEnumerable<OrderRisk> OrderRisks { get; set; } = null!;
}
public partial record CreateOrderRiskRequest
{
    [JsonPropertyName("risk"), Required]
    public CreateOrderRisk OrderRisk { get; set; } = null!;
}

/// <inheritdoc cref="OrderRiskBase"/>
public partial record CreateOrderRisk : OrderRiskBase {}
public partial record UpdateOrderRiskRequest
{
    [JsonPropertyName("risk"), Required]
    public UpdateOrderRisk OrderRisk { get; set; } = null!;
}

/// <inheritdoc cref="OrderRisk"/>
public partial record UpdateOrderRisk : OrderRisk
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="OrderRiskBase"/>
public partial record OrderRisk : OrderRiskBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="OrderRiskOrig"/>
public partial record OrderRiskBase : OrderRiskOrig{}

	
public partial record RefundItem
{
    [JsonPropertyName("refund"), Required]
    public Refund Refund { get; set; } = null!;
}

public partial record RefundList
{
    [JsonPropertyName("refunds"), Required]
    public IEnumerable<Refund> Refunds { get; set; } = null!;
}
public partial record CreateRefundRequest
{
    [JsonPropertyName("refund"), Required]
    public CreateRefund Refund { get; set; } = null!;
}

/// <inheritdoc cref="RefundBase"/>
public partial record CreateRefund : RefundBase {}
public partial record UpdateRefundRequest
{
    [JsonPropertyName("refund"), Required]
    public UpdateRefund Refund { get; set; } = null!;
}

/// <inheritdoc cref="Refund"/>
public partial record UpdateRefund : Refund
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="RefundBase"/>
public partial record Refund : RefundBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="RefundOrig"/>
public partial record RefundBase : RefundOrig{}

	
public partial record TransactionItem
{
    [JsonPropertyName("transaction"), Required]
    public Transaction Transaction { get; set; } = null!;
}

public partial record TransactionList
{
    [JsonPropertyName("transactions"), Required]
    public IEnumerable<Transaction> Transactions { get; set; } = null!;
}
public partial record CreateTransactionRequest
{
    [JsonPropertyName("transaction"), Required]
    public CreateTransaction Transaction { get; set; } = null!;
}

/// <inheritdoc cref="TransactionBase"/>
public partial record CreateTransaction : TransactionBase {}
public partial record UpdateTransactionRequest
{
    [JsonPropertyName("transaction"), Required]
    public UpdateTransaction Transaction { get; set; } = null!;
}

/// <inheritdoc cref="Transaction"/>
public partial record UpdateTransaction : Transaction
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="TransactionBase"/>
public partial record Transaction : TransactionBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="TransactionOrig"/>
public partial record TransactionBase : TransactionOrig{}

	
public partial record TransactionForOrderItem
{
    [JsonPropertyName("transaction"), Required]
    public Transaction TransactionForOrder { get; set; } = null!;
}

public partial record TransactionForOrderList
{
    [JsonPropertyName("transactions"), Required]
    public IEnumerable<Transaction> Transactions { get; set; } = null!;
}
public partial record CreateTransactionForOrderRequest
{
    [JsonPropertyName("transaction"), Required]
    public CreateTransactionForOrder TransactionForOrder { get; set; } = null!;
}

/// <inheritdoc cref="TransactionBase"/>
public partial record CreateTransactionForOrder : TransactionBase {}
public partial record UpdateTransactionForOrderRequest
{
    [JsonPropertyName("transaction"), Required]
    public UpdateTransactionForOrder TransactionForOrder { get; set; } = null!;
}

/// <inheritdoc cref="Transaction"/>
public partial record UpdateTransactionForOrder : Transaction
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="TransactionBase"/>
public partial record TransactionForOrder : TransactionBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="TransactionOrig"/>
public partial record TransactionBase : TransactionOrig{}

	
public partial record TransactionOfOrItem
{
    [JsonPropertyName("transaction"), Required]
    public Transaction TransactionOfOr { get; set; } = null!;
}

public partial record TransactionOfOrList
{
    [JsonPropertyName("transactions"), Required]
    public IEnumerable<Transaction> Transactions { get; set; } = null!;
}
public partial record CreateTransactionOfOrRequest
{
    [JsonPropertyName("transaction"), Required]
    public CreateTransactionOfOr TransactionOfOr { get; set; } = null!;
}

/// <inheritdoc cref="TransactionBase"/>
public partial record CreateTransactionOfOr : TransactionBase {}
public partial record UpdateTransactionOfOrRequest
{
    [JsonPropertyName("transaction"), Required]
    public UpdateTransactionOfOr TransactionOfOr { get; set; } = null!;
}

/// <inheritdoc cref="Transaction"/>
public partial record UpdateTransactionOfOr : Transaction
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="TransactionBase"/>
public partial record TransactionOfOr : TransactionBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="TransactionOrig"/>
public partial record TransactionBase : TransactionOrig{}

	
public partial record GiftCardItem
{
    [JsonPropertyName("gift_card"), Required]
    public GiftCard GiftCard { get; set; } = null!;
}

public partial record GiftCardList
{
    [JsonPropertyName("gift_cards"), Required]
    public IEnumerable<GiftCard> GiftCards { get; set; } = null!;
}
public partial record CreateGiftCardRequest
{
    [JsonPropertyName("gift_card"), Required]
    public CreateGiftCard GiftCard { get; set; } = null!;
}

/// <inheritdoc cref="GiftCardBase"/>
public partial record CreateGiftCard : GiftCardBase {}
public partial record UpdateGiftCardRequest
{
    [JsonPropertyName("gift_card"), Required]
    public UpdateGiftCard GiftCard { get; set; } = null!;
}

/// <inheritdoc cref="GiftCard"/>
public partial record UpdateGiftCard : GiftCard
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="GiftCardBase"/>
public partial record GiftCard : GiftCardBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="GiftCardOrig"/>
public partial record GiftCardBase : GiftCardOrig{}

	
public partial record UserItem
{
    [JsonPropertyName("user"), Required]
    public User User { get; set; } = null!;
}

public partial record UserList
{
    [JsonPropertyName("users"), Required]
    public IEnumerable<User> Users { get; set; } = null!;
}
public partial record CreateUserRequest
{
    [JsonPropertyName("user"), Required]
    public CreateUser User { get; set; } = null!;
}

/// <inheritdoc cref="UserBase"/>
public partial record CreateUser : UserBase {}
public partial record UpdateUserRequest
{
    [JsonPropertyName("user"), Required]
    public UpdateUser User { get; set; } = null!;
}

/// <inheritdoc cref="User"/>
public partial record UpdateUser : User
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="UserBase"/>
public partial record User : UserBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="UserOrig"/>
public partial record UserBase : UserOrig{}

	
public partial record CollectItem
{
    [JsonPropertyName("collect"), Required]
    public Collect Collect { get; set; } = null!;
}

public partial record CollectList
{
    [JsonPropertyName("collects"), Required]
    public IEnumerable<Collect> Collects { get; set; } = null!;
}
public partial record CreateCollectRequest
{
    [JsonPropertyName("collect"), Required]
    public CreateCollect Collect { get; set; } = null!;
}

/// <inheritdoc cref="CollectBase"/>
public partial record CreateCollect : CollectBase {}
public partial record UpdateCollectRequest
{
    [JsonPropertyName("collect"), Required]
    public UpdateCollect Collect { get; set; } = null!;
}

/// <inheritdoc cref="Collect"/>
public partial record UpdateCollect : Collect
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CollectBase"/>
public partial record Collect : CollectBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CollectOrig"/>
public partial record CollectBase : CollectOrig{}

	
public partial record CollectionItem
{
    [JsonPropertyName("collection"), Required]
    public Collection Collection { get; set; } = null!;
}

public partial record CollectionList
{
    [JsonPropertyName("collections"), Required]
    public IEnumerable<Collection> Collections { get; set; } = null!;
}
public partial record CreateCollectionRequest
{
    [JsonPropertyName("collection"), Required]
    public CreateCollection Collection { get; set; } = null!;
}

/// <inheritdoc cref="CollectionBase"/>
public partial record CreateCollection : CollectionBase {}
public partial record UpdateCollectionRequest
{
    [JsonPropertyName("collection"), Required]
    public UpdateCollection Collection { get; set; } = null!;
}

/// <inheritdoc cref="Collection"/>
public partial record UpdateCollection : Collection
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CollectionBase"/>
public partial record Collection : CollectionBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CollectionOrig"/>
public partial record CollectionBase : CollectionOrig{}

	
public partial record CustomCollectionItem
{
    [JsonPropertyName("custom_collection"), Required]
    public CustomCollection CustomCollection { get; set; } = null!;
}

public partial record CustomCollectionList
{
    [JsonPropertyName("custom_collections"), Required]
    public IEnumerable<CustomCollection> CustomCollections { get; set; } = null!;
}
public partial record CreateCustomCollectionRequest
{
    [JsonPropertyName("custom_collection"), Required]
    public CreateCustomCollection CustomCollection { get; set; } = null!;
}

/// <inheritdoc cref="CustomCollectionBase"/>
public partial record CreateCustomCollection : CustomCollectionBase {}
public partial record UpdateCustomCollectionRequest
{
    [JsonPropertyName("custom_collection"), Required]
    public UpdateCustomCollection CustomCollection { get; set; } = null!;
}

/// <inheritdoc cref="CustomCollection"/>
public partial record UpdateCustomCollection : CustomCollection
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CustomCollectionBase"/>
public partial record CustomCollection : CustomCollectionBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CustomCollectionOrig"/>
public partial record CustomCollectionBase : CustomCollectionOrig{}

	
public partial record ProductItem
{
    [JsonPropertyName("product"), Required]
    public Product Product { get; set; } = null!;
}

public partial record ProductList
{
    [JsonPropertyName("products"), Required]
    public IEnumerable<Product> Products { get; set; } = null!;
}
public partial record CreateProductRequest
{
    [JsonPropertyName("product"), Required]
    public CreateProduct Product { get; set; } = null!;
}

/// <inheritdoc cref="ProductBase"/>
public partial record CreateProduct : ProductBase {}
public partial record UpdateProductRequest
{
    [JsonPropertyName("product"), Required]
    public UpdateProduct Product { get; set; } = null!;
}

/// <inheritdoc cref="Product"/>
public partial record UpdateProduct : Product
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ProductBase"/>
public partial record Product : ProductBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ProductOrig"/>
public partial record ProductBase : ProductOrig{}

	
public partial record ProductImageItem
{
    [JsonPropertyName("image"), Required]
    public ProductImage ProductImage { get; set; } = null!;
}

public partial record ProductImageList
{
    [JsonPropertyName("images"), Required]
    public IEnumerable<ProductImage> ProductImages { get; set; } = null!;
}
public partial record CreateProductImageRequest
{
    [JsonPropertyName("image"), Required]
    public CreateProductImage ProductImage { get; set; } = null!;
}

/// <inheritdoc cref="ProductImageBase"/>
public partial record CreateProductImage : ProductImageBase {}
public partial record UpdateProductImageRequest
{
    [JsonPropertyName("image"), Required]
    public UpdateProductImage ProductImage { get; set; } = null!;
}

/// <inheritdoc cref="ProductImage"/>
public partial record UpdateProductImage : ProductImage
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ProductImageBase"/>
public partial record ProductImage : ProductImageBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ProductImageOrig"/>
public partial record ProductImageBase : ProductImageOrig{}

	
public partial record ProductVariantItem
{
    [JsonPropertyName("variant"), Required]
    public ProductVariant ProductVariant { get; set; } = null!;
}

public partial record ProductVariantList
{
    [JsonPropertyName("variants"), Required]
    public IEnumerable<ProductVariant> ProductVariants { get; set; } = null!;
}
public partial record CreateProductVariantRequest
{
    [JsonPropertyName("variant"), Required]
    public CreateProductVariant ProductVariant { get; set; } = null!;
}

/// <inheritdoc cref="ProductVariantBase"/>
public partial record CreateProductVariant : ProductVariantBase {}
public partial record UpdateProductVariantRequest
{
    [JsonPropertyName("variant"), Required]
    public UpdateProductVariant ProductVariant { get; set; } = null!;
}

/// <inheritdoc cref="ProductVariant"/>
public partial record UpdateProductVariant : ProductVariant
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ProductVariantBase"/>
public partial record ProductVariant : ProductVariantBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ProductVariantOrig"/>
public partial record ProductVariantBase : ProductVariantOrig{}

	
public partial record SmartCollectionItem
{
    [JsonPropertyName("smart_collection"), Required]
    public SmartCollection SmartCollection { get; set; } = null!;
}

public partial record SmartCollectionList
{
    [JsonPropertyName("smart_collections"), Required]
    public IEnumerable<SmartCollection> SmartCollections { get; set; } = null!;
}
public partial record CreateSmartCollectionRequest
{
    [JsonPropertyName("smart_collection"), Required]
    public CreateSmartCollection SmartCollection { get; set; } = null!;
}

/// <inheritdoc cref="SmartCollectionBase"/>
public partial record CreateSmartCollection : SmartCollectionBase {}
public partial record UpdateSmartCollectionRequest
{
    [JsonPropertyName("smart_collection"), Required]
    public UpdateSmartCollection SmartCollection { get; set; } = null!;
}

/// <inheritdoc cref="SmartCollection"/>
public partial record UpdateSmartCollection : SmartCollection
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="SmartCollectionBase"/>
public partial record SmartCollection : SmartCollectionBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="SmartCollectionOrig"/>
public partial record SmartCollectionBase : SmartCollectionOrig{}

	
public partial record CheckoutItem
{
    [JsonPropertyName("checkout"), Required]
    public Checkout Checkout { get; set; } = null!;
}

public partial record CheckoutList
{
    [JsonPropertyName("checkouts"), Required]
    public IEnumerable<Checkout> Checkouts { get; set; } = null!;
}
public partial record CreateCheckoutRequest
{
    [JsonPropertyName("checkout"), Required]
    public CreateCheckout Checkout { get; set; } = null!;
}

/// <inheritdoc cref="CheckoutBase"/>
public partial record CreateCheckout : CheckoutBase {}
public partial record UpdateCheckoutRequest
{
    [JsonPropertyName("checkout"), Required]
    public UpdateCheckout Checkout { get; set; } = null!;
}

/// <inheritdoc cref="Checkout"/>
public partial record UpdateCheckout : Checkout
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CheckoutBase"/>
public partial record Checkout : CheckoutBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CheckoutOrig"/>
public partial record CheckoutBase : CheckoutOrig{}

	
public partial record CollectionListingItem
{
    [JsonPropertyName("collection_listing"), Required]
    public CollectionListing CollectionListing { get; set; } = null!;
}

public partial record CollectionListingList
{
    [JsonPropertyName("collection_listings"), Required]
    public IEnumerable<CollectionListing> CollectionListings { get; set; } = null!;
}
public partial record CreateCollectionListingRequest
{
    [JsonPropertyName("collection_listing"), Required]
    public CreateCollectionListing CollectionListing { get; set; } = null!;
}

/// <inheritdoc cref="CollectionListingBase"/>
public partial record CreateCollectionListing : CollectionListingBase {}
public partial record UpdateCollectionListingRequest
{
    [JsonPropertyName("collection_listing"), Required]
    public UpdateCollectionListing CollectionListing { get; set; } = null!;
}

/// <inheritdoc cref="CollectionListing"/>
public partial record UpdateCollectionListing : CollectionListing
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CollectionListingBase"/>
public partial record CollectionListing : CollectionListingBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CollectionListingOrig"/>
public partial record CollectionListingBase : CollectionListingOrig{}

	
public partial record MobilePlatformApplicationItem
{
    [JsonPropertyName("mobile_platform_application"), Required]
    public MobilePlatformApplication MobilePlatformApplication { get; set; } = null!;
}

public partial record MobilePlatformApplicationList
{
    [JsonPropertyName("mobile_platform_applications"), Required]
    public IEnumerable<MobilePlatformApplication> MobilePlatformApplications { get; set; } = null!;
}
public partial record CreateMobilePlatformApplicationRequest
{
    [JsonPropertyName("mobile_platform_application"), Required]
    public CreateMobilePlatformApplication MobilePlatformApplication { get; set; } = null!;
}

/// <inheritdoc cref="MobilePlatformApplicationBase"/>
public partial record CreateMobilePlatformApplication : MobilePlatformApplicationBase {}
public partial record UpdateMobilePlatformApplicationRequest
{
    [JsonPropertyName("mobile_platform_application"), Required]
    public UpdateMobilePlatformApplication MobilePlatformApplication { get; set; } = null!;
}

/// <inheritdoc cref="MobilePlatformApplication"/>
public partial record UpdateMobilePlatformApplication : MobilePlatformApplication
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="MobilePlatformApplicationBase"/>
public partial record MobilePlatformApplication : MobilePlatformApplicationBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="MobilePlatformApplicationOrig"/>
public partial record MobilePlatformApplicationBase : MobilePlatformApplicationOrig{}

	
public partial record PaymentItem
{
    [JsonPropertyName("payment"), Required]
    public Payment Payment { get; set; } = null!;
}

public partial record PaymentList
{
    [JsonPropertyName("payments"), Required]
    public IEnumerable<Payment> Payments { get; set; } = null!;
}
public partial record CreatePaymentRequest
{
    [JsonPropertyName("payment"), Required]
    public CreatePayment Payment { get; set; } = null!;
}

/// <inheritdoc cref="PaymentBase"/>
public partial record CreatePayment : PaymentBase {}
public partial record UpdatePaymentRequest
{
    [JsonPropertyName("payment"), Required]
    public UpdatePayment Payment { get; set; } = null!;
}

/// <inheritdoc cref="Payment"/>
public partial record UpdatePayment : Payment
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="PaymentBase"/>
public partial record Payment : PaymentBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="PaymentOrig"/>
public partial record PaymentBase : PaymentOrig{}

	
public partial record ProductResourceFeedbackItem
{
    [JsonPropertyName("product_resource_feedback"), Required]
    public ProductResourceFeedback ProductResourceFeedback { get; set; } = null!;
}

public partial record ProductResourceFeedbackList
{
    [JsonPropertyName("product_resource_feedbacks"), Required]
    public IEnumerable<ProductResourceFeedback> ProductResourceFeedbacks { get; set; } = null!;
}
public partial record CreateProductResourceFeedbackRequest
{
    [JsonPropertyName("product_resource_feedback"), Required]
    public CreateProductResourceFeedback ProductResourceFeedback { get; set; } = null!;
}

/// <inheritdoc cref="ProductResourceFeedbackBase"/>
public partial record CreateProductResourceFeedback : ProductResourceFeedbackBase {}
public partial record UpdateProductResourceFeedbackRequest
{
    [JsonPropertyName("product_resource_feedback"), Required]
    public UpdateProductResourceFeedback ProductResourceFeedback { get; set; } = null!;
}

/// <inheritdoc cref="ProductResourceFeedback"/>
public partial record UpdateProductResourceFeedback : ProductResourceFeedback
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ProductResourceFeedbackBase"/>
public partial record ProductResourceFeedback : ProductResourceFeedbackBase
{
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ProductResourceFeedbackOrig"/>
public partial record ProductResourceFeedbackBase : ProductResourceFeedbackOrig{}

	
public partial record ProductListingItem
{
    [JsonPropertyName("product_listing"), Required]
    public ProductListing ProductListing { get; set; } = null!;
}

public partial record ProductListingList
{
    [JsonPropertyName("product_listings"), Required]
    public IEnumerable<ProductListing> ProductListings { get; set; } = null!;
}
public partial record CreateProductListingRequest
{
    [JsonPropertyName("product_listing"), Required]
    public CreateProductListing ProductListing { get; set; } = null!;
}

/// <inheritdoc cref="ProductListingBase"/>
public partial record CreateProductListing : ProductListingBase {}
public partial record UpdateProductListingRequest
{
    [JsonPropertyName("product_listing"), Required]
    public UpdateProductListing ProductListing { get; set; } = null!;
}

/// <inheritdoc cref="ProductListing"/>
public partial record UpdateProductListing : ProductListing
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ProductListingBase"/>
public partial record ProductListing : ProductListingBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ProductListingOrig"/>
public partial record ProductListingBase : ProductListingOrig{}

	
public partial record ResourceFeedbackItem
{
    [JsonPropertyName("resource_feedback"), Required]
    public ResourceFeedback ResourceFeedback { get; set; } = null!;
}

public partial record ResourceFeedbackList
{
    [JsonPropertyName("resource_feedback"), Required]
    public IEnumerable<ResourceFeedback> ResourceFeedbacks { get; set; } = null!;
}
public partial record CreateResourceFeedbackRequest
{
    [JsonPropertyName("resource_feedback"), Required]
    public CreateResourceFeedback ResourceFeedback { get; set; } = null!;
}

/// <inheritdoc cref="ResourceFeedbackBase"/>
public partial record CreateResourceFeedback : ResourceFeedbackBase {}
public partial record UpdateResourceFeedbackRequest
{
    [JsonPropertyName("resource_feedback"), Required]
    public UpdateResourceFeedback ResourceFeedback { get; set; } = null!;
}

/// <inheritdoc cref="ResourceFeedback"/>
public partial record UpdateResourceFeedback : ResourceFeedback
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ResourceFeedbackBase"/>
public partial record ResourceFeedback : ResourceFeedbackBase
{
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ResourceFeedbackOrig"/>
public partial record ResourceFeedbackBase : ResourceFeedbackOrig{}

	
public partial record AssignedFulfillmentOrderItem
{
    [JsonPropertyName("fulfillment_order"), Required]
    public FulfillmentOrder AssignedFulfillmentOrder { get; set; } = null!;
}

public partial record AssignedFulfillmentOrderList
{
    [JsonPropertyName("fulfillment_orders"), Required]
    public IEnumerable<FulfillmentOrder> AssignedFulfillmentOrders { get; set; } = null!;
}
public partial record CreateAssignedFulfillmentOrderRequest
{
    [JsonPropertyName("fulfillment_order"), Required]
    public CreateAssignedFulfillmentOrder AssignedFulfillmentOrder { get; set; } = null!;
}

/// <inheritdoc cref="FulfillmentOrderBase"/>
public partial record CreateAssignedFulfillmentOrder : FulfillmentOrderBase {}
public partial record UpdateAssignedFulfillmentOrderRequest
{
    [JsonPropertyName("fulfillment_order"), Required]
    public UpdateAssignedFulfillmentOrder AssignedFulfillmentOrder { get; set; } = null!;
}

/// <inheritdoc cref="FulfillmentOrder"/>
public partial record UpdateAssignedFulfillmentOrder : FulfillmentOrder
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="FulfillmentOrderBase"/>
public partial record AssignedFulfillmentOrder : FulfillmentOrderBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="FulfillmentOrderOrig"/>
public partial record FulfillmentOrderBase : FulfillmentOrderOrig{}

	
public partial record CarrierServiceItem
{
    [JsonPropertyName("carrier_service"), Required]
    public CarrierService CarrierService { get; set; } = null!;
}

public partial record CarrierServiceList
{
    [JsonPropertyName("carrier_services"), Required]
    public IEnumerable<CarrierService> CarrierServices { get; set; } = null!;
}
public partial record CreateCarrierServiceRequest
{
    [JsonPropertyName("carrier_service"), Required]
    public CreateCarrierService CarrierService { get; set; } = null!;
}

/// <inheritdoc cref="CarrierServiceBase"/>
public partial record CreateCarrierService : CarrierServiceBase {}
public partial record UpdateCarrierServiceRequest
{
    [JsonPropertyName("carrier_service"), Required]
    public UpdateCarrierService CarrierService { get; set; } = null!;
}

/// <inheritdoc cref="CarrierService"/>
public partial record UpdateCarrierService : CarrierService
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CarrierServiceBase"/>
public partial record CarrierService : CarrierServiceBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CarrierServiceOrig"/>
public partial record CarrierServiceBase : CarrierServiceOrig{}

	
public partial record FulfillmentItem
{
    [JsonPropertyName("fulfillment"), Required]
    public Fulfillment Fulfillment { get; set; } = null!;
}

public partial record FulfillmentList
{
    [JsonPropertyName("fulfillments"), Required]
    public IEnumerable<Fulfillment> Fulfillments { get; set; } = null!;
}
public partial record CreateFulfillmentRequest
{
    [JsonPropertyName("fulfillment"), Required]
    public CreateFulfillment Fulfillment { get; set; } = null!;
}

/// <inheritdoc cref="FulfillmentBase"/>
public partial record CreateFulfillment : FulfillmentBase {}
public partial record UpdateFulfillmentRequest
{
    [JsonPropertyName("fulfillment"), Required]
    public UpdateFulfillment Fulfillment { get; set; } = null!;
}

/// <inheritdoc cref="Fulfillment"/>
public partial record UpdateFulfillment : Fulfillment
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="FulfillmentBase"/>
public partial record Fulfillment : FulfillmentBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="FulfillmentOrig"/>
public partial record FulfillmentBase : FulfillmentOrig{}

	
public partial record FulfillmentForOneOrManyFulfillmentOrdersItem
{
    [JsonPropertyName("fulfillment"), Required]
    public FulfillmentForOneOrManyFulfillmentOrders FulfillmentForOneOrManyFulfillmentOrders { get; set; } = null!;
}

public partial record FulfillmentForOneOrManyFulfillmentOrdersList
{
    [JsonPropertyName("fulfillments"), Required]
    public IEnumerable<FulfillmentForOneOrManyFulfillmentOrders> FulfillmentForOneOrManyFulfillmentOrderss { get; set; } = null!;
}
public partial record CreateFulfillmentForOneOrManyFulfillmentOrdersRequest
{
    [JsonPropertyName("fulfillment"), Required]
    public CreateFulfillmentForOneOrManyFulfillmentOrders FulfillmentForOneOrManyFulfillmentOrders { get; set; } = null!;
}

/// <inheritdoc cref="FulfillmentForOneOrManyFulfillmentOrdersBase"/>
public partial record CreateFulfillmentForOneOrManyFulfillmentOrders : FulfillmentForOneOrManyFulfillmentOrdersBase {}
public partial record UpdateFulfillmentForOneOrManyFulfillmentOrdersRequest
{
    [JsonPropertyName("fulfillment"), Required]
    public UpdateFulfillmentForOneOrManyFulfillmentOrders FulfillmentForOneOrManyFulfillmentOrders { get; set; } = null!;
}

/// <inheritdoc cref="FulfillmentForOneOrManyFulfillmentOrders"/>
public partial record UpdateFulfillmentForOneOrManyFulfillmentOrders : FulfillmentForOneOrManyFulfillmentOrders
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="FulfillmentForOneOrManyFulfillmentOrdersBase"/>
public partial record FulfillmentForOneOrManyFulfillmentOrders : FulfillmentForOneOrManyFulfillmentOrdersBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="FulfillmentForOneOrManyFulfillmentOrdersOrig"/>
public partial record FulfillmentForOneOrManyFulfillmentOrdersBase : FulfillmentForOneOrManyFulfillmentOrdersOrig{}

	
public partial record FulfillmentEventItem
{
    [JsonPropertyName("fulfillment_event"), Required]
    public FulfillmentEvent FulfillmentEvent { get; set; } = null!;
}

public partial record FulfillmentEventList
{
    [JsonPropertyName("fulfillment_events"), Required]
    public IEnumerable<FulfillmentEvent> FulfillmentEvents { get; set; } = null!;
}
		
/// <inheritdoc cref="FulfillmentEventBase"/>
public partial record FulfillmentEvent : FulfillmentEventBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="FulfillmentEventOrig"/>
public partial record FulfillmentEventBase : FulfillmentEventOrig{}

	
public partial record FulfillmentOrderItem
{
    [JsonPropertyName("fulfillment_order"), Required]
    public FulfillmentOrder FulfillmentOrder { get; set; } = null!;
}

public partial record FulfillmentOrderList
{
    [JsonPropertyName("fulfillment_orders"), Required]
    public IEnumerable<FulfillmentOrder> FulfillmentOrders { get; set; } = null!;
}
public partial record CreateFulfillmentOrderRequest
{
    [JsonPropertyName("fulfillment_order"), Required]
    public CreateFulfillmentOrder FulfillmentOrder { get; set; } = null!;
}

/// <inheritdoc cref="FulfillmentOrderBase"/>
public partial record CreateFulfillmentOrder : FulfillmentOrderBase {}
public partial record UpdateFulfillmentOrderRequest
{
    [JsonPropertyName("fulfillment_order"), Required]
    public UpdateFulfillmentOrder FulfillmentOrder { get; set; } = null!;
}

/// <inheritdoc cref="FulfillmentOrder"/>
public partial record UpdateFulfillmentOrder : FulfillmentOrder
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="FulfillmentOrderBase"/>
public partial record FulfillmentOrder : FulfillmentOrderBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="FulfillmentOrderOrig"/>
public partial record FulfillmentOrderBase : FulfillmentOrderOrig{}

	
public partial record FulfillmentServiceItem
{
    [JsonPropertyName("fulfillment_service"), Required]
    public FulfillmentService FulfillmentService { get; set; } = null!;
}

public partial record FulfillmentServiceList
{
    [JsonPropertyName("fulfillment_services"), Required]
    public IEnumerable<FulfillmentService> FulfillmentServices { get; set; } = null!;
}
public partial record CreateFulfillmentServiceRequest
{
    [JsonPropertyName("fulfillment_service"), Required]
    public CreateFulfillmentService FulfillmentService { get; set; } = null!;
}

/// <inheritdoc cref="FulfillmentServiceBase"/>
public partial record CreateFulfillmentService : FulfillmentServiceBase {}
public partial record UpdateFulfillmentServiceRequest
{
    [JsonPropertyName("fulfillment_service"), Required]
    public UpdateFulfillmentService FulfillmentService { get; set; } = null!;
}

/// <inheritdoc cref="FulfillmentService"/>
public partial record UpdateFulfillmentService : FulfillmentService
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="FulfillmentServiceBase"/>
public partial record FulfillmentService : FulfillmentServiceBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="FulfillmentServiceOrig"/>
public partial record FulfillmentServiceBase : FulfillmentServiceOrig{}

	
public partial record LocationsForMoveItem
{
    [JsonPropertyName("locations_for_move"), Required]
    public LocationsForMove LocationsForMove { get; set; } = null!;
}

public partial record LocationsForMoveList
{
    [JsonPropertyName("locations_for_move"), Required]
    public IEnumerable<LocationsForMove> LocationsForMoves { get; set; } = null!;
}
public partial record CreateLocationsForMoveRequest
{
    [JsonPropertyName("locations_for_move"), Required]
    public CreateLocationsForMove LocationsForMove { get; set; } = null!;
}

/// <inheritdoc cref="LocationsForMoveBase"/>
public partial record CreateLocationsForMove : LocationsForMoveBase {}
public partial record UpdateLocationsForMoveRequest
{
    [JsonPropertyName("locations_for_move"), Required]
    public UpdateLocationsForMove LocationsForMove { get; set; } = null!;
}

/// <inheritdoc cref="LocationsForMove"/>
public partial record UpdateLocationsForMove : LocationsForMove
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="LocationsForMoveBase"/>
public partial record LocationsForMove : LocationsForMoveBase
{
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="LocationsForMoveOrig"/>
public partial record LocationsForMoveBase : LocationsForMoveOrig{}

	
public partial record BalanceItem
{
    [JsonPropertyName("balance"), Required]
    public Balance Balance { get; set; } = null!;
}

public partial record BalanceList
{
    [JsonPropertyName("balance"), Required]
    public IEnumerable<Balance> Balances { get; set; } = null!;
}
public partial record CreateBalanceRequest
{
    [JsonPropertyName("balance"), Required]
    public CreateBalance Balance { get; set; } = null!;
}

/// <inheritdoc cref="BalanceBase"/>
public partial record CreateBalance : BalanceBase {}
public partial record UpdateBalanceRequest
{
    [JsonPropertyName("balance"), Required]
    public UpdateBalance Balance { get; set; } = null!;
}

/// <inheritdoc cref="Balance"/>
public partial record UpdateBalance : Balance
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="BalanceBase"/>
public partial record Balance : BalanceBase
{
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="BalanceOrig"/>
public partial record BalanceBase : BalanceOrig{}

	
public partial record DisputeItem
{
    [JsonPropertyName("dispute"), Required]
    public Dispute Dispute { get; set; } = null!;
}

public partial record DisputeList
{
    [JsonPropertyName("disputes"), Required]
    public IEnumerable<Dispute> Disputes { get; set; } = null!;
}
public partial record CreateDisputeRequest
{
    [JsonPropertyName("dispute"), Required]
    public CreateDispute Dispute { get; set; } = null!;
}

/// <inheritdoc cref="DisputeBase"/>
public partial record CreateDispute : DisputeBase {}
public partial record UpdateDisputeRequest
{
    [JsonPropertyName("dispute"), Required]
    public UpdateDispute Dispute { get; set; } = null!;
}

/// <inheritdoc cref="Dispute"/>
public partial record UpdateDispute : Dispute
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="DisputeBase"/>
public partial record Dispute : DisputeBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="DisputeOrig"/>
public partial record DisputeBase : DisputeOrig{}

	
public partial record DisputeEvidenceItem
{
    [JsonPropertyName("dispute_evidence"), Required]
    public DisputeEvidence DisputeEvidence { get; set; } = null!;
}

public partial record DisputeEvidenceList
{
    [JsonPropertyName("dispute_evidences"), Required]
    public IEnumerable<DisputeEvidence> DisputeEvidences { get; set; } = null!;
}
public partial record CreateDisputeEvidenceRequest
{
    [JsonPropertyName("dispute_evidence"), Required]
    public CreateDisputeEvidence DisputeEvidence { get; set; } = null!;
}

/// <inheritdoc cref="DisputeEvidenceBase"/>
public partial record CreateDisputeEvidence : DisputeEvidenceBase {}
public partial record UpdateDisputeEvidenceRequest
{
    [JsonPropertyName("dispute_evidence"), Required]
    public UpdateDisputeEvidence DisputeEvidence { get; set; } = null!;
}

/// <inheritdoc cref="DisputeEvidence"/>
public partial record UpdateDisputeEvidence : DisputeEvidence
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="DisputeEvidenceBase"/>
public partial record DisputeEvidence : DisputeEvidenceBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="DisputeEvidenceOrig"/>
public partial record DisputeEvidenceBase : DisputeEvidenceOrig{}

	
public partial record DisputeFileUploadItem
{
    [JsonPropertyName("dispute_file_upload"), Required]
    public DisputeFileUpload DisputeFileUpload { get; set; } = null!;
}

public partial record DisputeFileUploadList
{
    [JsonPropertyName("dispute_file_uploads"), Required]
    public IEnumerable<DisputeFileUpload> DisputeFileUploads { get; set; } = null!;
}
public partial record CreateDisputeFileUploadRequest
{
    [JsonPropertyName("dispute_file_upload"), Required]
    public CreateDisputeFileUpload DisputeFileUpload { get; set; } = null!;
}

/// <inheritdoc cref="DisputeFileUploadBase"/>
public partial record CreateDisputeFileUpload : DisputeFileUploadBase {}
public partial record UpdateDisputeFileUploadRequest
{
    [JsonPropertyName("dispute_file_upload"), Required]
    public UpdateDisputeFileUpload DisputeFileUpload { get; set; } = null!;
}

/// <inheritdoc cref="DisputeFileUpload"/>
public partial record UpdateDisputeFileUpload : DisputeFileUpload
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="DisputeFileUploadBase"/>
public partial record DisputeFileUpload : DisputeFileUploadBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="DisputeFileUploadOrig"/>
public partial record DisputeFileUploadBase : DisputeFileUploadOrig{}

	
public partial record PayoutItem
{
    [JsonPropertyName("payout"), Required]
    public Payout Payout { get; set; } = null!;
}

public partial record PayoutList
{
    [JsonPropertyName("payouts"), Required]
    public IEnumerable<Payout> Payouts { get; set; } = null!;
}
public partial record CreatePayoutRequest
{
    [JsonPropertyName("payout"), Required]
    public CreatePayout Payout { get; set; } = null!;
}

/// <inheritdoc cref="PayoutsBase"/>
public partial record CreatePayout : PayoutsBase {}
public partial record UpdatePayoutRequest
{
    [JsonPropertyName("payout"), Required]
    public UpdatePayout Payout { get; set; } = null!;
}

/// <inheritdoc cref="Payout"/>
public partial record UpdatePayout : Payout
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="PayoutsBase"/>
public partial record Payout : PayoutsBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="PayoutsOrig"/>
public partial record PayoutsBase : PayoutsOrig{}

	
public partial record CountryItem
{
    [JsonPropertyName("country"), Required]
    public Country Country { get; set; } = null!;
}

public partial record CountryList
{
    [JsonPropertyName("countries"), Required]
    public IEnumerable<Country> Countries { get; set; } = null!;
}
public partial record CreateCountryRequest
{
    [JsonPropertyName("country"), Required]
    public CreateCountry Country { get; set; } = null!;
}

/// <inheritdoc cref="CountryBase"/>
public partial record CreateCountry : CountryBase {}
public partial record UpdateCountryRequest
{
    [JsonPropertyName("country"), Required]
    public UpdateCountry Country { get; set; } = null!;
}

/// <inheritdoc cref="Country"/>
public partial record UpdateCountry : Country
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CountryBase"/>
public partial record Country : CountryBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CountryOrig"/>
public partial record CountryBase : CountryOrig{}

	
public partial record CurrencyItem
{
    [JsonPropertyName("currency"), Required]
    public Currency Currency { get; set; } = null!;
}

public partial record CurrencyList
{
    [JsonPropertyName("currencies"), Required]
    public IEnumerable<Currency> Currencies { get; set; } = null!;
}
public partial record CreateCurrencyRequest
{
    [JsonPropertyName("currency"), Required]
    public CreateCurrency Currency { get; set; } = null!;
}

/// <inheritdoc cref="CurrencyBase"/>
public partial record CreateCurrency : CurrencyBase {}
public partial record UpdateCurrencyRequest
{
    [JsonPropertyName("currency"), Required]
    public UpdateCurrency Currency { get; set; } = null!;
}

/// <inheritdoc cref="Currency"/>
public partial record UpdateCurrency : Currency
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CurrencyBase"/>
public partial record Currency : CurrencyBase
{
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CurrencyOrig"/>
public partial record CurrencyBase : CurrencyOrig{}

	
public partial record PolicyItem
{
    [JsonPropertyName("policy"), Required]
    public Policy Policy { get; set; } = null!;
}

public partial record PolicyList
{
    [JsonPropertyName("policies"), Required]
    public IEnumerable<Policy> Policies { get; set; } = null!;
}
public partial record CreatePolicyRequest
{
    [JsonPropertyName("policy"), Required]
    public CreatePolicy Policy { get; set; } = null!;
}

/// <inheritdoc cref="PolicyBase"/>
public partial record CreatePolicy : PolicyBase {}
public partial record UpdatePolicyRequest
{
    [JsonPropertyName("policy"), Required]
    public UpdatePolicy Policy { get; set; } = null!;
}

/// <inheritdoc cref="Policy"/>
public partial record UpdatePolicy : Policy
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="PolicyBase"/>
public partial record Policy : PolicyBase
{
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="PolicyOrig"/>
public partial record PolicyBase : PolicyOrig{}

	
public partial record ProvinceItem
{
    [JsonPropertyName("province"), Required]
    public Province Province { get; set; } = null!;
}

public partial record ProvinceList
{
    [JsonPropertyName("provinces"), Required]
    public IEnumerable<Province> Provinces { get; set; } = null!;
}
public partial record CreateProvinceRequest
{
    [JsonPropertyName("province"), Required]
    public CreateProvince Province { get; set; } = null!;
}

/// <inheritdoc cref="ProvinceBase"/>
public partial record CreateProvince : ProvinceBase {}
public partial record UpdateProvinceRequest
{
    [JsonPropertyName("province"), Required]
    public UpdateProvince Province { get; set; } = null!;
}

/// <inheritdoc cref="Province"/>
public partial record UpdateProvince : Province
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ProvinceBase"/>
public partial record Province : ProvinceBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ProvinceOrig"/>
public partial record ProvinceBase : ProvinceOrig{}

	
public partial record ShippingZoneItem
{
    [JsonPropertyName("shipping_zone"), Required]
    public ShippingZone ShippingZone { get; set; } = null!;
}

public partial record ShippingZoneList
{
    [JsonPropertyName("shipping_zones"), Required]
    public IEnumerable<ShippingZone> ShippingZones { get; set; } = null!;
}
public partial record CreateShippingZoneRequest
{
    [JsonPropertyName("shipping_zone"), Required]
    public CreateShippingZone ShippingZone { get; set; } = null!;
}

/// <inheritdoc cref="ShippingZoneBase"/>
public partial record CreateShippingZone : ShippingZoneBase {}
public partial record UpdateShippingZoneRequest
{
    [JsonPropertyName("shipping_zone"), Required]
    public UpdateShippingZone ShippingZone { get; set; } = null!;
}

/// <inheritdoc cref="ShippingZone"/>
public partial record UpdateShippingZone : ShippingZone
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ShippingZoneBase"/>
public partial record ShippingZone : ShippingZoneBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ShippingZoneOrig"/>
public partial record ShippingZoneBase : ShippingZoneOrig{}

	
public partial record ShopItem
{
    [JsonPropertyName("shop"), Required]
    public Shop Shop { get; set; } = null!;
}

public partial record ShopList
{
    [JsonPropertyName("shops"), Required]
    public IEnumerable<Shop> Shops { get; set; } = null!;
}
public partial record CreateShopRequest
{
    [JsonPropertyName("shop"), Required]
    public CreateShop Shop { get; set; } = null!;
}

/// <inheritdoc cref="ShopBase"/>
public partial record CreateShop : ShopBase {}
public partial record UpdateShopRequest
{
    [JsonPropertyName("shop"), Required]
    public UpdateShop Shop { get; set; } = null!;
}

/// <inheritdoc cref="Shop"/>
public partial record UpdateShop : Shop
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="ShopBase"/>
public partial record Shop : ShopBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ShopOrig"/>
public partial record ShopBase : ShopOrig{}

	
public partial record TenderTransactionItem
{
    [JsonPropertyName("tender_transaction"), Required]
    public TenderTransaction TenderTransaction { get; set; } = null!;
}

public partial record TenderTransactionList
{
    [JsonPropertyName("tender_transactions"), Required]
    public IEnumerable<TenderTransaction> TenderTransactions { get; set; } = null!;
}
public partial record CreateTenderTransactionRequest
{
    [JsonPropertyName("tender_transaction"), Required]
    public CreateTenderTransaction TenderTransaction { get; set; } = null!;
}

/// <inheritdoc cref="TenderTransactionBase"/>
public partial record CreateTenderTransaction : TenderTransactionBase {}
public partial record UpdateTenderTransactionRequest
{
    [JsonPropertyName("tender_transaction"), Required]
    public UpdateTenderTransaction TenderTransaction { get; set; } = null!;
}

/// <inheritdoc cref="TenderTransaction"/>
public partial record UpdateTenderTransaction : TenderTransaction
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="TenderTransactionBase"/>
public partial record TenderTransaction : TenderTransactionBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="TenderTransactionOrig"/>
public partial record TenderTransactionBase : TenderTransactionOrig{}

	
public partial record DiscountCodeCreationItem
{
    [JsonPropertyName("discount_code_creation"), Required]
    public DiscountCodeCreation DiscountCodeCreation { get; set; } = null!;
}

public partial record DiscountCodeCreationList
{
    [JsonPropertyName("discount_code_creations"), Required]
    public IEnumerable<DiscountCodeCreation> DiscountCodeCreations { get; set; } = null!;
}
public partial record CreateDiscountCodeCreationRequest
{
    [JsonPropertyName("discount_code_creation"), Required]
    public CreateDiscountCodeCreation DiscountCodeCreation { get; set; } = null!;
}

/// <inheritdoc cref="DiscountCodeCreationBase"/>
public partial record CreateDiscountCodeCreation : DiscountCodeCreationBase {}
public partial record UpdateDiscountCodeCreationRequest
{
    [JsonPropertyName("discount_code_creation"), Required]
    public UpdateDiscountCodeCreation DiscountCodeCreation { get; set; } = null!;
}

/// <inheritdoc cref="DiscountCodeCreation"/>
public partial record UpdateDiscountCodeCreation : DiscountCodeCreation
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="DiscountCodeCreationBase"/>
public partial record DiscountCodeCreation : DiscountCodeCreationBase
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="DiscountCodeCreationOrig"/>
public partial record DiscountCodeCreationBase : DiscountCodeCreationOrig{}

	
public partial record EngagementItem
{
    [JsonPropertyName("engagement"), Required]
    public Engagement Engagement { get; set; } = null!;
}

public partial record EngagementList
{
    [JsonPropertyName("engagements"), Required]
    public IEnumerable<Engagement> Engagements { get; set; } = null!;
}
public partial record CreateEngagementRequest
{
    [JsonPropertyName("engagement"), Required]
    public CreateEngagement Engagement { get; set; } = null!;
}

/// <inheritdoc cref="EngagementBase"/>
public partial record CreateEngagement : EngagementBase {}
public partial record UpdateEngagementRequest
{
    [JsonPropertyName("engagement"), Required]
    public UpdateEngagement Engagement { get; set; } = null!;
}

/// <inheritdoc cref="Engagement"/>
public partial record UpdateEngagement : Engagement
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="EngagementBase"/>
public partial record Engagement : EngagementBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="EngagementOrig"/>
public partial record EngagementBase : EngagementOrig{}

	
public partial record CustomerInviteItem
{
    [JsonPropertyName("customer_invite"), Required]
    public CustomerInvite CustomerInvite { get; set; } = null!;
}

public partial record CustomerInviteList
{
    [JsonPropertyName("customer_invites"), Required]
    public IEnumerable<CustomerInvite> CustomerInvites { get; set; } = null!;
}
public partial record CreateCustomerInviteRequest
{
    [JsonPropertyName("customer_invite"), Required]
    public CreateCustomerInvite CustomerInvite { get; set; } = null!;
}

/// <inheritdoc cref="CustomerInviteBase"/>
public partial record CreateCustomerInvite : CustomerInviteBase {}
public partial record UpdateCustomerInviteRequest
{
    [JsonPropertyName("customer_invite"), Required]
    public UpdateCustomerInvite CustomerInvite { get; set; } = null!;
}

/// <inheritdoc cref="CustomerInvite"/>
public partial record UpdateCustomerInvite : CustomerInvite
{
    [JsonIgnore]
    public new System.DateTimeOffset? CreatedAt { get; set; }
    [JsonIgnore]
    public new System.DateTimeOffset? UpdatedAt { get; set; }
}

		
/// <inheritdoc cref="CustomerInviteBase"/>
public partial record CustomerInvite : CustomerInviteBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="CustomerInviteOrig"/>
public partial record CustomerInviteBase : CustomerInviteOrig{}

	
public partial record ShippingRateItem
{
    [JsonPropertyName("shipping_rate"), Required]
    public ShippingRate ShippingRate { get; set; } = null!;
}

public partial record ShippingRateList
{
    [JsonPropertyName("shipping_rates"), Required]
    public IEnumerable<ShippingRate> ShippingRates { get; set; } = null!;
}
		
/// <inheritdoc cref="ShippingRateBase"/>
public partial record ShippingRate : ShippingRateBase
{
	
    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the asset was created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("created_at")]
    public System.DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when an asset was last updated.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
    public System.DateTimeOffset? UpdatedAt { get; set; }
}

/// <inheritdoc cref="ShippingRateOrig"/>
public partial record ShippingRateBase : ShippingRateOrig{}

	