namespace Ocelli.OpenShopify.Tests.Billing;

public class ApplicationChargeFixture : SharedFixture, IAsyncLifetime
{
    public List<ApplicationCharge> CreatedApplicationCharges = new();
    public IBillingService Service { get; set; }

    public ApplicationChargeFixture() =>
        Service = new BillingService(MyShopifyUrl, AccessToken);


    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("ApplicationChargeTests")]
public class ApplicationChargeTests : IClassFixture<ApplicationChargeFixture>
{
    private const string ApplicationChargePrefix = "Charge to Foo";
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

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateApplicationChargeAsync_CanCreate()
    {
        var name = $@"{ApplicationChargePrefix} {Fixture.BatchId}";
        var request = new CreateApplicationChargeRequest
        {
            ApplicationCharge = new CreateApplicationCharge
            {
                Test = true, Name = name, Status = ApplicationChargeStatus.Accepted, Price = 10
            }
        };
        var created =
            await Fixture.Service.ApplicationCharge.CreateApplicationChargeAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(created, Fixture.MyShopifyUrl);

        Assert.Equal(name, created.Result.ApplicationCharge.Name);
        Assert.True(created.Result.ApplicationCharge.Id > 0);
        Debug.Assert(created.Result.ApplicationCharge != null, "created.ApplicationCharge != null");
        Fixture.CreatedApplicationCharges.Add(created.Result.ApplicationCharge);
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetApplicationChargeAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        Skip.If(Fixture.CreatedApplicationCharges.FirstOrDefault()?.Id == null);
        var applicationCharge = Fixture.CreatedApplicationCharges.First();

        var single =
            await Fixture.Service.ApplicationCharge.GetApplicationChargeAsync(applicationCharge.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(single, Fixture.MyShopifyUrl);

        var charge = single.Result.ApplicationCharge;
        Assert.NotNull(charge);
        Assert.True(charge.Id > 0);
        Assert.NotNull(charge.Name);
        Assert.True(charge is { Test: { } } && charge.Test.Value);
        Assert.True(charge.Price > 0);
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListApplicationChargesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var result =
            await Fixture.Service.ApplicationCharge.ListApplicationChargesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(result, Fixture.MyShopifyUrl);

        Skip.If(!result.Result.ApplicationCharges.Any(), "WARN: No data returned. Could not test");

        foreach (var token in result.Result.ApplicationCharges)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(token, Fixture.MyShopifyUrl);
        }
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

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class ApplicationChargeMockClient : ApplicationChargeClient, IMockTests
{
    public ApplicationChargeMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnData()
    {
        await Assert.ThrowsAsync<ApiException>(async () => await CreateApplicationChargeAsync(new CreateApplicationChargeRequest()));
        await Assert.ThrowsAsync<ApiException>(async () => await GetApplicationChargeAsync(0, "test"));
        await Assert.ThrowsAsync<ApiException>(async () => await ListApplicationChargesAsync("test", 0));
    }
}
