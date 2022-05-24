namespace Ocelli.OpenShopify;

public interface IInventoryService
{
    public IInventoryItemClient InventoryItem { get; }
    public IInventoryLevelClient InventoryLevel { get; }
    public ILocationClient Location { get; }
}
public class InventoryService : ShopifyService, IInventoryService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public InventoryService(string myShopifyUrl, string shopAccessToken, bool isPlusStore = false) : base(myShopifyUrl, shopAccessToken, isPlusStore)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    
    public IInventoryItemClient InventoryItem => new InventoryItemClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IInventoryLevelClient InventoryLevel => new InventoryLevelClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public ILocationClient Location => new LocationClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}