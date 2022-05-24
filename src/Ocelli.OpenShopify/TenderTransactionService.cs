namespace Ocelli.OpenShopify;

public interface ITenderTransactionService
{
    public ITenderTransactionClient TenderTransaction { get; }
}

public class TenderTransactionService : ShopifyService, ITenderTransactionService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public TenderTransactionService(string myShopifyUrl, string shopAccessToken, bool isPlusStore = false) : base(myShopifyUrl, shopAccessToken, isPlusStore)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }

    public ITenderTransactionClient TenderTransaction => new TenderTransactionClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}