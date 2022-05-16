namespace Ocelli.OpenShopify;

public interface IProductsService
{
    public ICollectClient Collect { get; }
    public ICollectionClient Collection { get; }
    public ICustomCollectionClient CustomCollection { get; }
    public IProductClient Product { get; }
    public IProductImageClient ProductImage { get; }
    public IProductVariantClient ProductVariant { get; }
    public ISmartCollectionClient SmartCollection { get; }
}
public class ProductsService : ShopifyService, IProductsService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public ProductsService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    
    public ICollectClient Collect => new CollectClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public ICollectionClient Collection => new CollectionClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public ICustomCollectionClient CustomCollection => new CustomCollectionClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public IProductClient Product => new ProductClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public IProductImageClient ProductImage => new ProductImageClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public IProductVariantClient ProductVariant => new ProductVariantClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public ISmartCollectionClient SmartCollection => new SmartCollectionClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
}