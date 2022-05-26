using System.Collections.Generic;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Billing;

public class ApplicationChargeFixture : SharedFixture, IAsyncLifetime
{
    public List<ApplicationCharge> CreatedApplicationCharges = new();

    public ApplicationChargeFixture() =>
        Service = new BillingService(MyShopifyUrl, AccessToken);

    public BillingService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ApplicationChargeTests : IClassFixture<ApplicationChargeFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    
    
    public ApplicationChargeTests(ApplicationChargeFixture fixture, ITestOutputHelper testOutputHelper)
    {
                Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
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
}