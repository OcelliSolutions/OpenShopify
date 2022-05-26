using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Products;

[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CustomCollectionFixture : SharedFixture, IAsyncLifetime
{
    public List<CustomCollection> CreatedCustomCollections = new();
    public ProductsService Service;

    public CustomCollectionFixture() =>
        Service = new ProductsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteCustomCollectionAsync_CanDelete();
    }

    public async Task DeleteCustomCollectionAsync_CanDelete()
    {
        foreach (var customCollection in CreatedCustomCollections)
        {
            _ = await Service.CustomCollection.DeleteCustomCollectionAsync(customCollection.Id);
        }
        CreatedCustomCollections.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CustomCollectionTests : IClassFixture<CustomCollectionFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public CustomCollectionTests(CustomCollectionFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private CustomCollectionFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateCustomCollectionAsync_CanUpdate()
    {
        var originalCustomCollection = Fixture.CreatedCustomCollections.First();
        var request = new UpdateCustomCollectionRequest
        {
            CustomCollection = new UpdateCustomCollection
            {
                Id = originalCustomCollection.Id,
                BodyHtml = @"<p>5000 songs in your pocket</p>"
            }
        };
        var response =
            await Fixture.Service.CustomCollection.UpdateCustomCollectionAsync(request.CustomCollection.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCustomCollections.Remove(originalCustomCollection);
        Fixture.CreatedCustomCollections.Add(response.Result.CustomCollection);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCustomCollectionAsync_CanCreate()
    {
        var request = new CreateCustomCollectionRequest
        {
            CustomCollection = new CreateCustomCollection
            {
                Title = "Macbooks"
            }
        };
        var response = await Fixture.Service.CustomCollection.CreateCustomCollectionAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCustomCollections.Add(response.Result.CustomCollection);
    }

    //TODO: There is a different between an empty create error and an invalid request. Build out tests for each scenario.
    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCustomCollectionAsync_IsUnprocessableEntityError()
    {
        var request = new CreateCustomCollectionRequest
        {
            CustomCollection = new CreateCustomCollection()
        };
        await Assert.ThrowsAsync<ApiException<CustomCollectionError>>(async () =>
            await Fixture.Service.CustomCollection.CreateCustomCollectionAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountCustomCollectionsAsync_CanGet()
    {
        var response = await Fixture.Service.CustomCollection.CountCustomCollectionsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListCustomCollectionsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.CustomCollection.ListCustomCollectionsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var customCollection in response.Result.CustomCollections)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(customCollection, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.CustomCollections.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetCustomCollectionAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCustomCollections.Any(), "Must be run with create test");
        var customCollection = Fixture.CreatedCustomCollections.First();
        var response = await Fixture.Service.CustomCollection.GetCustomCollectionAsync(customCollection.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomCollection, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task DeleteCustomCollectionAsync_CanDelete()
    {
        await Fixture.DeleteCustomCollectionAsync_CanDelete();
    }

    #endregion
    }