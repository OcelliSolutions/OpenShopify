namespace Ocelli.OpenShopify.Tests.Products;

//[Collection("Shared collection")]
public class CustomCollectionFixture : SharedFixture, IAsyncLifetime
{
    public List<CustomCollection> CreatedCustomCollections = new();
    public IProductsService Service;

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
            _ = await Service.CustomCollection.DeleteCustomCollectionAsync(customCollection.Id, CancellationToken.None);
        }
        CreatedCustomCollections.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("CustomCollectionTests")]
public class CustomCollectionTests : IClassFixture<CustomCollectionFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CustomCollectionMockClient _badRequestMockClient;
    private readonly CustomCollectionMockClient _okEmptyMockClient;
    private readonly CustomCollectionMockClient _okInvalidJsonMockClient;

    public CustomCollectionTests(CustomCollectionFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new CustomCollectionMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new CustomCollectionMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new CustomCollectionMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
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
            await Fixture.Service.CustomCollection.UpdateCustomCollectionAsync(request.CustomCollection.Id, request, CancellationToken.None);
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
        var response = await Fixture.Service.CustomCollection.CreateCustomCollectionAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCustomCollections.Add(response.Result.CustomCollection);
    }
    
    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountCustomCollectionsAsync_CanGet()
    {
        var response = await Fixture.Service.CustomCollection.CountCustomCollectionsAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListCustomCollectionsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.CustomCollection.ListCustomCollectionsAsync(cancellationToken: CancellationToken.None);
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
        var response = await Fixture.Service.CustomCollection.GetCustomCollectionAsync(customCollection.Id, cancellationToken: CancellationToken.None);
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


    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class CustomCollectionMockClient : CustomCollectionClient, IMockTests
{
    public CustomCollectionMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListCustomCollectionsAsync(cancellationToken: CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListCustomCollectionsAsync(cancellationToken: CancellationToken.None));
    }
}
