

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OpenShopify.Common.Models;

namespace OpenShopify.Admin.Builder.Models;

public class AccessScopeItem
{
    [JsonPropertyName("access_scope"), Required]
    public AccessScope AccessScope { get; set; } = null!;
}

public class AccessScopeList
{
    [JsonPropertyName("access_scopes"), Required]
    public IEnumerable<AccessScope> AccessScopes { get; set; } = null!;
}
		
	
public class AccessScope : AccessScopeBase
{
}
	
public class StorefrontAccessTokenItem
{
    [JsonPropertyName("storefront_access_token"), Required]
    public StorefrontAccessToken StorefrontAccessToken { get; set; } = null!;
}

public class StorefrontAccessTokenList
{
    [JsonPropertyName("storefront_access_tokens"), Required]
    public IEnumerable<StorefrontAccessToken> StorefrontAccessTokens { get; set; } = null!;
}
public class CreateStorefrontAccessTokenRequest
{
    [JsonPropertyName("storefront_access_token"), Required]
    public CreateStorefrontAccessToken StorefrontAccessToken { get; set; } = null!;
}

public partial class CreateStorefrontAccessToken : StorefrontAccessTokenBase {}
public class UpdateStorefrontAccessTokenRequest
{
    [JsonPropertyName("storefront_access_token"), Required]
    public UpdateStorefrontAccessToken StorefrontAccessToken { get; set; } = null!;
}

public partial class UpdateStorefrontAccessToken : StorefrontAccessToken{}

		
	
public class StorefrontAccessToken : StorefrontAccessTokenBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ReportItem
{
    [JsonPropertyName("report"), Required]
    public Report Report { get; set; } = null!;
}

public class ReportList
{
    [JsonPropertyName("reports"), Required]
    public IEnumerable<Report> Reports { get; set; } = null!;
}
public class CreateReportRequest
{
    [JsonPropertyName("report"), Required]
    public CreateReport Report { get; set; } = null!;
}

public partial class CreateReport : ReportBase {}
public class UpdateReportRequest
{
    [JsonPropertyName("report"), Required]
    public UpdateReport Report { get; set; } = null!;
}

public partial class UpdateReport : Report{}

		
	
public class Report : ReportBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ApplicationChargeItem
{
    [JsonPropertyName("application_charge"), Required]
    public ApplicationCharge ApplicationCharge { get; set; } = null!;
}

public class ApplicationChargeList
{
    [JsonPropertyName("application_charges"), Required]
    public IEnumerable<ApplicationCharge> ApplicationCharges { get; set; } = null!;
}
public class CreateApplicationChargeRequest
{
    [JsonPropertyName("application_charge"), Required]
    public CreateApplicationCharge ApplicationCharge { get; set; } = null!;
}

public partial class CreateApplicationCharge : ApplicationChargeBase {}
public class UpdateApplicationChargeRequest
{
    [JsonPropertyName("application_charge"), Required]
    public UpdateApplicationCharge ApplicationCharge { get; set; } = null!;
}

public partial class UpdateApplicationCharge : ApplicationCharge{}

		
	
public class ApplicationCharge : ApplicationChargeBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ApplicationCreditItem
{
    [JsonPropertyName("application_credit"), Required]
    public ApplicationCredit ApplicationCredit { get; set; } = null!;
}

public class ApplicationCreditList
{
    [JsonPropertyName("application_credits"), Required]
    public IEnumerable<ApplicationCredit> ApplicationCredits { get; set; } = null!;
}
public class CreateApplicationCreditRequest
{
    [JsonPropertyName("application_credit"), Required]
    public CreateApplicationCredit ApplicationCredit { get; set; } = null!;
}

public partial class CreateApplicationCredit : ApplicationCreditBase {}
public class UpdateApplicationCreditRequest
{
    [JsonPropertyName("application_credit"), Required]
    public UpdateApplicationCredit ApplicationCredit { get; set; } = null!;
}

public partial class UpdateApplicationCredit : ApplicationCredit{}

		
	
public class ApplicationCredit : ApplicationCreditBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class RecurringApplicationChargeItem
{
    [JsonPropertyName("recurring_application_charge"), Required]
    public RecurringApplicationCharge RecurringApplicationCharge { get; set; } = null!;
}

public class RecurringApplicationChargeList
{
    [JsonPropertyName("recurring_application_charges"), Required]
    public IEnumerable<RecurringApplicationCharge> RecurringApplicationCharges { get; set; } = null!;
}
public class CreateRecurringApplicationChargeRequest
{
    [JsonPropertyName("recurring_application_charge"), Required]
    public CreateRecurringApplicationCharge RecurringApplicationCharge { get; set; } = null!;
}

public partial class CreateRecurringApplicationCharge : RecurringApplicationChargeBase {}
public class UpdateRecurringApplicationChargeRequest
{
    [JsonPropertyName("recurring_application_charge"), Required]
    public UpdateRecurringApplicationCharge RecurringApplicationCharge { get; set; } = null!;
}

public partial class UpdateRecurringApplicationCharge : RecurringApplicationCharge{}

		
	
public class RecurringApplicationCharge : RecurringApplicationChargeBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class UsageChargeItem
{
    [JsonPropertyName("usage_charge"), Required]
    public UsageCharge UsageCharge { get; set; } = null!;
}

public class UsageChargeList
{
    [JsonPropertyName("usage_charges"), Required]
    public IEnumerable<UsageCharge> UsageCharges { get; set; } = null!;
}
public class CreateUsageChargeRequest
{
    [JsonPropertyName("usage_charge"), Required]
    public CreateUsageCharge UsageCharge { get; set; } = null!;
}

public partial class CreateUsageCharge : UsageChargeBase {}
public class UpdateUsageChargeRequest
{
    [JsonPropertyName("usage_charge"), Required]
    public UpdateUsageCharge UsageCharge { get; set; } = null!;
}

public partial class UpdateUsageCharge : UsageCharge{}

		
	
public class UsageCharge : UsageChargeBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CustomerItem
{
    [JsonPropertyName("customer"), Required]
    public Customer Customer { get; set; } = null!;
}

public class CustomerList
{
    [JsonPropertyName("customers"), Required]
    public IEnumerable<Customer> Customers { get; set; } = null!;
}
public class CreateCustomerRequest
{
    [JsonPropertyName("customer"), Required]
    public CreateCustomer Customer { get; set; } = null!;
}

public partial class CreateCustomer : CustomerBase {}
public class UpdateCustomerRequest
{
    [JsonPropertyName("customer"), Required]
    public UpdateCustomer Customer { get; set; } = null!;
}

public partial class UpdateCustomer : Customer{}

		
	
public class Customer : CustomerBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class AddressItem
{
    [JsonPropertyName("address"), Required]
    public Address Address { get; set; } = null!;
}

public class AddressList
{
    [JsonPropertyName("addresses"), Required]
    public IEnumerable<Address> Addresses { get; set; } = null!;
}
public class CreateAddressRequest
{
    [JsonPropertyName("address"), Required]
    public CreateAddress Address { get; set; } = null!;
}

public partial class CreateAddress : AddressBase {}
public class UpdateAddressRequest
{
    [JsonPropertyName("address"), Required]
    public UpdateAddress Address { get; set; } = null!;
}

public partial class UpdateAddress : Address{}

		
	
public class Address : AddressBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CustomerAddressItem
{
    [JsonPropertyName("customer_address"), Required]
    public Address CustomerAddress { get; set; } = null!;
}

