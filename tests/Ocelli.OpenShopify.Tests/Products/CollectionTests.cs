using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Products;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CollectionTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ProductsService _service;

    public CollectionTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new ProductsService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    #region Create

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task Lists_Products_Belonging_To_Collection()
    {
        var collectResponse = await _service.Collect.ListCollectsAsync(limit: 1);
        var collect = collectResponse.Result.Collects.First();
        var response = await _service.Collection.ListProductsBelongingToCollectionAsync(collect.CollectionId ?? 0);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var product in response.Result.Products)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(product, Fixture.MyShopifyUrl);
        }
    }

    [SkippableFact, TestPriority(20)]
    public async Task Gets_Collects()
    {
        var collectResponse = await _service.Collect.ListCollectsAsync(limit: 1);
        var collect = collectResponse.Result.Collects.First();
        var response = await _service.Collection.GetCollectionAsync(collect.CollectionId ?? 0);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Collection, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}
