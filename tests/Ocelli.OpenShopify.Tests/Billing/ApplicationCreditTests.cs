using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Billing;

public class ApplicationCreditFixture : SharedFixture, IAsyncLifetime
{
    public List<ApplicationCredit> CreatedApplicationCredits = new();
    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ApplicationCreditTests : IClassFixture<ApplicationCreditFixture>
{
    private const string ApplicationCreditPrefix = "Refund for Foo";
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly BillingService _service;

    public ApplicationCreditTests(ITestOutputHelper testOutputHelper, ApplicationCreditFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new BillingService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private ApplicationCreditFixture Fixture { get; }

    #region Create

    [Fact(Skip = "Unknown required scope.")]
    [TestPriority(10)]
    public async Task CreateApplicationCreditAsync_CanCreate()
    {
        var name = $@"{ApplicationCreditPrefix} {Fixture.BatchId}";
        var request = new CreateApplicationCreditRequest
        {
            ApplicationCredit = new CreateApplicationCredit
            {
                Test = true, Description = name, Amount = (decimal)0.01
            }
        };
        var created =
            await _service.ApplicationCredit.CreateApplicationCreditAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(created, Fixture.MyShopifyUrl);

        Assert.Equal(name, created.Result.ApplicationCredit.Description);
        Assert.True(created.Result.ApplicationCredit.Id > 0);
        Debug.Assert(created.Result.ApplicationCredit != null, "created.ApplicationCredit != null");
        Fixture.CreatedApplicationCredits.Add(created.Result.ApplicationCredit);
    }

    #endregion Create

    #region Read

    [SkippableFact(Skip = "Unknown required scope.")]
    [TestPriority(20)]
    public async Task GetApplicationCreditAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        Skip.If(Fixture.CreatedApplicationCredits.FirstOrDefault()?.Id == null);
        var applicationCredit = Fixture.CreatedApplicationCredits.First();

        var single =
            await _service.ApplicationCredit.GetApplicationCreditAsync(applicationCredit.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(single, Fixture.MyShopifyUrl);

        var credit = single.Result.ApplicationCredit;
        Assert.NotNull(credit);
        Assert.True(credit.Id > 0);
        Assert.NotNull(credit.Description);
        Assert.True(credit is { Test: { } } && credit.Test.Value);
        Assert.True(credit.Amount > 0);
    }

    [SkippableFact(Skip = "Unknown required scope.")]
    [TestPriority(20)]
    public async Task GetAllApplicationCreditsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var result =
            await _service.ApplicationCredit.ListApplicationCreditsAsync();
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
}