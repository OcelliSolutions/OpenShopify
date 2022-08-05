namespace Ocelli.OpenShopify.Tests.TenderTransaction;

public class TenderTransactionFixture : SharedFixture, IAsyncLifetime
{
    public TenderTransactionFixture() =>
        Service = new AccessService(MyShopifyUrl, AccessToken);

    public IAccessService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("TenderTransactionTests")]
public class TenderTransactionTests : IClassFixture<TenderTransactionFixture>
{
    private TenderTransactionFixture Fixture { get; }
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly TenderTransactionMockClient _badRequestMockClient;
    private readonly TenderTransactionMockClient _okEmptyMockClient;
    private readonly TenderTransactionMockClient _okInvalidJsonMockClient;

    public TenderTransactionTests(TenderTransactionFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new TenderTransactionMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new TenderTransactionMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new TenderTransactionMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
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

internal class TenderTransactionMockClient : TenderTransactionClient, IMockTests
{
    public TenderTransactionMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        Skip.If(0==1,"Not implemented.");
        return Task.CompletedTask;
    }
}