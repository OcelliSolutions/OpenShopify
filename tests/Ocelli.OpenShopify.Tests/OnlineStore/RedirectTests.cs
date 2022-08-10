namespace Ocelli.OpenShopify.Tests.OnlineStore;

public class RedirectFixture : SharedFixture, IAsyncLifetime
{
    public List<Redirect> CreatedRedirects = new();
    public IOnlineStoreService Service;

    public RedirectFixture() =>
        Service = new OnlineStoreService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteRedirectAsync_CanDelete();
    }

    public async Task DeleteRedirectAsync_CanDelete()
    {
        foreach (var redirect in CreatedRedirects)
        {
            _ = await Service.Redirect.DeleteRedirectAsync(redirect.Id, CancellationToken.None);
        }
        CreatedRedirects.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("RedirectTests")]
public class RedirectTests : IClassFixture<RedirectFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly RedirectMockClient _badRequestMockClient;
    private readonly RedirectMockClient _okEmptyMockClient;
    private readonly RedirectMockClient _okInvalidJsonMockClient;

    public RedirectTests(RedirectFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new RedirectMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new RedirectMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new RedirectMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private RedirectFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateRedirectAsync_CanUpdate()
    {
        var originalRedirect = Fixture.CreatedRedirects.First();
        var request = new UpdateRedirectRequest
        {
            Redirect = new UpdateRedirect
            {
                Id = originalRedirect.Id,
                Target = @"/pages/itunes_archive"
            }
        };
        var response = await Fixture.Service.Redirect.UpdateRedirectAsync(request.Redirect.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedRedirects.Remove(originalRedirect);
        Fixture.CreatedRedirects.Add(response.Result.Redirect);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateRedirectAsync_CanCreate()
    {
        var request = new CreateRedirectRequest
        {
            Redirect = new CreateRedirect
            {
                Path = $@"/ipod/{Fixture.BatchId}",
                Target = $@"/pages/itunes/{Fixture.BatchId}"
            }
        };
        var response = await Fixture.Service.Redirect.CreateRedirectAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedRedirects.Add(response.Result.Redirect);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateRedirectAsync_IsUnprocessableEntityError()
    {
        var request = new CreateRedirectRequest
        {
            Redirect = new CreateRedirect()
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.Redirect.CreateRedirectAsync(request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountRedirectsAsync_CanGet()
    {
        var response = await Fixture.Service.Redirect.CountUrlRedirectsAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListRedirectsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Redirect.ListUrlRedirectsAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var redirect in response.Result.Redirects)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(redirect, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Redirects.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetRedirectAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedRedirects.Any(), "Must be run with create test");
        var redirect = Fixture.CreatedRedirects.First();
        var response = await Fixture.Service.Redirect.GetRedirectAsync(redirect.Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Redirect, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task DeleteRedirectAsync_CanDelete()
    {
        await Fixture.DeleteRedirectAsync_CanDelete();
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

internal class RedirectMockClient : RedirectClient, IMockTests
{
    public RedirectMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListUrlRedirectsAsync(cancellationToken: CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListUrlRedirectsAsync(cancellationToken: CancellationToken.None));
    }
}
