using OpenShopify.Common.Attributes;

#pragma warning disable CS1591

namespace OpenShopify.Common.Data;

public enum ApiGroupNames
{
    [GroupInfo(Title = "Access", Description = "Authentication and Authorization", Version = "2022-10")]
    Access,
    [GroupInfo(Title = "Access (OAuth)", Description = "OAuth", Version = "2022-10")]
    AccessOAuth,
    [GroupInfo(Title = "Analytics", Description = "Reporting and Analytics", Version = "2022-10")]
    Analytics,
    [GroupInfo(Title = "Billing", Description = "Billing", Version = "2022-10")]
    Billing,
    [GroupInfo(Title = "Customers", Description = "Customers", Version = "2022-10")]
    Customers,
    [GroupInfo(Title = "Deprecated API Calls", Description = "Deprecated API Calls", Version = "2022-10")]
    DeprecatedApiCalls,
    [GroupInfo(Title = "Discounts", Description = "Discounts", Version = "2022-10")]
    Discounts,
    [GroupInfo(Title = "Events", Description = "Events", Version = "2022-10")]
    Events,
    [GroupInfo(Title = "Inventory", Description = "Inventory", Version = "2022-10")]
    Inventory,
    [GroupInfo(Title = "Marketing Event", Description = "Marketing Event", Version = "2022-10")]
    MarketingEvent,
    [GroupInfo(Title = "Metafield", Description = "Metafield", Version = "2022-10")]
    Metafield,
    [GroupInfo(Title = "Online Store", Description = "Online Store", Version = "2022-10")]
    OnlineStore,
    [GroupInfo(Title = "Orders", Description = "Orders", Version = "2022-10")]
    Orders,
    [GroupInfo(Title = "Plus", Description = "Plus", Version = "2022-10")]
    Plus,
    [GroupInfo(Title = "Products", Description = "Products", Version = "2022-10")]
    Products,
    [GroupInfo(Title = "Sales Channels", Description = "Sales Channels", Version = "2022-10")]
    SalesChannels,
    [GroupInfo(Title = "Shipping & Fulfillment", Description = "Shipping & Fulfillment", Version = "2022-10")]
    ShippingAndFulfillment,
    [GroupInfo(Title = "Shopify Payments", Description = "Shopify Payments", Version = "2022-10")]
    ShopifyPayments,
    [GroupInfo(Title = "Store Properties", Description = "Store Properties", Version = "2022-10")]
    StoreProperties,
    [GroupInfo(Title = "Tender Transaction", Description = "Tender Transaction", Version = "2022-10")]
    TenderTransaction
}

