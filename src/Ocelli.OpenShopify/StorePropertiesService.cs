﻿namespace Ocelli.OpenShopify;

public interface IStorePropertiesService
{
    public ICountryClient Country { get; }
    public ICurrencyClient Currency { get; }
    public IPolicyClient Policy { get; }
    public IProvinceClient Province { get; }
    public IShippingZoneClient ShippingZone { get; }
    public IShopClient Shop { get; }
}
public class StorePropertiesService : ShopifyService, IStorePropertiesService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public StorePropertiesService(string myShopifyUrl, string shopAccessToken, bool isPlusStore = false) : base(myShopifyUrl, shopAccessToken, isPlusStore)
    {
        _baseUri = PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    
    public ICountryClient Country => new CountryClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public ICurrencyClient Currency => new CurrencyClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IPolicyClient Policy => new PolicyClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IProvinceClient Province => new ProvinceClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IShippingZoneClient ShippingZone => new ShippingZoneClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IShopClient Shop => new ShopClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}