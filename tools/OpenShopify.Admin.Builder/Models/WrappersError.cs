using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;
// ReSharper disable All
public record ApplicationChargeError
{
    [JsonPropertyName("errors"), Required]
    public ApplicationChargeErrorDetails Errors { get; set; } = null!;
}

public record ApplicationChargeErrorDetails
{
	[JsonPropertyName("name")]
    public IEnumerable<string>? Name { get; set; }
	[JsonPropertyName("price")]
    public IEnumerable<string>? Price { get; set; }
}

	public record ApplicationCreditError
{
    [JsonPropertyName("errors"), Required]
    public ApplicationCreditErrorDetails Errors { get; set; } = null!;
}

public record ApplicationCreditErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record ArticleError
{
    [JsonPropertyName("errors"), Required]
    public ArticleErrorDetails Errors { get; set; } = null!;
}

public record ArticleErrorDetails
{
	[JsonPropertyName("title")]
    public IEnumerable<string>? Title { get; set; }
}

	public record AssetError
{
    [JsonPropertyName("errors"), Required]
    public AssetErrorDetails Errors { get; set; } = null!;
}

public record AssetErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record BalanceError
{
    [JsonPropertyName("errors"), Required]
    public BalanceErrorDetails Errors { get; set; } = null!;
}

public record BalanceErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record BlogError
{
    [JsonPropertyName("errors"), Required]
    public BlogErrorDetails Errors { get; set; } = null!;
}

public record BlogErrorDetails
{
	[JsonPropertyName("title")]
    public IEnumerable<string>? Title { get; set; }
}

	public record CarrierServiceError
{
    [JsonPropertyName("errors"), Required]
    public CarrierServiceErrorDetails Errors { get; set; } = null!;
}

public record CarrierServiceErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record CheckoutError
{
    [JsonPropertyName("errors"), Required]
    public CheckoutErrorDetails Errors { get; set; } = null!;
}

public record CheckoutErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record CollectError
{
    [JsonPropertyName("errors"), Required]
    public CollectErrorDetails Errors { get; set; } = null!;
}

public record CollectErrorDetails
{
	[JsonPropertyName("product")]
    public IEnumerable<string>? Product { get; set; }
	[JsonPropertyName("collection")]
    public IEnumerable<string>? Collection { get; set; }
}

	public record CollectionError
{
    [JsonPropertyName("errors"), Required]
    public CollectionErrorDetails Errors { get; set; } = null!;
}

public record CollectionErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record CollectionListingError
{
    [JsonPropertyName("errors"), Required]
    public CollectionListingErrorDetails Errors { get; set; } = null!;
}

public record CollectionListingErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record CommentError
{
    [JsonPropertyName("errors"), Required]
    public CommentErrorDetails Errors { get; set; } = null!;
}

public record CommentErrorDetails
{
	[JsonPropertyName("author")]
    public IEnumerable<string>? Author { get; set; }
	[JsonPropertyName("body")]
    public IEnumerable<string>? Body { get; set; }
	[JsonPropertyName("email")]
    public IEnumerable<string>? Email { get; set; }
}

	public record CountryError
{
    [JsonPropertyName("errors"), Required]
    public CountryErrorDetails Errors { get; set; } = null!;
}

public record CountryErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record CurrencyError
{
    [JsonPropertyName("errors"), Required]
    public CurrencyErrorDetails Errors { get; set; } = null!;
}

public record CurrencyErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record CustomCollectionError
{
    [JsonPropertyName("errors"), Required]
    public CustomCollectionErrorDetails Errors { get; set; } = null!;
}

public record CustomCollectionErrorDetails
{
	[JsonPropertyName("title")]
    public IEnumerable<string>? Title { get; set; }
}

	public record CustomerError
{
    [JsonPropertyName("errors"), Required]
    public CustomerErrorDetails Errors { get; set; } = null!;
}

public record CustomerErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record CustomerAddressError
{
    [JsonPropertyName("errors"), Required]
    public CustomerAddressErrorDetails Errors { get; set; } = null!;
}

