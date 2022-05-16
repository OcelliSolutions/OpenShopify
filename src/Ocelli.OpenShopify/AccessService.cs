namespace Ocelli.OpenShopify;

public interface IAccessService
{
    public IAccessScopeClient AccessScope { get; }
    public IStorefrontAccessTokenClient StorefrontAccess { get; }
}

public class AccessService : ShopifyService, IAccessService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;
    private readonly Uri _baseUriAccessScope;

    public AccessService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken)
    {
        _baseUriAccessScope = AuthorizationService.BuildShopUri(myShopifyUrl, false);
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    public IAccessScopeClient AccessScope => new AccessScopeClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUriAccessScope.ToString(), ReadResponseAsString = false };
    public IStorefrontAccessTokenClient StorefrontAccess => new StorefrontAccessTokenClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
}
