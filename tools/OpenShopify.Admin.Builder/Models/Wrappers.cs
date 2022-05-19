using System.ComponentModel;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;



public class StorefrontAccessTokenItem
{
    [JsonPropertyName("storefront_access_token")]
    public StorefrontAccessToken? StorefrontAccessToken { get; set; }
}

public class StorefrontAccessTokenList
{
    [JsonPropertyName("storefront_access_tokens")]
    public IEnumerable<StorefrontAccessToken>? StorefrontAccessTokens { get; set; }
}

public class ReportItem
{
    [JsonPropertyName("report")]
    public Report? Report { get; set; }
}

public class ReportList
{
    [JsonPropertyName("reports")]
    public IEnumerable<Report>? Reports { get; set; }
}


public class ApplicationChargeItem
{
    [JsonPropertyName("application_charge")]
    public ApplicationCharge? ApplicationCharge { get; set; }
}

public class ApplicationChargeList
{
    [JsonPropertyName("application_charges")]
    public IEnumerable<ApplicationCharge>? ApplicationCharges { get; set; }
}

public class ApplicationCreditItem
{
    [JsonPropertyName("application_credit")]
    public ApplicationCredit? ApplicationCredit { get; set; }
}

public class ApplicationCreditList
{
    [JsonPropertyName("application_credits")]
    public IEnumerable<ApplicationCredit>? ApplicationCredits { get; set; }
}

public class RecurringApplicationChargeItem
{
    [JsonPropertyName("recurring_application_charge")]
    public RecurringApplicationCharge? RecurringApplicationCharge { get; set; }
}

public class RecurringApplicationChargeList
{
    [JsonPropertyName("recurring_application_charges")]
    public IEnumerable<RecurringApplicationCharge>? RecurringApplicationCharges { get; set; }
}

public class UsageChargeItem
{
    [JsonPropertyName("usage_charge")]
    public UsageCharge? UsageCharge { get; set; }
}

public class UsageChargeList
{
    [JsonPropertyName("usage_charges")]
    public IEnumerable<UsageCharge>? UsageCharges { get; set; }
}


public class CustomerAddressItem
{
    [JsonPropertyName("customer_address")]
    public Address? CustomerAddress { get; set; }
}

public class CustomerAddressList
{
    [JsonPropertyName("customer_address")]
    public IEnumerable<Address>? CustomerAddresses { get; set; }
}
public class CustomerCount : CountItem
{
}

public class CustomerItem
{
    [JsonPropertyName("customer")]
    public Customer? Customer { get; set; }
}

public class CustomerList
{
    [JsonPropertyName("customers")]
    public IEnumerable<Customer>? Customers { get; set; }
}

public class AccountActivation
{
    [JsonPropertyName("account_activation_url")]
    public string AccountActivationUrl { get; set; } = null!;
}


public class CustomerSavedSearchCount : CountItem
{
}

public class CustomerSavedSearchItem
{
    [JsonPropertyName("customer_saved_search")]
    public CustomerSavedSearch? CustomerSavedSearch { get; set; }
}

public class CustomerSavedSearchList
{
    [JsonPropertyName("customer_saved_search")]
    public IEnumerable<CustomerSavedSearch>? CustomerSavedSearches { get; set; }
}
public class DeprecatedApiCallList
{
    [JsonPropertyName("data_updated_at")]
    public DateTime DataUpdatedAt { get; set; }
    [JsonPropertyName("deprecated_api_calls")]
    public IEnumerable<DeprecatedApiCall>? DeprecatedApiCalls { get; set; }
}
public class DiscountCodeCount : CountItem
{
}

public class DiscountCodeItem
{
    [JsonPropertyName("discount_code")]
    public DiscountCode? DiscountCode { get; set; }
}

public class DiscountCodeList
{
    [JsonPropertyName("discount_codes")]
    public IEnumerable<DiscountCode>? DiscountCodes { get; set; }
}
public class DiscountCodeCreationItem
{
    [JsonPropertyName("discount_code_creation")]
    public DiscountCodeCreation? DiscountCodeCreation { get; set; }
}

