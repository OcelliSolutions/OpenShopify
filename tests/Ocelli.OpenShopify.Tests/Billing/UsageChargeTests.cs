using System.Collections.Generic;

namespace Ocelli.OpenShopify.Tests.Billing;

public class UsageChargeFixture : SharedFixture, IAsyncLifetime
{
    public List<UsageCharge> CreatedUsageCharges = new();

    public UsageChargeFixture() =>
        Service = new BillingService(MyShopifyUrl, AccessToken);

    public IBillingService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class UsageChargeTests : IClassFixture<UsageChargeFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly UsageChargeMockClient _badRequestMockClient;
    private readonly UsageChargeMockClient _okEmptyMockClient;
    private readonly UsageChargeMockClient _okInvalidJsonMockClient;

    public UsageChargeTests(UsageChargeFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new UsageChargeMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new UsageChargeMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new UsageChargeMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private UsageChargeFixture Fixture { get; }

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

internal class UsageChargeMockClient : UsageChargeClient, IMockTests
{
    public UsageChargeMockClient(HttpClient httpClient, UsageChargeFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        throw new XunitException("Not implemented.");
    }
}
