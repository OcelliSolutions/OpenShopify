using System.Collections.Generic;

namespace Ocelli.OpenShopify.Tests.Billing;

public class ApplicationChargeFixture : SharedFixture, IAsyncLifetime
{
    public List<ApplicationCharge> CreatedApplicationCharges = new();

    public ApplicationChargeFixture() =>
        Service = new BillingService(MyShopifyUrl, AccessToken);

    public IBillingService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ApplicationChargeTests : IClassFixture<ApplicationChargeFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ApplicationChargeMockClient _badRequestMockClient;
    private readonly ApplicationChargeMockClient _okEmptyMockClient;
    private readonly ApplicationChargeMockClient _okInvalidJsonMockClient;

    public ApplicationChargeTests(ApplicationChargeFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ApplicationChargeMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new ApplicationChargeMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new ApplicationChargeMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private ApplicationChargeFixture Fixture { get; }

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

internal class ApplicationChargeMockClient : ApplicationChargeClient, IMockTests
{
    public ApplicationChargeMockClient(HttpClient httpClient, ApplicationChargeFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        throw new XunitException("Not implemented.");
    }
}
