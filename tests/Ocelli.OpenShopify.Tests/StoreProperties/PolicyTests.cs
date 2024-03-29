﻿namespace Ocelli.OpenShopify.Tests.StoreProperties;

public class PolicyFixture : SharedFixture, IAsyncLifetime
{
    public IStorePropertiesService Service;

    public PolicyFixture() =>
        Service = new StorePropertiesService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("PolicyTests")]
public class PolicyTests : IClassFixture<PolicyFixture>
{
    private PolicyFixture Fixture { get; }
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly PolicyMockClient _badRequestMockClient;
    private readonly PolicyMockClient _okEmptyMockClient;
    private readonly PolicyMockClient _okInvalidJsonMockClient;

    public PolicyTests(PolicyFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new PolicyMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new PolicyMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new PolicyMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListShopsPoliciesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Policy.ListShopsPoliciesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        Skip.If(!response.Result.Policies.Any(), "No available policies to test");
    }

    #endregion Read

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class PolicyMockClient : PolicyClient, IMockTests
{
    public PolicyMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListShopsPoliciesAsync(CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListShopsPoliciesAsync(CancellationToken.None));
    }
}
