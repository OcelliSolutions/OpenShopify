

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Models;

namespace OpenShopify.Admin.Builder.Models;

public class AccessScopeItem
{
    [JsonPropertyName("access_scope")]
    public AccessScope AccessScope { get; set; } = null!;
}

public class AccessScopeList
{
    [JsonPropertyName("access_scopes")]
    public IEnumerable<AccessScope> AccessScopes { get; set; } = null!;
}
		
	
public class AccessScope : AccessScopeBase
{
}
	
public class StorefrontAccessTokenItem
{
    [JsonPropertyName("storefront_access_token")]
    public StorefrontAccessToken StorefrontAccessToken { get; set; } = null!;
}

public class StorefrontAccessTokenList
{
    [JsonPropertyName("storefront_access_tokens")]
    public IEnumerable<StorefrontAccessToken> StorefrontAccessTokens { get; set; } = null!;
}
public class CreateStorefrontAccessTokenRequest
{
    [JsonPropertyName("storefront_access_token")]
    public CreateStorefrontAccessToken StorefrontAccessToken { get; set; } = null!;
}

public partial class CreateStorefrontAccessToken : StorefrontAccessTokenBase {}
public class UpdateStorefrontAccessTokenRequest : StorefrontAccessToken
{
    [JsonPropertyName("storefront_access_token")]
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
    [JsonPropertyName("report")]
    public Report Report { get; set; } = null!;
}

public class ReportList
{
    [JsonPropertyName("reports")]
    public IEnumerable<Report> Reports { get; set; } = null!;
}
public class CreateReportRequest
{
    [JsonPropertyName("report")]
    public CreateReport Report { get; set; } = null!;
}

public partial class CreateReport : ReportBase {}
public class UpdateReportRequest : Report
{
    [JsonPropertyName("report")]
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
    [JsonPropertyName("application_charge")]
    public ApplicationCharge ApplicationCharge { get; set; } = null!;
}

public class ApplicationChargeList
{
    [JsonPropertyName("application_charges")]
    public IEnumerable<ApplicationCharge> ApplicationCharges { get; set; } = null!;
}
public class CreateApplicationChargeRequest
{
    [JsonPropertyName("application_charge")]
    public CreateApplicationCharge ApplicationCharge { get; set; } = null!;
}

public partial class CreateApplicationCharge : ApplicationChargeBase {}
public class UpdateApplicationChargeRequest : ApplicationCharge
{
    [JsonPropertyName("application_charge")]
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
    [JsonPropertyName("application_credit")]
    public ApplicationCredit ApplicationCredit { get; set; } = null!;
}

public class ApplicationCreditList
{
    [JsonPropertyName("application_credits")]
    public IEnumerable<ApplicationCredit> ApplicationCredits { get; set; } = null!;
}
public class CreateApplicationCreditRequest
{
    [JsonPropertyName("application_credit")]
    public CreateApplicationCredit ApplicationCredit { get; set; } = null!;
}

public partial class CreateApplicationCredit : ApplicationCreditBase {}
public class UpdateApplicationCreditRequest : ApplicationCredit
{
    [JsonPropertyName("application_credit")]
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
    [JsonPropertyName("recurring_application_charge")]
    public RecurringApplicationCharge RecurringApplicationCharge { get; set; } = null!;
}

public class RecurringApplicationChargeList
{
    [JsonPropertyName("recurring_application_charges")]
    public IEnumerable<RecurringApplicationCharge> RecurringApplicationCharges { get; set; } = null!;
}
public class CreateRecurringApplicationChargeRequest
{
    [JsonPropertyName("recurring_application_charge")]
    public CreateRecurringApplicationCharge RecurringApplicationCharge { get; set; } = null!;
}

public partial class CreateRecurringApplicationCharge : RecurringApplicationChargeBase {}
public class UpdateRecurringApplicationChargeRequest : RecurringApplicationCharge
{
    [JsonPropertyName("recurring_application_charge")]
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
    [JsonPropertyName("usage_charge")]
    public UsageCharge UsageCharge { get; set; } = null!;
}

public class UsageChargeList
{
    [JsonPropertyName("usage_charges")]
    public IEnumerable<UsageCharge> UsageCharges { get; set; } = null!;
}
public class CreateUsageChargeRequest
{
    [JsonPropertyName("usage_charge")]
    public CreateUsageCharge UsageCharge { get; set; } = null!;
}

public partial class CreateUsageCharge : UsageChargeBase {}
public class UpdateUsageChargeRequest : UsageCharge
{
    [JsonPropertyName("usage_charge")]
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
    [JsonPropertyName("customer")]
    public Customer Customer { get; set; } = null!;
}

public class CustomerList
{
    [JsonPropertyName("customers")]
    public IEnumerable<Customer> Customers { get; set; } = null!;
}
public class CreateCustomerRequest
{
    [JsonPropertyName("customer")]
    public CreateCustomer Customer { get; set; } = null!;
}

public partial class CreateCustomer : CustomerBase {}
public class UpdateCustomerRequest : Customer
{
    [JsonPropertyName("customer")]
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
    [JsonPropertyName("address")]
    public Address Address { get; set; } = null!;
}

public class AddressList
{
    [JsonPropertyName("addresses")]
    public IEnumerable<Address> Addresses { get; set; } = null!;
}
public class CreateAddressRequest
{
    [JsonPropertyName("address")]
    public CreateAddress Address { get; set; } = null!;
}

public partial class CreateAddress : AddressBase {}
public class UpdateAddressRequest : Address
{
    [JsonPropertyName("address")]
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
    [JsonPropertyName("customer_address")]
    public Address CustomerAddress { get; set; } = null!;
}

