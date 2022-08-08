namespace Ocelli.OpenShopify.Tests.OnlineStore;

public class AssetFixture : SharedFixture, IAsyncLifetime
{
    public List<Asset> CreatedAssets = new();
    public IOnlineStoreService Service;
    public Theme Theme = new();

    public AssetFixture() =>
        Service = new OnlineStoreService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync() => await CreateTheme();

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteWebhookAsync_CanDelete();

        if (Theme.Id > 0)
        {
            await Service.Theme.DeleteThemeAsync(Theme.Id);
        }
    }

    public async Task DeleteWebhookAsync_CanDelete()
    {
        foreach (var asset in CreatedAssets)
        {
            _ = await Service.Asset.DeleteAssetFromThemeAsync(Theme.Id, asset.Key, CancellationToken.None);
        }
        CreatedAssets.Clear();
    }

    private async Task CreateTheme()
    {
        var request = CreateThemeRequest();
        var response = await Service.Theme.CreateThemeAsync(request);
        Theme = response.Result.Theme;
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("AssetTests")]
public class AssetTests : IClassFixture<AssetFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly AssetMockClient _badRequestMockClient;
    private readonly AssetMockClient _okEmptyMockClient;
    private readonly AssetMockClient _okInvalidJsonMockClient;

    public AssetTests(AssetFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new AssetMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new AssetMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new AssetMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private AssetFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListAssetsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Asset.ListAssetsForThemeAsync(Fixture.Theme.Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var asset in response.Result.Assets)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(asset, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Assets.Any(), "No results returned. Unable to test");
    }

    #endregion Read

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateAssetAsync_CanCreate()
    {
        var request = new CreateOrUpdatesAssetForThemeRequest
        {
            Asset = new CreateAsset()
            {
                Key = "assets/empty.gif",
                Attachment = @"R0lGODlhAQABAPABAP///wAAACH5BAEKAAAALAAAAAABAAEAAAICRAEAOw==\n"
            }
        };
        var response = await Fixture.Service.Asset.CreateOrUpdatesAssetForThemeAsync(Fixture.Theme.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedAssets.Add(response.Result.Asset);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateAssetAsync_IsUnprocessableEntityError()
    {
        var request = new CreateOrUpdatesAssetForThemeRequest()
        {
            Asset = new CreateAsset()
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.Asset.CreateOrUpdatesAssetForThemeAsync(Fixture.Theme.Id, request, CancellationToken.None));
    }

    #endregion Create

    #region Delete


    [SkippableFact, TestPriority(99)]
    public async Task DeleteWebhookAsync_CanDelete()
    {
        await Fixture.DeleteWebhookAsync_CanDelete();
    }

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

internal class AssetMockClient : AssetClient, IMockTests
{
    public AssetMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListAssetsForThemeAsync(0, cancellationToken: CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListAssetsForThemeAsync(0, cancellationToken: CancellationToken.None));
    }
}
