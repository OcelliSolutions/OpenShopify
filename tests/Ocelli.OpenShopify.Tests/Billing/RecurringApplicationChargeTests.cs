using System.Collections.Generic;

namespace Ocelli.OpenShopify.Tests.Billing;

public class RecurringApplicationChargeFixture : SharedFixture, IAsyncLifetime
{
    public List<RecurringApplicationCharge> CreatedRecurringApplicationCharges = new();

    public RecurringApplicationChargeFixture() =>
        Service = new BillingService(MyShopifyUrl, AccessToken);

    public IBillingService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class RecurringApplicationChargeTests : IClassFixture<RecurringApplicationChargeFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly RecurringApplicationChargeMockClient _badRequestMockClient;
    private readonly RecurringApplicationChargeMockClient _okEmptyMockClient;
    private readonly RecurringApplicationChargeMockClient _okInvalidJsonMockClient;

    public RecurringApplicationChargeTests(RecurringApplicationChargeFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new RecurringApplicationChargeMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new RecurringApplicationChargeMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new RecurringApplicationChargeMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private RecurringApplicationChargeFixture Fixture { get; }
    
    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListRecurringApplicationChargesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.RecurringApplicationCharge.ListRecurringApplicationChargesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var recurringApplicationCharge in response.Result.RecurringApplicationCharges)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(recurringApplicationCharge, Fixture.MyShopifyUrl);
        }
        
        Skip.If(!response.Result.RecurringApplicationCharges.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetRecurringApplicationChargeAsync_AdditionalPropertiesAreEmpty()
    {
        var recurringApplicationChargeListResponse =
            await Fixture.Service.RecurringApplicationCharge.ListRecurringApplicationChargesAsync();

        Skip.If(!recurringApplicationChargeListResponse.Result.RecurringApplicationCharges.Any(), "No results returned. Unable to test");
        var response = await Fixture.Service.RecurringApplicationCharge.GetChargeAsync(recurringApplicationChargeListResponse
            .Result.RecurringApplicationCharges.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.RecurringApplicationCharge,
            Fixture.MyShopifyUrl);
    }

    #endregion Read


    [Fact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class RecurringApplicationChargeMockClient : RecurringApplicationChargeClient, IMockTests
{
    public RecurringApplicationChargeMockClient(HttpClient httpClient, RecurringApplicationChargeFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        throw new XunitException("Not implemented.");
    }
}
