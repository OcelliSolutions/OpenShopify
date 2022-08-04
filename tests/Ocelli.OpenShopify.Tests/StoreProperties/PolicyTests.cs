using System.Collections.Generic;

namespace Ocelli.OpenShopify.Tests.StoreProperties;

public class PolicyFixture : SharedFixture, IAsyncLifetime
{
    public List<Policy> CreatedPolicies = new();
    public IStorePropertiesService Service;

    public PolicyFixture() =>
        Service = new StorePropertiesService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
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


    #region Create

    #endregion Create

    #region Read

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete

    [Fact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class PolicyMockClient : PolicyClient, IMockTests
{
    public PolicyMockClient(HttpClient httpClient, PolicyFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        throw new XunitException("Not implemented.");
    }
}
