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
    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class UsageChargeTests : IClassFixture<UsageChargeFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly BillingService _service;
    private readonly ITestOutputHelper _testOutputHelper;

    public UsageChargeTests(ITestOutputHelper testOutputHelper, UsageChargeFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new BillingService(Fixture.MyShopifyUrl, Fixture.AccessToken);
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