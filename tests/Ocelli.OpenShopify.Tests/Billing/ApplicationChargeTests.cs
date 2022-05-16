using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Billing;

[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ApplicationChargeTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public ApplicationChargeTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    [SkippableFact]
    public async void RetrieveListOfApplicationChargesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var requiredPermissions = new List<AuthorizationScope> { AuthorizationScope.read_reports };
        foreach (var apiKey in Fixture.ApiKeys)
        {
            //apiKey.ValidateScopes(requiredPermissions);
            var service = new BillingService(apiKey.MyShopifyUrl, apiKey.AccessToken);
            var result = await service.ApplicationCharge.RetrieveListOfApplicationChargesAsync();
            _additionalPropertiesHelper.CheckAdditionalProperties(result, apiKey.MyShopifyUrl);

            if (result.ApplicationCharges != null && !result.ApplicationCharges.Any())
            {
                Skip.If(result.ApplicationCharges == null || !result.ApplicationCharges.Any(),
                    "WARN: No data returned. Could not test");
                return;
            }

            Debug.Assert(result.ApplicationCharges != null, "result.ApplicationCharges != null");
            foreach (var token in result.ApplicationCharges)
            {
                _additionalPropertiesHelper.CheckAdditionalProperties(token, apiKey.MyShopifyUrl);
            }

            Assert.NotEmpty(result.ApplicationCharges);
        }
    }
}
