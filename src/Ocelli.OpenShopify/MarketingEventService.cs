﻿namespace Ocelli.OpenShopify;

public interface IMarketingEventService
{
    public IMarketingEventClient MarketingEvent { get; }
}

public class MarketingEventService : ShopifyService, IMarketingEventService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public MarketingEventService(string myShopifyUrl, string shopAccessToken, bool isPlusStore = false) : base(myShopifyUrl, shopAccessToken, isPlusStore)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }

    public IMarketingEventClient MarketingEvent => new MarketingEventClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}