public class CustomerAddressList
{
    [JsonPropertyName("customer_addresses")]
    public IEnumerable<Address> CustomerAddresses { get; set; } = null!;
}
public class CreateCustomerAddressRequest
{
    [JsonPropertyName("customer_address")]
    public CreateCustomerAddress CustomerAddress { get; set; } = null!;
}

public partial class CreateCustomerAddress : AddressBase {}
public class UpdateCustomerAddressRequest : Address
{
    [JsonPropertyName("customer_address")]
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
    [JsonPropertyName("customer_saved_search")]
    public CustomerSavedSearch CustomerSavedSearch { get; set; } = null!;
}

public class CustomerSavedSearchList
{
    [JsonPropertyName("customer_saved_searchs")]
    public IEnumerable<CustomerSavedSearch> CustomerSavedSearchs { get; set; } = null!;
}
public class CreateCustomerSavedSearchRequest
{
    [JsonPropertyName("customer_saved_search")]
    public CreateCustomerSavedSearch CustomerSavedSearch { get; set; } = null!;
}

public partial class CreateCustomerSavedSearch : CustomerSavedSearchBase {}
public class UpdateCustomerSavedSearchRequest : CustomerSavedSearch
{
    [JsonPropertyName("customer_saved_search")]
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
    [JsonPropertyName("deprecated_api_call")]
    public DeprecatedApiCall DeprecatedApiCall { get; set; } = null!;
}

public class DeprecatedApiCallList
{
    [JsonPropertyName("deprecated_api_calls")]
    public IEnumerable<DeprecatedApiCall> DeprecatedApiCalls { get; set; } = null!;
}
public class CreateDeprecatedApiCallRequest
{
    [JsonPropertyName("deprecated_api_call")]
    public CreateDeprecatedApiCall DeprecatedApiCall { get; set; } = null!;
}

public partial class CreateDeprecatedApiCall : DeprecatedApiCallBase {}
public class UpdateDeprecatedApiCallRequest : DeprecatedApiCall
{
    [JsonPropertyName("deprecated_api_call")]
    public UpdateDeprecatedApiCall DeprecatedApiCall { get; set; } = null!;
}

public partial class UpdateDeprecatedApiCall : DeprecatedApiCall{}

		
	
public class DeprecatedApiCall : DeprecatedApiCallBase
{
}
	
public class DiscountCodeItem
{
    [JsonPropertyName("discount_code")]
    public DiscountCode DiscountCode { get; set; } = null!;
}

public class DiscountCodeList
{
    [JsonPropertyName("discount_codes")]
    public IEnumerable<DiscountCode> DiscountCodes { get; set; } = null!;
}
public class CreateDiscountCodeRequest
{
    [JsonPropertyName("discount_code")]
    public CreateDiscountCode DiscountCode { get; set; } = null!;
}

public partial class CreateDiscountCode : DiscountCodeBase {}
public class UpdateDiscountCodeRequest : DiscountCode
{
    [JsonPropertyName("discount_code")]
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
    [JsonPropertyName("price_rule")]
    public PriceRule PriceRule { get; set; } = null!;
}

public class PriceRuleList
{
    [JsonPropertyName("price_rules")]
    public IEnumerable<PriceRule> PriceRules { get; set; } = null!;
}
public class CreatePriceRuleRequest
{
    [JsonPropertyName("price_rule")]
    public CreatePriceRule PriceRule { get; set; } = null!;
}

public partial class CreatePriceRule : PriceRuleBase {}
public class UpdatePriceRuleRequest : PriceRule
{
    [JsonPropertyName("price_rule")]
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
    [JsonPropertyName("event")]
    public Event Event { get; set; } = null!;
}

public class EventList
{
    [JsonPropertyName("events")]
    public IEnumerable<Event> Events { get; set; } = null!;
}
public class CreateEventRequest
{
    [JsonPropertyName("event")]
    public CreateEvent Event { get; set; } = null!;
}

public partial class CreateEvent : EventBase {}
public class UpdateEventRequest : Event
{
    [JsonPropertyName("event")]
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
    [JsonPropertyName("webhook")]
    public Webhook Webhook { get; set; } = null!;
}

public class WebhookList
{
    [JsonPropertyName("webhooks")]
    public IEnumerable<Webhook> Webhooks { get; set; } = null!;
}
public class CreateWebhookRequest
{
    [JsonPropertyName("webhook")]
    public CreateWebhook Webhook { get; set; } = null!;
}

public partial class CreateWebhook : WebhookBase {}
public class UpdateWebhookRequest : Webhook
{
    [JsonPropertyName("webhook")]
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
    [JsonPropertyName("inventory_item")]
    public InventoryItem InventoryItem { get; set; } = null!;
}

public class InventoryItemList
{
    [JsonPropertyName("inventory_items")]
    public IEnumerable<InventoryItem> InventoryItems { get; set; } = null!;
}
public class CreateInventoryItemRequest
{
    [JsonPropertyName("inventory_item")]
    public CreateInventoryItem InventoryItem { get; set; } = null!;
}

public partial class CreateInventoryItem : InventoryItemBase {}
public class UpdateInventoryItemRequest : InventoryItem
{
    [JsonPropertyName("inventory_item")]
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
    [JsonPropertyName("inventory_level")]
    public InventoryLevel InventoryLevel { get; set; } = null!;
}

public class InventoryLevelList
{
    [JsonPropertyName("inventory_levels")]
    public IEnumerable<InventoryLevel> InventoryLevels { get; set; } = null!;
}
public class CreateInventoryLevelRequest
{
    [JsonPropertyName("inventory_level")]
    public CreateInventoryLevel InventoryLevel { get; set; } = null!;
}

