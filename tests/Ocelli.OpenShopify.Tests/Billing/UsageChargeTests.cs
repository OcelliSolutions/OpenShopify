using System.Collections.Generic;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Billing;

public class UsageChargeFixture : SharedFixture, IAsyncLifetime
{
    public List<UsageCharge> CreatedUsageCharges = new();

    public UsageChargeFixture() =>
        Service = new BillingService(MyShopifyUrl, AccessToken);

    public BillingService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class UsageChargeTests : IClassFixture<UsageChargeFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public UsageChargeTests(UsageChargeFixture fixture, ITestOutputHelper testOutputHelper)
    {
                Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
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
}