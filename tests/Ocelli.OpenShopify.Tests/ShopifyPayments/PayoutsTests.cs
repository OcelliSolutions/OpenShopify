namespace Ocelli.OpenShopify.Tests.ShopifyPayments;
public class PayoutsFixture : SharedFixture, IAsyncLifetime
{
    public PayoutsFixture() =>
        Service = new ShopifyPaymentsService(MyShopifyUrl, AccessToken);

    public IShopifyPaymentsService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("PayoutsTests")]
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


    #region Create

    #endregion Create

    #region Read

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete


    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class PayoutsMockClient : PayoutsClient, IMockTests
{
    public PayoutsMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        Skip.If(0==1,"Not implemented.");
        return Task.CompletedTask;
    }
}
