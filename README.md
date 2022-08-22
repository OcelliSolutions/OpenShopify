![Open:Shopify](img/OpenShopifyBanner.png)

![Nuget](https://img.shields.io/nuget/v/Ocelli.OpenShopify)
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/OcelliSolutions/OpenShopify/Deploy%20to%20Github%20Packages)

**Open:Shopify** is an OpenAPI implementation of the `2022-07` version of the Shopify Management API. The difference between this and other projects that attempt to expand on the documentation from Shopify is that Open:Shopify scrapes the documentation and generates most of the OpenAPI documentation automatically. Once scraped, any undocumented features/properties are injected and integration tests are executed to ensure that all enums and properties are correctly formatted and accounted for.

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