public class CustomerAddressList
{
    [JsonPropertyName("customer_addresses"), Required]
    public IEnumerable<Address> CustomerAddresses { get; set; } = null!;
}
public class CreateCustomerAddressRequest
{
    [JsonPropertyName("customer_address"), Required]
    public CreateCustomerAddress CustomerAddress { get; set; } = null!;
}

public partial class CreateCustomerAddress : AddressBase {}
public class UpdateCustomerAddressRequest
{
    [JsonPropertyName("customer_address"), Required]
    public UpdateCustomerAddress CustomerAddress { get; set; } = null!;
}

public partial class UpdateCustomerAddress : Address{}

		
	
public class CustomerAddress : AddressBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CustomerSavedSearchItem
{
    [JsonPropertyName("customer_saved_search"), Required]
    public CustomerSavedSearch CustomerSavedSearch { get; set; } = null!;
}

public class CustomerSavedSearchList
{
    [JsonPropertyName("customer_saved_searches"), Required]
    public IEnumerable<CustomerSavedSearch> CustomerSavedSearches { get; set; } = null!;
}
public class CreateCustomerSavedSearchRequest
{
    [JsonPropertyName("customer_saved_search"), Required]
    public CreateCustomerSavedSearch CustomerSavedSearch { get; set; } = null!;
}

public partial class CreateCustomerSavedSearch : CustomerSavedSearchBase {}
public class UpdateCustomerSavedSearchRequest
{
    [JsonPropertyName("customer_saved_search"), Required]
    public UpdateCustomerSavedSearch CustomerSavedSearch { get; set; } = null!;
}

public partial class UpdateCustomerSavedSearch : CustomerSavedSearch{}

		
	
public class CustomerSavedSearch : CustomerSavedSearchBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class DeprecatedApiCallItem
{
    [JsonPropertyName("deprecated_api_call"), Required]
    public DeprecatedApiCall DeprecatedApiCall { get; set; } = null!;
}

public class DeprecatedApiCallList
{
    [JsonPropertyName("deprecated_api_calls"), Required]
    public IEnumerable<DeprecatedApiCall> DeprecatedApiCalls { get; set; } = null!;
}
public class CreateDeprecatedApiCallRequest
{
    [JsonPropertyName("deprecated_api_call"), Required]
    public CreateDeprecatedApiCall DeprecatedApiCall { get; set; } = null!;
}

public partial class CreateDeprecatedApiCall : DeprecatedApiCallBase {}
public class UpdateDeprecatedApiCallRequest
{
    [JsonPropertyName("deprecated_api_call"), Required]
    public UpdateDeprecatedApiCall DeprecatedApiCall { get; set; } = null!;
}

public partial class UpdateDeprecatedApiCall : DeprecatedApiCall{}

		
	
public class DeprecatedApiCall : DeprecatedApiCallBase
{
}
	
public class DiscountCodeItem
{
    [JsonPropertyName("discount_code"), Required]
    public DiscountCode DiscountCode { get; set; } = null!;
}

public class DiscountCodeList
{
    [JsonPropertyName("discount_codes"), Required]
    public IEnumerable<DiscountCode> DiscountCodes { get; set; } = null!;
}
public class CreateDiscountCodeRequest
{
    [JsonPropertyName("discount_code"), Required]
    public CreateDiscountCode DiscountCode { get; set; } = null!;
}

public partial class CreateDiscountCode : DiscountCodeBase {}
public class UpdateDiscountCodeRequest
{
    [JsonPropertyName("discount_code"), Required]
    public UpdateDiscountCode DiscountCode { get; set; } = null!;
}

public partial class UpdateDiscountCode : DiscountCode{}

		
	
public class DiscountCode : DiscountCodeBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class PriceRuleItem
{
    [JsonPropertyName("price_rule"), Required]
    public PriceRule PriceRule { get; set; } = null!;
}

public class PriceRuleList
{
    [JsonPropertyName("price_rules"), Required]
    public IEnumerable<PriceRule> PriceRules { get; set; } = null!;
}
public class CreatePriceRuleRequest
{
    [JsonPropertyName("price_rule"), Required]
    public CreatePriceRule PriceRule { get; set; } = null!;
}

public partial class CreatePriceRule : PriceRuleBase {}
public class UpdatePriceRuleRequest
{
    [JsonPropertyName("price_rule"), Required]
    public UpdatePriceRule PriceRule { get; set; } = null!;
}

public partial class UpdatePriceRule : PriceRule{}

		
	
public class PriceRule : PriceRuleBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class EventItem
{
    [JsonPropertyName("event"), Required]
    public Event Event { get; set; } = null!;
}

public class EventList
{
    [JsonPropertyName("events"), Required]
    public IEnumerable<Event> Events { get; set; } = null!;
}
public class CreateEventRequest
{
    [JsonPropertyName("event"), Required]
    public CreateEvent Event { get; set; } = null!;
}

public partial class CreateEvent : EventBase {}
public class UpdateEventRequest
{
    [JsonPropertyName("event"), Required]
    public UpdateEvent Event { get; set; } = null!;
}

public partial class UpdateEvent : Event{}

		
	
public class Event : EventBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class WebhookItem
{
    [JsonPropertyName("webhook"), Required]
    public Webhook Webhook { get; set; } = null!;
}

public class WebhookList
{
    [JsonPropertyName("webhooks"), Required]
    public IEnumerable<Webhook> Webhooks { get; set; } = null!;
}
public class CreateWebhookRequest
{
    [JsonPropertyName("webhook"), Required]
    public CreateWebhook Webhook { get; set; } = null!;
}

public partial class CreateWebhook : WebhookBase {}
public class UpdateWebhookRequest
{
    [JsonPropertyName("webhook"), Required]
    public UpdateWebhook Webhook { get; set; } = null!;
}

public partial class UpdateWebhook : Webhook{}

		
	
public class Webhook : WebhookBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class InventoryItemItem
{
    [JsonPropertyName("inventory_item"), Required]
    public InventoryItem InventoryItem { get; set; } = null!;
}

public class InventoryItemList
{
    [JsonPropertyName("inventory_items"), Required]
    public IEnumerable<InventoryItem> InventoryItems { get; set; } = null!;
}
public class CreateInventoryItemRequest
{
    [JsonPropertyName("inventory_item"), Required]
    public CreateInventoryItem InventoryItem { get; set; } = null!;
}

public partial class CreateInventoryItem : InventoryItemBase {}
public class UpdateInventoryItemRequest
{
    [JsonPropertyName("inventory_item"), Required]
    public UpdateInventoryItem InventoryItem { get; set; } = null!;
}

public partial class UpdateInventoryItem : InventoryItem{}

		
	
public class InventoryItem : InventoryItemBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class InventoryLevelItem
{
    [JsonPropertyName("inventory_level"), Required]
    public InventoryLevel InventoryLevel { get; set; } = null!;
}

public class InventoryLevelList
{
    [JsonPropertyName("inventory_levels"), Required]
    public IEnumerable<InventoryLevel> InventoryLevels { get; set; } = null!;
}
public class CreateInventoryLevelRequest
{
    [JsonPropertyName("inventory_level"), Required]
    public CreateInventoryLevel InventoryLevel { get; set; } = null!;
}

public partial class CreateInventoryLevel : InventoryLevelBase {}
public class UpdateInventoryLevelRequest
{
    [JsonPropertyName("inventory_level"), Required]
    public UpdateInventoryLevel InventoryLevel { get; set; } = null!;
}

public partial class UpdateInventoryLevel : InventoryLevel{}

		
	
public class InventoryLevel : InventoryLevelBase
{
}
	