public partial class CreateInventoryLevel : InventoryLevelBase {}
public class UpdateInventoryLevelRequest : InventoryLevel
{
    [JsonPropertyName("inventory_level")]
    public UpdateInventoryLevel InventoryLevel { get; set; } = null!;
}

public partial class UpdateInventoryLevel : InventoryLevel{}

		
	
public class InventoryLevel : InventoryLevelBase
{
}
	
public class LocationItem
{
    [JsonPropertyName("location")]
    public Location Location { get; set; } = null!;
}

public class LocationList
{
    [JsonPropertyName("locations")]
    public IEnumerable<Location> Locations { get; set; } = null!;
}
public class CreateLocationRequest
{
    [JsonPropertyName("location")]
    public CreateLocation Location { get; set; } = null!;
}

public partial class CreateLocation : LocationBase {}
public class UpdateLocationRequest : Location
{
    [JsonPropertyName("location")]
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
    [JsonPropertyName("marketing_event")]
    public MarketingEvent MarketingEvent { get; set; } = null!;
}

public class MarketingEventList
{
    [JsonPropertyName("marketing_events")]
    public IEnumerable<MarketingEvent> MarketingEvents { get; set; } = null!;
}
public class CreateMarketingEventRequest
{
    [JsonPropertyName("marketing_event")]
    public CreateMarketingEvent MarketingEvent { get; set; } = null!;
}

public partial class CreateMarketingEvent : MarketingEventBase {}
public class UpdateMarketingEventRequest : MarketingEvent
{
    [JsonPropertyName("marketing_event")]
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
    [JsonPropertyName("metafield")]
    public Metafield Metafield { get; set; } = null!;
}

public class MetafieldList
{
    [JsonPropertyName("metafields")]
    public IEnumerable<Metafield> Metafields { get; set; } = null!;
}
public class CreateMetafieldRequest
{
    [JsonPropertyName("metafield")]
    public CreateMetafield Metafield { get; set; } = null!;
}

public partial class CreateMetafield : MetafieldBase {}
public class UpdateMetafieldRequest : Metafield
{
    [JsonPropertyName("metafield")]
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
    [JsonPropertyName("article")]
    public Article Article { get; set; } = null!;
}

public class ArticleList
{
    [JsonPropertyName("articles")]
    public IEnumerable<Article> Articles { get; set; } = null!;
}
public class CreateArticleRequest
{
    [JsonPropertyName("article")]
    public CreateArticle Article { get; set; } = null!;
}

public partial class CreateArticle : ArticleBase {}
public class UpdateArticleRequest : Article
{
    [JsonPropertyName("article")]
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
    [JsonPropertyName("asset")]
    public Asset Asset { get; set; } = null!;
}

public class AssetList
{
    [JsonPropertyName("assets")]
    public IEnumerable<Asset> Assets { get; set; } = null!;
}
public class CreateAssetRequest
{
    [JsonPropertyName("asset")]
    public CreateAsset Asset { get; set; } = null!;
}

public partial class CreateAsset : AssetBase {}
public class UpdateAssetRequest : Asset
{
    [JsonPropertyName("asset")]
    public UpdateAsset Asset { get; set; } = null!;
}

public partial class UpdateAsset : Asset{}

		
	
public class Asset : AssetBase
{
}
	
public class BlogItem
{
    [JsonPropertyName("blog")]
    public Blog Blog { get; set; } = null!;
}

public class BlogList
{
    [JsonPropertyName("blogs")]
    public IEnumerable<Blog> Blogs { get; set; } = null!;
}
public class CreateBlogRequest
{
    [JsonPropertyName("blog")]
    public CreateBlog Blog { get; set; } = null!;
}

public partial class CreateBlog : BlogBase {}
public class UpdateBlogRequest : Blog
{
    [JsonPropertyName("blog")]
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
    [JsonPropertyName("comment")]
    public Comment Comment { get; set; } = null!;
}

public class CommentList
{
    [JsonPropertyName("comments")]
    public IEnumerable<Comment> Comments { get; set; } = null!;
}
public class CreateCommentRequest
{
    [JsonPropertyName("comment")]
    public CreateComment Comment { get; set; } = null!;
}

public partial class CreateComment : CommentBase {}
public class UpdateCommentRequest : Comment
{
    [JsonPropertyName("comment")]
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
    [JsonPropertyName("page")]
    public Page Page { get; set; } = null!;
}

public class PageList
{
    [JsonPropertyName("pages")]
    public IEnumerable<Page> Pages { get; set; } = null!;
}
public class CreatePageRequest
{
    [JsonPropertyName("page")]
    public CreatePage Page { get; set; } = null!;
}

public partial class CreatePage : PageBase {}
public class UpdatePageRequest : Page
{
    [JsonPropertyName("page")]
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
    [JsonPropertyName("redirect")]
    public Redirect Redirect { get; set; } = null!;
}

public class RedirectList
{
    [JsonPropertyName("redirects")]
    public IEnumerable<Redirect> Redirects { get; set; } = null!;
}
public class CreateRedirectRequest
{
    [JsonPropertyName("redirect")]
    public CreateRedirect Redirect { get; set; } = null!;
}

public partial class CreateRedirect : RedirectBase {}
public class UpdateRedirectRequest : Redirect
{
    [JsonPropertyName("redirect")]
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
    [JsonPropertyName("script_tag")]
    public ScriptTag ScriptTag { get; set; } = null!;
}

public class ScriptTagList
{
    [JsonPropertyName("script_tags")]
    public IEnumerable<ScriptTag> ScriptTags { get; set; } = null!;
}
public class CreateScriptTagRequest
{
    [JsonPropertyName("script_tag")]
    public CreateScriptTag ScriptTag { get; set; } = null!;
}

