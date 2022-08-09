namespace Ocelli.OpenShopify.Tests.Access;

public class AccessScopeFixture : SharedFixture, IAsyncLifetime
{
    public AccessScopeFixture() =>
        Service = new AccessService(MyShopifyUrl, AccessToken);

    public IAccessService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("AccessScopeTests")]
public class AccessScopeTests : IClassFixture<AccessScopeFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly AccessScopeMockClient _badRequestMockClient;
    private readonly AccessScopeMockClient _okEmptyMockClient;
    private readonly AccessScopeMockClient _okInvalidJsonMockClient;

    public AccessScopeTests(AccessScopeFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new AccessScopeMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new AccessScopeMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new AccessScopeMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private AccessScopeFixture Fixture { get; }

    [SkippableFact]
    public async Task ListAccessScopesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var result = await Fixture.Service.AccessScope.ListAccessScopesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(result, Fixture.MyShopifyUrl);

        if (result.Result.AccessScopes == null)
        {
            Skip.If(result.Result.AccessScopes == null || !result.Result.AccessScopes.Any(),
                "WARN: No data returned. Could not test");
            return;
        }

        foreach (var accessScope in result.Result.AccessScopes)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(accessScope, Fixture.MyShopifyUrl);
        }

        Assert.NotEmpty(result.Result.AccessScopes);
        var handles = result.Result.AccessScopes.Select(a => a.Handle!);
        Assert.Contains(AuthorizationScope.ReadOrders, handles);
    }

    [SkippableFact]
    public async Task ListAccessScopesAsync_InvalidCredentials_ShouldFail()
    {
        var service = new AccessService("invalid", "invalid");
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
            await service.AccessScope.ListAccessScopesAsync());
    }
    
    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class AccessScopeMockClient : AccessScopeClient, IMockTests
{
    public AccessScopeMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MockShopifyUrl, true).ToString();
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListAccessScopesAsync(CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListAccessScopesAsync(CancellationToken.None));
    }
}
