namespace Ocelli.OpenShopify.Tests.DeprecatedApiCalls;

public class DeprecatedApiCallsFixture : SharedFixture, IAsyncLifetime
{
    public List<DeprecatedApiCall> CreatedDeprecatedApiCalls = new();
    public IDeprecatedApiCallsService Service;

    public DeprecatedApiCallsFixture() =>
        Service = new DeprecatedApiCallsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("DeprecatedApiCallsTests")]
public class DeprecatedApiCallsTests : IClassFixture<DeprecatedApiCallsFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly DeprecatedApiCallMockClient _badRequestMockClient;
    private readonly DeprecatedApiCallMockClient _okEmptyMockClient;
    private readonly DeprecatedApiCallMockClient _okInvalidJsonMockClient;

    public DeprecatedApiCallsTests(DeprecatedApiCallsFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new DeprecatedApiCallMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new DeprecatedApiCallMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new DeprecatedApiCallMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    public DeprecatedApiCallsFixture Fixture { get; set; }

    #region Read

    [SkippableFact(Skip =
        "The Deprecated API calls resource is available only for private apps and currently just returns 404.")]
    [TestPriority(20)]
    public async Task ListDeprecatedAPICallsAsync_CanList()
    {
        var response = await Fixture.Service.DeprecatedApiCalls.ListDeprecatedAPICallsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var call in response.Result.DeprecatedApiCalls)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(call, Fixture.MyShopifyUrl);
        }
    }

    [SkippableFact]
    [TestPriority(20)]
    // If this one fails, enable the one above and see if it validates correctly. Once complete, delete this test.
    public async Task ListDeprecatedAPICallsAsync_Returns404()
    {
        await Assert.ThrowsAsync<ApiException>(async () => await Fixture.Service.DeprecatedApiCalls.ListDeprecatedAPICallsAsync());
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

internal class DeprecatedApiCallMockClient : DeprecatedApiCallsClient, IMockTests
{
    public DeprecatedApiCallMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListDeprecatedAPICallsAsync(CancellationToken.None));
    }
}
