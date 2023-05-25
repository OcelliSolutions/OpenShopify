![Open:Shopify](img/OpenShopifyBanner.png)

![Nuget](https://img.shields.io/nuget/v/Ocelli.OpenShopify)
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/OcelliSolutions/OpenShopify/Deploy%20to%20Github%20Packages)

**Open:Shopify** is an OpenAPI implementation of the `2023-04` version of the Shopify Management API. The difference between this and other projects that attempt to expand on the documentation from Shopify is that Open:Shopify scrapes the documentation and generates most of the OpenAPI documentation automatically. Once scraped, any undocumented features/properties are injected and integration tests are executed to ensure that all enums and properties are correctly formatted and accounted for.

## Implementation Summary

Items that are in an `Untestable` status are build but return a `4##` code on some or all tests. These endpoints _should_ work but cannot be verified.

### Access

In order to _test_ the **Storefront access tokens**, use a custom app &raquo; App Setup &raquo; Enable Storefront API &raquo; Save. Once that is complete, (re)register a development store then the API will be accessible.

![OAuth authentication](https://badgen.net/badge/OAuth%20Authentication/Complete/green)
![Access Scopes](https://badgen.net/badge/Access%20Scopes/Complete/green)
![Storefront Access Tokens](https://badgen.net/badge/Storefront%20Access%20Tokens/Complete/green)
![Message Validation](https://badgen.net/badge/Message%20Validation/Tests%20Fail/red)

### Analytics

![Report](https://badgen.net/badge/Report/Complete/green)

### Billing

All create endpoints return a 403 error code if using a custom app. Will have to test with a public app in the future.

![Application%20charges](https://badgen.net/badge/Application%20charges/Untestable/orange)
![Application%20Credits](https://badgen.net/badge/Application%20Credits/Untestable/orange)
![Recurring%20application%20charges](https://badgen.net/badge/Recurring%20application%20charges/Untestable/orange)
![Usage%20charges](https://badgen.net/badge/Usage%20charges/Untestable/orange)

### Customers

![Customers](https://badgen.net/badge/Customers/Complete/green)
![Customer%20Address](https://badgen.net/badge/Customer%20Address/Complete/green)
![Customer%20Saved%20Search](https://badgen.net/badge/Customer%20Saved%20Search/Complete/green)

### Discounts

![Discounts](https://badgen.net/badge/Discounts/Complete/green)
![Price%20Rules](https://badgen.net/badge/Price%20Rules/Complete/green)

### Events

![Events](https://badgen.net/badge/Events/Complete/green)
![Webhooks](https://badgen.net/badge/Webhooks/Complete/green)

### Inventory

![Inventory%20Item](https://badgen.net/badge/Inventory%20Item/Complete/green)
![Inventory%20Level](https://badgen.net/badge/Inventory%20Level/Complete/green)
![Locations](https://badgen.net/badge/Locations/Complete/green)

### Marketing Event

![Marketing%20Event](https://badgen.net/badge/Marketing%20Event/Complete/green)

### Metafields

Metafields is setup differently than every other section in Shopify. There are separate endpoints with different routing for every object that can contain metafields. The hidden groups are broken out below.

![Article](https://badgen.net/badge/Article/Incomplete%20Tests/orange)
![Blog](https://badgen.net/badge/Blog/Complete/green)
![Collection](https://badgen.net/badge/Collection/Incomplete%20Tests/orange)
![Customer](https://badgen.net/badge/Customer/Complete/green)
![Draft%20Order](https://badgen.net/badge/Draft%20Order/Complete/green)
![Order](https://badgen.net/badge/Order/Complete/green)
![Page](https://badgen.net/badge/Page/Incomplete%20Tests/orange)
![Product](https://badgen.net/badge/Product/Complete/green)
![Product%20Image](https://badgen.net/badge/Product%20Image/Complete/green)
![Product%20Variants](https://badgen.net/badge/Product%20Variants/Incomplete%20Tests/orange)

### Online Store

![Articles](https://badgen.net/badge/Articles/Complete/green)
![Assets](https://badgen.net/badge/Assets/Complete/green)
![Blogs](https://badgen.net/badge/Blogs/Complete/green)
![Comment](https://badgen.net/badge/Comment/Complete/green)
![Pages](https://badgen.net/badge/Pages/Untestable/orange)
![Redirects](https://badgen.net/badge/Redirects/Complete/green)
![Script%20Tags](https://badgen.net/badge/Script%20Tags/Complete/green)
![Themes](https://badgen.net/badge/Themes/Complete/green)

### Orders

![Abandoned%20Checkouts](https://badgen.net/badge/Abandoned%20Checkouts/Complete/green)
![Draft%20Orders](https://badgen.net/badge/Draft%20Orders/Complete/green)
![Orders](https://badgen.net/badge/Orders/Complete/green)
![Order%20Risks](https://badgen.net/badge/Order%20Risks/Complete/green)
![Refund](https://badgen.net/badge/Refund/Untestable/orange)
![Transactions](https://badgen.net/badge/Transactions/Untestable/orange)

### Plus

![GiftCards](https://badgen.net/badge/GiftCards/Complete/green)
![User](https://badgen.net/badge/User/Complete/green)

### Products

![Collects](https://badgen.net/badge/Collects/Complete/green)
![Collections](https://badgen.net/badge/Collections/Complete/green)
![Custom%20Collections](https://badgen.net/badge/Custom%20Collections/Complete/green)
![Products](https://badgen.net/badge/Products/Complete/green)
![Product%20Images](https://badgen.net/badge/Product%20Images/Complete/green)
![Product%20Variants](https://badgen.net/badge/Product%20Variants/Complete/green)
![Smart%20Collections](https://badgen.net/badge/Smart%20Collections/Complete/green)

### Sales Channels

![Checkouts](https://badgen.net/badge/Customers/Complete/green)
![Collection%20Listing](https://badgen.net/badge/Collection%20Listing/Untestable/orange)
![Mobile%20Platform%20Application](https://badgen.net/badge/Mobile%20Platform%20Application/Untestable/orange)
![Payment](https://badgen.net/badge/Payment/Untestable/orange)
![Product%20Resource%20Feedback](https://badgen.net/badge/Product%20Resource%20Feedback/Untestable/orange)
![Product%20Listing](https://badgen.net/badge/Product%20Listing/Untestable/orange)
![Resource%20Feedback](https://badgen.net/badge/Resource%20Feedback/Complete/green)

### Shipping and Fulfillment

![Assigned%20Fulfillment%20Orders](https://badgen.net/badge/Assigned%20Fulfillment/Complete/green)
![Cancellation%20Request](https://badgen.net/badge/Cancellation%20Request/Complete/green)
![Carrier%20Service](https://badgen.net/badge/Carrier%20Service/Complete/green)
![Fulfillments](https://badgen.net/badge/Fulfillments/Complete/green)
![Fulfillment%20Events](https://badgen.net/badge/Fulfillment%20Events/Complete/green)
![Fulfillment%20Orders](https://badgen.net/badge/Fulfillment%20Orders/Untestable/orange)
![Fulfillment%20Requests](https://badgen.net/badge/Fulfillment%20Requests/Untestable/orange)
![Fulfillment%20Services](https://badgen.net/badge/Fulfillment%20Services/Complete/green)
![Locations%20For%20Move](https://badgen.net/badge/Locations%20For%20Move/Untestable/orange)

### Shopify Payments

![Balance](https://badgen.net/badge/Balance/Complete/green)
![Dispute](https://badgen.net/badge/Dispute/Complete/green)
![Payouts](https://badgen.net/badge/Payouts/Complete/green)
![Transactions](https://badgen.net/badge/Transactions/Complete/green)

### Store Properties

![Country](https://badgen.net/badge/Country/Untestable/orange)
![Currency](https://badgen.net/badge/Currency/Complete/green)
![Policies](https://badgen.net/badge/Policies/Complete/green)
![Province](https://badgen.net/badge/Province/Complete/green)
![Shipping%20Zones](https://badgen.net/badge/Shipping%20Zones/Complete/green)
![Shops](https://badgen.net/badge/Shops/Complete/green)

### Tender Transactions

![Tender%20Transactions](https://badgen.net/badge/Tender%20Transactions/Complete/green)

## Usage

---

Open:Shopify uses the same categories and general organization that Shopify uses in their documentation. For instance, the [Orders]("https://shopify.dev/api/admin-rest/2022-04/resources/abandoned-checkouts") category of the API contains the following sections. Also included is a sample of how to call the list endpoints for each section given the following service.

`var service = OrdersService(MyShopifyUrl, AccessToken);`

* Abandoned checkouts
  * `var response = await service.AbandonedCheckouts.ListAbandonedCheckoutsAsync();`
* DraftOrder [sic]
  * `var response = await service.DraftOrder.ListDraftOrdersAsync();`
* Order
  * `var response = await service.Order.ListOrdersAsync();`
  * `var response = await service.Order.CreateOrderAsync(request);`
  * `var response = await service.Order.CloseOrderAsync(orderId);`
* Order Risks
  * `var response = await service.OrderRisk.ListOrderRisksAsync();`
* Refund
  * `var response = await service.Refund.ListRefundsAsync();`
* Transaction
  * `var response = await service.Transaction.ListTransactionsAsync();`

### Pagination APIs

Pagination in Shopify relies on various headers in the response. For this reason, all responses from Shopify are wrapped in a `ShopifyResponse` object that contains the headers, status code, and results of the call. This can make life much easier when paginating over results or handling unexpected status codes.

```csharp
var products = new List<Product>();
string? pageInfo = null;
while (true)
{
    var service = new ProductsService(MyShopifyUrl, AccessToken);
    var response = await service.Product.ListProductsAsync(pageInfo: pageInfo);
    products.AddRange(response.Result.Products);
    if (!response.Pagination.HasNextPage)
        break;
    pageInfo = response.Pagination.NextPageInfo;
}
```

## Installation

Open:Shopify is available on [NuGet](https://www.nuget.org/packages/Ocelli.OpenShopify/). Use the package manager console in Visual Studio to install it:

```powershell
Install-Package Ocelli.OpenShopify
```

### Access Token

Shopify uses an OAuth process to grant access to a store. Included in the project is a [SampleApp](tests/SampleApp) that can be used as a template for registering a store using Open:Shopify. This application can also be used locally for development.

## How to Contribute

---

Details about the components of the project and any special notes can be found [here](CONTRIBUTE.md).

1. Clone repo and create a new branch: `$ git checkout https://github.com/OcelliSolutions/OpenShopify -b name_for_new_branch`.
2. Make changes and test.
3. Submit Pull Request with comprehensive description of changes.

## Acknowledgements

---

* [@ShipOffers](https://github.com/ShipOffers) for sponsoring this project.
* [gms Design](https://gmsdesign.solutions) for logo and UI design.