public class LocationItem
{
    [JsonPropertyName("location"), Required]
    public Location Location { get; set; } = null!;
}

public class LocationList
{
    [JsonPropertyName("locations"), Required]
    public IEnumerable<Location> Locations { get; set; } = null!;
}
public class CreateLocationRequest
{
    [JsonPropertyName("location"), Required]
    public CreateLocation Location { get; set; } = null!;
}

public partial class CreateLocation : LocationBase {}
public class UpdateLocationRequest
{
    [JsonPropertyName("location"), Required]
    public UpdateLocation Location { get; set; } = null!;
}

public partial class UpdateLocation : Location{}

		
	
public class Location : LocationBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class MarketingEventItem
{
    [JsonPropertyName("marketing_event"), Required]
    public MarketingEvent MarketingEvent { get; set; } = null!;
}

public class MarketingEventList
{
    [JsonPropertyName("marketing_events"), Required]
    public IEnumerable<MarketingEvent> MarketingEvents { get; set; } = null!;
}
public class CreateMarketingEventRequest
{
    [JsonPropertyName("marketing_event"), Required]
    public CreateMarketingEvent MarketingEvent { get; set; } = null!;
}

public partial class CreateMarketingEvent : MarketingEventBase {}
public class UpdateMarketingEventRequest
{
    [JsonPropertyName("marketing_event"), Required]
    public UpdateMarketingEvent MarketingEvent { get; set; } = null!;
}

public partial class UpdateMarketingEvent : MarketingEvent{}

		
	
public class MarketingEvent : MarketingEventBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class MetafieldItem
{
    [JsonPropertyName("metafield"), Required]
    public Metafield Metafield { get; set; } = null!;
}

public class MetafieldList
{
    [JsonPropertyName("metafields"), Required]
    public IEnumerable<Metafield> Metafields { get; set; } = null!;
}
public class CreateMetafieldRequest
{
    [JsonPropertyName("metafield"), Required]
    public CreateMetafield Metafield { get; set; } = null!;
}

public partial class CreateMetafield : MetafieldBase {}
public class UpdateMetafieldRequest
{
    [JsonPropertyName("metafield"), Required]
    public UpdateMetafield Metafield { get; set; } = null!;
}

public partial class UpdateMetafield : Metafield{}

		
	
public class Metafield : MetafieldBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ArticleItem
{
    [JsonPropertyName("article"), Required]
    public Article Article { get; set; } = null!;
}

public class ArticleList
{
    [JsonPropertyName("articles"), Required]
    public IEnumerable<Article> Articles { get; set; } = null!;
}
public class CreateArticleRequest
{
    [JsonPropertyName("article"), Required]
    public CreateArticle Article { get; set; } = null!;
}

public partial class CreateArticle : ArticleBase {}
public class UpdateArticleRequest
{
    [JsonPropertyName("article"), Required]
    public UpdateArticle Article { get; set; } = null!;
}

public partial class UpdateArticle : Article{}

		
	
public class Article : ArticleBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class AssetItem
{
    [JsonPropertyName("asset"), Required]
    public Asset Asset { get; set; } = null!;
}

public class AssetList
{
    [JsonPropertyName("assets"), Required]
    public IEnumerable<Asset> Assets { get; set; } = null!;
}
public class CreateAssetRequest
{
    [JsonPropertyName("asset"), Required]
    public CreateAsset Asset { get; set; } = null!;
}

public partial class CreateAsset : AssetBase {}
public class UpdateAssetRequest
{
    [JsonPropertyName("asset"), Required]
    public UpdateAsset Asset { get; set; } = null!;
}

public partial class UpdateAsset : Asset{}

		
	
public class Asset : AssetBase
{
}
	
public class BlogItem
{
    [JsonPropertyName("blog"), Required]
    public Blog Blog { get; set; } = null!;
}

public class BlogList
{
    [JsonPropertyName("blogs"), Required]
    public IEnumerable<Blog> Blogs { get; set; } = null!;
}
public class CreateBlogRequest
{
    [JsonPropertyName("blog"), Required]
    public CreateBlog Blog { get; set; } = null!;
}

public partial class CreateBlog : BlogBase {}
public class UpdateBlogRequest
{
    [JsonPropertyName("blog"), Required]
    public UpdateBlog Blog { get; set; } = null!;
}

public partial class UpdateBlog : Blog{}

		
	
public class Blog : BlogBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CommentItem
{
    [JsonPropertyName("comment"), Required]
    public Comment Comment { get; set; } = null!;
}

public class CommentList
{
    [JsonPropertyName("comments"), Required]
    public IEnumerable<Comment> Comments { get; set; } = null!;
}
public class CreateCommentRequest
{
    [JsonPropertyName("comment"), Required]
    public CreateComment Comment { get; set; } = null!;
}

public partial class CreateComment : CommentBase {}
public class UpdateCommentRequest
{
    [JsonPropertyName("comment"), Required]
    public UpdateComment Comment { get; set; } = null!;
}

public partial class UpdateComment : Comment{}

		
	
public class Comment : CommentBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class PageItem
{
    [JsonPropertyName("page"), Required]
    public Page Page { get; set; } = null!;
}

public class PageList
{
    [JsonPropertyName("pages"), Required]
    public IEnumerable<Page> Pages { get; set; } = null!;
}
public class CreatePageRequest
{
    [JsonPropertyName("page"), Required]
    public CreatePage Page { get; set; } = null!;
}

public partial class CreatePage : PageBase {}
public class UpdatePageRequest
{
    [JsonPropertyName("page"), Required]
    public UpdatePage Page { get; set; } = null!;
}

public partial class UpdatePage : Page{}

		
	
public class Page : PageBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class RedirectItem
{
    [JsonPropertyName("redirect"), Required]
    public Redirect Redirect { get; set; } = null!;
}

public class RedirectList
{
    [JsonPropertyName("redirects"), Required]
    public IEnumerable<Redirect> Redirects { get; set; } = null!;
}
public class CreateRedirectRequest
{
    [JsonPropertyName("redirect"), Required]
    public CreateRedirect Redirect { get; set; } = null!;
}

public partial class CreateRedirect : RedirectBase {}
public class UpdateRedirectRequest
{
    [JsonPropertyName("redirect"), Required]
    public UpdateRedirect Redirect { get; set; } = null!;
}

public partial class UpdateRedirect : Redirect{}

		
	
public class Redirect : RedirectBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ScriptTagItem
{
    [JsonPropertyName("script_tag"), Required]
    public ScriptTag ScriptTag { get; set; } = null!;
}

public class ScriptTagList
{
    [JsonPropertyName("script_tags"), Required]
    public IEnumerable<ScriptTag> ScriptTags { get; set; } = null!;
}
public class CreateScriptTagRequest
{
    [JsonPropertyName("script_tag"), Required]
    public CreateScriptTag ScriptTag { get; set; } = null!;
}

public partial class CreateScriptTag : ScriptTagBase {}
public class UpdateScriptTagRequest
{
    [JsonPropertyName("script_tag"), Required]
    public UpdateScriptTag ScriptTag { get; set; } = null!;
}

public partial class UpdateScriptTag : ScriptTag{}

		
	
public class ScriptTag : ScriptTagBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ThemeItem
{
    [JsonPropertyName("theme"), Required]
    public Theme Theme { get; set; } = null!;
}

public class ThemeList
{
    [JsonPropertyName("themes"), Required]
    public IEnumerable<Theme> Themes { get; set; } = null!;
}
public class CreateThemeRequest
{
    [JsonPropertyName("theme"), Required]
    public CreateTheme Theme { get; set; } = null!;
}

