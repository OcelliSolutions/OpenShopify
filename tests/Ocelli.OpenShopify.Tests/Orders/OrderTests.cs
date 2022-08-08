namespace Ocelli.OpenShopify.Tests.Orders;

public class OrderFixture : SharedFixture, IAsyncLifetime
{
    public List<Order> CreatedOrders = new();
    public Product Product = new();
    public IOrdersService Service;

    public OrderFixture() =>
        Service = new OrdersService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync() => await CreateProduct();

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteOrderAsync_CanDelete();

        if (Product.Id > 0)
        {
            var productService = new ProductsService(MyShopifyUrl, AccessToken);
            await productService.Product.DeleteProductAsync(Product.Id);
        }
    }

    public async Task CreateProduct()
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        var request = CreateProductRequest();
        request.Product.Variants ??= new List<ProductVariant>();
        request.Product.Variants.Add(new ProductVariant { Sku = BatchId });
        var productResponse = await productService.Product.CreateProductAsync(request);
        Product = productResponse.Result.Product;
    }

    public async Task DeleteOrderAsync_CanDelete()
    {
        foreach (var order in CreatedOrders)
        {
            _ = await Service.Order.DeleteOrderAsync(order.Id);
        }

        CreatedOrders.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("OrderTests")]
public class OrderTests : IClassFixture<OrderFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly OrderMockClient _badRequestMockClient;
    private readonly OrderMockClient _okEmptyMockClient;
    private readonly OrderMockClient _okInvalidJsonMockClient;

    public OrderTests(OrderFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new OrderMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new OrderMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new OrderMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private OrderFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateOrderAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedOrders.Any(), "Must be run with create test");
        var originalOrder = Fixture.CreatedOrders.First();
        var request = new UpdateOrderRequest
        {
            Order = new UpdateOrder
            {
                Id = originalOrder.Id,
                Note = $@"{originalOrder.Note} | Customer contacted us about a custom engraving on this iPod"
            }
        };
        var response = await Fixture.Service.Order.UpdateOrderAsync(request.Order.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedOrders.Remove(originalOrder);
        Fixture.CreatedOrders.Add(response.Result.Order);
    }

    #endregion Update

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteOrderAsync_CanDelete() => await Fixture.DeleteOrderAsync_CanDelete();

    #endregion Delete

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateOrderAsync_CanCreate()
    {
        var request = Fixture.CreateOrderRequest(Fixture.Product.Variants!.First().Id);
        var response = await Fixture.Service.Order.CreateOrderAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedOrders.Add(response.Result.Order);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateOrderAsync_IsUnprocessableEntityError()
    {
        var request = new CreateOrderRequest
        {
            Order = new CreateOrder()
            {
                Name = Fixture.UniqueString()
            }
        };
        await Assert.ThrowsAsync<ApiException<OrderError>>(async () =>
            await Fixture.Service.Order.CreateOrderAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountOrdersAsync_CanGet()
    {
        var response = await Fixture.Service.Order.CountOrdersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Order.ListOrdersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var order in response.Result.Orders)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(order, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Orders.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListOrdersAsync_CanGetListOfOrders()
    {
        var initialList = await Fixture.Service.Order.ListOrdersAsync();
        var response = await Fixture.Service.Order.ListOrdersAsync(ids: initialList.Result.Orders.Select(o => o.Id));
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var order in response.Result.Orders)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(order, Fixture.MyShopifyUrl);
        }
        Assert.True(initialList.Result.Orders.Count > 0);
        //Assert.Equal(initialList.Result.Orders.Count, response.Result.Orders.Count);
        Skip.If(!response.Result.Orders.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetOrderAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedOrders.Any(), "Must be run with create test");
        var order = Fixture.CreatedOrders.First();
        var response = await Fixture.Service.Order.GetOrderAsync(order.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Order, Fixture.MyShopifyUrl);
    }

    #endregion Read


    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class OrderMockClient : OrderClient, IMockTests
{
    public OrderMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnData()
    {
        ReadResponseAsString = true;
        //TODO: Validate that all methods are tested in this first section
        await Assert.ThrowsAsync<ApiException>(async () => await ListOrdersAsync());
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListOrdersAsync());
    }
}
