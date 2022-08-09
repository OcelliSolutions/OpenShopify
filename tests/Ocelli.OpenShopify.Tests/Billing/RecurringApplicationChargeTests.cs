using System;

namespace Ocelli.OpenShopify.Tests.Billing;

public class RecurringApplicationChargeFixture : SharedFixture, IAsyncLifetime
{
    public List<RecurringApplicationCharge> CreatedRecurringApplicationCharges = new();
    public IBillingService Service { get; set; }

    public RecurringApplicationChargeFixture() =>
        Service = new BillingService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await CancelRecurringApplicationChargeAsync_CanCancel();
    }

    public async Task CancelRecurringApplicationChargeAsync_CanCancel()
    {
        foreach (var recurringApplicationCharge in CreatedRecurringApplicationCharges)
        {
            if (recurringApplicationCharge.Status != RecurringApplicationChargeStatus.Active)
            {

                // reference (https://shopify.dev/apps/billing/rest/implement-billing-model#implement-the-recurringapplicationcharge-resource)
                // You will have to manually follow the link 
                Console.WriteLine(
                    $@"Unable to cancel charge ({recurringApplicationCharge.Id}), not in `active` status.");
                continue;
            }
            var request = new CancelRecurringApplicationChargeRequest();
            _ = await Service.RecurringApplicationCharge.CancelRecurringApplicationChargeAsync(recurringApplicationCharge.Id, request);
        }
        CreatedRecurringApplicationCharges.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("RecurringApplicationChargeTests")]
public class RecurringApplicationChargeTests : IClassFixture<RecurringApplicationChargeFixture>
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly RecurringApplicationChargeMockClient _badRequestMockClient;
    private readonly RecurringApplicationChargeMockClient _okEmptyMockClient;
    private readonly RecurringApplicationChargeMockClient _okInvalidJsonMockClient;

    public RecurringApplicationChargeTests(RecurringApplicationChargeFixture fixture, ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new RecurringApplicationChargeMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new RecurringApplicationChargeMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new RecurringApplicationChargeMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private RecurringApplicationChargeFixture Fixture { get; }

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateRecurringApplicationChargeAsync_CanCreate()
    {
        var request = Fixture.CreateRecurringApplicationChargeRequest();
        var created =
            await Fixture.Service.RecurringApplicationCharge.CreateRecurringApplicationChargeAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(created, Fixture.MyShopifyUrl);

        Assert.Equal(request.RecurringApplicationCharge.Name, created.Result.RecurringApplicationCharge.Name);
        Assert.True(created.Result.RecurringApplicationCharge.Id > 0);
        Debug.Assert(created.Result.RecurringApplicationCharge != null, "created.RecurringApplicationCharge != null");
        Fixture.CreatedRecurringApplicationCharges.Add(created.Result.RecurringApplicationCharge);
        _testOutputHelper.WriteLine($@"Follow this link to change the status of the recurring application charge in order to cancel: {created.Result.RecurringApplicationCharge.ConfirmationUrl}");
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListRecurringApplicationChargesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.RecurringApplicationCharge.ListRecurringApplicationChargesAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var recurringApplicationCharge in response.Result.RecurringApplicationCharges)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(recurringApplicationCharge, Fixture.MyShopifyUrl);

            if (string.IsNullOrWhiteSpace(recurringApplicationCharge.ConfirmationUrl))
                Fixture.CreatedRecurringApplicationCharges.Add(recurringApplicationCharge);
            else
                _testOutputHelper.WriteLine($@"Follow this link to change the status of the recurring application charge in order to cancel: {recurringApplicationCharge.ConfirmationUrl}");
        }
        
        Skip.If(!response.Result.RecurringApplicationCharges.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetRecurringApplicationChargeAsync_AdditionalPropertiesAreEmpty()
    {
        var recurringApplicationChargeListResponse =
            await Fixture.Service.RecurringApplicationCharge.ListRecurringApplicationChargesAsync(cancellationToken: CancellationToken.None);

        Skip.If(!recurringApplicationChargeListResponse.Result.RecurringApplicationCharges.Any(), "No results returned. Unable to test");
        var response = await Fixture.Service.RecurringApplicationCharge.GetRecurringApplicationChargeAsync(recurringApplicationChargeListResponse
            .Result.RecurringApplicationCharges.First().Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.RecurringApplicationCharge,
            Fixture.MyShopifyUrl);
        _testOutputHelper.WriteLine($@"Follow this link to change the status of the recurring application charge in order to cancel: {response.Result.RecurringApplicationCharge.ConfirmationUrl}");
    }

    #endregion Read

    #region Update
    [SkippableFact, TestPriority(3)]
    public async Task Updates_RecurringApplicationCharges()
    {

        Skip.If(!Fixture.CreatedRecurringApplicationCharges.Any(), "This should be run with the create test.");
        var createdRecurringApplicationCharge = Fixture.CreatedRecurringApplicationCharges.First();
        var request = 100;
        var response = await Fixture.Service.RecurringApplicationCharge.UpdateCappedAmountOfRecurringApplicationChargeAsync(createdRecurringApplicationCharge.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.RecurringApplicationCharge, Fixture.MyShopifyUrl);

        var updated = response.Result.RecurringApplicationCharge;
        Assert.Equal(request, updated.CappedAmount);

        // Reset the id so the Fixture can properly cancel this object.
        Fixture.CreatedRecurringApplicationCharges.Remove(createdRecurringApplicationCharge);
        Fixture.CreatedRecurringApplicationCharges.Add(response.Result.RecurringApplicationCharge);
        if (!string.IsNullOrWhiteSpace(updated.ConfirmationUrl))
            _testOutputHelper.WriteLine($@"Follow this link to change the status of the recurring application charge in order to cancel: {updated.ConfirmationUrl}");
    }
    #endregion Update

    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task CancelRecurringApplicationChargeAsync_CanCancel()
    {
        await Fixture.CancelRecurringApplicationChargeAsync_CanCancel();
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

internal class RecurringApplicationChargeMockClient : RecurringApplicationChargeClient, IMockTests
{
    public RecurringApplicationChargeMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListRecurringApplicationChargesAsync("test", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetRecurringApplicationChargeAsync(0, "test", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CreateRecurringApplicationChargeAsync(new CreateRecurringApplicationChargeRequest(), CancellationToken.None));
        
        ReadResponseAsString = false;
        await Assert.ThrowsAsync<ApiException>(async () => await ListRecurringApplicationChargesAsync("test", cancellationToken: CancellationToken.None));
    }
}
