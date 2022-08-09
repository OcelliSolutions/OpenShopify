namespace Ocelli.OpenShopify.Tests.Orders;

public class AbandonedCheckoutFixture : SharedFixture, IAsyncLifetime
{
    public List<Checkout> CreatedAbandonedCheckouts = new();
    public IOrdersService Service;

    public AbandonedCheckoutFixture() =>
        Service = new OrdersService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("AbandonedCheckoutTests")]
public class AbandonedCheckoutTests : IClassFixture<AbandonedCheckoutFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly AbandonedCheckoutMockClient _badRequestMockClient;
    private readonly AbandonedCheckoutMockClient _okEmptyMockClient;
    private readonly AbandonedCheckoutMockClient _okInvalidJsonMockClient;

    public AbandonedCheckoutTests(AbandonedCheckoutFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new AbandonedCheckoutMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new AbandonedCheckoutMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new AbandonedCheckoutMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private AbandonedCheckoutFixture Fixture { get; }

    #region Read

    //TODO: needs a test to trigger an abandoned checkout
    [SkippableFact]
    [TestPriority(20)]
    public async Task ListAbandonedCheckoutsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.AbandonedCheckouts.ListAbandonedCheckoutsAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var abandonedCheckout in response.Result.Checkouts)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(abandonedCheckout, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Checkouts.Any(), "No results returned. Unable to test");
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

internal class AbandonedCheckoutMockClient : AbandonedCheckoutsClient, IMockTests
{
    public AbandonedCheckoutMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListAbandonedCheckoutsAsync(cancellationToken: CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListAbandonedCheckoutsAsync(cancellationToken: CancellationToken.None));
    }
}