public partial class CreateTheme : ThemeBase {}
public class UpdateThemeRequest
{
    [JsonPropertyName("theme"), Required]
    public UpdateTheme Theme { get; set; } = null!;
}

public partial class UpdateTheme : Theme{}

		
	
public class Theme : ThemeBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class AbandonedCheckoutItem
{
    [JsonPropertyName("abandoned_checkout"), Required]
    public Checkout AbandonedCheckout { get; set; } = null!;
}

public class AbandonedCheckoutList
{
    [JsonPropertyName("abandoned_checkouts"), Required]
    public IEnumerable<Checkout> AbandonedCheckouts { get; set; } = null!;
}
public class CreateAbandonedCheckoutRequest
{
    [JsonPropertyName("abandoned_checkout"), Required]
    public CreateAbandonedCheckout AbandonedCheckout { get; set; } = null!;
}

public partial class CreateAbandonedCheckout : CheckoutBase {}
public class UpdateAbandonedCheckoutRequest
{
    [JsonPropertyName("abandoned_checkout"), Required]
    public UpdateAbandonedCheckout AbandonedCheckout { get; set; } = null!;
}

public partial class UpdateAbandonedCheckout : Checkout{}

		
	
public class AbandonedCheckout : CheckoutBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class DraftOrderItem
{
    [JsonPropertyName("draft_order"), Required]
    public DraftOrder DraftOrder { get; set; } = null!;
}

public class DraftOrderList
{
    [JsonPropertyName("draft_orders"), Required]
    public IEnumerable<DraftOrder> DraftOrders { get; set; } = null!;
}
public class CreateDraftOrderRequest
{
    [JsonPropertyName("draft_order"), Required]
    public CreateDraftOrder DraftOrder { get; set; } = null!;
}

public partial class CreateDraftOrder : DraftOrderBase {}
public class UpdateDraftOrderRequest
{
    [JsonPropertyName("draft_order"), Required]
    public UpdateDraftOrder DraftOrder { get; set; } = null!;
}

public partial class UpdateDraftOrder : DraftOrder{}

		
	
public class DraftOrder : DraftOrderBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class OrderItem
{
    [JsonPropertyName("order"), Required]
    public Order Order { get; set; } = null!;
}

public class OrderList
{
    [JsonPropertyName("orders"), Required]
    public IEnumerable<Order> Orders { get; set; } = null!;
}
public class CreateOrderRequest
{
    [JsonPropertyName("order"), Required]
    public CreateOrder Order { get; set; } = null!;
}

public partial class CreateOrder : OrderBase {}
public class UpdateOrderRequest
{
    [JsonPropertyName("order"), Required]
    public UpdateOrder Order { get; set; } = null!;
}

public partial class UpdateOrder : Order{}

		
	
public class Order : OrderBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class OrderRiskItem
{
    [JsonPropertyName("order_risk"), Required]
    public OrderRisk OrderRisk { get; set; } = null!;
}

public class OrderRiskList
{
    [JsonPropertyName("order_risks"), Required]
    public IEnumerable<OrderRisk> OrderRisks { get; set; } = null!;
}
public class CreateOrderRiskRequest
{
    [JsonPropertyName("order_risk"), Required]
    public CreateOrderRisk OrderRisk { get; set; } = null!;
}

public partial class CreateOrderRisk : OrderRiskBase {}
public class UpdateOrderRiskRequest
{
    [JsonPropertyName("order_risk"), Required]
    public UpdateOrderRisk OrderRisk { get; set; } = null!;
}

public partial class UpdateOrderRisk : OrderRisk{}

		
	
public class OrderRisk : OrderRiskBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class RefundItem
{
    [JsonPropertyName("refund"), Required]
    public Refund Refund { get; set; } = null!;
}

public class RefundList
{
    [JsonPropertyName("refunds"), Required]
    public IEnumerable<Refund> Refunds { get; set; } = null!;
}
public class CreateRefundRequest
{
    [JsonPropertyName("refund"), Required]
    public CreateRefund Refund { get; set; } = null!;
}

public partial class CreateRefund : RefundBase {}
public class UpdateRefundRequest
{
    [JsonPropertyName("refund"), Required]
    public UpdateRefund Refund { get; set; } = null!;
}

public partial class UpdateRefund : Refund{}

		
	
public class Refund : RefundBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class TransactionItem
{
    [JsonPropertyName("transaction"), Required]
    public Transaction Transaction { get; set; } = null!;
}

public class TransactionList
{
    [JsonPropertyName("transactions"), Required]
    public IEnumerable<Transaction> Transactions { get; set; } = null!;
}
public class CreateTransactionRequest
{
    [JsonPropertyName("transaction"), Required]
    public CreateTransaction Transaction { get; set; } = null!;
}

public partial class CreateTransaction : TransactionBase {}
public class UpdateTransactionRequest
{
    [JsonPropertyName("transaction"), Required]
    public UpdateTransaction Transaction { get; set; } = null!;
}

public partial class UpdateTransaction : Transaction{}

		
	
public class Transaction : TransactionBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class GiftCardItem
{
    [JsonPropertyName("gift_card"), Required]
    public GiftCard GiftCard { get; set; } = null!;
}

public class GiftCardList
{
    [JsonPropertyName("gift_cards"), Required]
    public IEnumerable<GiftCard> GiftCards { get; set; } = null!;
}
public class CreateGiftCardRequest
{
    [JsonPropertyName("gift_card"), Required]
    public CreateGiftCard GiftCard { get; set; } = null!;
}

public partial class CreateGiftCard : GiftCardBase {}
public class UpdateGiftCardRequest
{
    [JsonPropertyName("gift_card"), Required]
    public UpdateGiftCard GiftCard { get; set; } = null!;
}

public partial class UpdateGiftCard : GiftCard{}

		
	
public class GiftCard : GiftCardBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class UserItem
{
    [JsonPropertyName("user"), Required]
    public User User { get; set; } = null!;
}

public class UserList
{
    [JsonPropertyName("users"), Required]
    public IEnumerable<User> Users { get; set; } = null!;
}
public class CreateUserRequest
{
    [JsonPropertyName("user"), Required]
    public CreateUser User { get; set; } = null!;
}

public partial class CreateUser : UserBase {}
public class UpdateUserRequest
{
    [JsonPropertyName("user"), Required]
    public UpdateUser User { get; set; } = null!;
}

public partial class UpdateUser : User{}

		
	
public class User : UserBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CollectItem
{
    [JsonPropertyName("collect"), Required]
    public Collect Collect { get; set; } = null!;
}

public class CollectList
{
    [JsonPropertyName("collects"), Required]
    public IEnumerable<Collect> Collects { get; set; } = null!;
}
public class CreateCollectRequest
{
    [JsonPropertyName("collect"), Required]
    public CreateCollect Collect { get; set; } = null!;
}

public partial class CreateCollect : CollectBase {}
public class UpdateCollectRequest
{
    [JsonPropertyName("collect"), Required]
    public UpdateCollect Collect { get; set; } = null!;
}

public partial class UpdateCollect : Collect{}

		
	
public class Collect : CollectBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CollectionItem
{
    [JsonPropertyName("collection"), Required]
    public Collection Collection { get; set; } = null!;
}

public class CollectionList
{
    [JsonPropertyName("collections"), Required]
    public IEnumerable<Collection> Collections { get; set; } = null!;
}
public class CreateCollectionRequest
{
    [JsonPropertyName("collection"), Required]
    public CreateCollection Collection { get; set; } = null!;
}

