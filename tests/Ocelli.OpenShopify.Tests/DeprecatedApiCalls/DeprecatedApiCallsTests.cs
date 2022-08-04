using System.Collections.Generic;

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

    #endregion Read


    [Fact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class DeprecatedApiCallMockClient : DeprecatedApiCallsClient, IMockTests
{
    public DeprecatedApiCallMockClient(HttpClient httpClient, DeprecatedApiCallsFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        throw new XunitException("Not implemented.");
    }
}
