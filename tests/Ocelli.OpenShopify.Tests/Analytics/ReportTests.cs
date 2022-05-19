using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Analytics;

[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ReportTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public ReportTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }
    /*
    [SkippableFact]
    public async Task RetrieveListOfReportsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var requiredPermissions = new List<AuthorizationScope> { AuthorizationScope.read_reports };
        Fixture.ValidateScopes(requiredPermissions);
        var service = new AnalyticsService(Fixture.MyShopifyUrl, Fixture.AccessToken);
        var result = await service.Report.RetrieveListOfReportsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(result, Fixture.MyShopifyUrl);

        if (result.Reports != null && !result.Reports.Any())
        {
            Skip.If(result.Reports == null || !result.Reports.Any(),
                "WARN: No data returned. Could not test");
            return;
        }

        Debug.Assert(result.Reports != null, "result.Reports != null");
        foreach (var token in result.Reports)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(token, Fixture.MyShopifyUrl);
        }

        Assert.NotEmpty(result.Reports);
    }
    */
}