public partial class CreateCollection : CollectionBase {}
public class UpdateCollectionRequest
{
    [JsonPropertyName("collection"), Required]
    public UpdateCollection Collection { get; set; } = null!;
}

public partial class UpdateCollection : Collection{}

		
	
public class Collection : CollectionBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CustomCollectionItem
{
    [JsonPropertyName("custom_collection"), Required]
    public CustomCollection CustomCollection { get; set; } = null!;
}

public class CustomCollectionList
{
    [JsonPropertyName("custom_collections"), Required]
    public IEnumerable<CustomCollection> CustomCollections { get; set; } = null!;
}
public class CreateCustomCollectionRequest
{
    [JsonPropertyName("custom_collection"), Required]
    public CreateCustomCollection CustomCollection { get; set; } = null!;
}

public partial class CreateCustomCollection : CustomCollectionBase {}
public class UpdateCustomCollectionRequest
{
    [JsonPropertyName("custom_collection"), Required]
    public UpdateCustomCollection CustomCollection { get; set; } = null!;
}

public partial class UpdateCustomCollection : CustomCollection{}

		
	
public class CustomCollection : CustomCollectionBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ProductItem
{
    [JsonPropertyName("product"), Required]
    public Product Product { get; set; } = null!;
}

public class ProductList
{
    [JsonPropertyName("products"), Required]
    public IEnumerable<Product> Products { get; set; } = null!;
}
public class CreateProductRequest
{
    [JsonPropertyName("product"), Required]
    public CreateProduct Product { get; set; } = null!;
}

public partial class CreateProduct : ProductBase {}
public class UpdateProductRequest
{
    [JsonPropertyName("product"), Required]
    public UpdateProduct Product { get; set; } = null!;
}

public partial class UpdateProduct : Product{}

		
	
public class Product : ProductBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ProductImageItem
{
    [JsonPropertyName("product_image"), Required]
    public ProductImage ProductImage { get; set; } = null!;
}

public class ProductImageList
{
    [JsonPropertyName("product_images"), Required]
    public IEnumerable<ProductImage> ProductImages { get; set; } = null!;
}
public class CreateProductImageRequest
{
    [JsonPropertyName("product_image"), Required]
    public CreateProductImage ProductImage { get; set; } = null!;
}

public partial class CreateProductImage : ProductImageBase {}
public class UpdateProductImageRequest
{
    [JsonPropertyName("product_image"), Required]
    public UpdateProductImage ProductImage { get; set; } = null!;
}

public partial class UpdateProductImage : ProductImage{}

		
	
public class ProductImage : ProductImageBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ProductVariantItem
{
    [JsonPropertyName("product_variant"), Required]
    public ProductVariant ProductVariant { get; set; } = null!;
}

public class ProductVariantList
{
    [JsonPropertyName("product_variants"), Required]
    public IEnumerable<ProductVariant> ProductVariants { get; set; } = null!;
}
public class CreateProductVariantRequest
{
    [JsonPropertyName("product_variant"), Required]
    public CreateProductVariant ProductVariant { get; set; } = null!;
}

public partial class CreateProductVariant : ProductVariantBase {}
public class UpdateProductVariantRequest
{
    [JsonPropertyName("product_variant"), Required]
    public UpdateProductVariant ProductVariant { get; set; } = null!;
}

public partial class UpdateProductVariant : ProductVariant{}

		
	
public class ProductVariant : ProductVariantBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class SmartCollectionItem
{
    [JsonPropertyName("smart_collection"), Required]
    public SmartCollection SmartCollection { get; set; } = null!;
}

public class SmartCollectionList
{
    [JsonPropertyName("smart_collections"), Required]
    public IEnumerable<SmartCollection> SmartCollections { get; set; } = null!;
}
public class CreateSmartCollectionRequest
{
    [JsonPropertyName("smart_collection"), Required]
    public CreateSmartCollection SmartCollection { get; set; } = null!;
}

public partial class CreateSmartCollection : SmartCollectionBase {}
public class UpdateSmartCollectionRequest
{
    [JsonPropertyName("smart_collection"), Required]
    public UpdateSmartCollection SmartCollection { get; set; } = null!;
}

public partial class UpdateSmartCollection : SmartCollection{}

		
	
public class SmartCollection : SmartCollectionBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CheckoutItem
{
    [JsonPropertyName("checkout"), Required]
    public Checkout Checkout { get; set; } = null!;
}

public class CheckoutList
{
    [JsonPropertyName("checkouts"), Required]
    public IEnumerable<Checkout> Checkouts { get; set; } = null!;
}
public class CreateCheckoutRequest
{
    [JsonPropertyName("checkout"), Required]
    public CreateCheckout Checkout { get; set; } = null!;
}

public partial class CreateCheckout : CheckoutBase {}
public class UpdateCheckoutRequest
{
    [JsonPropertyName("checkout"), Required]
    public UpdateCheckout Checkout { get; set; } = null!;
}

public partial class UpdateCheckout : Checkout{}

		
	
public class Checkout : CheckoutBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CollectionListingItem
{
    [JsonPropertyName("collection_listing"), Required]
    public CollectionListing CollectionListing { get; set; } = null!;
}

public class CollectionListingList
{
    [JsonPropertyName("collection_listings"), Required]
    public IEnumerable<CollectionListing> CollectionListings { get; set; } = null!;
}
public class CreateCollectionListingRequest
{
    [JsonPropertyName("collection_listing"), Required]
    public CreateCollectionListing CollectionListing { get; set; } = null!;
}

public partial class CreateCollectionListing : CollectionListingBase {}
public class UpdateCollectionListingRequest
{
    [JsonPropertyName("collection_listing"), Required]
    public UpdateCollectionListing CollectionListing { get; set; } = null!;
}

public partial class UpdateCollectionListing : CollectionListing{}

		
	
public class CollectionListing : CollectionListingBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class MobilePlatformApplicationItem
{
    [JsonPropertyName("mobile_platform_application"), Required]
    public MobilePlatformApplication MobilePlatformApplication { get; set; } = null!;
}

public class MobilePlatformApplicationList
{
    [JsonPropertyName("mobile_platform_applications"), Required]
    public IEnumerable<MobilePlatformApplication> MobilePlatformApplications { get; set; } = null!;
}
public class CreateMobilePlatformApplicationRequest
{
    [JsonPropertyName("mobile_platform_application"), Required]
    public CreateMobilePlatformApplication MobilePlatformApplication { get; set; } = null!;
}

public partial class CreateMobilePlatformApplication : MobilePlatformApplicationBase {}
public class UpdateMobilePlatformApplicationRequest
{
    [JsonPropertyName("mobile_platform_application"), Required]
    public UpdateMobilePlatformApplication MobilePlatformApplication { get; set; } = null!;
}

public partial class UpdateMobilePlatformApplication : MobilePlatformApplication{}

		
	
public class MobilePlatformApplication : MobilePlatformApplicationBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class PaymentItem
{
    [JsonPropertyName("payment"), Required]
    public Payment Payment { get; set; } = null!;
}

public class PaymentList
{
    [JsonPropertyName("payments"), Required]
    public IEnumerable<Payment> Payments { get; set; } = null!;
}
public class CreatePaymentRequest
{
    [JsonPropertyName("payment"), Required]
    public CreatePayment Payment { get; set; } = null!;
}

public partial class CreatePayment : PaymentBase {}
public class UpdatePaymentRequest
{
    [JsonPropertyName("payment"), Required]
    public UpdatePayment Payment { get; set; } = null!;
}