public partial class CreateScriptTag : ScriptTagBase {}
public class UpdateScriptTagRequest : ScriptTag
{
    [JsonPropertyName("script_tag")]
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
    [JsonPropertyName("theme")]
    public Theme Theme { get; set; } = null!;
}

public class ThemeList
{
    [JsonPropertyName("themes")]
    public IEnumerable<Theme> Themes { get; set; } = null!;
}
public class CreateThemeRequest
{
    [JsonPropertyName("theme")]
    public CreateTheme Theme { get; set; } = null!;
}

public partial class CreateTheme : ThemeBase {}
public class UpdateThemeRequest : Theme
{
    [JsonPropertyName("theme")]
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
    [JsonPropertyName("abandoned_checkout")]
    public Checkout AbandonedCheckout { get; set; } = null!;
}

public class AbandonedCheckoutList
{
    [JsonPropertyName("abandoned_checkouts")]
    public IEnumerable<Checkout> AbandonedCheckouts { get; set; } = null!;
}
public class CreateAbandonedCheckoutRequest
{
    [JsonPropertyName("abandoned_checkout")]
    public CreateAbandonedCheckout AbandonedCheckout { get; set; } = null!;
}

public partial class CreateAbandonedCheckout : CheckoutBase {}
public class UpdateAbandonedCheckoutRequest : Checkout
{
    [JsonPropertyName("abandoned_checkout")]
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
    [JsonPropertyName("draft_order")]
    public DraftOrder DraftOrder { get; set; } = null!;
}

public class DraftOrderList
{
    [JsonPropertyName("draft_orders")]
    public IEnumerable<DraftOrder> DraftOrders { get; set; } = null!;
}
public class CreateDraftOrderRequest
{
    [JsonPropertyName("draft_order")]
    public CreateDraftOrder DraftOrder { get; set; } = null!;
}

public partial class CreateDraftOrder : DraftOrderBase {}
public class UpdateDraftOrderRequest : DraftOrder
{
    [JsonPropertyName("draft_order")]
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
    [JsonPropertyName("order")]
    public Order Order { get; set; } = null!;
}

public class OrderList
{
    [JsonPropertyName("orders")]
    public IEnumerable<Order> Orders { get; set; } = null!;
}
public class CreateOrderRequest
{
    [JsonPropertyName("order")]
    public CreateOrder Order { get; set; } = null!;
}

public partial class CreateOrder : OrderBase {}
public class UpdateOrderRequest : Order
{
    [JsonPropertyName("order")]
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
    [JsonPropertyName("order_risk")]
    public OrderRisk OrderRisk { get; set; } = null!;
}

public class OrderRiskList
{
    [JsonPropertyName("order_risks")]
    public IEnumerable<OrderRisk> OrderRisks { get; set; } = null!;
}
public class CreateOrderRiskRequest
{
    [JsonPropertyName("order_risk")]
    public CreateOrderRisk OrderRisk { get; set; } = null!;
}

public partial class CreateOrderRisk : OrderRiskBase {}
public class UpdateOrderRiskRequest : OrderRisk
{
    [JsonPropertyName("order_risk")]
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
    [JsonPropertyName("refund")]
    public Refund Refund { get; set; } = null!;
}

public class RefundList
{
    [JsonPropertyName("refunds")]
    public IEnumerable<Refund> Refunds { get; set; } = null!;
}
public class CreateRefundRequest
{
    [JsonPropertyName("refund")]
    public CreateRefund Refund { get; set; } = null!;
}

public partial class CreateRefund : RefundBase {}
public class UpdateRefundRequest : Refund
{
    [JsonPropertyName("refund")]
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
    [JsonPropertyName("transaction")]
    public Transaction Transaction { get; set; } = null!;
}

public class TransactionList
{
    [JsonPropertyName("transactions")]
    public IEnumerable<Transaction> Transactions { get; set; } = null!;
}
public class CreateTransactionRequest
{
    [JsonPropertyName("transaction")]
    public CreateTransaction Transaction { get; set; } = null!;
}

public partial class CreateTransaction : TransactionBase {}
public class UpdateTransactionRequest : Transaction
{
    [JsonPropertyName("transaction")]
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
    [JsonPropertyName("gift_card")]
    public GiftCard GiftCard { get; set; } = null!;
}

public class GiftCardList
{
    [JsonPropertyName("gift_cards")]
    public IEnumerable<GiftCard> GiftCards { get; set; } = null!;
}
public class CreateGiftCardRequest
{
    [JsonPropertyName("gift_card")]
    public CreateGiftCard GiftCard { get; set; } = null!;
}

public partial class CreateGiftCard : GiftCardBase {}
public class UpdateGiftCardRequest : GiftCard
{
    [JsonPropertyName("gift_card")]
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
    [JsonPropertyName("user")]
    public User User { get; set; } = null!;
}

public class UserList
{
    [JsonPropertyName("users")]
    public IEnumerable<User> Users { get; set; } = null!;
}
public class CreateUserRequest
{
    [JsonPropertyName("user")]
    public CreateUser User { get; set; } = null!;
}

public partial class CreateUser : UserBase {}
public class UpdateUserRequest : User
{
    [JsonPropertyName("user")]
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
    [JsonPropertyName("collect")]
    public Collect Collect { get; set; } = null!;
}

public class CollectList
{
    [JsonPropertyName("collects")]
    public IEnumerable<Collect> Collects { get; set; } = null!;
}
public class CreateCollectRequest
{
    [JsonPropertyName("collect")]
    public CreateCollect Collect { get; set; } = null!;
}

public partial class CreateCollect : CollectBase {}
public class UpdateCollectRequest : Collect
{
    [JsonPropertyName("collect")]
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
    [JsonPropertyName("collection")]
    public Collection Collection { get; set; } = null!;
}

