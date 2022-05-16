namespace Ocelli.OpenShopify;

public interface ICustomersService
{
    public ICustomerClient Customer { get; }
    public ICustomerAddressClient CustomerAddress { get; }
    public ICustomerSavedSearchClient CustomerSavedSearch { get; }
}

public class CustomersService : ShopifyService, ICustomersService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public CustomersService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    public ICustomerClient Customer => new CustomerClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public ICustomerAddressClient CustomerAddress => new CustomerAddressClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public ICustomerSavedSearchClient CustomerSavedSearch => new CustomerSavedSearchClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
}