public partial class UpdatePayment : Payment{}

		
	
public class Payment : PaymentBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ProductResourceFeedbackItem
{
    [JsonPropertyName("product_resource_feedback"), Required]
    public ProductResourceFeedback ProductResourceFeedback { get; set; } = null!;
}

public class ProductResourceFeedbackList
{
    [JsonPropertyName("product_resource_feedbacks"), Required]
    public IEnumerable<ProductResourceFeedback> ProductResourceFeedbacks { get; set; } = null!;
}
public class CreateProductResourceFeedbackRequest
{
    [JsonPropertyName("product_resource_feedback"), Required]
    public CreateProductResourceFeedback ProductResourceFeedback { get; set; } = null!;
}

public partial class CreateProductResourceFeedback : ProductResourceFeedbackBase {}
public class UpdateProductResourceFeedbackRequest
{
    [JsonPropertyName("product_resource_feedback"), Required]
    public UpdateProductResourceFeedback ProductResourceFeedback { get; set; } = null!;
}

public partial class UpdateProductResourceFeedback : ProductResourceFeedback{}

		
	
public class ProductResourceFeedback : ProductResourceFeedbackBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ProductListingItem
{
    [JsonPropertyName("product_listing"), Required]
    public ProductListing ProductListing { get; set; } = null!;
}

public class ProductListingList
{
    [JsonPropertyName("product_listings"), Required]
    public IEnumerable<ProductListing> ProductListings { get; set; } = null!;
}
public class CreateProductListingRequest
{
    [JsonPropertyName("product_listing"), Required]
    public CreateProductListing ProductListing { get; set; } = null!;
}

public partial class CreateProductListing : ProductListingBase {}
public class UpdateProductListingRequest
{
    [JsonPropertyName("product_listing"), Required]
    public UpdateProductListing ProductListing { get; set; } = null!;
}

public partial class UpdateProductListing : ProductListing{}

		
	
public class ProductListing : ProductListingBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ResourceFeedbackItem
{
    [JsonPropertyName("resource_feedback"), Required]
    public ResourceFeedback ResourceFeedback { get; set; } = null!;
}

public class ResourceFeedbackList
{
    [JsonPropertyName("resource_feedbacks"), Required]
    public IEnumerable<ResourceFeedback> ResourceFeedbacks { get; set; } = null!;
}
public class CreateResourceFeedbackRequest
{
    [JsonPropertyName("resource_feedback"), Required]
    public CreateResourceFeedback ResourceFeedback { get; set; } = null!;
}

public partial class CreateResourceFeedback : ResourceFeedbackBase {}
public class UpdateResourceFeedbackRequest
{
    [JsonPropertyName("resource_feedback"), Required]
    public UpdateResourceFeedback ResourceFeedback { get; set; } = null!;
}

public partial class UpdateResourceFeedback : ResourceFeedback{}

		
	
public class ResourceFeedback : ResourceFeedbackBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class AssignedFulfillmentOrderItem
{
    [JsonPropertyName("assigned_fulfillment_order"), Required]
    public FulfillmentOrder AssignedFulfillmentOrder { get; set; } = null!;
}

public class AssignedFulfillmentOrderList
{
    [JsonPropertyName("assigned_fulfillment_orders"), Required]
    public IEnumerable<FulfillmentOrder> AssignedFulfillmentOrders { get; set; } = null!;
}
public class CreateAssignedFulfillmentOrderRequest
{
    [JsonPropertyName("assigned_fulfillment_order"), Required]
    public CreateAssignedFulfillmentOrder AssignedFulfillmentOrder { get; set; } = null!;
}

public partial class CreateAssignedFulfillmentOrder : FulfillmentOrderBase {}
public class UpdateAssignedFulfillmentOrderRequest
{
    [JsonPropertyName("assigned_fulfillment_order"), Required]
    public UpdateAssignedFulfillmentOrder AssignedFulfillmentOrder { get; set; } = null!;
}

public partial class UpdateAssignedFulfillmentOrder : FulfillmentOrder{}

		
	
public class AssignedFulfillmentOrder : FulfillmentOrderBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CancellationRequestItem
{
    [JsonPropertyName("cancellation_request"), Required]
    public FulfillmentOrder CancellationRequest { get; set; } = null!;
}

public class CancellationRequestList
{
    [JsonPropertyName("cancellation_request"), Required]
    public IEnumerable<FulfillmentOrder> CancellationRequest { get; set; } = null!;
}
public class CreateCancellationRequestRequest
{
    [JsonPropertyName("cancellation_request"), Required]
    public CreateCancellationRequest CancellationRequest { get; set; } = null!;
}

public partial class CreateCancellationRequest : FulfillmentOrderBase {}
public class UpdateCancellationRequestRequest
{
    [JsonPropertyName("cancellation_request"), Required]
    public UpdateCancellationRequest CancellationRequest { get; set; } = null!;
}

public partial class UpdateCancellationRequest : FulfillmentOrder{}

		
	
public class CancellationRequest : FulfillmentOrderBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CarrierServiceItem
{
    [JsonPropertyName("carrier_service"), Required]
    public CarrierService CarrierService { get; set; } = null!;
}

public class CarrierServiceList
{
    [JsonPropertyName("carrier_services"), Required]
    public IEnumerable<CarrierService> CarrierServices { get; set; } = null!;
}
public class CreateCarrierServiceRequest
{
    [JsonPropertyName("carrier_service"), Required]
    public CreateCarrierService CarrierService { get; set; } = null!;
}

public partial class CreateCarrierService : CarrierServiceBase {}
public class UpdateCarrierServiceRequest
{
    [JsonPropertyName("carrier_service"), Required]
    public UpdateCarrierService CarrierService { get; set; } = null!;
}

public partial class UpdateCarrierService : CarrierService{}

		
	
public class CarrierService : CarrierServiceBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class FulfillmentItem
{
    [JsonPropertyName("fulfillment"), Required]
    public Fulfillment Fulfillment { get; set; } = null!;
}

public class FulfillmentList
{
    [JsonPropertyName("fulfillments"), Required]
    public IEnumerable<Fulfillment> Fulfillments { get; set; } = null!;
}
public class CreateFulfillmentRequest
{
    [JsonPropertyName("fulfillment"), Required]
    public CreateFulfillment Fulfillment { get; set; } = null!;
}

public partial class CreateFulfillment : FulfillmentBase {}
public class UpdateFulfillmentRequest
{
    [JsonPropertyName("fulfillment"), Required]
    public UpdateFulfillment Fulfillment { get; set; } = null!;
}

public partial class UpdateFulfillment : Fulfillment{}

		
	
public class Fulfillment : FulfillmentBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class FulfillmentEventItem
{
    [JsonPropertyName("fulfillment_event"), Required]
    public FulfillmentEvent FulfillmentEvent { get; set; } = null!;
}

public class FulfillmentEventList
{
    [JsonPropertyName("fulfillment_events"), Required]
    public IEnumerable<FulfillmentEvent> FulfillmentEvents { get; set; } = null!;
}
public class CreateFulfillmentEventRequest
{
    [JsonPropertyName("fulfillment_event"), Required]
    public CreateFulfillmentEvent FulfillmentEvent { get; set; } = null!;
}

public partial class CreateFulfillmentEvent : FulfillmentEventBase {}
public class UpdateFulfillmentEventRequest
{
    [JsonPropertyName("fulfillment_event"), Required]
    public UpdateFulfillmentEvent FulfillmentEvent { get; set; } = null!;
}

public partial class UpdateFulfillmentEvent : FulfillmentEvent{}

		
	