public class CollectionList
{
    [JsonPropertyName("collections")]
    public IEnumerable<Collection> Collections { get; set; } = null!;
}
public class CreateCollectionRequest
{
    [JsonPropertyName("collection")]
    public CreateCollection Collection { get; set; } = null!;
}

public partial class CreateCollection : CollectionBase {}
public class UpdateCollectionRequest : Collection
{
    [JsonPropertyName("collection")]
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
    [JsonPropertyName("custom_collection")]
    public CustomCollection CustomCollection { get; set; } = null!;
}

public class CustomCollectionList
{
    [JsonPropertyName("custom_collections")]
    public IEnumerable<CustomCollection> CustomCollections { get; set; } = null!;
}
public class CreateCustomCollectionRequest
{
    [JsonPropertyName("custom_collection")]
    public CreateCustomCollection CustomCollection { get; set; } = null!;
}

public partial class CreateCustomCollection : CustomCollectionBase {}
public class UpdateCustomCollectionRequest : CustomCollection
{
    [JsonPropertyName("custom_collection")]
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
    [JsonPropertyName("product")]
    public Product Product { get; set; } = null!;
}

public class ProductList
{
    [JsonPropertyName("products")]
    public IEnumerable<Product> Products { get; set; } = null!;
}
public class CreateProductRequest
{
    [JsonPropertyName("product")]
    public CreateProduct Product { get; set; } = null!;
}

public partial class CreateProduct : ProductBase {}
public class UpdateProductRequest : Product
{
    [JsonPropertyName("product")]
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
    [JsonPropertyName("product_image")]
    public ProductImage ProductImage { get; set; } = null!;
}

public class ProductImageList
{
    [JsonPropertyName("product_images")]
    public IEnumerable<ProductImage> ProductImages { get; set; } = null!;
}
public class CreateProductImageRequest
{
    [JsonPropertyName("product_image")]
    public CreateProductImage ProductImage { get; set; } = null!;
}

public partial class CreateProductImage : ProductImageBase {}
public class UpdateProductImageRequest : ProductImage
{
    [JsonPropertyName("product_image")]
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
    [JsonPropertyName("product_variant")]
    public ProductVariant ProductVariant { get; set; } = null!;
}

public class ProductVariantList
{
    [JsonPropertyName("product_variants")]
    public IEnumerable<ProductVariant> ProductVariants { get; set; } = null!;
}
public class CreateProductVariantRequest
{
    [JsonPropertyName("product_variant")]
    public CreateProductVariant ProductVariant { get; set; } = null!;
}

public partial class CreateProductVariant : ProductVariantBase {}
public class UpdateProductVariantRequest : ProductVariant
{
    [JsonPropertyName("product_variant")]
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
    [JsonPropertyName("smart_collection")]
    public SmartCollection SmartCollection { get; set; } = null!;
}

public class SmartCollectionList
{
    [JsonPropertyName("smart_collections")]
    public IEnumerable<SmartCollection> SmartCollections { get; set; } = null!;
}
public class CreateSmartCollectionRequest
{
    [JsonPropertyName("smart_collection")]
    public CreateSmartCollection SmartCollection { get; set; } = null!;
}

public partial class CreateSmartCollection : SmartCollectionBase {}
public class UpdateSmartCollectionRequest : SmartCollection
{
    [JsonPropertyName("smart_collection")]
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
    [JsonPropertyName("checkout")]
    public Checkout Checkout { get; set; } = null!;
}

public class CheckoutList
{
    [JsonPropertyName("checkouts")]
    public IEnumerable<Checkout> Checkouts { get; set; } = null!;
}
public class CreateCheckoutRequest
{
    [JsonPropertyName("checkout")]
    public CreateCheckout Checkout { get; set; } = null!;
}

public partial class CreateCheckout : CheckoutBase {}
public class UpdateCheckoutRequest : Checkout
{
    [JsonPropertyName("checkout")]
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
    [JsonPropertyName("collection_listing")]
    public CollectionListing CollectionListing { get; set; } = null!;
}

public class CollectionListingList
{
    [JsonPropertyName("collection_listings")]
    public IEnumerable<CollectionListing> CollectionListings { get; set; } = null!;
}
public class CreateCollectionListingRequest
{
    [JsonPropertyName("collection_listing")]
    public CreateCollectionListing CollectionListing { get; set; } = null!;
}

public partial class CreateCollectionListing : CollectionListingBase {}
public class UpdateCollectionListingRequest : CollectionListing
{
    [JsonPropertyName("collection_listing")]
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
    [JsonPropertyName("mobile_platform_application")]
    public MobilePlatformApplication MobilePlatformApplication { get; set; } = null!;
}

public class MobilePlatformApplicationList
{
    [JsonPropertyName("mobile_platform_applications")]
    public IEnumerable<MobilePlatformApplication> MobilePlatformApplications { get; set; } = null!;
}
public class CreateMobilePlatformApplicationRequest
{
    [JsonPropertyName("mobile_platform_application")]
    public CreateMobilePlatformApplication MobilePlatformApplication { get; set; } = null!;
}

public partial class CreateMobilePlatformApplication : MobilePlatformApplicationBase {}
public class UpdateMobilePlatformApplicationRequest : MobilePlatformApplication
{
    [JsonPropertyName("mobile_platform_application")]
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
    [JsonPropertyName("payment")]
    public Payment Payment { get; set; } = null!;
}

public class PaymentList
{
    [JsonPropertyName("payments")]
    public IEnumerable<Payment> Payments { get; set; } = null!;
}
public class CreatePaymentRequest
{
    [JsonPropertyName("payment")]
    public CreatePayment Payment { get; set; } = null!;
}

