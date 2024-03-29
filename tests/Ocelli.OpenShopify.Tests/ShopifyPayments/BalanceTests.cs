﻿namespace Ocelli.OpenShopify.Tests.ShopifyPayments;

public class BalanceFixture : SharedFixture, IAsyncLifetime
{
    public BalanceFixture() =>
        Service = new ShopifyPaymentsService(MyShopifyUrl, AccessToken);

    public IShopifyPaymentsService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("BalanceTests")]
public class BalanceTests : IClassFixture<BalanceFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly BalanceMockClient _badRequestMockClient;
    private readonly BalanceMockClient _okEmptyMockClient;
    private readonly BalanceMockClient _okInvalidJsonMockClient;

    public BalanceTests(BalanceFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new BalanceMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new BalanceMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new BalanceMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    public BalanceFixture Fixture { get; set; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetCurrentBalanceAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Balance.GetCurrentBalanceAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
    }

    #endregion Read
    
    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class BalanceMockClient : BalanceClient, IMockTests
{
    public BalanceMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await GetCurrentBalanceAsync(CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await GetCurrentBalanceAsync(CancellationToken.None));
    }
}
