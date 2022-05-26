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
    public DiscountsService Service;
    public List<PriceRule> CreatedPriceRules = new();

    public PriceRuleFixture()
    {
        Service = new DiscountsService(MyShopifyUrl, AccessToken);
    }
    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeletePriceRuleAsync_CanDelete();
    }
    
    public async Task DeletePriceRuleAsync_CanDelete()
    {
        foreach (var priceRule in CreatedPriceRules)
        {
            _ = await Service.PriceRule.DeletePriceRuleAsync(priceRule.Id);
        }
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class PriceRuleTests : IClassFixture<PriceRuleFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
        

    public PriceRuleTests(PriceRuleFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
                _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
            }

    private PriceRuleFixture Fixture { get; }

    #region Create
    [SkippableFact, TestPriority(1)]
    public async Task Creates_PriceRules()
    {
        var request = Fixture.CreatePriceRuleRequest();
        var response = await Fixture.Service.PriceRule.CreatePriceRuleAsync(request);
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
        var response = await Fixture.Service.PriceRule.ListPriceRulesAsync();
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
        var response = await Fixture.Service.PriceRule.GetPriceRuleAsync(createdPriceRule.Id);
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

        var response = await Fixture.Service.PriceRule.UpdatePriceRuleAsync(createdPriceRule.Id, request);
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

    [SkippableFact, TestPriority(99)]
    public async Task DeletePriceRuleAsync_CanDelete()
    {
        foreach (var priceRule in Fixture.CreatedPriceRules)
        {
            _ = await Fixture.Service.PriceRule.DeletePriceRuleAsync(priceRule.Id);
        }
        Fixture.CreatedPriceRules.Clear();
    }
    #endregion Delete
}
