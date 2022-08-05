namespace Ocelli.OpenShopify.Tests.OnlineStore;

public class ThemeFixture : SharedFixture, IAsyncLifetime
{
    public ThemeFixture() =>
        Service = new OnlineStoreService(MyShopifyUrl, AccessToken);

    public IOnlineStoreService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("ThemeTests")]
public class ThemeTests : IClassFixture<ThemeFixture>
{
    private ThemeFixture Fixture { get; }
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ThemeMockClient _badRequestMockClient;
    private readonly ThemeMockClient _okEmptyMockClient;
    private readonly ThemeMockClient _okInvalidJsonMockClient;

    public ThemeTests(ThemeFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ThemeMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new ThemeMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new ThemeMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
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

internal class ThemeMockClient : ThemeClient, IMockTests
{
    public ThemeMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        Skip.If(0==1,"Not implemented.");
        return Task.CompletedTask;
    }
}

