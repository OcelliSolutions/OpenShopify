namespace Ocelli.OpenShopify;

public interface IAnalyticsService
{
    public IReportClient Report { get; }
}

public class AnalyticsService : ShopifyService, IAnalyticsService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public AnalyticsService(string myShopifyUrl, string shopAccessToken, bool isPlusStore = false) : base(myShopifyUrl, shopAccessToken, isPlusStore)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    public IReportClient Report => new ReportClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}
