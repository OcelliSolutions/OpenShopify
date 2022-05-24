namespace Ocelli.OpenShopify;

public interface IDiscountsService
{
    public IDiscountCodeClient DiscountCode { get; }
    public IPriceRuleClient PriceRule { get; }
}
public class DiscountsService : ShopifyService, IDiscountsService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public DiscountsService(string myShopifyUrl, string shopAccessToken, bool isPlusStore = false) : base(myShopifyUrl, shopAccessToken, isPlusStore)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    
    public IDiscountCodeClient DiscountCode => new DiscountCodeClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IPriceRuleClient PriceRule => new PriceRuleClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}