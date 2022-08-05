namespace Ocelli.OpenShopify.Tests.Billing;

public class UsageChargeFixture : SharedFixture, IAsyncLifetime
{
    public List<UsageCharge> CreatedUsageCharges = new();
    public List<RecurringApplicationCharge> CreatedRecurringApplicationCharges = new();
    public IBillingService Service { get; set; }

    public UsageChargeFixture() =>
        Service = new BillingService(MyShopifyUrl, AccessToken);


    public async Task InitializeAsync()
    {
        var billingService = new BillingService(MyShopifyUrl, AccessToken);
        var response = await billingService.RecurringApplicationCharge.ListRecurringApplicationChargesAsync();
        var recurringApplicationCharges = response.Result.RecurringApplicationCharges;
        if(!recurringApplicationCharges.Any())
            recurringApplicationCharges.Add(await CreateRecurringApplicationCharge());

        //should also have terms, however, they are not always returned by the api
        CreatedRecurringApplicationCharges = recurringApplicationCharges.Where(rac => rac.CappedAmount > 0).ToList();
    }

    //anything that is created by this process cannot be deleted programatically.
    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("UsageChargeTests")]
public class UsageChargeTests : IClassFixture<UsageChargeFixture>
{
    private const string UsageChargePrefix = "Usage charge for Foo";
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

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateUsageChargeAsync_CanCreate()
    {
        Skip.If(!Fixture.CreatedRecurringApplicationCharges.Any(), "No valid recurring application charges to add usage to.");
        var name = $@"{UsageChargePrefix} {Fixture.BatchId}";
        var request = new CreateUsageChargeRequest
        {
            UsageCharge = new CreateUsageCharge
            {
                Description = name,
                Price = 10
            }
        };

        var created =
            await Fixture.Service.UsageCharge.CreateUsageChargeAsync(Fixture.CreatedRecurringApplicationCharges.First().Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(created, Fixture.MyShopifyUrl);

        Assert.Equal(name, created.Result.UsageCharge.Description);
        Assert.True(created.Result.UsageCharge.Id > 0);
        Debug.Assert(created.Result.UsageCharge != null, "created.UsageCharge != null");
        Fixture.CreatedUsageCharges.Add(created.Result.UsageCharge);
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListUsageChargesAsync_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedRecurringApplicationCharges.Any(), "No valid recurring application charges to add usage to.");
        var response = await Fixture.Service.UsageCharge.ListUsageChargesAsync(Fixture.CreatedRecurringApplicationCharges.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var usageCharge in response.Result.UsageCharges)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(usageCharge, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.UsageCharges.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetUsageChargeAsync_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedRecurringApplicationCharges.Any(), "No valid recurring application charges to add usage to.");
        var usageChargeListResponse =
            await Fixture.Service.UsageCharge.ListUsageChargesAsync(Fixture.CreatedRecurringApplicationCharges.First().Id);

        Skip.If(!usageChargeListResponse.Result.UsageCharges.Any(), "No results returned. Unable to test");
        var response = await Fixture.Service.UsageCharge.GetUsageChargeAsync(Fixture.CreatedRecurringApplicationCharges.First().Id, usageChargeListResponse
            .Result.UsageCharges.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.UsageCharge,
            Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete


    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class UsageChargeMockClient : UsageChargeClient, IMockTests
{
    public UsageChargeMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public async Task TestAllMethodsThatReturnData()
    {
        await Assert.ThrowsAsync<ApiException>(async () => await CreateUsageChargeAsync(0, new CreateUsageChargeRequest()));
        await Assert.ThrowsAsync<ApiException>(async () => await GetUsageChargeAsync(0, 0, "test"));
        await Assert.ThrowsAsync<ApiException>(async () => await ListUsageChargesAsync(0, "test"));
    }
}
