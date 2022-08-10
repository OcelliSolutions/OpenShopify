namespace Ocelli.OpenShopify.Tests.Products;

public class SmartCollectionFixture : SharedFixture, IAsyncLifetime
{
    public List<SmartCollection> CreatedSmartCollections = new();
    public IProductsService Service;

    public SmartCollectionFixture() =>
        Service = new ProductsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteSmartCollectionAsync_CanDelete();

    public async Task DeleteSmartCollectionAsync_CanDelete()
    {
        foreach (var smartCollection in CreatedSmartCollections)
        {
            _ = await Service.SmartCollection.DeleteSmartCollectionAsync(smartCollection.Id, CancellationToken.None);
        }
        CreatedSmartCollections.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("SmartCollectionTests")]
public class SmartCollectionTests : IClassFixture<SmartCollectionFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly SmartCollectionMockClient _badRequestMockClient;
    private readonly SmartCollectionMockClient _okEmptyMockClient;
    private readonly SmartCollectionMockClient _okInvalidJsonMockClient;

    public SmartCollectionTests(SmartCollectionFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new SmartCollectionMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new SmartCollectionMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new SmartCollectionMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private SmartCollectionFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateSmartCollectionAsync_CanUpdate()
    {
        var originalSmartCollection = Fixture.CreatedSmartCollections.First();
        var request = new UpdateSmartCollectionRequest
        {
            SmartCollection = new UpdateSmartCollection
            {
                Id = originalSmartCollection.Id, BodyHtml = @"<p>5000 songs in your pocket</p>"
            }
        };
        var response =
            await Fixture.Service.SmartCollection.UpdateSmartCollectionAsync(request.SmartCollection.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedSmartCollections.Remove(originalSmartCollection);
        Fixture.CreatedSmartCollections.Add(response.Result.SmartCollection);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateSmartCollectionAsync_CanCreate()
    {
        var request = new CreateSmartCollectionRequest
        {
            SmartCollection = new CreateSmartCollection
            {
                Title = "IPods",
                Rules = new List<SmartCollectionRules>
                {
                    new() { Column = RuleColumn.Title, Condition = "IPod", Relation = RuleRelation.StartsWith }
                }
            }
        };
        var response = await Fixture.Service.SmartCollection.CreateSmartCollectionAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedSmartCollections.Add(response.Result.SmartCollection);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateSmartCollectionAsync_IsUnprocessableEntityError()
    {
        var request = new CreateSmartCollectionRequest
        {
            SmartCollection = new CreateSmartCollection()
            {
                Title = Fixture.UniqueString()
            }
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.SmartCollection.CreateSmartCollectionAsync(request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountSmartCollectionsAsync_CanGet()
    {
        var response = await Fixture.Service.SmartCollection.CountSmartCollectionsAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListSmartCollectionsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.SmartCollection.ListSmartCollectionsAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var smartCollection in response.Result.SmartCollections)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(smartCollection, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.SmartCollections.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetSmartCollectionAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedSmartCollections.Any(), "Must be run with create test");
        var smartCollection = Fixture.CreatedSmartCollections.First();
        var response = await Fixture.Service.SmartCollection.GetSmartCollectionAsync(smartCollection.Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.SmartCollection, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task DeleteSmartCollectionAsync_CanDelete()
    {
        await Fixture.DeleteSmartCollectionAsync_CanDelete();
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

internal class SmartCollectionMockClient : SmartCollectionClient, IMockTests
{
    public SmartCollectionMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListSmartCollectionsAsync(cancellationToken: CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListSmartCollectionsAsync(cancellationToken: CancellationToken.None));
    }
}
