namespace Ocelli.OpenShopify;

public interface IShopifyPaymentsService
{
    public IBalanceClient Balance { get; }
    public IDisputeClient Dispute { get; }
    //TODO: figure out why IDisputeEvidenceClient is not reading in
    //public IDisputeEvidenceClient DisputeEvidence { get; }
    //TODO: figure out why IDisputeFileUploadClient is not reading in
    //public IDisputeFileUploadClient DisputeFileUpload { get; }
    public IPayoutsClient Payouts { get; }
    public ITransactionsClient Transactions { get; }
}
public class ShopifyPaymentsService : ShopifyService, IShopifyPaymentsService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public ShopifyPaymentsService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    
    public IBalanceClient Balance => new BalanceClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IDisputeClient Dispute => new DisputeClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IPayoutsClient Payouts => new PayoutsClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public ITransactionsClient Transactions => new TransactionsClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}