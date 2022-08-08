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
//[Collection("TenderTransactionTests")]
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
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class TenderTransactionMockClient : TenderTransactionClient, IMockTests
{
    public TenderTransactionMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListTenderTransactionsAsync());
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListTenderTransactionsAsync());
    }
}