public class DiscountCodeCreation
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("price_rule_id")]
    public long PriceRuleId { get; set; }
    [JsonPropertyName("started_at")]
    public DateTimeOffset? StartedAt { get; set; }
    [JsonPropertyName("completed_at")]
    public DateTimeOffset? CompletedAt { get; set; }
    [JsonPropertyName("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    [JsonPropertyName("codes_count")]
    public int? CodesCount { get; set; }
    [JsonPropertyName("imported_count")]
    public int? ImportedCount { get; set; }
    [JsonPropertyName("failed_count")]
    public int? FailedCount { get; set; }
    [JsonPropertyName("logs")]
    public object[]? Logs { get; set; }
}


public class PriceRuleCount : CountItem
{
}
public class PriceRuleItem
{
    [JsonPropertyName("price_rule")]
    public PriceRule? PriceRule { get; set; }
}

public class PriceRuleList
{
    [JsonPropertyName("price_rules")]
    public IEnumerable<PriceRule>? PriceRule { get; set; }
}
public class EventCount : CountItem
{
}
public class EventItem
{
    [JsonPropertyName("event")]
    public Event? Event { get; set; }
}

public class EventList
{
    [JsonPropertyName("events")]
    public IEnumerable<Event>? Events { get; set; }
}
public class WebhookCount : CountItem
{
}
public class WebhookItem
{
    [JsonPropertyName("webhook")]
    public Webhook? Webhook { get; set; }
}

public class WebhookList
{
    [JsonPropertyName("webhooks")]
    public IEnumerable<Webhook>? Webhooks { get; set; }
}
public class InventoryItemItem
{
    [JsonPropertyName("inventory_item")]
    public InventoryItem? InventoryItem { get; set; }
}

public class InventoryItemList
{
    [JsonPropertyName("inventory_items")]
    public IEnumerable<InventoryItem>? InventoryItems { get; set; }
}
public class InventoryLevelItem
{
    [JsonPropertyName("inventory_level")]
    public InventoryLevel? InventoryLevel { get; set; }
}

public class InventoryLevelList
{
    [JsonPropertyName("inventory_levels")]
    public IEnumerable<InventoryLevel>? InventoryLevels { get; set; }
}
public class LocationCount : CountItem
{
}
public class LocationItem
{
    [JsonPropertyName("location")]
    public Location? Location { get; set; }
}

public class LocationList
{
    [JsonPropertyName("locations")]
    public IEnumerable<Location>? Locations { get; set; }
}

public class MarketingEventCount : CountItem
{
}
public class MarketingEventItem
{
    [JsonPropertyName("marketing_event")]
    public MarketingEvent? MarketingEvent { get; set; }
}

public class MarketingEventList
{
    [JsonPropertyName("marketing_events")]
    public IEnumerable<MarketingEvent>? MarketingEvents { get; set; }
}
public class EngagementList
{
    [JsonPropertyName("engagements")]
    public IEnumerable<Engagement>? Engagements { get; set; }
}

public class MarketingEvent
{
    [JsonPropertyName("remote_id"), Description("An optional remote identifier for a marketing event. The remote identifier lets Shopify validate engagement data")]
    public string? RemoteId { get; set; }
    [JsonPropertyName("event_type"), Description("The type of marketing event. Valid values: `ad`, `post`, `message`, `retargeting`, `transactional`, `affiliate`, `loyalty`, `newsletter`, `abandoned_cart`.")]
    public string? EventType { get; set; }
    [JsonPropertyName("marketing_channel"), Description("The channel that your marketing event will use. Valid values: `search`, `display`, `social`, `email`, `referral`.")]
    public string? MarketingChannel { get; set; }
    [JsonPropertyName("paid"), Description("Whether the event is paid or organic.")]
    public bool? Paid { get; set; }
    [JsonPropertyName("referring_domain"), Description("The destination domain of the marketing event. Required if the `marketing_channel` is set to `search` or `social`")]
    public string? ReferringDomain { get; set; }
    [JsonPropertyName("budget"), Description("The budget of the ad campaign.")]
    public float? Budget { get; set; }
    [JsonPropertyName("currency"), Description("The currency for the budget. Required if `budget` is specified.")]
    public string? Currency { get; set; }
    [JsonPropertyName("budget_type"), Description("The type of the budget. Required if budget is specified. Valid values: `daily`, `lifetime`.")]
    public string? BudgetType { get; set; }
    [JsonPropertyName("started_at"), Description("The time when the marketing action was started.")]
    public DateTime? StartedAt { get; set; }
    [JsonPropertyName("scheduled_to_end_at"), Description("For events with a duration, the time when the event was scheduled to end.")]
    public DateTime? ScheduledToEndAt { get; set; }
    [JsonPropertyName("ended_at"), Description("For events with a duration, the time when the event actually ended.")]
    public DateTime? EndedAt { get; set; }
    [JsonPropertyName("UTM parameters"), Description($@"The UTM parameters used in the links provided in the marketing event. Values must be unique and should not be url-encoded
To do traffic or order attribution you must at least define `utm_campaign`, `utm_source`, and `utm_medium`.")]
    public UtmParameters? UmtParameters { get; set; }
    [JsonPropertyName("description"), Description("A description of the marketing event.")]
    public string? Description { get; set; }
    [JsonPropertyName("manage_url"), Description("A link to manage the marketing event. In most cases, this links to the app that created the event.")]
    public string? ManageUrl { get; set; }
    [JsonPropertyName("preview_url"), Description("A link to the live version of the event, or to a rendered preview in the app that created it.")]
    public string? PreviewUrl { get; set; }
    [JsonPropertyName("marketed_resources"), Description("An optional remote identifier for a marketing event. The remote identifier lets Shopify validate engagement data")]
    public MarketedResources[]? MarketedResources { get; set; }
}

public class UtmParameters
{
    [JsonPropertyName("marketing_event")]
    public UtmMarketingEvent? MarketingEvent { get; set; }
}

public class UtmMarketingEvent
{
    [JsonPropertyName("utm_campaign")]
    public string? UtmCampaign { get; set; }
    [JsonPropertyName("utm_source")]
    public string? UtmSource { get; set; }
    [JsonPropertyName("utm_medium")]
    public string? UtmMedium { get; set; }
}

public class MarketedResources
{
    [JsonPropertyName("type")]
    public MarketedResourcesType Type { get; set; }
    [JsonPropertyName("id")]
    public long Id { get; set; }
}

public enum MarketedResourcesType
{
    product,
    collection,
    price_rule,
    discount,
    page,
    article,
    homepage
}

public class Engagement
{
    [JsonPropertyName("occurred_on")]
    public DateTime? OccurredOn { get; set; }
    [JsonPropertyName("fetched_at")]
    public DateTime? FetchedAt { get; set; }
    [JsonPropertyName("views_count")]
    public int? ViewsCount { get; set; }
    [JsonPropertyName("impressions_count")]
    public int? ImpressionsCount { get; set; }
    [JsonPropertyName("clicks_count")]
    public int? ClicksCount { get; set; }
    [JsonPropertyName("favorites_count")]
    public int? FavoritesCount { get; set; }
    [JsonPropertyName("comments_count")]
    public int? CommentsCount { get; set; }
    [JsonPropertyName("shares_count")]
    public int? SharesCount { get; set; }
    [JsonPropertyName("ad_spend")]
    public decimal AdSpend { get; set; }
    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; set; }
    [JsonPropertyName("is_cumulative")]
    public bool? IsCumulative { get; set; }
    [JsonPropertyName("unsubscribes_count")]
    public int? UnsubscribesCount { get; set; }
    [JsonPropertyName("complaints_count")]
    public int? ComplaintsCount { get; set; }
    [JsonPropertyName("fails_count")]
    public int? FailsCount { get; set; }
    [JsonPropertyName("sends_count")]
    public int? SendsCount { get; set; }
    [JsonPropertyName("unique_views_count")]
    public int? UniqueViewsCount { get; set; }
    [JsonPropertyName("unique_clicks_count")]
    public int? UniqueClicksCount { get; set; }
    [JsonPropertyName("utc_offset")]
    public string? UtcOffset { get; set; }
}


public class MetafieldCount : CountItem
{
}
public class MetafieldItem
{
    [JsonPropertyName("metafield")]
    public Models.Metafield? Metafield { get; set; }
}

public class MetafieldList
{
    [JsonPropertyName("metafields")]
    public IEnumerable<Models.Metafield>? Metafields { get; set; }
}

public class ArticleCount : CountItem
{
}

public class BlogCount : CountItem
{
}

public class CommentCount : CountItem
{
}
public class PageCount : CountItem
{
}
public class RedirectCount : CountItem
{
}
public class ScriptTagCount : CountItem
{
}

public class DraftOrderCount : CountItem
{
}

public class OrderCount : CountItem
{
}


public class TransactionCount : CountItem
{
}
public class GiftCardCount : CountItem
{
}
public class CollectCount : CountItem
{
}

public class CollectItem
{
    [JsonPropertyName("collect")]
    public Collect? Collect { get; set; }
}

public class CollectList
{
    [JsonPropertyName("collects")]
    public IEnumerable<Collect>? Collects { get; set; }
}

public class CollectionItem
{
    [JsonPropertyName("collection")]
    public Collection? Collection { get; set; }
}

public class CustomCollectionCount : CountItem
{
}

public class CustomCollectionItem
{
    [JsonPropertyName("custom_collection")]
    public CustomCollection? CustomCollection { get; set; }
}

public class CustomCollectionList
{
    [JsonPropertyName("custom_collections")]
    public IEnumerable<CustomCollection>? CustomCollections { get; set; }
}
public class ProductCount : CountItem
{
}

public class ProductItem
{
    [JsonPropertyName("product")]
    public Product? Product { get; set; }
}

public class ProductList
{
    [JsonPropertyName("products")]
    public IEnumerable<Product>? Products { get; set; }
}

public class ImageCount : CountItem
{
}

public class VariantCount : CountItem
{
}

public class ProductVariantItem
{
    [JsonPropertyName("variant")]
    public ProductVariant? ProductVariant { get; set; }
}

public class ProductVariantList
{
    [JsonPropertyName("variants")]
    public IEnumerable<ProductVariant>? ProductVariants { get; set; }
}
public class SmartCollectionCount : CountItem
{
}

public class SmartCollectionItem
{
    [JsonPropertyName("smart_collection")]
    public SmartCollection? SmartCollection { get; set; }
}

public class SmartCollectionList
{
    [JsonPropertyName("smart_collections")]
    public IEnumerable<SmartCollection>? SmartCollections { get; set; }
}

public class PaymentCount : CountItem
{
}
public class PublishedProductCount : CountItem
{
}
public class OrderFulfillmentCount : CountItem
{
}
public class FulfillmentServiceItem
{
    [JsonPropertyName("fulfillment_service")]
    public FulfillmentService? FulfillmentService { get; set; }
}

public class FulfillmentServiceList
{
    [JsonPropertyName("fulfillment_services")]
    public IEnumerable<FulfillmentService>? FulfillmentServices { get; set; }
}


public class CountryCount : CountItem
{
}

public class CountryItem
{
    [JsonPropertyName("country")]
    public Country? Country { get; set; }
}

public class CountryList
{
    [JsonPropertyName("countries")]
    public IEnumerable<Country>? Countries { get; set; }
}


public class CurrencyList
{
    [JsonPropertyName("currencies")]
    public IEnumerable<Currency>? Currencies { get; set; }
}


public class ProvinceCount : CountItem
{
}
public class ArticleItem
{
    [JsonPropertyName("article")]
    public Article? Article { get; set; }
}

public class CarrierServiceItem
{
    [JsonPropertyName("carrier_service")]
    public CarrierService? CarrierService { get; set; }
}

public class CarrierService
{
    //TODO: map CarrierService
}

public class CheckoutItem
{
    [JsonPropertyName("checkout")]
    public Checkout? Checkout { get; set; }
}
public class GiftCardItem
{
    [JsonPropertyName("gift_card")]
    public GiftCard? GiftCard { get; set; }
}
public class ResourceFeedbackItem
{
    [JsonPropertyName("resource_feedback")]
    public ResourceFeedback? ResourceFeedback { get; set; }
}

public class ResourceFeedback
{
    //TODO: map ResourceFeedback
}
public class ScriptTagItem
{
    [JsonPropertyName("script_tag")]
    public ScriptTag? ScriptTag { get; set; }
}
public class ThemeItem
{
    [JsonPropertyName("theme")]
    public Theme? Theme { get; set; }
}
public class RefundItem
{
    [JsonPropertyName("refund")]
    public Refund? Refund { get; set; }
}
public class RedirectItem
{
    [JsonPropertyName("redirect")]
    public Redirect? Redirect { get; set; }
}
public class ProductResourceFeedbackItem
{
    [JsonPropertyName("product_resource_feedback")]
    public ProductResourceFeedback? ProductResourceFeedback { get; set; }
}

public class ProductResourceFeedback
{
    //TODO: map ProductResourceFeedback
}
public class ProductImageItem
{
    [JsonPropertyName("product_image")]
    public ProductImage? ProductImage { get; set; }
}
public class ProvinceItem
{
    [JsonPropertyName("province")]
    public Province? Province { get; set; }
}
public class PaymentItem
{
    [JsonPropertyName("payment")]
    public Payment? Payment { get; set; }
}

public class Payment
{
    //TODO: map Payment
}
public class PageItem
{
    [JsonPropertyName("page")]
    public Page? Page { get; set; }
}
public class ProductListingItem
{
    [JsonPropertyName("product_listing")]
    public ProductListing? ProductListing { get; set; }
}

public class ProductListing
{
    //TODO: map ProductListing
}
public class OrderRiskItem
{
    [JsonPropertyName("order_risk")]
    public OrderRisk? OrderRisk { get; set; }
}
public class OrderItem
{
    [JsonPropertyName("order")]
    public Order? Order { get; set; }
}
public class OrderList
{
    [JsonPropertyName("orders")]
    public IEnumerable<Order>? Orders { get; set; }
}
public class MobilePlatformApplicationItem
{
    [JsonPropertyName("mobile_platform_application")]
    public MobilePlatformApplication? MobilePlatformApplication { get; set; }
}

public class MobilePlatformApplication
{
    //TODO: map MobilePlatformApplication
}
public class FulfillmentItem
{
    [JsonPropertyName("fulfillment")]
    public Fulfillment? Fulfillment { get; set; }
}
public class DraftOrderItem
{
    [JsonPropertyName("draft_order")]
    public DraftOrder? DraftOrder { get; set; }
}
public class FulfillmentEventItem
{
    [JsonPropertyName("fulfillment_event")]
    public FulfillmentEvent? FulfillmentEvent { get; set; }
}
public class BlogItem
{
    [JsonPropertyName("blog")]
    public Blog? Blog { get; set; }
}
public class CommentItem
{
    [JsonPropertyName("comment")]
    public Comment? Comment { get; set; }
}

public class Comment
{
    //TODO: map Comment
}
public class AssetItem
{
    [JsonPropertyName("asset")]
    public Asset? Asset { get; set; }
}
public class TransactionItem
{
    [JsonPropertyName("transaction")]
    public Transaction? Transaction { get; set; }
}
public class CollectionListingItem
{
    [JsonPropertyName("collection_listing")]
    public CollectionListing? CollectionListing { get; set; }
}

public class CollectionListing
{
    //TODO: map Comment
}
