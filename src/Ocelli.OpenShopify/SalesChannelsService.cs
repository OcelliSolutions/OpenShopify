namespace Ocelli.OpenShopify;

public interface ISalesChannelsService
{
    public ICheckoutClient Checkout { get; }
    public ICollectionListingClient CollectionListing { get; }
    public IMobilePlatformApplicationClient MobilePlatformApplication { get; }
    public IPaymentClient Payment { get; }
    //TODO: figure out why IProductResourceFeedback is not reading in
    //public IProductResourceFeedback ProductResourceFeedback => new ProductResourceFeedback(_httpClient) { BaseUrl = _baseUrl };
    public IProductListingClient ProductListing { get; }
    public IResourceFeedbackClient ResourceFeedback { get; }
}
public class SalesChannelsService : ShopifyService, ISalesChannelsService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public SalesChannelsService(string myShopifyUrl, string shopAccessToken, bool isPlusStore = false) : base(myShopifyUrl, shopAccessToken, isPlusStore)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    
    public ICheckoutClient Checkout => new CheckoutClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public ICollectionListingClient CollectionListing => new CollectionListingClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IMobilePlatformApplicationClient MobilePlatformApplication => new MobilePlatformApplicationClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IPaymentClient Payment => new PaymentClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IProductListingClient ProductListing => new ProductListingClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IResourceFeedbackClient ResourceFeedback => new ResourceFeedbackClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}