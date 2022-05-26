using System.Collections.Generic;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.StoreProperties;

public class ShopFixture : SharedFixture, IAsyncLifetime
{
    public List<Shop> CreatedShops = new();
    public StorePropertiesService Service;

    public ShopFixture() =>
        Service = new StorePropertiesService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ShopTests : IClassFixture<ShopFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;


    public ShopTests(ShopFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private ShopFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetShopsConfigurationAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Shop.GetShopsConfigurationAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Shop, Fixture.MyShopifyUrl);
    }

    #endregion Read
}