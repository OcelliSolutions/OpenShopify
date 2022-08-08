using SkipException = Xunit.SkipException;

namespace Ocelli.OpenShopify.Tests.SalesChannels;
public class CheckoutFixture : SharedFixture, IAsyncLifetime
{
    public ISalesChannelsService Service;
    public List<Checkout> CreatedCheckouts = new();
    public List<Product> CreatedProducts = new();

    public CheckoutFixture() => Service = new SalesChannelsService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
        var product = await CreateProduct();
        var inventoryService = new InventoryService(MyShopifyUrl, AccessToken);
        var variant = product.Variants!.First();
        var locations = await inventoryService.Location.ListLocationsAsync();
        await inventoryService.InventoryLevel.SetInventoryLevelForInventoryItemAtLocationAsync(
            new SetInventoryLevelForInventoryItemAtLocationRequest()
            {
                Available = 10,
                InventoryItemId = variant.InventoryItemId ?? 0,
                LocationId = locations.Result.Locations.First(l => l.Active == true).Id
            });
        CreatedProducts.Add(product);
    }

    async Task IAsyncLifetime.DisposeAsync() => await DeleteProductAsync_CanDelete();

    public async Task DeleteProductAsync_CanDelete()
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        foreach (var product in CreatedProducts)
        {
            _ = await productService.Product.DeleteProductAsync(product.Id, CancellationToken.None);
        }
        CreatedProducts.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("CheckoutTests")]
public class CheckoutTests : IClassFixture<CheckoutFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CheckoutMockClient _badRequestMockClient;
    private readonly CheckoutMockClient _okEmptyMockClient;
    private readonly CheckoutMockClient _okInvalidJsonMockClient;

    public CheckoutTests(CheckoutFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new CheckoutMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new CheckoutMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new CheckoutMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private CheckoutFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateCheckoutAsync_CanCreate()
    {
        var lineItems = Fixture.CreatedProducts.SelectMany(p =>
            (p.Variants ?? throw new SkipException("No variants available")).Take(1)
            .Select(v => new CheckoutLineItem { VariantId = v.Id, Quantity = 1, Price = v.Price })).ToList();
        Skip.If(!lineItems.Any(), "No variants available");
        
        var request = new CreateCheckoutRequest()
        {
            Checkout = new()
            {
                Email = Fixture.Email,
                LineItems = lineItems,
                ShippingAddress = new()
                {
                    Address1 = "126 York St.",
                    City = "Beverly Hills",
                    ProvinceCode = "CA",
                    Zip = "90035",
                    Phone = "(123)456-7890",
                    FirstName = "John",
                    LastName = "Smith",
                    CountryCode = "US"
                }
            }
        };
        var response = await Fixture.Service.Checkout.CreateCheckoutAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Checkout, Fixture.MyShopifyUrl);

        Fixture.CreatedCheckouts.Add(response.Result.Checkout);
    }

    [SkippableFact, TestPriority(11)]
    public async Task CompleteCheckoutAsync_CanComplete()
    {
        Skip.If(!Fixture.CreatedCheckouts.Any(), "Must be run with create test");
        var checkout = Fixture.CreatedCheckouts.First();
        checkout.ShippingLine = new ShippingLine()
        {
            Handle = "shopify-Free%20Shipping-0.00",
            Price = 0,
            Title = "Free Shipping"
        };

        checkout.ShippingRate = new ShippingRate()
        {
            Id = "shopify-Free%20Shipping-0.00",
            Price = 0,
            Title = "Free Shipping"
        };
        var response = await Fixture.Service.Checkout.CompleteCheckoutAsync(checkout.Token);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCheckouts.Add(response.Result.Checkout);
    }

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task ListShippingRatesAsync_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCheckouts.Any(), "Must be run with create test");
        var createdCheckout = Fixture.CreatedCheckouts.First();
        var response = await Fixture.Service.Checkout.ListShippingRatesAsync(createdCheckout.Token);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var checkout in response.Result.ShippingRates)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(checkout, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.ShippingRates.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetCheckoutAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCheckouts.Any(), "Must be run with create test");
        var checkout = Fixture.CreatedCheckouts.First();
        var response = await Fixture.Service.Checkout.GetCheckoutAsync(checkout.Token);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Checkout, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateCheckoutAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedCheckouts.Any(), "Must be run with create test");
        var originalCheckout = Fixture.CreatedCheckouts.First();
        var request = new UpdateCheckoutRequest()
        {
            Checkout = new()
            {
                Id = originalCheckout.Id,
                Token = originalCheckout.Token,
                ShippingAddress = new()
                {
                    Address1 = "126 York St.",
                    City = "Beverly Hills",
                    ProvinceCode = "CA",
                    Zip = "90035",
                    Phone = "(123)456-7890",
                    FirstName = "John",
                    LastName = "Smith",
                    CountryCode = "US"
                }
            }
        };
        var response = await Fixture.Service.Checkout.UpdateCheckoutAsync(request.Checkout.Token, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCheckouts.Remove(originalCheckout);
        Fixture.CreatedCheckouts.Add(response.Result.Checkout);
    }

    #endregion Update

    
    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class CheckoutMockClient : CheckoutClient, IMockTests
{
    public CheckoutMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }
    
    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        //TODO: Validate that all methods are tested in this first section
        await Assert.ThrowsAsync<ApiException>(async () => await ListShippingRatesAsync(string.Empty, CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListShippingRatesAsync(string.Empty, CancellationToken.None));
    }
}
