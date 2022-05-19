using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Billing;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ApplicationCreditTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly BillingService _service;
    private const string ApplicationCreditPrefix = "Refund for Foo";

    public ApplicationCreditTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new BillingService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    [Fact, TestPriority(10)]
    public async Task CreateApplicationCreditAsync_CanCreate()
    {
        var name = $@"{ApplicationCreditPrefix} {Fixture.BatchId}";
        var request = new ApplicationCreditItem()
        {
            ApplicationCredit = new ApplicationCredit()
            { 
                Test = true, Description = name, Amount = 0.01
            }
        };
        var created =
            await _service.ApplicationCredit.CreateApplicationCreditAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(created, Fixture.MyShopifyUrl);

        Assert.Equal(name, created.Result.ApplicationCredit?.Description);
        Assert.NotNull(created.Result.ApplicationCredit?.Id);
        Debug.Assert(created.Result.ApplicationCredit != null, "created.ApplicationCredit != null");
        Fixture.CreatedApplicationCredits.Add(created.Result.ApplicationCredit);
    }

    [SkippableFact, TestPriority(20)]
    public async Task RetrieveSingleApplicationCreditAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        Skip.If(Fixture.CreatedApplicationCredits.FirstOrDefault()?.Id == null);
        var applicationCredit = Fixture.CreatedApplicationCredits.First();

        var single =
            await _service.ApplicationCredit.RetrieveSingleApplicationCreditAsync(applicationCredit.Id ?? 0,
                cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(single, Fixture.MyShopifyUrl);

        var credit = single.Result.ApplicationCredit;
        Assert.NotNull(credit);
        Assert.True(credit?.Id.HasValue);
        Assert.NotNull(credit?.Description);
        Assert.True(credit is { Test: { } } && credit.Test.Value);
        Assert.True(credit?.Amount > 0);
    }

    [SkippableFact, TestPriority(20)]
    public async Task RetrieveAllApplicationCreditsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var result =
            await _service.ApplicationCredit.RetrieveAllApplicationCreditsAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(result, Fixture.MyShopifyUrl);
        
        Skip.If(result.Result.ApplicationCredits == null || !result.Result.ApplicationCredits.Any(),
            "WARN: No data returned. Could not test");

        foreach (var token in result.Result.ApplicationCredits!)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(token, Fixture.MyShopifyUrl);
        }
    }
}
