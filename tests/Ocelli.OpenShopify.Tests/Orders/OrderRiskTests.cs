namespace Ocelli.OpenShopify.Tests.Orders;

public class OrderRiskFixture : SharedFixture, IAsyncLifetime
{
    public List<OrderRisk> CreatedOrderRisks = new();
    public Order Order = new();
    public Product Product = new();
    public Checkout Checkout = new();
    public IOrdersService Service;

    public OrderRiskFixture() =>
        Service = new OrdersService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
        Product = await CreateProduct();
        Order = await CreateOrder(Product.Variants!.First());
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteOrderRiskAsync_CanDelete();

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
    }

    public async Task DeleteOrderRiskAsync_CanDelete()
    {
        foreach (var orderRisk in CreatedOrderRisks)
        {
            _ = await Service.OrderRisk.DeleteOrderRiskAsync(Order.Id, orderRisk.Id);
        }
        CreatedOrderRisks.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("OrderRiskTests")]
public class OrderRiskTests : IClassFixture<OrderRiskFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly OrderRiskMockClient _badRequestMockClient;
    private readonly OrderRiskMockClient _okEmptyMockClient;
    private readonly OrderRiskMockClient _okInvalidJsonMockClient;

    public OrderRiskTests(OrderRiskFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new OrderRiskMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new OrderRiskMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new OrderRiskMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private OrderRiskFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateOrderRiskAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedOrderRisks.Any(), "Must be run with create test");
        var originalOrderRisk = Fixture.CreatedOrderRisks.First();
        var request = new UpdateOrderRiskRequest
        {
            Risk = new UpdateOrderRisk
            {
                Id = originalOrderRisk.Id,
                Message = "After further review, this is a legitimate order",
                Recommendation = RiskRecommendation.Accept,
                Source = "External",
                CauseCancel = false,
                Score = (decimal)0.0
            }
        };
        var response =
            await Fixture.Service.OrderRisk.UpdateOrderRiskAsync(Fixture.Order.Id, originalOrderRisk.Id,
                request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedOrderRisks.Remove(originalOrderRisk);
        Fixture.CreatedOrderRisks.Add(response.Result.Risk);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateOrderRiskAsync_CanCreate()
    {
        var request = Fixture.CreateOrderRiskRequest();
        var response = await Fixture.Service.OrderRisk.CreateOrderRiskAsync(Fixture.Order.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedOrderRisks.Add(response.Result.Risk);
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListOrderRisksAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.OrderRisk.ListOrderRisksAsync(Fixture.Order.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var orderRisk in response.Result.Risks)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(orderRisk, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Risks.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetOrderRiskAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedOrderRisks.Any(), "Must be run with create test");
        var orderRisk = Fixture.CreatedOrderRisks.First();
        var response = await Fixture.Service.OrderRisk.GetOrderRiskAsync(Fixture.Order.Id, orderRisk.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Risk, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete


    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteOrderRiskAsync_CanDelete()
    {
        await Fixture.DeleteOrderRiskAsync_CanDelete();
    }

    #endregion Delete


    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class OrderRiskMockClient : OrderRiskClient, IMockTests
{
    public OrderRiskMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        Skip.If(0==1,"Not implemented.");
        return Task.CompletedTask;
    }
}
