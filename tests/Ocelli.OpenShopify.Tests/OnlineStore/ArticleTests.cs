namespace Ocelli.OpenShopify.Tests.OnlineStore;

public class ArticleFixture : SharedFixture, IAsyncLifetime
{
    public ArticleFixture() =>
        Service = new OnlineStoreService(MyShopifyUrl, AccessToken);

    public IOnlineStoreService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("ArticleTests")]
public class ArticleTests : IClassFixture<ArticleFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ArticleMockClient _badRequestMockClient;
    private readonly ArticleMockClient _okEmptyMockClient;
    private readonly ArticleMockClient _okInvalidJsonMockClient;

    public ArticleTests(ArticleFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ArticleMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new ArticleMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new ArticleMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    public ArticleFixture Fixture { get; set; }
    
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

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class ArticleMockClient : ArticleClient, IMockTests
{
    public ArticleMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnData()
    {
        ReadResponseAsString = true;
        //TODO: Validate that all methods are tested in this first section
        await Assert.ThrowsAsync<ApiException>(async () => await ListArticlesAsync(0));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListArticlesAsync(0));
    }
}

