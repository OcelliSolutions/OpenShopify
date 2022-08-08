using System;

namespace Ocelli.OpenShopify.Tests.Metafield;

public class MetafieldFixture : SharedFixture, IAsyncLifetime
{
    public List<Order> CreatedOrders = new();
    public List<OpenShopify.Metafield> CreatedMetafields = new();
    public IMetafieldService Service;

    public MetafieldFixture() =>
        Service = new MetafieldService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        var products = await productService.Product.ListProductsAsync(limit: 1);
        var product = products.Result.Products.FirstOrDefault();
        var productVariant = product?.Variants?.FirstOrDefault();
        if(productVariant == null) return;

        var order = await CreateOrder(productVariant);
        CreatedOrders.Add(order);
    }

    async Task IAsyncLifetime.DisposeAsync() => await DeleteMetafieldAsync_CanDelete();
    
    public async Task DeleteMetafieldAsync_CanDelete()
    {
        foreach (var metafield in CreatedMetafields)
        {
            _ = await Service.Metafield.DeleteMetafieldAsync(metafield.Id, CancellationToken.None);
        }
        CreatedMetafields.Clear();
    }
    public async Task DeleteOrderAsync_CanDelete()
    {
        var orderService = new OrdersService(MyShopifyUrl, AccessToken);
        foreach (var order in CreatedOrders)
        {
            _ = await orderService.Order.DeleteOrderAsync(order.Id, CancellationToken.None);
        }
        CreatedOrders.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("MetafieldTests")]
public class MetafieldTests : IClassFixture<MetafieldFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly MetafieldMockClient _badRequestMockClient;
    private readonly MetafieldMockClient _okEmptyMockClient;
    private readonly MetafieldMockClient _okInvalidJsonMockClient;

    public MetafieldTests(MetafieldFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new MetafieldMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new MetafieldMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new MetafieldMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private MetafieldFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateMetafieldAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedMetafields.Any(), "Please run with the create tests");
        var originalMetafield = Fixture.CreatedMetafields.First();
        var request = new UpdateMetafieldRequest
        {
            Metafield = new UpdateMetafield
            {
                Id = originalMetafield.Id,
                Value = "something new",
                Type = MetafieldType.SingleLineTextField
            }
        };
        var response = await Fixture.Service.Metafield.UpdateMetafieldAsync(originalMetafield.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMetafields.Remove(originalMetafield);
        Fixture.CreatedMetafields.Add(response.Result.Metafield);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMetafieldAsync_CanCreate()
    {
        var order = Fixture.CreatedOrders.First();
        var request = Fixture.CreateMetafieldRequest();
        var response = await Fixture.Service.Metafield.CreateMetafieldAsync(order.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMetafields.Add(response.Result.Metafield);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMetafieldAsync_IsUnprocessableEntityError()
    {
        var order = Fixture.CreatedOrders.First();
        var request = new CreateMetafieldRequest
        {
            Metafield = new CreateMetafield()
        };
        await Assert.ThrowsAsync<ApiException<MetafieldError>>(async () =>
            await Fixture.Service.Metafield.CreateMetafieldAsync(order.Id, request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountMetafieldsAsync_CanGet()
    {
        var response = await Fixture.Service.Metafield.CountResourcesMetafieldsAsync(CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListMetafieldsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Metafield.ListMetafieldsFromResourcesEndpointAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var metafield in response.Result.Metafields)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(metafield, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Metafields.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetMetafieldAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedMetafields.Any(), "Must be run with create test");
        var metafield = Fixture.CreatedMetafields.First();
        var response = await Fixture.Service.Metafield.GetMetafieldAsync(metafield.Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Metafield, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteMetafieldAsync_CanDelete()
    {
        await Fixture.DeleteMetafieldAsync_CanDelete();
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

internal class MetafieldMockClient : MetafieldClient, IMockTests
{
    public MetafieldMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsFromResourcesEndpointAsync(createdAtMax: DateTimeOffset.Now, createdAtMin: DateTimeOffset.Now.AddDays(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsFromResourcesEndpointAsync(updatedAtMax: DateTimeOffset.Now, updatedAtMin: DateTimeOffset.Now.AddDays(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsFromResourcesEndpointAsync(fields: "id", limit: 1, pageInfo: "", key: "", @namespace: "", type: MetafieldType.Boolean, sinceId: 0, cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CountResourcesMetafieldsAsync(CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetMetafieldAsync(0, "id", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CreateMetafieldAsync(0, new CreateMetafieldRequest(), CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await UpdateMetafieldAsync(0, new UpdateMetafieldRequest(), CancellationToken.None));

        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsFromResourcesEndpointAsync(cancellationToken: CancellationToken.None));
    }
}
