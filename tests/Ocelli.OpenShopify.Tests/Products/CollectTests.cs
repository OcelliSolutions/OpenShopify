﻿using System.Collections.Generic;

namespace Ocelli.OpenShopify.Tests.Products;

public class CollectFixture : SharedFixture, IAsyncLifetime
{
    public IProductsService Service;
    public List<Collect> CreatedCollects = new();

    public CollectFixture()
    {
        Service = new ProductsService(MyShopifyUrl, AccessToken);
    }
    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteCollectAsync_CanDelete();
    }
    
    public async Task DeleteCollectAsync_CanDelete()
    {
        foreach (var collect in CreatedCollects)
        {
            _ = await Service.Collect.DeleteProductFromCollectionAsync(collect.Id);
        }
        CreatedCollects.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CollectTests : IClassFixture<CollectFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CollectMockClient _badRequestMockClient;
    private readonly CollectMockClient _okEmptyMockClient;
    private readonly CollectMockClient _okInvalidJsonMockClient;

    public CollectTests(CollectFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new CollectMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new CollectMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new CollectMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private CollectFixture Fixture { get; }

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountCollectsAsync_CanGet()
    {
        var response = await Fixture.Service.Collect.CountCollectsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListCollectsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Collect.ListCollectsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var collect in response.Result.Collects)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(collect, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.Collects.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetCollectAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCollects.Any(), "Must be run with create test");
        var collect = Fixture.CreatedCollects.First();
        var response = await Fixture.Service.Collect.GetCollectAsync(collect.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Collect, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update
    /*
    [SkippableFact, TestPriority(30)]
    public async Task UpdateCollectAsync_CanUpdate()
    {
        var originalCollect = Fixture.CreatedCollects.First();
        var request = new UpdateCollectRequest()
        {
            Collect = new()
            {
                Id = originalCollect.Id,
                Fields = new List<string> { "id" }
            }
        };
        var response = await Fixture.Service.Collect.AddProductToCustomCollectionAsync(request.Collect.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCollects.Remove(originalCollect);
        Fixture.CreatedCollects.Add(response.Result.Collect);
    }
    */
    #endregion Update

    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task DeleteCollectAsync_CanDelete()
    {
        await Fixture.DeleteCollectAsync_CanDelete();
    }


    #endregion


    [Fact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class CollectMockClient : CollectClient, IMockTests
{
    public CollectMockClient(HttpClient httpClient, CollectFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        throw new XunitException("Not implemented.");
    }
}