public partial class CreatePayment : PaymentBase {}
public class UpdatePaymentRequest : Payment
{
    [JsonPropertyName("payment")]
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
    [JsonPropertyName("product_resource_feedback")]
    public ProductResourceFeedback ProductResourceFeedback { get; set; } = null!;
}

public class ProductResourceFeedbackList
{
    [JsonPropertyName("product_resource_feedbacks")]
    public IEnumerable<ProductResourceFeedback> ProductResourceFeedbacks { get; set; } = null!;
}
public class CreateProductResourceFeedbackRequest
{
    [JsonPropertyName("product_resource_feedback")]
    public CreateProductResourceFeedback ProductResourceFeedback { get; set; } = null!;
}

public partial class CreateProductResourceFeedback : ProductResourceFeedbackBase {}
public class UpdateProductResourceFeedbackRequest : ProductResourceFeedback
{
    [JsonPropertyName("product_resource_feedback")]
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
    [JsonPropertyName("product_listing")]
    public ProductListing ProductListing { get; set; } = null!;
}

public class ProductListingList
{
    [JsonPropertyName("product_listings")]
    public IEnumerable<ProductListing> ProductListings { get; set; } = null!;
}
public class CreateProductListingRequest
{
    [JsonPropertyName("product_listing")]
    public CreateProductListing ProductListing { get; set; } = null!;
}

public partial class CreateProductListing : ProductListingBase {}
public class UpdateProductListingRequest : ProductListing
{
    [JsonPropertyName("product_listing")]
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
    [JsonPropertyName("resource_feedback")]
    public ResourceFeedback ResourceFeedback { get; set; } = null!;
}

public class ResourceFeedbackList
{
    [JsonPropertyName("resource_feedbacks")]
    public IEnumerable<ResourceFeedback> ResourceFeedbacks { get; set; } = null!;
}
public class CreateResourceFeedbackRequest
{
    [JsonPropertyName("resource_feedback")]
    public CreateResourceFeedback ResourceFeedback { get; set; } = null!;
}

public partial class CreateResourceFeedback : ResourceFeedbackBase {}
public class UpdateResourceFeedbackRequest : ResourceFeedback
{
    [JsonPropertyName("resource_feedback")]
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
    [JsonPropertyName("assigned_fulfillment_order")]
    public FulfillmentOrder AssignedFulfillmentOrder { get; set; } = null!;
}

public class AssignedFulfillmentOrderList
{
    [JsonPropertyName("assigned_fulfillment_orders")]
    public IEnumerable<FulfillmentOrder> AssignedFulfillmentOrders { get; set; } = null!;
}
public class CreateAssignedFulfillmentOrderRequest
{
    [JsonPropertyName("assigned_fulfillment_order")]
    public CreateAssignedFulfillmentOrder AssignedFulfillmentOrder { get; set; } = null!;
}

public partial class CreateAssignedFulfillmentOrder : FulfillmentOrderBase {}
public class UpdateAssignedFulfillmentOrderRequest : FulfillmentOrder
{
    [JsonPropertyName("assigned_fulfillment_order")]
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
    [JsonPropertyName("cancellation_request")]
    public FulfillmentOrder CancellationRequest { get; set; } = null!;
}

public class CancellationRequestList
{
    [JsonPropertyName("cancellation_request")]
    public IEnumerable<FulfillmentOrder> CancellationRequest { get; set; } = null!;
}
public class CreateCancellationRequestRequest
{
    [JsonPropertyName("cancellation_request")]
    public CreateCancellationRequest CancellationRequest { get; set; } = null!;
}

public partial class CreateCancellationRequest : FulfillmentOrderBase {}
public class UpdateCancellationRequestRequest : FulfillmentOrder
{
    [JsonPropertyName("cancellation_request")]
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
    [JsonPropertyName("carrier_service")]
    public CarrierService CarrierService { get; set; } = null!;
}

public class CarrierServiceList
{
    [JsonPropertyName("carrier_services")]
    public IEnumerable<CarrierService> CarrierServices { get; set; } = null!;
}
public class CreateCarrierServiceRequest
{
    [JsonPropertyName("carrier_service")]
    public CreateCarrierService CarrierService { get; set; } = null!;
}

public partial class CreateCarrierService : CarrierServiceBase {}
public class UpdateCarrierServiceRequest : CarrierService
{
    [JsonPropertyName("carrier_service")]
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
    [JsonPropertyName("fulfillment")]
    public Fulfillment Fulfillment { get; set; } = null!;
}

public class FulfillmentList
{
    [JsonPropertyName("fulfillments")]
    public IEnumerable<Fulfillment> Fulfillments { get; set; } = null!;
}
public class CreateFulfillmentRequest
{
    [JsonPropertyName("fulfillment")]
    public CreateFulfillment Fulfillment { get; set; } = null!;
}

public partial class CreateFulfillment : FulfillmentBase {}
public class UpdateFulfillmentRequest : Fulfillment
{
    [JsonPropertyName("fulfillment")]
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
    [JsonPropertyName("fulfillment_event")]
    public FulfillmentEvent FulfillmentEvent { get; set; } = null!;
}

public class FulfillmentEventList
{
    [JsonPropertyName("fulfillment_events")]
    public IEnumerable<FulfillmentEvent> FulfillmentEvents { get; set; } = null!;
}
public class CreateFulfillmentEventRequest
{
    [JsonPropertyName("fulfillment_event")]
    public CreateFulfillmentEvent FulfillmentEvent { get; set; } = null!;
}

