using System;

namespace Ocelli.OpenShopify.Tests.Metafield;

public class MetafieldDraftOrderFixture : SharedFixture, IAsyncLifetime
{
    public List<DraftOrder> CreatedDraftOrders = new();
    public List<OpenShopify.Metafield> CreatedMetafields = new();
    public IMetafieldService Service;

    public MetafieldDraftOrderFixture() =>
        Service = new MetafieldService(MyShopifyUrl, AccessToken);


    public async Task InitializeAsync()
    {
        var ordersService = new OrdersService(MyShopifyUrl, AccessToken);
        var draftOrderRequest = this.CreateDraftOrderRequest();
        var draftOrder = await ordersService.DraftOrder.CreateDraftOrderAsync(draftOrderRequest, CancellationToken.None);
        CreatedDraftOrders.Add(draftOrder.Result.DraftOrder);
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteMetafieldForDraftOrderAsync_CanDelete();
        await DeleteDraftOrderAsync_CanDelete();
    }

    public async Task DeleteMetafieldForDraftOrderAsync_CanDelete()
    {
        foreach (var metafield in CreatedMetafields)
        {
            _ = await Service.Metafield.DeleteMetafieldForDraftOrderAsync(metafield.OwnerId ?? 0, metafield.Id, CancellationToken.None);
        }
        CreatedMetafields.Clear();
    }
    public async Task DeleteDraftOrderAsync_CanDelete()
    {
        var ordersService = new OrdersService(MyShopifyUrl, AccessToken);
        foreach (var draftOrder in CreatedDraftOrders)
        {
            _ = await ordersService.DraftOrder.DeleteDraftOrderAsync(draftOrder.Id, CancellationToken.None);
        }
        CreatedDraftOrders.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("MetafieldDraftOrderTests")]
public class MetafieldDraftOrderTests : IClassFixture<MetafieldDraftOrderFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly MetafieldDraftOrderMockClient _badRequestMockClient;
    private readonly MetafieldDraftOrderMockClient _okEmptyMockClient;
    private readonly MetafieldDraftOrderMockClient _okInvalidJsonMockClient;

    public MetafieldDraftOrderTests(MetafieldDraftOrderFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new MetafieldDraftOrderMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new MetafieldDraftOrderMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new MetafieldDraftOrderMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private MetafieldDraftOrderFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateMetafieldForDraftOrderAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedMetafields.Any(), "Please run with the create tests");
        var originalMetafield = Fixture.CreatedMetafields.First();
        var request = new UpdateMetafieldForDraftOrderRequest
        {
            Metafield = new ()
            {
                Id = originalMetafield.Id,
                Value = "something new",
                Type = MetafieldType.SingleLineTextField
            }
        };
        var response = await Fixture.Service.Metafield.UpdateMetafieldForDraftOrderAsync(originalMetafield.OwnerId ?? 0, originalMetafield.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMetafields.Remove(originalMetafield);
        Fixture.CreatedMetafields.Add(response.Result.Metafield);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMetafieldForDraftOrderAsync_CanCreate()
    {
        var draftOrder = Fixture.CreatedDraftOrders.First();
        var request = new CreateMetafieldForDraftOrderRequest()
        {
            Metafield = Fixture.CreateMetafieldRequest().Metafield
        };
        var response = await Fixture.Service.Metafield.CreateMetafieldForDraftOrderAsync(draftOrder.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMetafields.Add(response.Result.Metafield);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMetafieldForDraftOrderAsync_IsUnprocessableEntityError()
    {
        var draftOrder = Fixture.CreatedDraftOrders.First();
        var request = new CreateMetafieldForDraftOrderRequest
        {
            Metafield = new CreateMetafield()
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.Metafield.CreateMetafieldForDraftOrderAsync(draftOrder.Id, request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountMetafieldDraftOrdersAsync_CanGet()
    {
        var response = await Fixture.Service.Metafield.CountMetafieldsAttachedToDraftOrderAsync(Fixture.CreatedDraftOrders.First().Id, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListMetafieldDraftOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Metafield.ListMetafieldsAttachedToDraftOrderAsync(Fixture.CreatedDraftOrders.First().Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var metafield in response.Result.Metafields)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(metafield, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Metafields.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetMetafieldForDraftOrderAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedMetafields.Any(), "Must be run with create test");
        var metafield = Fixture.CreatedMetafields.First();
        var response = await Fixture.Service.Metafield.GetMetafieldAttachedToDraftOrderAsync(metafield.Id, metafield.OwnerId ?? 0, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Metafield, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteMetafieldForDraftOrderAsync_CanDelete()
    {
        await Fixture.DeleteMetafieldForDraftOrderAsync_CanDelete();
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

internal class MetafieldDraftOrderMockClient : MetafieldClient, IMockTests
{
    public MetafieldDraftOrderMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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

        #region DraftOrder

        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToDraftOrderAsync(draftOrderId: 0, createdAtMax: DateTimeOffset.Now, createdAtMin: DateTimeOffset.Now.AddDays(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToDraftOrderAsync(draftOrderId: 0, updatedAtMax: DateTimeOffset.Now, updatedAtMin: DateTimeOffset.Now.AddDays(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToDraftOrderAsync(draftOrderId: 0, fields: "id", limit: 1, pageInfo: "", key: "", @namespace: "", type: MetafieldType.Boolean, sinceId: 0, cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CountMetafieldsAttachedToDraftOrderAsync(draftOrderId: 0, CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetMetafieldAttachedToDraftOrderAsync(0, 0, "id", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CreateMetafieldForDraftOrderAsync(0, new CreateMetafieldForDraftOrderRequest(), CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await UpdateMetafieldForDraftOrderAsync(0, 0, new UpdateMetafieldForDraftOrderRequest(), CancellationToken.None));

        #endregion DraftOrder
        
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToDraftOrderAsync(0, cancellationToken: CancellationToken.None));
    }
}
