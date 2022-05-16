namespace Ocelli.OpenShopify;

public interface IMetafieldService
{
    public IMetafieldClient Metafield { get; }
}
public class MetafieldService : ShopifyService, IMetafieldService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public MetafieldService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }

    public IMetafieldClient Metafield => new MetafieldClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = false };
}