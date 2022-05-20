namespace Ocelli.OpenShopify;

public interface IStorePropertiesService
{
    public ICountryClient Country { get; }
    public ICurrencyClient Currency { get; }
    public IPolicyClient Policy { get; }
    public IProvinceClient Province { get; }
    public IShippingZoneClient ShippingZone { get; }
    public IShopClient Shop { get; }
}
public class StorePropertiesService : ShopifyService, IStorePropertiesService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public StorePropertiesService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken)
    {
        _baseUri = PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    
    public ICountryClient Country => new CountryClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public ICurrencyClient Currency => new CurrencyClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public IPolicyClient Policy => new PolicyClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public IProvinceClient Province => new ProvinceClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public IShippingZoneClient ShippingZone => new ShippingZoneClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public IShopClient Shop => new ShopClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
}