﻿namespace Ocelli.OpenShopify.Tests.Orders;

public class DraftOrderFixture : SharedFixture, IAsyncLifetime
{
    public List<DraftOrder> CreatedDraftOrders = new();
    public IOrdersService Service;

    public DraftOrderFixture() =>
        Service = new OrdersService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteDraftOrderAsync_CanDelete();
    
    public async Task DeleteDraftOrderAsync_CanDelete()
    {
        foreach (var draftOrder in CreatedDraftOrders)
        {
            _ = await Service.DraftOrder.DeleteDraftOrderAsync(draftOrder.Id, CancellationToken.None);
        }
        CreatedDraftOrders.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("DraftOrderTests")]
public class DraftOrderTests : IClassFixture<DraftOrderFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly DraftOrderMockClient _badRequestMockClient;
    private readonly DraftOrderMockClient _okEmptyMockClient;
    private readonly DraftOrderMockClient _okInvalidJsonMockClient;

    public DraftOrderTests(DraftOrderFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new DraftOrderMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new DraftOrderMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new DraftOrderMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private DraftOrderFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateDraftOrderAsync_CanUpdate()
    {
        var originalDraftOrder = Fixture.CreatedDraftOrders.First();
        var request = new UpdateDraftOrderRequest
        {
            DraftOrder = new UpdateDraftOrder
            {
                Id = originalDraftOrder.Id,
                Note = "Customer contacted us about a custom engraving on this iPod"
            }
        };
        var response = await Fixture.Service.DraftOrder.UpdateDraftOrderAsync(originalDraftOrder.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedDraftOrders.Remove(originalDraftOrder);
        Fixture.CreatedDraftOrders.Add(response.Result.DraftOrder);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateDraftOrderAsync_CanCreate()
    {
        var request = Fixture.CreateDraftOrderRequest();
        var response = await Fixture.Service.DraftOrder.CreateDraftOrderAsync(body: request, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedDraftOrders.Add(response.Result.DraftOrder);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateDraftOrderAsync_IsUnprocessableEntityError()
    {
        var request = new CreateDraftOrderRequest
        {
            DraftOrder = new CreateDraftOrder()
            {
                Name = Fixture.UniqueString()
            }
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.DraftOrder.CreateDraftOrderAsync(body: request, cancellationToken: CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountDraftOrdersAsync_CanGet()
    {
        var response = await Fixture.Service.DraftOrder.CountDraftOrdersAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListDraftOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.DraftOrder.ListDraftOrdersAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var draftOrder in response.Result.DraftOrders)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(draftOrder, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.DraftOrders.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetDraftOrderAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedDraftOrders.Any(), "Must be run with create test");
        var draftOrder = Fixture.CreatedDraftOrders.First();
        var response = await Fixture.Service.DraftOrder.GetDraftOrderAsync(draftOrder.Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.DraftOrder, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteDraftOrderAsync_CanDelete()
    {
        await Fixture.DeleteDraftOrderAsync_CanDelete();
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

internal class DraftOrderMockClient : DraftOrderClient, IMockTests
{
    public DraftOrderMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListDraftOrdersAsync(cancellationToken: CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListDraftOrdersAsync(cancellationToken: CancellationToken.None));
    }
}