public record CustomerAddressErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record CustomerInviteError
{
    [JsonPropertyName("errors"), Required]
    public CustomerInviteErrorDetails Errors { get; set; } = null!;
}

public record CustomerInviteErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record CustomerSavedSearchError
{
    [JsonPropertyName("errors"), Required]
    public CustomerSavedSearchErrorDetails Errors { get; set; } = null!;
}

public record CustomerSavedSearchErrorDetails
{
	[JsonPropertyName("name")]
    public IEnumerable<string>? Name { get; set; }
	[JsonPropertyName("search_terms")]
    public IEnumerable<string>? SearchTerms { get; set; }
}

	public record DeprecatedApiCallError
{
    [JsonPropertyName("errors"), Required]
    public DeprecatedApiCallErrorDetails Errors { get; set; } = null!;
}

public record DeprecatedApiCallErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record DiscountCodeError
{
    [JsonPropertyName("errors"), Required]
    public DiscountCodeErrorDetails Errors { get; set; } = null!;
}

public record DiscountCodeErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record DiscountCodeCreationError
{
    [JsonPropertyName("errors"), Required]
    public DiscountCodeCreationErrorDetails Errors { get; set; } = null!;
}

public record DiscountCodeCreationErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record DisputeError
{
    [JsonPropertyName("errors"), Required]
    public DisputeErrorDetails Errors { get; set; } = null!;
}

public record DisputeErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record DraftOrderError
{
    [JsonPropertyName("errors"), Required]
    public DraftOrderErrorDetails Errors { get; set; } = null!;
}

public record DraftOrderErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record DraftOrderInvoiceError
{
    [JsonPropertyName("errors"), Required]
    public DraftOrderInvoiceErrorDetails Errors { get; set; } = null!;
}

public record DraftOrderInvoiceErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record EngagementError
{
    [JsonPropertyName("errors"), Required]
    public EngagementErrorDetails Errors { get; set; } = null!;
}

public record EngagementErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record EventError
{
    [JsonPropertyName("errors"), Required]
    public EventErrorDetails Errors { get; set; } = null!;
}

public record EventErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record FulfillmentError
{
    [JsonPropertyName("errors"), Required]
    public FulfillmentErrorDetails Errors { get; set; } = null!;
}

public record FulfillmentErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record FulfillmentEventError
{
    [JsonPropertyName("errors"), Required]
    public FulfillmentEventErrorDetails Errors { get; set; } = null!;
}

public record FulfillmentEventErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record FulfillmentOrderError
{
    [JsonPropertyName("errors"), Required]
    public FulfillmentOrderErrorDetails Errors { get; set; } = null!;
}

public record FulfillmentOrderErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record FulfillmentRequestError
{
    [JsonPropertyName("errors"), Required]
    public FulfillmentRequestErrorDetails Errors { get; set; } = null!;
}

public record FulfillmentRequestErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record FulfillmentServiceError
{
    [JsonPropertyName("errors"), Required]
    public FulfillmentServiceErrorDetails Errors { get; set; } = null!;
}

public record FulfillmentServiceErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record GiftCardError
{
    [JsonPropertyName("errors"), Required]
    public GiftCardErrorDetails Errors { get; set; } = null!;
}

public record GiftCardErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record InventoryItemError
{
    [JsonPropertyName("errors"), Required]
    public InventoryItemErrorDetails Errors { get; set; } = null!;
}

public record InventoryItemErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record InventoryLevelError
{
    [JsonPropertyName("errors"), Required]
    public InventoryLevelErrorDetails Errors { get; set; } = null!;
}

public record InventoryLevelErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record LocationError
{
    [JsonPropertyName("errors"), Required]
    public LocationErrorDetails Errors { get; set; } = null!;
}

public record LocationErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record LocationsForMoveError
{
    [JsonPropertyName("errors"), Required]
    public LocationsForMoveErrorDetails Errors { get; set; } = null!;
}

