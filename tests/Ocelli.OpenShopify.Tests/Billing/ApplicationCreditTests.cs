namespace Ocelli.OpenShopify.Tests.Billing;

public class ApplicationCreditFixture : SharedFixture, IAsyncLifetime
{
    public List<ApplicationCredit> CreatedApplicationCredits = new();
    public IBillingService Service { get; set; }

    public ApplicationCreditFixture() =>
        Service = new BillingService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("ApplicationCreditTests")]
public class ApplicationCreditTests : IClassFixture<ApplicationCreditFixture>
{
    private const string ApplicationCreditPrefix = "Refund for Foo";
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ApplicationCreditMockClient _badRequestMockClient;
    private readonly ApplicationCreditMockClient _okEmptyMockClient;
    private readonly ApplicationCreditMockClient _okInvalidJsonMockClient;

    public ApplicationCreditTests(ApplicationCreditFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ApplicationCreditMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new ApplicationCreditMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new ApplicationCreditMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private ApplicationCreditFixture Fixture { get; }

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateApplicationCreditAsync_CanCreate()
    {
        var name = $@"{ApplicationCreditPrefix} {Fixture.BatchId}";
        var request = new CreateApplicationCreditRequest
        {
            ApplicationCredit = new CreateApplicationCredit
            {
                Test = true,
                Description = name,
                Amount = (decimal)0.01
            }
        };
        var created =
            await Fixture.Service.ApplicationCredit.CreateApplicationCreditAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(created, Fixture.MyShopifyUrl);

        Assert.Equal(name, created.Result.ApplicationCredit.Description);
        Assert.True(created.Result.ApplicationCredit.Id > 0);
        Debug.Assert(created.Result.ApplicationCredit != null, "created.ApplicationCredit != null");
        Fixture.CreatedApplicationCredits.Add(created.Result.ApplicationCredit);
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetApplicationCreditAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        Skip.If(Fixture.CreatedApplicationCredits.FirstOrDefault()?.Id == null);
        var applicationCredit = Fixture.CreatedApplicationCredits.First();

        var single =
            await Fixture.Service.ApplicationCredit.GetApplicationCreditAsync(applicationCredit.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(single, Fixture.MyShopifyUrl);

        var credit = single.Result.ApplicationCredit;
        Assert.NotNull(credit);
        Assert.True(credit.Id > 0);
        Assert.NotNull(credit.Description);
        Assert.True(credit is { Test: { } } && credit.Test.Value);
        Assert.True(credit.Amount > 0);
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListApplicationCreditsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var result =
            await Fixture.Service.ApplicationCredit.ListApplicationCreditsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(result, Fixture.MyShopifyUrl);

        Skip.If(!result.Result.ApplicationCredits.Any(), "WARN: No data returned. Could not test");

        foreach (var token in result.Result.ApplicationCredits)
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
}

internal class ApplicationCreditMockClient : ApplicationCreditClient, IMockTests
{
    public ApplicationCreditMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public async Task TestAllMethodsThatReturnData()
    {
        await Assert.ThrowsAsync<ApiException>(async () => await CreateApplicationCreditAsync(new CreateApplicationCreditRequest()));
        await Assert.ThrowsAsync<ApiException>(async () => await GetApplicationCreditAsync(0, "test"));
        await Assert.ThrowsAsync<ApiException>(async () => await ListApplicationCreditsAsync("test"));
    }
}