public partial class CreateFulfillmentEvent : FulfillmentEventBase {}
public class UpdateFulfillmentEventRequest : FulfillmentEvent
{
    [JsonPropertyName("fulfillment_event")]
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
    [JsonPropertyName("fulfillment_order")]
    public FulfillmentOrder FulfillmentOrder { get; set; } = null!;
}

public class FulfillmentOrderList
{
    [JsonPropertyName("fulfillment_orders")]
    public IEnumerable<FulfillmentOrder> FulfillmentOrders { get; set; } = null!;
}
public class CreateFulfillmentOrderRequest
{
    [JsonPropertyName("fulfillment_order")]
    public CreateFulfillmentOrder FulfillmentOrder { get; set; } = null!;
}

public partial class CreateFulfillmentOrder : FulfillmentOrderBase {}
public class UpdateFulfillmentOrderRequest : FulfillmentOrder
{
    [JsonPropertyName("fulfillment_order")]
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
    [JsonPropertyName("fulfillment_service")]
    public FulfillmentService FulfillmentService { get; set; } = null!;
}

public class FulfillmentServiceList
{
    [JsonPropertyName("fulfillment_services")]
    public IEnumerable<FulfillmentService> FulfillmentServices { get; set; } = null!;
}
public class CreateFulfillmentServiceRequest
{
    [JsonPropertyName("fulfillment_service")]
    public CreateFulfillmentService FulfillmentService { get; set; } = null!;
}

public partial class CreateFulfillmentService : FulfillmentServiceBase {}
public class UpdateFulfillmentServiceRequest : FulfillmentService
{
    [JsonPropertyName("fulfillment_service")]
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
    [JsonPropertyName("locations_for_move")]
    public LocationsForMove LocationsForMove { get; set; } = null!;
}

public class LocationsForMoveList
{
    [JsonPropertyName("locations_for_moves")]
    public IEnumerable<LocationsForMove> LocationsForMoves { get; set; } = null!;
}
public class CreateLocationsForMoveRequest
{
    [JsonPropertyName("locations_for_move")]
    public CreateLocationsForMove LocationsForMove { get; set; } = null!;
}

public partial class CreateLocationsForMove : LocationsForMoveBase {}
public class UpdateLocationsForMoveRequest : LocationsForMove
{
    [JsonPropertyName("locations_for_move")]
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
    [JsonPropertyName("balance")]
    public Balance Balance { get; set; } = null!;
}

public class BalanceList
{
    [JsonPropertyName("balances")]
    public IEnumerable<Balance> Balances { get; set; } = null!;
}
public class CreateBalanceRequest
{
    [JsonPropertyName("balance")]
    public CreateBalance Balance { get; set; } = null!;
}

public partial class CreateBalance : BalanceBase {}
public class UpdateBalanceRequest : Balance
{
    [JsonPropertyName("balance")]
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
    [JsonPropertyName("dispute")]
    public Dispute Dispute { get; set; } = null!;
}

public class DisputeList
{
    [JsonPropertyName("disputes")]
    public IEnumerable<Dispute> Disputes { get; set; } = null!;
}
public class CreateDisputeRequest
{
    [JsonPropertyName("dispute")]
    public CreateDispute Dispute { get; set; } = null!;
}

public partial class CreateDispute : DisputeBase {}
public class UpdateDisputeRequest : Dispute
{
    [JsonPropertyName("dispute")]
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
    [JsonPropertyName("dispute_evidence")]
    public DisputeEvidence DisputeEvidence { get; set; } = null!;
}

public class DisputeEvidenceList
{
    [JsonPropertyName("dispute_evidences")]
    public IEnumerable<DisputeEvidence> DisputeEvidences { get; set; } = null!;
}
public class CreateDisputeEvidenceRequest
{
    [JsonPropertyName("dispute_evidence")]
    public CreateDisputeEvidence DisputeEvidence { get; set; } = null!;
}

public partial class CreateDisputeEvidence : DisputeEvidenceBase {}
public class UpdateDisputeEvidenceRequest : DisputeEvidence
{
    [JsonPropertyName("dispute_evidence")]
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
    [JsonPropertyName("dispute_file_upload")]
    public DisputeFileUpload DisputeFileUpload { get; set; } = null!;
}

public class DisputeFileUploadList
{
    [JsonPropertyName("dispute_file_uploads")]
    public IEnumerable<DisputeFileUpload> DisputeFileUploads { get; set; } = null!;
}
public class CreateDisputeFileUploadRequest
{
    [JsonPropertyName("dispute_file_upload")]
    public CreateDisputeFileUpload DisputeFileUpload { get; set; } = null!;
}

public partial class CreateDisputeFileUpload : DisputeFileUploadBase {}
public class UpdateDisputeFileUploadRequest : DisputeFileUpload
{
    [JsonPropertyName("dispute_file_upload")]
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
    [JsonPropertyName("payout")]
    public Payout Payout { get; set; } = null!;
}

public class PayoutList
{
    [JsonPropertyName("payouts")]
    public IEnumerable<Payout> Payouts { get; set; } = null!;
}
public class CreatePayoutRequest
{
    [JsonPropertyName("payout")]
    public CreatePayout Payout { get; set; } = null!;
}

public partial class CreatePayout : PayoutBase {}
public class UpdatePayoutRequest : Payout
{
    [JsonPropertyName("payout")]
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
    [JsonPropertyName("country")]
    public Country Country { get; set; } = null!;
}

public class CountryList
{
    [JsonPropertyName("countries")]
    public IEnumerable<Country> Countries { get; set; } = null!;
}
public class CreateCountryRequest
{
    [JsonPropertyName("country")]
    public CreateCountry Country { get; set; } = null!;
}

public partial class CreateCountry : CountryBase {}
public class UpdateCountryRequest : Country
{
    [JsonPropertyName("country")]
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
    [JsonPropertyName("currency")]
    public Currency Currency { get; set; } = null!;
}

