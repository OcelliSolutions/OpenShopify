using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Discounts;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class DiscountCodeTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly DiscountsService _service;

    public DiscountCodeTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new DiscountsService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    #region Create
    //TODO: Revisit DiscountCode after PriceRule tests are complete
    /*
    [SkippableFact, TestPriority(1)]
    public async Task Creates_DiscountCode()
    {
        var request = new CreateDiscountCodeRequest()
        {
            DiscountCode = new()
            {
                Code = Fixture.BatchId
            }
        };
        var response = _service.DiscountCode.CreateDiscountCodeAsync()
        var code = "UNITTEST2";
        var created = await Fixture.Create(code);

        Assert.NotNull(created);
        Assert.Equal(code, created.Code);
        Assert.NotNull(created.UsageCount);
    }
    */
    #endregion Create

    #region Read
    /*
    [SkippableFact, TestPriority(2)]
    public async Task Lists_DiscountCodes()
    {
        var list = await Fixture.DiscountCodeService.ListAsync(Fixture.CreatedPriceRules.First().Id.Value, new PriceRuleDiscountCodeListFilter
        {
            Limit = 5
        });

        Assert.True(list.Items.Count() > 0);
    }

    [SkippableFact, TestPriority(2)]
    public async Task Gets_DiscountCode()
    {
        var obj = await Fixture.DiscountCodeService.GetAsync(Fixture.CreatedPriceRules.First().Id.Value, Fixture.CreatedDiscountCodes.First().Id.Value);

        Assert.NotNull(obj);
        Assert.Equal(Fixture.Code, obj.Code);
    }
    */
    #endregion Read

    #region Update
    /*
    [SkippableFact, TestPriority(3)]
    public async Task Updates_DiscountCode()
    {
        var newCode = "UNITTEST-AFTER-UPDATE";
        var created = await Fixture.Create("UNITTEST-BEFORE-UPDATE");
        created.Code = newCode;

        var updated = await Fixture.DiscountCodeService.UpdateAsync(created.PriceRuleId.Value, created);

        Assert.Equal(newCode, updated.Code);
    }
    */
    #endregion Update

    #region Delete

    //TODO: Create delete for discount code

    #endregion Delete
}
