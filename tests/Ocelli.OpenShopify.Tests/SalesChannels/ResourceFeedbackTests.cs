using System;

namespace Ocelli.OpenShopify.Tests.SalesChannels;

public class ResourceFeedbackFixture : SharedFixture, IAsyncLifetime
{
    public List<ResourceFeedback> CreatedResourceFeedbacks = new();
    public ISalesChannelsService Service;

    public ResourceFeedbackFixture() =>
        Service = new SalesChannelsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("ResourceFeedbackTests")]
public class ResourceFeedbackTests : IClassFixture<ResourceFeedbackFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ResourceFeedbackMockClient _badRequestMockClient;
    private readonly ResourceFeedbackMockClient _okEmptyMockClient;
    private readonly ResourceFeedbackMockClient _okInvalidJsonMockClient;

    public ResourceFeedbackTests(ResourceFeedbackFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ResourceFeedbackMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new ResourceFeedbackMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new ResourceFeedbackMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private ResourceFeedbackFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListResourceFeedbacksAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.ResourceFeedback.ListResourceFeedbacksAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var resourceFeedback in response.Result.ResourceFeedback)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(resourceFeedback, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.ResourceFeedback.Any(), "No results returned. Unable to test");
    }

    #endregion Read

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateResourceFeedbackAsync_CanCreate()
    {
        var request = new CreateResourceFeedbackRequest
        {
            ResourceFeedback = new CreateResourceFeedback
            {
                State = ResourceFeedbackState.RequiresAction,
                Messages = new List<string>
                {
                    "is not connected. Connect your account to use this sales channel."
                },
                FeedbackGeneratedAt = DateTimeOffset.Now
            }
        };
        var response = await Fixture.Service.ResourceFeedback.CreateResourceFeedbackAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedResourceFeedbacks.Add(response.Result.ResourceFeedback);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateResourceFeedbackAsync_IsUnprocessableEntityError()
    {
        var request = new CreateResourceFeedbackRequest
        {
            ResourceFeedback = new CreateResourceFeedback()
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.ResourceFeedback.CreateResourceFeedbackAsync(request));
    }

    #endregion Create


    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class ResourceFeedbackMockClient : ResourceFeedbackClient, IMockTests
{
    public ResourceFeedbackMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListResourceFeedbacksAsync(CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListResourceFeedbacksAsync(CancellationToken.None));
    }
}
