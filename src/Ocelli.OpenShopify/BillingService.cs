namespace Ocelli.OpenShopify;

public interface IBillingService
{
    public IApplicationChargeClient ApplicationCharge { get; }
    public IApplicationCreditClient ApplicationCredit { get; }
    public IRecurringApplicationChargeClient RecurringApplicationCharge { get; }
    public IUsageChargeClient UsageCharge { get; }
}

public class BillingService : ShopifyService, IBillingService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public BillingService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    public IApplicationChargeClient ApplicationCharge => new ApplicationChargeClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IApplicationCreditClient ApplicationCredit => new ApplicationCreditClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IRecurringApplicationChargeClient RecurringApplicationCharge => new RecurringApplicationChargeClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IUsageChargeClient UsageCharge => new UsageChargeClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}