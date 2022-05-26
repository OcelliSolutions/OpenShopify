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

public record CreateApplicationChargeRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateApplicationChargeRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateApplicationChargeRequestErrorDetails
{
	[JsonPropertyName("name")]
    public string? Name { get; set; }
	[JsonPropertyName("price")]
    public string? Price { get; set; }
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

public record CreateApplicationCreditRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateApplicationCreditRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateApplicationCreditRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateArticleRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateArticleRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateArticleRequestErrorDetails
{
	[JsonPropertyName("title")]
    public string? Title { get; set; }
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

public record CreateAssetRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateAssetRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateAssetRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateBalanceRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateBalanceRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateBalanceRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateBlogRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateBlogRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateBlogRequestErrorDetails
{
	[JsonPropertyName("title")]
    public string? Title { get; set; }
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

public record CreateCarrierServiceRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateCarrierServiceRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateCarrierServiceRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateCheckoutRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateCheckoutRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateCheckoutRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateCollectRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateCollectRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateCollectRequestErrorDetails
{
	[JsonPropertyName("product")]
    public string? Product { get; set; }
	[JsonPropertyName("collection")]
    public string? Collection { get; set; }
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

public record CreateCollectionRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateCollectionRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateCollectionRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateCollectionListingRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateCollectionListingRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateCollectionListingRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateCommentRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateCommentRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateCommentRequestErrorDetails
{
	[JsonPropertyName("author")]
    public string? Author { get; set; }
	[JsonPropertyName("body")]
    public string? Body { get; set; }
	[JsonPropertyName("email")]
    public string? Email { get; set; }
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

public record CreateCountryRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateCountryRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateCountryRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateCurrencyRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateCurrencyRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateCurrencyRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateCustomCollectionRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateCustomCollectionRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateCustomCollectionRequestErrorDetails
{
	[JsonPropertyName("title")]
    public string? Title { get; set; }
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

public record CreateCustomerRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateCustomerRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateCustomerRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateCustomerAddressRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateCustomerAddressRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateCustomerAddressRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateCustomerInviteRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateCustomerInviteRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateCustomerInviteRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateCustomerSavedSearchRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateCustomerSavedSearchRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateCustomerSavedSearchRequestErrorDetails
{
	[JsonPropertyName("name")]
    public string? Name { get; set; }
	[JsonPropertyName("search_terms")]
    public string? SearchTerms { get; set; }
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

public record CreateDeprecatedApiCallRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateDeprecatedApiCallRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateDeprecatedApiCallRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateDiscountCodeRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateDiscountCodeRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateDiscountCodeRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateDiscountCodeCreationRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateDiscountCodeCreationRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateDiscountCodeCreationRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateDisputeRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateDisputeRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateDisputeRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateDraftOrderRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateDraftOrderRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateDraftOrderRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateDraftOrderInvoiceRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateDraftOrderInvoiceRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateDraftOrderInvoiceRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateEngagementRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateEngagementRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateEngagementRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateEventRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateEventRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateEventRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateFulfillmentRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateFulfillmentRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateFulfillmentRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateFulfillmentEventRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateFulfillmentEventRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateFulfillmentEventRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateFulfillmentOrderRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateFulfillmentOrderRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateFulfillmentOrderRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateFulfillmentRequestRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateFulfillmentRequestRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateFulfillmentRequestRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateFulfillmentServiceRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateFulfillmentServiceRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateFulfillmentServiceRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateGiftCardRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateGiftCardRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateGiftCardRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateInventoryItemRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateInventoryItemRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateInventoryItemRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateInventoryLevelRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateInventoryLevelRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateInventoryLevelRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateLocationRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateLocationRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateLocationRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateLocationsForMoveRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateLocationsForMoveRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateLocationsForMoveRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateMarketingEventRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateMarketingEventRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateMarketingEventRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateMetafieldRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateMetafieldRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateMetafieldRequestErrorDetails
{
	[JsonPropertyName("type")]
    public string? Type { get; set; }
	[JsonPropertyName("namespace")]
    public string? Namespace { get; set; }
	[JsonPropertyName("key")]
    public string? Key { get; set; }
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

public record CreateMobilePlatformApplicationRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateMobilePlatformApplicationRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateMobilePlatformApplicationRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateOrderRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateOrderRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateOrderRequestErrorDetails
{
	[JsonPropertyName("order")]
    public string? Order { get; set; }
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

public record CreateOrderRiskRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateOrderRiskRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateOrderRiskRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreatePageRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreatePageRequestErrorDetails Errors { get; set; } = null!;
}

public record CreatePageRequestErrorDetails
{
	[JsonPropertyName("title")]
    public string? Title { get; set; }
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

public record CreatePaymentRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreatePaymentRequestErrorDetails Errors { get; set; } = null!;
}

public record CreatePaymentRequestErrorDetails
{
	[JsonPropertyName("amount")]
    public string? Amount { get; set; }
	[JsonPropertyName("payment_gateway")]
    public string? PaymentGateway { get; set; }
	[JsonPropertyName("checkout")]
    public string? Checkout { get; set; }
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

public record CreatePayoutRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreatePayoutRequestErrorDetails Errors { get; set; } = null!;
}

public record CreatePayoutRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreatePolicyRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreatePolicyRequestErrorDetails Errors { get; set; } = null!;
}

public record CreatePolicyRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreatePriceRuleRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreatePriceRuleRequestErrorDetails Errors { get; set; } = null!;
}

public record CreatePriceRuleRequestErrorDetails
{
	[JsonPropertyName("customer_segment_prerequisite_ids")]
    public string? CustomerSegmentPrerequisiteIds { get; set; }
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

public record CreateProductRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateProductRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateProductRequestErrorDetails
{
	[JsonPropertyName("title")]
    public string? Title { get; set; }
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

public record CreateProductImageRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateProductImageRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateProductImageRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateProductListingRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateProductListingRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateProductListingRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateProductResourceFeedbackRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateProductResourceFeedbackRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateProductResourceFeedbackRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateProvinceRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateProvinceRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateProvinceRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateRecurringApplicationChargeRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateRecurringApplicationChargeRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateRecurringApplicationChargeRequestErrorDetails
{
	[JsonPropertyName("name")]
    public string? Name { get; set; }
	[JsonPropertyName("price")]
    public string? Price { get; set; }
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

public record CreateRedirectRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateRedirectRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateRedirectRequestErrorDetails
{
	[JsonPropertyName("path")]
    public string? Path { get; set; }
	[JsonPropertyName("target")]
    public string? Target { get; set; }
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

public record CreateRefundRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateRefundRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateRefundRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateReportRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateReportRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateReportRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateResourceFeedbackRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateResourceFeedbackRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateResourceFeedbackRequestErrorDetails
{
	[JsonPropertyName("messages")]
    public string? Messages { get; set; }
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

public record CreateScriptTagRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateScriptTagRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateScriptTagRequestErrorDetails
{
	[JsonPropertyName("src")]
    public string? Src { get; set; }
	[JsonPropertyName("event")]
    public string? Event { get; set; }
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

public record CreateShippingZoneRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateShippingZoneRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateShippingZoneRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateShopRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateShopRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateShopRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateSmartCollectionRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateSmartCollectionRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateSmartCollectionRequestErrorDetails
{
	[JsonPropertyName("title")]
    public string? Title { get; set; }
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

public record CreateStorefrontAccessTokenRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateStorefrontAccessTokenRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateStorefrontAccessTokenRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateTenderTransactionRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateTenderTransactionRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateTenderTransactionRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateThemeRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateThemeRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateThemeRequestErrorDetails
{
	[JsonPropertyName("name")]
    public string? Name { get; set; }
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

public record CreateTransactionRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateTransactionRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateTransactionRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateUsageChargeRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateUsageChargeRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateUsageChargeRequestErrorDetails
{
	[JsonPropertyName("description")]
    public string? Description { get; set; }
	[JsonPropertyName("price")]
    public string? Price { get; set; }
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

public record CreateUserRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateUserRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateUserRequestErrorDetails
{
	[JsonPropertyName("base")]
    public string? Base { get; set; }
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

public record CreateWebhookRequestError
{
    [JsonPropertyName("errors"), Required]
    public CreateWebhookRequestErrorDetails Errors { get; set; } = null!;
}

public record CreateWebhookRequestErrorDetails
{
	[JsonPropertyName("topic")]
    public string? Topic { get; set; }
	[JsonPropertyName("address")]
    public string? Address { get; set; }
}

	