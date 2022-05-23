namespace Ocelli.OpenShopify;

public interface IEventsService
{
    public IEventClient Event { get; }
    public IWebhookClient Webhook { get; }
}
public class EventsService : ShopifyService, IEventsService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public EventsService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    public IEventClient Event => new EventClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IWebhookClient Webhook => new WebhookClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}