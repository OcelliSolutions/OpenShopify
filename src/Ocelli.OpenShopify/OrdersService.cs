﻿namespace Ocelli.OpenShopify;

public interface IOrdersService
{
    public IAbandonedCheckoutsClient AbandonedCheckouts { get; }
    public IDraftOrderClient DraftOrder { get; }
    public IOrderClient Order { get; }
    public IOrderRiskClient OrderRisk { get; }
    public IRefundClient Refund { get; }
    public ITransactionClient Transaction { get; }
}
public class OrdersService : ShopifyService, IOrdersService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public OrdersService(string myShopifyUrl, string shopAccessToken, bool isPlusStore = false) : base(myShopifyUrl, shopAccessToken, isPlusStore)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }

    public IAbandonedCheckoutsClient AbandonedCheckouts => new AbandonedCheckoutsClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IDraftOrderClient DraftOrder => new DraftOrderClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IOrderClient Order => new OrderClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IOrderRiskClient OrderRisk => new OrderRiskClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IRefundClient Refund => new RefundClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public ITransactionClient Transaction => new TransactionClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}