public record LocationsForMoveErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record MarketingEventError
{
    [JsonPropertyName("errors"), Required]
    public MarketingEventErrorDetails Errors { get; set; } = null!;
}

public record MarketingEventErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record MetafieldError
{
    [JsonPropertyName("errors"), Required]
    public MetafieldErrorDetails Errors { get; set; } = null!;
}

public record MetafieldErrorDetails
{
	[JsonPropertyName("type")]
    public IEnumerable<string>? Type { get; set; }
	[JsonPropertyName("namespace")]
    public IEnumerable<string>? Namespace { get; set; }
	[JsonPropertyName("key")]
    public IEnumerable<string>? Key { get; set; }
}

	public record MobilePlatformApplicationError
{
    [JsonPropertyName("errors"), Required]
    public MobilePlatformApplicationErrorDetails Errors { get; set; } = null!;
}

public record MobilePlatformApplicationErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record OrderError
{
    [JsonPropertyName("errors"), Required]
    public OrderErrorDetails Errors { get; set; } = null!;
}

public record OrderErrorDetails
{
	[JsonPropertyName("order")]
    public IEnumerable<string>? Order { get; set; }
}

	public record OrderRiskError
{
    [JsonPropertyName("errors"), Required]
    public OrderRiskErrorDetails Errors { get; set; } = null!;
}

public record OrderRiskErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record PageError
{
    [JsonPropertyName("errors"), Required]
    public PageErrorDetails Errors { get; set; } = null!;
}

public record PageErrorDetails
{
	[JsonPropertyName("title")]
    public IEnumerable<string>? Title { get; set; }
}

	public record PaymentError
{
    [JsonPropertyName("errors"), Required]
    public PaymentErrorDetails Errors { get; set; } = null!;
}

public record PaymentErrorDetails
{
	[JsonPropertyName("amount")]
    public IEnumerable<string>? Amount { get; set; }
	[JsonPropertyName("payment_gateway")]
    public IEnumerable<string>? PaymentGateway { get; set; }
	[JsonPropertyName("checkout")]
    public IEnumerable<string>? Checkout { get; set; }
}

	public record PayoutError
{
    [JsonPropertyName("errors"), Required]
    public PayoutErrorDetails Errors { get; set; } = null!;
}

public record PayoutErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record PolicyError
{
    [JsonPropertyName("errors"), Required]
    public PolicyErrorDetails Errors { get; set; } = null!;
}

public record PolicyErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record PriceRuleError
{
    [JsonPropertyName("errors"), Required]
    public PriceRuleErrorDetails Errors { get; set; } = null!;
}

public record PriceRuleErrorDetails
{
	[JsonPropertyName("customer_segment_prerequisite_ids")]
    public IEnumerable<string>? CustomerSegmentPrerequisiteIds { get; set; }
}

	public record ProductError
{
    [JsonPropertyName("errors"), Required]
    public ProductErrorDetails Errors { get; set; } = null!;
}

public record ProductErrorDetails
{
	[JsonPropertyName("title")]
    public IEnumerable<string>? Title { get; set; }
}

	public record ProductImageError
{
    [JsonPropertyName("errors"), Required]
    public ProductImageErrorDetails Errors { get; set; } = null!;
}

public record ProductImageErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record ProductListingError
{
    [JsonPropertyName("errors"), Required]
    public ProductListingErrorDetails Errors { get; set; } = null!;
}

public record ProductListingErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record ProductResourceFeedbackError
{
    [JsonPropertyName("errors"), Required]
    public ProductResourceFeedbackErrorDetails Errors { get; set; } = null!;
}

public record ProductResourceFeedbackErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record ProvinceError
{
    [JsonPropertyName("errors"), Required]
    public ProvinceErrorDetails Errors { get; set; } = null!;
}

public record ProvinceErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record RecurringApplicationChargeError
{
    [JsonPropertyName("errors"), Required]
    public RecurringApplicationChargeErrorDetails Errors { get; set; } = null!;
}

