namespace Ocelli.OpenShopify;

public interface IPlusService
{
    public IGiftCardClient GiftCard { get; }
    public IUserClient User { get; }
}
public class PlusService : ShopifyService, IPlusService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public PlusService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    
    public IGiftCardClient GiftCard => new GiftCardClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
    public IUserClient User => new UserClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
}