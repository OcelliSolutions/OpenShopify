using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Billing;

public class RecurringApplicationChargeFixture : SharedFixture, IAsyncLifetime
{
    public List<RecurringApplicationCharge> CreatedRecurringApplicationCharges = new();

    public RecurringApplicationChargeFixture() =>
        Service = new BillingService(MyShopifyUrl, AccessToken);

    public BillingService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class RecurringApplicationChargeTests : IClassFixture<RecurringApplicationChargeFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    
    
    public RecurringApplicationChargeTests(RecurringApplicationChargeFixture fixture, ITestOutputHelper testOutputHelper)
    {
                Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
            }

    private RecurringApplicationChargeFixture Fixture { get; }
    
    #region Read

    [SkippableFact(Skip = "Unknown required scope.")]
    [TestPriority(20)]
    public async Task ListRecurringApplicationChargesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.RecurringApplicationCharge.ListRecurringApplicationChargesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var recurringApplicationCharge in response.Result.RecurringApplicationCharges)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(recurringApplicationCharge, Fixture.MyShopifyUrl);
        }

        var list = response.Result.RecurringApplicationCharges;
        Assert.True(list.Any());
    }

    [SkippableFact(Skip = "Unknown required scope.")]
    [TestPriority(20)]
    public async Task GetRecurringApplicationChargeAsync_AdditionalPropertiesAreEmpty()
    {
        var recurringApplicationChargeListResponse =
            await Fixture.Service.RecurringApplicationCharge.ListRecurringApplicationChargesAsync();
        var response = await Fixture.Service.RecurringApplicationCharge.GetChargeAsync(recurringApplicationChargeListResponse
            .Result.RecurringApplicationCharges.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.RecurringApplicationCharge,
            Fixture.MyShopifyUrl);
    }

    #endregion Read
}