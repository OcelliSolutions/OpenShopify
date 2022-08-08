namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;

public class AssignedFulfillmentOrderFixture : SharedFixture, IAsyncLifetime
{
    public FulfillmentService FulfillmentService = new();
    public Order Order = new();
    public Product Product = new();
    public ProductVariant ProductVariant = new();

    public AssignedFulfillmentOrderFixture() =>
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);

    public IShippingAndFulfillmentService Service { get; set; }

    public async Task InitializeAsync()
    {
        FulfillmentService = await CreateFulfillmentService();
        Product = await CreateProduct(FulfillmentService);
        ProductVariant = Product.Variants!.First(v => v.FulfillmentService != null);
        Order = await CreateOrder(ProductVariant);
        
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        if (Order.Id > 0)
        {
            var orderService = new OrdersService(MyShopifyUrl, AccessToken);
            await orderService.Order.DeleteOrderAsync(Order.Id);
        }

        if (Product.Id > 0)
        {
            var productService = new ProductsService(MyShopifyUrl, AccessToken);
            await productService.Product.DeleteProductAsync(Product.Id);
        }

        if (FulfillmentService.Id > 0)
        {
            var fulfillmentService = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
            await fulfillmentService.FulfillmentService.DeleteFulfillmentServiceAsync(FulfillmentService.Id);
        }
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("AssignedFulfillmentOrderTests")]
public class AssignedFulfillmentOrderTests : IClassFixture<AssignedFulfillmentOrderFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly AssignedFulfillmentOrderMockClient _badRequestMockClient;
    private readonly AssignedFulfillmentOrderMockClient _okEmptyMockClient;
    private readonly AssignedFulfillmentOrderMockClient _okInvalidJsonMockClient;

    public AssignedFulfillmentOrderTests(AssignedFulfillmentOrderFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new AssignedFulfillmentOrderMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new AssignedFulfillmentOrderMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new AssignedFulfillmentOrderMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private AssignedFulfillmentOrderFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListAssignedFulfillmentOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.AssignedFulfillmentOrder.ListFulfillmentOrdersOnShopForSpecificAppAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var assignedFulfillmentOrder in response.Result.FulfillmentOrders)
        {
            Assert.NotNull(assignedFulfillmentOrder.OrderId);
            _additionalPropertiesHelper.CheckAdditionalProperties(assignedFulfillmentOrder, Fixture.MyShopifyUrl);
        }

        var list = response.Result.FulfillmentOrders;
        Skip.If(!list.Any(), "No results returned. Unable to test");
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

internal class AssignedFulfillmentOrderMockClient : AssignedFulfillmentOrderClient, IMockTests
{
    public AssignedFulfillmentOrderMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListFulfillmentOrdersOnShopForSpecificAppAsync());
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListFulfillmentOrdersOnShopForSpecificAppAsync());
    }
}
