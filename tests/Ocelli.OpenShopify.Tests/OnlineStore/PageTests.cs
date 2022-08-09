using System;

namespace Ocelli.OpenShopify.Tests.OnlineStore;

public class PageFixture : SharedFixture, IAsyncLifetime
{
    public List<Page> CreatedPages = new();
    public IOnlineStoreService Service;

    public PageFixture() =>
        Service = new OnlineStoreService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeletePageAsync_CanDelete();
    }

    public async Task DeletePageAsync_CanDelete()
    {
        foreach (var page in CreatedPages)
        {
            _ = await Service.Page.DeletePageAsync(page.Id, CancellationToken.None);
        }
        CreatedPages.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("PageTests")]
public class PageTests : IClassFixture<PageFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly PageMockClient _badRequestMockClient;
    private readonly PageMockClient _okEmptyMockClient;
    private readonly PageMockClient _okInvalidJsonMockClient;

    public PageTests(PageFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new PageMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new PageMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new PageMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private PageFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdatePageAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedPages.Any(), "Must be run with create test");
        var originalPage = Fixture.CreatedPages.First();
        var request = new UpdatePageRequest
        {
            Page = new UpdatePage
            {
                Id = originalPage.Id,
                Title = Fixture.UniqueString()
            }
        };
        var response = await Fixture.Service.Page.UpdatePageAsync(request.Page.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedPages.Remove(originalPage);
        Fixture.CreatedPages.Add(response.Result.Page);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreatePageAsync_CanCreate()
    {
        var request = Fixture.CreatePageRequest();
        var response = await Fixture.Service.Page.CreatePageAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedPages.Add(response.Result.Page);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreatePageAsync_IsUnprocessableEntityError()
    {
        var request = new CreatePageRequest
        {
            Page = new CreatePage()
        };
        await Assert.ThrowsAsync<ApiException<PageError>>(async () =>
            await Fixture.Service.Page.CreatePageAsync(request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountPagesAsync_CanGet()
    {
        var response = await Fixture.Service.Page.GetPageCountAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListPagesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Page.ListPagesAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var page in response.Result.Pages)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(page, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Pages.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetPageAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedPages.Any(), "Must be run with create test");
        var page = Fixture.CreatedPages.First();
        var response = await Fixture.Service.Page.GetPageAsync(page.Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Page, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete


    [SkippableFact, TestPriority(99)]
    public async Task DeletePageAsync_CanDelete()
    {
        await Fixture.DeletePageAsync_CanDelete();
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

internal class PageMockClient : PageClient, IMockTests
{
    public PageMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListPagesAsync(createdAtMax: DateTimeOffset.Now, createdAtMin: DateTimeOffset.Now.AddMonths(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListPagesAsync(updatedAtMax: DateTimeOffset.Now, updatedAtMin: DateTimeOffset.Now.AddMonths(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListPagesAsync(publishedAtMax: DateTimeOffset.Now, publishedAtMin: DateTimeOffset.Now.AddMonths(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListPagesAsync(fields: "id,name", limit:1, handle:"NA", pageInfo:"NA", sinceId: 0, publishedStatus: PagePublishStatus.Any, title: "NA", cancellationToken: CancellationToken.None));

        await Assert.ThrowsAsync<ApiException>(async () => await GetPageCountAsync(createdAtMax: DateTimeOffset.Now, createdAtMin: DateTimeOffset.Now.AddMonths(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetPageCountAsync(updatedAtMax: DateTimeOffset.Now, updatedAtMin: DateTimeOffset.Now.AddMonths(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetPageCountAsync(publishedAtMax: DateTimeOffset.Now, publishedAtMin: DateTimeOffset.Now.AddMonths(-1), cancellationToken: CancellationToken.None));

        await Assert.ThrowsAsync<ApiException>(async () => await GetPageAsync(0, "id", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CreatePageAsync(new CreatePageRequest(), CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await UpdatePageAsync(0, new UpdatePageRequest(), CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await DeletePageAsync(0, CancellationToken.None));

        ReadResponseAsString = false;
        await Assert.ThrowsAsync<ApiException>(async () => await ListPagesAsync(createdAtMax: DateTimeOffset.Now, createdAtMin: DateTimeOffset.Now.AddMonths(-1), cancellationToken: CancellationToken.None));
    }
}