public class FulfillmentEvent : FulfillmentEventBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class FulfillmentOrderItem
{
    [JsonPropertyName("fulfillment_order"), Required]
    public FulfillmentOrder FulfillmentOrder { get; set; } = null!;
}

public class FulfillmentOrderList
{
    [JsonPropertyName("fulfillment_orders"), Required]
    public IEnumerable<FulfillmentOrder> FulfillmentOrders { get; set; } = null!;
}
public class CreateFulfillmentOrderRequest
{
    [JsonPropertyName("fulfillment_order"), Required]
    public CreateFulfillmentOrder FulfillmentOrder { get; set; } = null!;
}

public partial class CreateFulfillmentOrder : FulfillmentOrderBase {}
public class UpdateFulfillmentOrderRequest
{
    [JsonPropertyName("fulfillment_order"), Required]
    public UpdateFulfillmentOrder FulfillmentOrder { get; set; } = null!;
}

public partial class UpdateFulfillmentOrder : FulfillmentOrder{}

		
	
public class FulfillmentOrder : FulfillmentOrderBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class FulfillmentServiceItem
{
    [JsonPropertyName("fulfillment_service"), Required]
    public FulfillmentService FulfillmentService { get; set; } = null!;
}

public class FulfillmentServiceList
{
    [JsonPropertyName("fulfillment_services"), Required]
    public IEnumerable<FulfillmentService> FulfillmentServices { get; set; } = null!;
}
public class CreateFulfillmentServiceRequest
{
    [JsonPropertyName("fulfillment_service"), Required]
    public CreateFulfillmentService FulfillmentService { get; set; } = null!;
}

public partial class CreateFulfillmentService : FulfillmentServiceBase {}
public class UpdateFulfillmentServiceRequest
{
    [JsonPropertyName("fulfillment_service"), Required]
    public UpdateFulfillmentService FulfillmentService { get; set; } = null!;
}

public partial class UpdateFulfillmentService : FulfillmentService{}

		
	
public class FulfillmentService : FulfillmentServiceBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class LocationsForMoveItem
{
    [JsonPropertyName("locations_for_move"), Required]
    public LocationsForMove LocationsForMove { get; set; } = null!;
}

public class LocationsForMoveList
{
    [JsonPropertyName("locations_for_moves"), Required]
    public IEnumerable<LocationsForMove> LocationsForMoves { get; set; } = null!;
}
public class CreateLocationsForMoveRequest
{
    [JsonPropertyName("locations_for_move"), Required]
    public CreateLocationsForMove LocationsForMove { get; set; } = null!;
}

public partial class CreateLocationsForMove : LocationsForMoveBase {}
public class UpdateLocationsForMoveRequest
{
    [JsonPropertyName("locations_for_move"), Required]
    public UpdateLocationsForMove LocationsForMove { get; set; } = null!;
}

public partial class UpdateLocationsForMove : LocationsForMove{}

		
	
public class LocationsForMove : LocationsForMoveBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class BalanceItem
{
    [JsonPropertyName("balance"), Required]
    public Balance Balance { get; set; } = null!;
}

public class BalanceList
{
    [JsonPropertyName("balances"), Required]
    public IEnumerable<Balance> Balances { get; set; } = null!;
}
public class CreateBalanceRequest
{
    [JsonPropertyName("balance"), Required]
    public CreateBalance Balance { get; set; } = null!;
}

public partial class CreateBalance : BalanceBase {}
public class UpdateBalanceRequest
{
    [JsonPropertyName("balance"), Required]
    public UpdateBalance Balance { get; set; } = null!;
}

public partial class UpdateBalance : Balance{}

		
	
public class Balance : BalanceBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class DisputeItem
{
    [JsonPropertyName("dispute"), Required]
    public Dispute Dispute { get; set; } = null!;
}

public class DisputeList
{
    [JsonPropertyName("disputes"), Required]
    public IEnumerable<Dispute> Disputes { get; set; } = null!;
}
public class CreateDisputeRequest
{
    [JsonPropertyName("dispute"), Required]
    public CreateDispute Dispute { get; set; } = null!;
}

public partial class CreateDispute : DisputeBase {}
public class UpdateDisputeRequest
{
    [JsonPropertyName("dispute"), Required]
    public UpdateDispute Dispute { get; set; } = null!;
}

public partial class UpdateDispute : Dispute{}

		
	
public class Dispute : DisputeBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class DisputeEvidenceItem
{
    [JsonPropertyName("dispute_evidence"), Required]
    public DisputeEvidence DisputeEvidence { get; set; } = null!;
}

public class DisputeEvidenceList
{
    [JsonPropertyName("dispute_evidences"), Required]
    public IEnumerable<DisputeEvidence> DisputeEvidences { get; set; } = null!;
}
public class CreateDisputeEvidenceRequest
{
    [JsonPropertyName("dispute_evidence"), Required]
    public CreateDisputeEvidence DisputeEvidence { get; set; } = null!;
}

public partial class CreateDisputeEvidence : DisputeEvidenceBase {}
public class UpdateDisputeEvidenceRequest
{
    [JsonPropertyName("dispute_evidence"), Required]
    public UpdateDisputeEvidence DisputeEvidence { get; set; } = null!;
}

public partial class UpdateDisputeEvidence : DisputeEvidence{}

		
	
public class DisputeEvidence : DisputeEvidenceBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class DisputeFileUploadItem
{
    [JsonPropertyName("dispute_file_upload"), Required]
    public DisputeFileUpload DisputeFileUpload { get; set; } = null!;
}

public class DisputeFileUploadList
{
    [JsonPropertyName("dispute_file_uploads"), Required]
    public IEnumerable<DisputeFileUpload> DisputeFileUploads { get; set; } = null!;
}
public class CreateDisputeFileUploadRequest
{
    [JsonPropertyName("dispute_file_upload"), Required]
    public CreateDisputeFileUpload DisputeFileUpload { get; set; } = null!;
}

public partial class CreateDisputeFileUpload : DisputeFileUploadBase {}
public class UpdateDisputeFileUploadRequest
{
    [JsonPropertyName("dispute_file_upload"), Required]
    public UpdateDisputeFileUpload DisputeFileUpload { get; set; } = null!;
}

public partial class UpdateDisputeFileUpload : DisputeFileUpload{}

		
	
public class DisputeFileUpload : DisputeFileUploadBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class PayoutItem
{
    [JsonPropertyName("payout"), Required]
    public Payout Payout { get; set; } = null!;
}

public class PayoutList
{
    [JsonPropertyName("payouts"), Required]
    public IEnumerable<Payout> Payouts { get; set; } = null!;
}
public class CreatePayoutRequest
{
    [JsonPropertyName("payout"), Required]
    public CreatePayout Payout { get; set; } = null!;
}

public partial class CreatePayout : PayoutBase {}
public class UpdatePayoutRequest
{
    [JsonPropertyName("payout"), Required]
    public UpdatePayout Payout { get; set; } = null!;
}

public partial class UpdatePayout : Payout{}

		
	
public class Payout : PayoutBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CountryItem
{
    [JsonPropertyName("country"), Required]
    public Country Country { get; set; } = null!;
}

public class CountryList
{
    [JsonPropertyName("countries"), Required]
    public IEnumerable<Country> Countries { get; set; } = null!;
}
public class CreateCountryRequest
{
    [JsonPropertyName("country"), Required]
    public CreateCountry Country { get; set; } = null!;
}

public partial class CreateCountry : CountryBase {}
public class UpdateCountryRequest
{
    [JsonPropertyName("country"), Required]
    public UpdateCountry Country { get; set; } = null!;
}

