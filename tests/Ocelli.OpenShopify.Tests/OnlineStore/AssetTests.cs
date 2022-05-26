using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.OnlineStore;

public class AssetFixture : SharedFixture, IAsyncLifetime
{
    public List<Asset> CreatedAssets = new();
    public OnlineStoreService Service;
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
            _ = await Service.Asset.DeleteAssetFromThemeAsync(Theme.Id, asset.Key);
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
public class AssetTests : IClassFixture<AssetFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public AssetTests(AssetFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private AssetFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListAssetsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Asset.ListAssetsForThemeAsync(Fixture.Theme.Id);
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
        var request = new CreateAssetRequest
        {
            Asset = new CreateAsset
            {
                Key = "assets/empty.gif",
                Attachment = @"R0lGODlhAQABAPABAP///wAAACH5BAEKAAAALAAAAAABAAEAAAICRAEAOw==\n"
            }
        };
        var response = await Fixture.Service.Asset.CreateOrUpdatesAssetForThemeAsync(Fixture.Theme.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedAssets.Add(response.Result.Asset);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateAssetAsync_IsUnprocessableEntityError()
    {
        var request = new CreateAssetRequest
        {
            Asset = new CreateAsset()
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.Asset.CreateOrUpdatesAssetForThemeAsync(Fixture.Theme.Id, request));
    }

    #endregion Create

    #region Delete


    [SkippableFact, TestPriority(99)]
    public async Task DeleteWebhookAsync_CanDelete()
    {
        await Fixture.DeleteWebhookAsync_CanDelete();
    }

    #endregion Delete
}