public record RecurringApplicationChargeErrorDetails
{
	[JsonPropertyName("name")]
    public IEnumerable<string>? Name { get; set; }
	[JsonPropertyName("price")]
    public IEnumerable<string>? Price { get; set; }
}

	public record RedirectError
{
    [JsonPropertyName("errors"), Required]
    public RedirectErrorDetails Errors { get; set; } = null!;
}

public record RedirectErrorDetails
{
	[JsonPropertyName("path")]
    public IEnumerable<string>? Path { get; set; }
	[JsonPropertyName("target")]
    public IEnumerable<string>? Target { get; set; }
}

	public record RefundError
{
    [JsonPropertyName("errors"), Required]
    public RefundErrorDetails Errors { get; set; } = null!;
}

public record RefundErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record ReportError
{
    [JsonPropertyName("errors"), Required]
    public ReportErrorDetails Errors { get; set; } = null!;
}

public record ReportErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record ResourceFeedbackError
{
    [JsonPropertyName("errors"), Required]
    public ResourceFeedbackErrorDetails Errors { get; set; } = null!;
}

public record ResourceFeedbackErrorDetails
{
	[JsonPropertyName("messages")]
    public IEnumerable<string>? Messages { get; set; }
}

	public record ScriptTagError
{
    [JsonPropertyName("errors"), Required]
    public ScriptTagErrorDetails Errors { get; set; } = null!;
}

public record ScriptTagErrorDetails
{
	[JsonPropertyName("src")]
    public IEnumerable<string>? Src { get; set; }
	[JsonPropertyName("event")]
    public IEnumerable<string>? Event { get; set; }
}

	public record ShippingZoneError
{
    [JsonPropertyName("errors"), Required]
    public ShippingZoneErrorDetails Errors { get; set; } = null!;
}

public record ShippingZoneErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record ShopError
{
    [JsonPropertyName("errors"), Required]
    public ShopErrorDetails Errors { get; set; } = null!;
}

public record ShopErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record SmartCollectionError
{
    [JsonPropertyName("errors"), Required]
    public SmartCollectionErrorDetails Errors { get; set; } = null!;
}

public record SmartCollectionErrorDetails
{
	[JsonPropertyName("title")]
    public IEnumerable<string>? Title { get; set; }
}

	public record StorefrontAccessTokenError
{
    [JsonPropertyName("errors"), Required]
    public StorefrontAccessTokenErrorDetails Errors { get; set; } = null!;
}

public record StorefrontAccessTokenErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record TenderTransactionError
{
    [JsonPropertyName("errors"), Required]
    public TenderTransactionErrorDetails Errors { get; set; } = null!;
}

public record TenderTransactionErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record ThemeError
{
    [JsonPropertyName("errors"), Required]
    public ThemeErrorDetails Errors { get; set; } = null!;
}

public record ThemeErrorDetails
{
	[JsonPropertyName("name")]
    public IEnumerable<string>? Name { get; set; }
}

	public record TransactionError
{
    [JsonPropertyName("errors"), Required]
    public TransactionErrorDetails Errors { get; set; } = null!;
}

public record TransactionErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record UsageChargeError
{
    [JsonPropertyName("errors"), Required]
    public UsageChargeErrorDetails Errors { get; set; } = null!;
}

public record UsageChargeErrorDetails
{
	[JsonPropertyName("description")]
    public IEnumerable<string>? Description { get; set; }
	[JsonPropertyName("price")]
    public IEnumerable<string>? Price { get; set; }
}

	public record UserError
{
    [JsonPropertyName("errors"), Required]
    public UserErrorDetails Errors { get; set; } = null!;
}

public record UserErrorDetails
{
	[JsonPropertyName("base")]
    public IEnumerable<string>? Base { get; set; }
}

	public record WebhookError
{
    [JsonPropertyName("errors"), Required]
    public WebhookErrorDetails Errors { get; set; } = null!;
}

public record WebhookErrorDetails
{
	[JsonPropertyName("topic")]
    public IEnumerable<string>? Topic { get; set; }
	[JsonPropertyName("address")]
    public IEnumerable<string>? Address { get; set; }
}

	