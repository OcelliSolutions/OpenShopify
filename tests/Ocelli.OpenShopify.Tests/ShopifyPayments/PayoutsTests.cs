namespace Ocelli.OpenShopify.Tests.ShopifyPayments;
public class PayoutsFixture : SharedFixture, IAsyncLifetime
{
    public List<Payout> Payouts = new ();
    public PayoutsFixture() =>
        Service = new ShopifyPaymentsService(MyShopifyUrl, AccessToken);

    public IShopifyPaymentsService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("PayoutsTests")]
public class PayoutsTests : IClassFixture<PayoutsFixture>
{
    private PayoutsFixture Fixture { get; }
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly PayoutsMockClient _badRequestMockClient;
    private readonly PayoutsMockClient _okEmptyMockClient;
    private readonly PayoutsMockClient _okInvalidJsonMockClient;

    public PayoutsTests(PayoutsFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new PayoutsMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new PayoutsMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new PayoutsMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListPayoutsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Payouts.ListPayoutsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        Skip.If(!response.Result.Payouts.Any(), "No available payouts to test");
        Fixture.Payouts.AddRange(response.Result.Payouts);
    }

    [SkippableFact]
    [TestPriority(21)]
    public async Task GetPayoutAsync_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.Payouts.Any(), "No available payouts to test");
        var payout = Fixture.Payouts.First();
        var response = await Fixture.Service.Payouts.GetPayoutAsync(payout.Id);
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

internal class PayoutsMockClient : PayoutsClient, IMockTests
{
    public PayoutsMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListPayoutsAsync());
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListPayoutsAsync());
    }
}