public partial class UpdateCountry : Country{}

		
	
public class Country : CountryBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CurrencyItem
{
    [JsonPropertyName("currency"), Required]
    public Currency Currency { get; set; } = null!;
}

public class CurrencyList
{
    [JsonPropertyName("currencies"), Required]
    public IEnumerable<Currency> Currencies { get; set; } = null!;
}
public class CreateCurrencyRequest
{
    [JsonPropertyName("currency"), Required]
    public CreateCurrency Currency { get; set; } = null!;
}

public partial class CreateCurrency : CurrencyBase {}
public class UpdateCurrencyRequest
{
    [JsonPropertyName("currency"), Required]
    public UpdateCurrency Currency { get; set; } = null!;
}

public partial class UpdateCurrency : Currency{}

		
	
public class Currency : CurrencyBase
{
}
	
public class PolicyItem
{
    [JsonPropertyName("policy"), Required]
    public Policy Policy { get; set; } = null!;
}

public class PolicyList
{
    [JsonPropertyName("policies"), Required]
    public IEnumerable<Policy> Policies { get; set; } = null!;
}
public class CreatePolicyRequest
{
    [JsonPropertyName("policy"), Required]
    public CreatePolicy Policy { get; set; } = null!;
}

public partial class CreatePolicy : PolicyBase {}
public class UpdatePolicyRequest
{
    [JsonPropertyName("policy"), Required]
    public UpdatePolicy Policy { get; set; } = null!;
}

public partial class UpdatePolicy : Policy{}

		
	
public class Policy : PolicyBase
{
}
	
public class ProvinceItem
{
    [JsonPropertyName("province"), Required]
    public Province Province { get; set; } = null!;
}

public class ProvinceList
{
    [JsonPropertyName("provinces"), Required]
    public IEnumerable<Province> Provinces { get; set; } = null!;
}
public class CreateProvinceRequest
{
    [JsonPropertyName("province"), Required]
    public CreateProvince Province { get; set; } = null!;
}

public partial class CreateProvince : ProvinceBase {}
public class UpdateProvinceRequest
{
    [JsonPropertyName("province"), Required]
    public UpdateProvince Province { get; set; } = null!;
}

public partial class UpdateProvince : Province{}

		
	
public class Province : ProvinceBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ShippingZoneItem
{
    [JsonPropertyName("shipping_zone"), Required]
    public ShippingZone ShippingZone { get; set; } = null!;
}

public class ShippingZoneList
{
    [JsonPropertyName("shipping_zones"), Required]
    public IEnumerable<ShippingZone> ShippingZones { get; set; } = null!;
}
public class CreateShippingZoneRequest
{
    [JsonPropertyName("shipping_zone"), Required]
    public CreateShippingZone ShippingZone { get; set; } = null!;
}

public partial class CreateShippingZone : ShippingZoneBase {}
public class UpdateShippingZoneRequest
{
    [JsonPropertyName("shipping_zone"), Required]
    public UpdateShippingZone ShippingZone { get; set; } = null!;
}

public partial class UpdateShippingZone : ShippingZone{}

		
	
public class ShippingZone : ShippingZoneBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class ShopItem
{
    [JsonPropertyName("shop"), Required]
    public Shop Shop { get; set; } = null!;
}

public class ShopList
{
    [JsonPropertyName("shops"), Required]
    public IEnumerable<Shop> Shops { get; set; } = null!;
}
public class CreateShopRequest
{
    [JsonPropertyName("shop"), Required]
    public CreateShop Shop { get; set; } = null!;
}

public partial class CreateShop : ShopBase {}
public class UpdateShopRequest
{
    [JsonPropertyName("shop"), Required]
    public UpdateShop Shop { get; set; } = null!;
}

public partial class UpdateShop : Shop{}

		
	
public class Shop : ShopBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class TenderTransactionItem
{
    [JsonPropertyName("tender_transaction"), Required]
    public TenderTransaction TenderTransaction { get; set; } = null!;
}

public class TenderTransactionList
{
    [JsonPropertyName("tender_transactions"), Required]
    public IEnumerable<TenderTransaction> TenderTransactions { get; set; } = null!;
}
public class CreateTenderTransactionRequest
{
    [JsonPropertyName("tender_transaction"), Required]
    public CreateTenderTransaction TenderTransaction { get; set; } = null!;
}

public partial class CreateTenderTransaction : TenderTransactionBase {}
public class UpdateTenderTransactionRequest
{
    [JsonPropertyName("tender_transaction"), Required]
    public UpdateTenderTransaction TenderTransaction { get; set; } = null!;
}

public partial class UpdateTenderTransaction : TenderTransaction{}

		
	
public class TenderTransaction : TenderTransactionBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class DiscountCodeCreationItem
{
    [JsonPropertyName("discount_code_creation"), Required]
    public DiscountCodeCreation DiscountCodeCreation { get; set; } = null!;
}

public class DiscountCodeCreationList
{
    [JsonPropertyName("discount_code_creations"), Required]
    public IEnumerable<DiscountCodeCreation> DiscountCodeCreations { get; set; } = null!;
}
public class CreateDiscountCodeCreationRequest
{
    [JsonPropertyName("discount_code_creation"), Required]
    public CreateDiscountCodeCreation DiscountCodeCreation { get; set; } = null!;
}

public partial class CreateDiscountCodeCreation : DiscountCodeCreationBase {}
public class UpdateDiscountCodeCreationRequest
{
    [JsonPropertyName("discount_code_creation"), Required]
    public UpdateDiscountCodeCreation DiscountCodeCreation { get; set; } = null!;
}

public partial class UpdateDiscountCodeCreation : DiscountCodeCreation{}

		
	
public class DiscountCodeCreation : DiscountCodeCreationBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class EngagementItem
{
    [JsonPropertyName("engagement"), Required]
    public Engagement Engagement { get; set; } = null!;
}

public class EngagementList
{
    [JsonPropertyName("engagements"), Required]
    public IEnumerable<Engagement> Engagements { get; set; } = null!;
}
public class CreateEngagementRequest
{
    [JsonPropertyName("engagement"), Required]
    public CreateEngagement Engagement { get; set; } = null!;
}

public partial class CreateEngagement : EngagementBase {}
public class UpdateEngagementRequest
{
    [JsonPropertyName("engagement"), Required]
    public UpdateEngagement Engagement { get; set; } = null!;
}

public partial class UpdateEngagement : Engagement{}

		
	
public class Engagement : EngagementBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	
public class CustomerInviteItem
{
    [JsonPropertyName("customer_invite"), Required]
    public CustomerInvite CustomerInvite { get; set; } = null!;
}

public class CustomerInviteList
{
    [JsonPropertyName("customer_invites"), Required]
    public IEnumerable<CustomerInvite> CustomerInvites { get; set; } = null!;
}
public class CreateCustomerInviteRequest
{
    [JsonPropertyName("customer_invite"), Required]
    public CreateCustomerInvite CustomerInvite { get; set; } = null!;
}

public partial class CreateCustomerInvite : CustomerInviteBase {}
public class UpdateCustomerInviteRequest
{
    [JsonPropertyName("customer_invite"), Required]
    public UpdateCustomerInvite CustomerInvite { get; set; } = null!;
}

public partial class UpdateCustomerInvite : CustomerInvite{}

		
	
public class CustomerInvite : CustomerInviteBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
	    [JsonPropertyName("admin_graphql_api_id")]
    public string? AdminGraphQLAPIId { get; set; }
	}
	