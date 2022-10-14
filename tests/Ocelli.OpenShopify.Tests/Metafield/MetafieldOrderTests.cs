using System;

namespace Ocelli.OpenShopify.Tests.Metafield;

public class MetafieldOrderFixture : SharedFixture, IAsyncLifetime
{
    public List<Order> CreatedOrders = new();
    public List<OpenShopify.Metafield> CreatedMetafields = new();
    public IMetafieldService Service;

    public MetafieldOrderFixture() =>
        Service = new MetafieldService(MyShopifyUrl, AccessToken);


    public async Task InitializeAsync()
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        var products = await productService.Product.ListProductsAsync(limit: 1);
        var product = products.Result.Products.FirstOrDefault();
        var productVariant = product?.Variants?.FirstOrDefault();
        if (productVariant == null) return;

        var order = await CreateOrder(productVariant);
        CreatedOrders.Add(order);
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteMetafieldForOrderAsync_CanDelete();
        await DeleteOrderAsync_CanDelete();
    }

    public async Task DeleteMetafieldForOrderAsync_CanDelete()
    {
        foreach (var metafield in CreatedMetafields)
        {
            _ = await Service.Metafield.DeleteMetafieldForOrderAsync(metafield.OwnerId ?? 0, metafield.Id, CancellationToken.None);
        }
        CreatedMetafields.Clear();
    }
    public async Task DeleteOrderAsync_CanDelete()
    {
        var ordersService = new OrdersService(MyShopifyUrl, AccessToken);
        foreach (var order in CreatedOrders)
        {
            _ = await ordersService.Order.DeleteOrderAsync(order.Id, CancellationToken.None);
        }
        CreatedOrders.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("MetafieldOrderTests")]
public class MetafieldOrderTests : IClassFixture<MetafieldOrderFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly MetafieldOrderMockClient _badRequestMockClient;
    private readonly MetafieldOrderMockClient _okEmptyMockClient;
    private readonly MetafieldOrderMockClient _okInvalidJsonMockClient;

    public MetafieldOrderTests(MetafieldOrderFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new MetafieldOrderMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new MetafieldOrderMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new MetafieldOrderMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private MetafieldOrderFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateMetafieldForOrderAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedMetafields.Any(), "Please run with the create tests");
        var originalMetafield = Fixture.CreatedMetafields.First();
        var request = new UpdateMetafieldForOrderRequest
        {
            Metafield = new ()
            {
                Id = originalMetafield.Id,
                Value = "something new",
                Type = MetafieldType.SingleLineTextField
            }
        };
        var response = await Fixture.Service.Metafield.UpdateMetafieldForOrderAsync(originalMetafield.OwnerId ?? 0, originalMetafield.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMetafields.Remove(originalMetafield);
        Fixture.CreatedMetafields.Add(response.Result.Metafield);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMetafieldForOrderAsync_CanCreate()
    {
        var order = Fixture.CreatedOrders.First();
        var request = new CreateMetafieldForOrderRequest()
        {
            Metafield = Fixture.CreateMetafieldRequest().Metafield
        };
        var response = await Fixture.Service.Metafield.CreateMetafieldForOrderAsync(order.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMetafields.Add(response.Result.Metafield);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMetafieldForOrderAsync_IsUnprocessableEntityError()
    {
        var order = Fixture.CreatedOrders.First();
        var request = new CreateMetafieldForOrderRequest
        {
            Metafield = new CreateMetafield()
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.Metafield.CreateMetafieldForOrderAsync(order.Id, request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountMetafieldOrdersAsync_CanGet()
    {
        var response = await Fixture.Service.Metafield.CountMetafieldsAttachedToOrderAsync(Fixture.CreatedOrders.First().Id, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListMetafieldOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Metafield.ListMetafieldsAttachedToOrderAsync(Fixture.CreatedOrders.First().Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var metafield in response.Result.Metafields)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(metafield, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Metafields.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetMetafieldForOrderAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedMetafields.Any(), "Must be run with create test");
        var metafield = Fixture.CreatedMetafields.First();
        var response = await Fixture.Service.Metafield.GetMetafieldAttachedToOrderAsync(metafield.Id, metafield.OwnerId ?? 0, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Metafield, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteMetafieldForOrderAsync_CanDelete()
    {
        await Fixture.DeleteMetafieldForOrderAsync_CanDelete();
    }

    #endregion Delete


    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class MetafieldOrderMockClient : MetafieldClient, IMockTests
{
    public MetafieldOrderMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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

        #region Order

        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToOrderAsync(orderId: 0, createdAtMax: DateTimeOffset.Now, createdAtMin: DateTimeOffset.Now.AddDays(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToOrderAsync(orderId: 0, updatedAtMax: DateTimeOffset.Now, updatedAtMin: DateTimeOffset.Now.AddDays(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToOrderAsync(orderId: 0, fields: "id", limit: 1, pageInfo: "", key: "", @namespace: "", type: MetafieldType.Boolean, sinceId: 0, cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CountMetafieldsAttachedToOrderAsync(orderId: 0, CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetMetafieldAttachedToOrderAsync(0, 0, "id", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CreateMetafieldForOrderAsync(0, new CreateMetafieldForOrderRequest(), CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await UpdateMetafieldForOrderAsync(0, 0, new UpdateMetafieldForOrderRequest(), CancellationToken.None));

        #endregion Order
        
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToOrderAsync(0, cancellationToken: CancellationToken.None));
    }
}
