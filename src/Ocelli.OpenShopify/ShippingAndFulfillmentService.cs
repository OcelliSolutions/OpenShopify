namespace Ocelli.OpenShopify;

public interface IShippingAndFulfillmentService
{
    public IAssignedFulfillmentOrderClient AssignedFulfillmentOrder { get; }
    public ICancellationRequestClient CancellationRequest { get; }
    public ICarrierServiceClient CarrierService { get; }
    public IFulfillmentClient Fulfillment { get; }
    public IFulfillmentEventClient FulfillmentEvent { get; }
    public IFulfillmentOrderClient FulfillmentOrder { get; }
    public IFulfillmentRequestClient FulfillmentRequest { get; }
    public IFulfillmentServiceClient FulfillmentService { get; }
    public ILocationsForMoveClient LocationsForMove { get; }
}
public class ShippingAndFulfillmentService : ShopifyService, IShippingAndFulfillmentService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public ShippingAndFulfillmentService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    
    public IAssignedFulfillmentOrderClient AssignedFulfillmentOrder => new AssignedFulfillmentOrderClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public ICancellationRequestClient CancellationRequest => new CancellationRequestClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public ICarrierServiceClient CarrierService => new CarrierServiceClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IFulfillmentClient Fulfillment => new FulfillmentClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IFulfillmentEventClient FulfillmentEvent => new FulfillmentEventClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IFulfillmentOrderClient FulfillmentOrder => new FulfillmentOrderClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IFulfillmentRequestClient FulfillmentRequest => new FulfillmentRequestClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IFulfillmentServiceClient FulfillmentService => new FulfillmentServiceClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public ILocationsForMoveClient LocationsForMove => new LocationsForMoveClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}