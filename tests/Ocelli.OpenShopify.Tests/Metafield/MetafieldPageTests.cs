using System;

namespace Ocelli.OpenShopify.Tests.Metafield;

public class MetafieldPageFixture : SharedFixture, IAsyncLifetime
{
    public List<Page> CreatedPages = new();
    public List<OpenShopify.Metafield> CreatedMetafields = new();
    public IMetafieldService Service;

    public MetafieldPageFixture() =>
        Service = new MetafieldService(MyShopifyUrl, AccessToken);


    public async Task InitializeAsync()
    {
        var onlineStoreService = new OnlineStoreService(MyShopifyUrl, AccessToken);
        var pageRequest = this.CreatePageRequest();
        var page = await onlineStoreService.Page.CreatePageAsync(pageRequest, CancellationToken.None);
        CreatedPages.Add(page.Result.Page);
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteMetafieldForPageAsync_CanDelete();
        await DeletePageAsync_CanDelete();
    }

    public async Task DeleteMetafieldForPageAsync_CanDelete()
    {
        foreach (var metafield in CreatedMetafields)
        {
            _ = await Service.Metafield.DeleteMetafieldForPageAsync(metafield.OwnerId ?? 0, metafield.Id, CancellationToken.None);
        }
        CreatedMetafields.Clear();
    }
    public async Task DeletePageAsync_CanDelete()
    {
        var onlineStoreService = new OnlineStoreService(MyShopifyUrl, AccessToken);
        foreach (var page in CreatedPages)
        {
            _ = await onlineStoreService.Page.DeletePageAsync(page.Id, CancellationToken.None);
        }
        CreatedPages.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("MetafieldPageTests")]
public class MetafieldPageTests : IClassFixture<MetafieldPageFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly MetafieldPageMockClient _badRequestMockClient;
    private readonly MetafieldPageMockClient _okEmptyMockClient;
    private readonly MetafieldPageMockClient _okInvalidJsonMockClient;

    public MetafieldPageTests(MetafieldPageFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new MetafieldPageMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new MetafieldPageMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new MetafieldPageMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private MetafieldPageFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateMetafieldForPageAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedMetafields.Any(), "Please run with the create tests");
        var originalMetafield = Fixture.CreatedMetafields.First();
        var request = new UpdateMetafieldForPageRequest
        {
            Metafield = new ()
            {
                Id = originalMetafield.Id,
                Value = "something new",
                Type = MetafieldType.SingleLineTextField
            }
        };
        var response = await Fixture.Service.Metafield.UpdateMetafieldForPageAsync(originalMetafield.OwnerId ?? 0, originalMetafield.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMetafields.Remove(originalMetafield);
        Fixture.CreatedMetafields.Add(response.Result.Metafield);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMetafieldForPageAsync_CanCreate()
    {
        var page = Fixture.CreatedPages.First();
        var request = new CreateMetafieldForPageRequest()
        {
            Metafield = Fixture.CreateMetafieldRequest().Metafield
        };
        var response = await Fixture.Service.Metafield.CreateMetafieldForPageAsync(page.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMetafields.Add(response.Result.Metafield);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMetafieldForPageAsync_IsUnprocessableEntityError()
    {
        var page = Fixture.CreatedPages.First();
        var request = new CreateMetafieldForPageRequest
        {
            Metafield = new CreateMetafield()
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.Metafield.CreateMetafieldForPageAsync(page.Id, request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountMetafieldPagesAsync_CanGet()
    {
        var response = await Fixture.Service.Metafield.CountMetafieldsAttachedToPageAsync(Fixture.CreatedPages.First().Id, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListMetafieldPagesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Metafield.ListMetafieldsAttachedToPageAsync(Fixture.CreatedPages.First().Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var metafield in response.Result.Metafields)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(metafield, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Metafields.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetMetafieldForPageAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedMetafields.Any(), "Must be run with create test");
        var metafield = Fixture.CreatedMetafields.First();
        var response = await Fixture.Service.Metafield.GetMetafieldAttachedToPageAsync(metafield.Id, metafield.OwnerId ?? 0, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Metafield, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteMetafieldForPageAsync_CanDelete()
    {
        await Fixture.DeleteMetafieldForPageAsync_CanDelete();
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

internal class MetafieldPageMockClient : MetafieldClient, IMockTests
{
    public MetafieldPageMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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

        #region Page

        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToPageAsync(pageId: 0, createdAtMax: DateTimeOffset.Now, createdAtMin: DateTimeOffset.Now.AddDays(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToPageAsync(pageId: 0, updatedAtMax: DateTimeOffset.Now, updatedAtMin: DateTimeOffset.Now.AddDays(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToPageAsync(pageId: 0, fields: "id", limit: 1, pageInfo: "", key: "", @namespace: "", type: MetafieldType.Boolean, sinceId: 0, cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CountMetafieldsAttachedToPageAsync(pageId: 0, CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetMetafieldAttachedToPageAsync(0, 0, "id", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CreateMetafieldForPageAsync(0, new CreateMetafieldForPageRequest(), CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await UpdateMetafieldForPageAsync(0, 0, new UpdateMetafieldForPageRequest(), CancellationToken.None));

        #endregion Page
        
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToPageAsync(0, cancellationToken: CancellationToken.None));
    }
}
