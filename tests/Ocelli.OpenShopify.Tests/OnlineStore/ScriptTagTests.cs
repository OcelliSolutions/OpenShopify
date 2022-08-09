using System;

namespace Ocelli.OpenShopify.Tests.OnlineStore;

public class ScriptTagFixture : SharedFixture, IAsyncLifetime
{
    public List<ScriptTag> CreatedScriptTags = new();
    public IOnlineStoreService Service;

    public ScriptTagFixture() =>
        Service = new OnlineStoreService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteScriptTagAsync_CanDelete();
    }
    
    public async Task DeleteScriptTagAsync_CanDelete()
    {
        foreach (var scriptTag in CreatedScriptTags)
        {
            _ = await Service.ScriptTag.DeleteScriptTagAsync(scriptTag.Id, CancellationToken.None);
        }
        CreatedScriptTags.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("ScriptTagTests")]
public class ScriptTagTests : IClassFixture<ScriptTagFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ScriptTagMockClient _badRequestMockClient;
    private readonly ScriptTagMockClient _okEmptyMockClient;
    private readonly ScriptTagMockClient _okInvalidJsonMockClient;

    public ScriptTagTests(ScriptTagFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ScriptTagMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new ScriptTagMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new ScriptTagMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private ScriptTagFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateScriptTagAsync_CanUpdate()
    {
        var originalScriptTag = Fixture.CreatedScriptTags.First();
        var request = new UpdateScriptTagRequest
        {
            ScriptTag = new UpdateScriptTag
            {
                Id = originalScriptTag.Id,
                Src = Fixture.CallbackUrl
            }
        };
        var response = await Fixture.Service.ScriptTag.UpdateScriptTagAsync(request.ScriptTag.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedScriptTags.Remove(originalScriptTag);
        Fixture.CreatedScriptTags.Add(response.Result.ScriptTag);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateScriptTagAsync_CanCreate()
    {
        var request = new CreateScriptTagRequest
        {
            ScriptTag = new CreateScriptTag
            {
                Event = ScriptTagEvent.Onload,
                Src = "https://djavaskripped.org/fancy.js"
            }
        };
        var response = await Fixture.Service.ScriptTag.CreateScriptTagAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedScriptTags.Add(response.Result.ScriptTag);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateScriptTagAsync_IsUnprocessableEntityError()
    {
        var request = new CreateScriptTagRequest
        {
            ScriptTag = new CreateScriptTag()
        };
        await Assert.ThrowsAsync<ApiException<ScriptTagError>>(async () =>
            await Fixture.Service.ScriptTag.CreateScriptTagAsync(request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountScriptTagsAsync_CanGet()
    {
        var response = await Fixture.Service.ScriptTag.CountScriptTagsAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListScriptTagsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.ScriptTag.ListScriptTagsAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var scriptTag in response.Result.ScriptTags)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(scriptTag, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.ScriptTags.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetScriptTagAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedScriptTags.Any(), "Must be run with create test");
        var scriptTag = Fixture.CreatedScriptTags.First();
        var response = await Fixture.Service.ScriptTag.GetScriptTagAsync(scriptTag.Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.ScriptTag, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task DeleteScriptTagAsync_CanDelete()
    {
        await Fixture.DeleteScriptTagAsync_CanDelete();
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

internal class ScriptTagMockClient : ScriptTagClient, IMockTests
{
    public ScriptTagMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListScriptTagsAsync(createdAtMax: DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListScriptTagsAsync(updatedAtMax: DateTimeOffset.Now, updatedAtMin: DateTimeOffset.Now.AddMonths(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListScriptTagsAsync(fields:"id", limit:1, pageInfo:"", sinceId:0, src: "", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CountScriptTagsAsync(cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetScriptTagAsync(0, cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await UpdateScriptTagAsync(0, new UpdateScriptTagRequest(), CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await DeleteScriptTagAsync(0, CancellationToken.None));

        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListScriptTagsAsync(cancellationToken: CancellationToken.None));
    }
}