public class CurrencyList
{
    [JsonPropertyName("currencies")]
    public IEnumerable<Currency> Currencies { get; set; } = null!;
}
public class CreateCurrencyRequest
{
    [JsonPropertyName("currency")]
    public CreateCurrency Currency { get; set; } = null!;
}

public partial class CreateCurrency : CurrencyBase {}
public class UpdateCurrencyRequest : Currency
{
    [JsonPropertyName("currency")]
    public UpdateCurrency Currency { get; set; } = null!;
}

public partial class UpdateCurrency : Currency{}

		
	
public class Currency : CurrencyBase
{
}
	
public class PolicyItem
{
    [JsonPropertyName("policy")]
    public Policy Policy { get; set; } = null!;
}

public class PolicyList
{
    [JsonPropertyName("policies")]
    public IEnumerable<Policy> Policies { get; set; } = null!;
}
public class CreatePolicyRequest
{
    [JsonPropertyName("policy")]
    public CreatePolicy Policy { get; set; } = null!;
}

public partial class CreatePolicy : PolicyBase {}
public class UpdatePolicyRequest : Policy
{
    [JsonPropertyName("policy")]
    public UpdatePolicy Policy { get; set; } = null!;
}

public partial class UpdatePolicy : Policy{}

		
	
public class Policy : PolicyBase
{
}
	
public class ProvinceItem
{
    [JsonPropertyName("province")]
    public Province Province { get; set; } = null!;
}

public class ProvinceList
{
    [JsonPropertyName("provinces")]
    public IEnumerable<Province> Provinces { get; set; } = null!;
}
public class CreateProvinceRequest
{
    [JsonPropertyName("province")]
    public CreateProvince Province { get; set; } = null!;
}

public partial class CreateProvince : ProvinceBase {}
public class UpdateProvinceRequest : Province
{
    [JsonPropertyName("province")]
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
    [JsonPropertyName("shipping_zone")]
    public ShippingZone ShippingZone { get; set; } = null!;
}

public class ShippingZoneList
{
    [JsonPropertyName("shipping_zones")]
    public IEnumerable<ShippingZone> ShippingZones { get; set; } = null!;
}
public class CreateShippingZoneRequest
{
    [JsonPropertyName("shipping_zone")]
    public CreateShippingZone ShippingZone { get; set; } = null!;
}

public partial class CreateShippingZone : ShippingZoneBase {}
public class UpdateShippingZoneRequest : ShippingZone
{
    [JsonPropertyName("shipping_zone")]
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
    [JsonPropertyName("shop")]
    public Shop Shop { get; set; } = null!;
}

public class ShopList
{
    [JsonPropertyName("shops")]
    public IEnumerable<Shop> Shops { get; set; } = null!;
}
public class CreateShopRequest
{
    [JsonPropertyName("shop")]
    public CreateShop Shop { get; set; } = null!;
}

public partial class CreateShop : ShopBase {}
public class UpdateShopRequest : Shop
{
    [JsonPropertyName("shop")]
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
    [JsonPropertyName("tender_transaction")]
    public TenderTransaction TenderTransaction { get; set; } = null!;
}

public class TenderTransactionList
{
    [JsonPropertyName("tender_transactions")]
    public IEnumerable<TenderTransaction> TenderTransactions { get; set; } = null!;
}
public class CreateTenderTransactionRequest
{
    [JsonPropertyName("tender_transaction")]
    public CreateTenderTransaction TenderTransaction { get; set; } = null!;
}

public partial class CreateTenderTransaction : TenderTransactionBase {}
public class UpdateTenderTransactionRequest : TenderTransaction
{
    [JsonPropertyName("tender_transaction")]
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
    [JsonPropertyName("discount_code_creation")]
    public DiscountCodeCreation DiscountCodeCreation { get; set; } = null!;
}

public class DiscountCodeCreationList
{
    [JsonPropertyName("discount_code_creations")]
    public IEnumerable<DiscountCodeCreation> DiscountCodeCreations { get; set; } = null!;
}
public class CreateDiscountCodeCreationRequest
{
    [JsonPropertyName("discount_code_creation")]
    public CreateDiscountCodeCreation DiscountCodeCreation { get; set; } = null!;
}

public partial class CreateDiscountCodeCreation : DiscountCodeCreationBase {}
public class UpdateDiscountCodeCreationRequest : DiscountCodeCreation
{
    [JsonPropertyName("discount_code_creation")]
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
    [JsonPropertyName("engagement")]
    public Engagement Engagement { get; set; } = null!;
}

public class EngagementList
{
    [JsonPropertyName("engagements")]
    public IEnumerable<Engagement> Engagements { get; set; } = null!;
}
public class CreateEngagementRequest
{
    [JsonPropertyName("engagement")]
    public CreateEngagement Engagement { get; set; } = null!;
}

public partial class CreateEngagement : EngagementBase {}
public class UpdateEngagementRequest : Engagement
{
    [JsonPropertyName("engagement")]
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
    [JsonPropertyName("customer_invite")]
    public CustomerInvite CustomerInvite { get; set; } = null!;
}

public class CustomerInviteList
{
    [JsonPropertyName("customer_invites")]
    public IEnumerable<CustomerInvite> CustomerInvites { get; set; } = null!;
}
public class CreateCustomerInviteRequest
{
    [JsonPropertyName("customer_invite")]
    public CreateCustomerInvite CustomerInvite { get; set; } = null!;
}

public partial class CreateCustomerInvite : CustomerInviteBase {}
public class UpdateCustomerInviteRequest : CustomerInvite
{
    [JsonPropertyName("customer_invite")]
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
	