namespace Ocelli.OpenShopify;

public interface IDeprecatedApiCallsService
{
    public IDeprecatedApiCallsClient DeprecatedApiCalls { get; }
}
public class DeprecatedApiCallsService : ShopifyService, IDeprecatedApiCallsService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public DeprecatedApiCallsService(string myShopifyUrl, string shopAccessToken, bool isPlusStore = false) : base(myShopifyUrl, shopAccessToken, isPlusStore)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }

    public IDeprecatedApiCallsClient DeprecatedApiCalls => new DeprecatedApiCallsClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}