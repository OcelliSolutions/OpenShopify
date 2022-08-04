using System.Collections.Generic;

namespace Ocelli.OpenShopify.Tests.SalesChannels;
public class CollectionListingFixture : SharedFixture, IAsyncLifetime
{
    public ISalesChannelsService Service;
    public List<CollectionListing> CreatedCollectionListings = new();

    public CollectionListingFixture()
    {
        Service = new SalesChannelsService(MyShopifyUrl, AccessToken);
    }
    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteCollectionListingAsync_CanDelete();
    }
    
    public async Task DeleteCollectionListingAsync_CanDelete()
    {
        foreach (var collectionListing in CreatedCollectionListings)
        {
            _ = await Service.CollectionListing.DeleteCollectionListingAsync(collectionListing.Id);
        }
        CreatedCollectionListings.Clear();
    }
}
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CollectionListingTests : IClassFixture<CollectionListingFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CollectionListingMockClient _badRequestMockClient;
    private readonly CollectionListingMockClient _okEmptyMockClient;
    private readonly CollectionListingMockClient _okInvalidJsonMockClient;

    public CollectionListingTests(CollectionListingFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new CollectionListingMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new CollectionListingMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new CollectionListingMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private CollectionListingFixture Fixture { get; }

    //TODO: Build Collection Listing Tests
    /*
    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateCollectionListingAsync_CanCreate()
    {
        var request = new CreateCollectionListingRequest()
        {
            CollectionListing = new()
            {
                Topic = CollectionListingTopic.FulfillmentEventsCreate,
                Address = $@"{Fixture.CallbackUrl}/fulfillment_events_create"
            }
        };
        var response = await Fixture.Service.CollectionListing.CreateCollectionListingAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCollectionListings.Add(response.Result.CollectionListing);
    }

    [SkippableFact, TestPriority(10)]
    public async Task CreateCollectionListingAsync_IsUnprocessableEntityError()
    {
        var request = new CreateCollectionListingRequest()
        {
            CollectionListing = new()
        };
        await Assert.ThrowsAsync<ApiException<CollectionListingError>>(async () => await Fixture.Service.CollectionListing.CreateCollectionListingAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountCollectionListingsAsync_CanGet()
    {
        var response = await Fixture.Service.CollectionListing.CountCollectionListingsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListCollectionListingsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.CollectionListing.ListCollectionListingsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var collectionListing in response.Result.CollectionListings)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(collectionListing, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.CollectionListings.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetCollectionListingAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCollectionListings.Any(), "Must be run with create test");
        var collectionListing = Fixture.CreatedCollectionListings.First();
        var response = await Fixture.Service.CollectionListing.GetCollectionListingAsync(collectionListing.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CollectionListing, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateCollectionListingAsync_CanUpdate()
    {
        var originalCollectionListing = Fixture.CreatedCollectionListings.First();
        var request = new UpdateCollectionListingRequest()
        {
            CollectionListing = new()
            {
                Id = originalCollectionListing.Id,
                Fields = new List<string> { "id" }
            }
        };
        var response = await Fixture.Service.CollectionListing.UpdateCollectionListingAsync(request.CollectionListing.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCollectionListings.Remove(originalCollectionListing);
        Fixture.CreatedCollectionListings.Add(response.Result.CollectionListing);
    }

    #endregion Update
*/
    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task DeleteCollectionListingAsync_CanDelete()
    {
        await Fixture.DeleteCollectionListingAsync_CanDelete();
    }

    #endregion Delete


    [Fact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class CollectionListingMockClient : CollectionListingClient, IMockTests
{
    public CollectionListingMockClient(HttpClient httpClient, CollectionListingFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        throw new XunitException("Not implemented.");
    }
}

