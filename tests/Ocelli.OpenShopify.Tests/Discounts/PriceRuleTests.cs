using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Discounts;

public class PriceRuleFixture : SharedFixture, IAsyncLifetime
{
    public List<PriceRule> CreatedPriceRules = new();
    public Task InitializeAsync() => Task.CompletedTask;
    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class PriceRuleTests : IClassFixture<PriceRuleFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly DiscountsService _service;

    public PriceRuleTests(ITestOutputHelper testOutputHelper, PriceRuleFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new DiscountsService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private PriceRuleFixture Fixture { get; }

    #region Create
    [SkippableFact, TestPriority(1)]
    public async Task Creates_PriceRules()
    {
        var request = Fixture.CreatePriceRuleRequest;
        var response = await _service.PriceRule.CreatePriceRuleAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.PriceRule, Fixture.MyShopifyUrl);

        var created = response.Result.PriceRule;
        Assert.NotNull(created);
        Assert.Equal(request.PriceRule.Title, created.Title);
        Assert.Equal(request.PriceRule.ValueType, created.ValueType);
        Assert.Equal(request.PriceRule.TargetType, created.TargetType);
        Assert.Equal(request.PriceRule.TargetSelection, created.TargetSelection);
        Assert.Equal(request.PriceRule.AllocationMethod, created.AllocationMethod);
        Assert.Equal(request.PriceRule.Value, created.Value);
        Fixture.CreatedPriceRules.Add(created);
    }
    #endregion Create

    #region Read
    [SkippableFact, TestPriority(2)]
    public async Task Lists_PriceRules()
    {
        var response = await _service.PriceRule.ListPriceRulesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var priceRule in response.Result.PriceRules)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(priceRule, Fixture.MyShopifyUrl);
        }
        Assert.True(response.Result.PriceRules.Any());
        //Add any created items from previously failed tests to the created list for later deletion.
        Fixture.CreatedPriceRules.AddRange(response.Result.PriceRules.Where(fs =>
            !Fixture.CreatedPriceRules.Exists(e => e.Id == fs.Id) &&
            fs.Title!.StartsWith(Fixture.Company)));
    }

    [SkippableFact, TestPriority(2)]
    public async Task Gets_PriceRules()
    {
        Skip.If(!Fixture.CreatedPriceRules.Any(), "This should be run with the create test.");
        var createdPriceRule = Fixture.CreatedPriceRules.First();
        var response = await _service.PriceRule.GetPriceRuleAsync(createdPriceRule.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.PriceRule, Fixture.MyShopifyUrl);

        var priceRule = response.Result.PriceRule;
        Assert.NotNull(priceRule);
        Assert.Equal(createdPriceRule.ValueType, priceRule.ValueType);
        Assert.Equal(createdPriceRule.TargetType, priceRule.TargetType);
        Assert.Equal(createdPriceRule.TargetSelection, priceRule.TargetSelection);
        Assert.Equal(createdPriceRule.AllocationMethod, priceRule.AllocationMethod);
        Assert.Equal(createdPriceRule.Value, priceRule.Value);
    }
    #endregion Read

    #region Update
    [SkippableFact, TestPriority(3)]
    public async Task Updates_PriceRules()
    {

        Skip.If(!Fixture.CreatedPriceRules.Any(), "This should be run with the create test.");
        var createdPriceRule = Fixture.CreatedPriceRules.First();
        var request = new UpdatePriceRuleRequest()
        {
            PriceRule = new ()
            {
                Id = createdPriceRule.Id,
                Value = (decimal)-5.0,
            }
        };

        var response = await _service.PriceRule.UpdatePriceRuleAsync(createdPriceRule.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.PriceRule, Fixture.MyShopifyUrl);

        var updated = response.Result.PriceRule;
        Assert.Equal(request.PriceRule.Value, updated.Value);

        // Reset the id so the Fixture can properly delete this object.
        Fixture.CreatedPriceRules.Remove(createdPriceRule);
        Fixture.CreatedPriceRules.Add(response.Result.PriceRule);
    }
    #endregion Update

    #region Delete
    [SkippableFact, TestPriority(4)]
    public async Task Deletes_PriceRules()
    {
        Skip.If(Fixture.CreatedPriceRules.Count == 0, "WARN: No data returned. Could not test");
        var errors = new List<Exception>();
        foreach (var priceRule in Fixture.CreatedPriceRules)
        {
            try
            {
                await _service.PriceRule.DeletePriceRuleAsync(priceRule.Id);
            }
            catch (Exception ex)
            {
                errors.Add(ex);
            }
        }

        foreach (var error in errors)
        {
            _testOutputHelper.WriteLine(error.Message);
        }
        Assert.Empty(errors);
    }
    #endregion Delete
}
