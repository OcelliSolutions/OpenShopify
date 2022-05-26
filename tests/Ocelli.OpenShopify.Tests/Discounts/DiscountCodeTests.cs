using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Discounts;

public class DiscountCodeFixture : SharedFixture, IAsyncLifetime
{
    public List<DiscountCodeCreation> CreatedDiscountCodeCreations = new();
    public List<DiscountCode> CreatedDiscountCodes = new();
    public PriceRule PriceRule = new();
    public DiscountsService Service;

    public DiscountCodeFixture() =>
        Service = new DiscountsService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync() => await CreatePriceRule();

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteDiscountCodeAsync_CanDelete();

        if (PriceRule.Id > 0)
        {
            await Service.PriceRule.DeletePriceRuleAsync(PriceRule.Id);
        }
    }

    public async Task DeleteDiscountCodeAsync_CanDelete()
    {
        foreach (var discountCode in CreatedDiscountCodes)
        {
            _ = await Service.DiscountCode.DeleteDiscountCodeAsync(discountCode.Id, PriceRule.Id);
        }
        CreatedDiscountCodes.Clear();
        CreatedDiscountCodeCreations.Clear();
    }

    public async Task CreatePriceRule()
    {
        var request = CreatePriceRuleRequest();
        request.PriceRule.Title = $@"{Company} DiscountCode ({BatchId})";
        var response = await Service.PriceRule.CreatePriceRuleAsync(request);
        PriceRule = response.Result.PriceRule;
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class DiscountCodeTests : IClassFixture<DiscountCodeFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public DiscountCodeTests(DiscountCodeFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private DiscountCodeFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateDiscountCodeAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedDiscountCodes.Any(), "Please run this with the create test");
        var originalDiscountCode = Fixture.CreatedDiscountCodes.First();
        var request = new UpdateDiscountCodeRequest
        {
            DiscountCode = new UpdateDiscountCode
            {
                Id = originalDiscountCode.Id,
                PriceRuleId = originalDiscountCode.PriceRuleId,
                Code = "WINTERSALE20OFF"
            }
        };
        var response = await Fixture.Service.DiscountCode.UpdateDiscountCodeAsync(request.DiscountCode.Id,
            Fixture.PriceRule.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedDiscountCodes.Remove(originalDiscountCode);
        Fixture.CreatedDiscountCodes.Add(response.Result.DiscountCode);
    }

    #endregion Update

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteDiscountCodeAsync_CanDelete()
    {
        await Fixture.DeleteDiscountCodeAsync_CanDelete();
    }

    #endregion Delete

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateDiscountCodeAsync_CanCreate()
    {
        var request = new CreateDiscountCodeRequest
        {
            DiscountCode = new CreateDiscountCode
            {
                PriceRuleId = Fixture.PriceRule.Id,
                Code = $@"SUMMERSALE10OFF_{Fixture.BatchId}"
            }
        };
        var response = await Fixture.Service.DiscountCode.CreateDiscountCodeAsync(Fixture.PriceRule.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedDiscountCodes.Add(response.Result.DiscountCode);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateDiscountCodeCreationJobAsync_CanCreate()
    {
        var request = new CreateDiscountCodeBatchRequest
        {
            DiscountCodes = new List<CreateDiscountCode>
            {
                new() { Code = @"SUMMER0", PriceRuleId = Fixture.PriceRule.Id }, //this one can cause an error message
                new() { Code = $@"SUMMER1_{Fixture.BatchId}", PriceRuleId = Fixture.PriceRule.Id },
                new() { Code = $@"SUMMER2_{Fixture.BatchId}", PriceRuleId = Fixture.PriceRule.Id },
                new() { Code = $@"SUMMER3_{Fixture.BatchId}", PriceRuleId = Fixture.PriceRule.Id }
            }
        };
        var response =
            await Fixture.Service.DiscountCode.CreateDiscountCodeCreationJobAsync(Fixture.PriceRule.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        var batch = response.Result.DiscountCodeCreation;
        Fixture.CreatedDiscountCodeCreations.Add(batch);
        var list = await Fixture.Service.DiscountCode.ListDiscountCodesForDiscountCodeCreationJobAsync(batch.Id,
            Fixture.PriceRule.Id);
        Fixture.CreatedDiscountCodes.AddRange(list.Result.DiscountCodes);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateDiscountCodeAsync_IsUnprocessableEntityError()
    {
        var request = new CreateDiscountCodeRequest
        {
            DiscountCode = new CreateDiscountCode()
        };
        await Assert.ThrowsAsync<ApiException<DiscountCodeError>>(async () =>
            await Fixture.Service.DiscountCode.CreateDiscountCodeAsync(Fixture.PriceRule.Id, request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountDiscountCodesAsync_CanGet()
    {
        var response = await Fixture.Service.DiscountCode.CountDiscountCodesForShopAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListDiscountCodesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.DiscountCode.ListDiscountCodesAsync(Fixture.PriceRule.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var discountCode in response.Result.DiscountCodes)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(discountCode, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.DiscountCodes.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListDiscountCodesForDiscountCodeCreationJobAsync_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedDiscountCodeCreations.Any(), "Must be run with create test");
        var batch = Fixture.CreatedDiscountCodeCreations.First();
        var response =
            await Fixture.Service.DiscountCode.ListDiscountCodesForDiscountCodeCreationJobAsync(batch.Id,
                Fixture.PriceRule.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var discountCode in response.Result.DiscountCodes)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(discountCode, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.DiscountCodes.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetDiscountCodeAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedDiscountCodes.Any(), "Must be run with create test");
        var discountCode = Fixture.CreatedDiscountCodes.First();
        var response =
            await Fixture.Service.DiscountCode.GetDiscountCodeAsync(discountCode.Id, Fixture.PriceRule.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.DiscountCode, Fixture.MyShopifyUrl);
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetDiscountCodeCreationJobAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedDiscountCodeCreations.Any(), "Must be run with create test");
        var batch = Fixture.CreatedDiscountCodeCreations.First();
        var response =
            await Fixture.Service.DiscountCode.GetDiscountCodeCreationJobAsync(batch.Id, Fixture.PriceRule.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.DiscountCodeCreation,
            Fixture.MyShopifyUrl);
    }
    /*
     //TODO: this endpoint is not documented to return a standard response. debug later.
    [SkippableFact, TestPriority(20)]
    public async Task GetLocationOfDiscountCodeAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedDiscountCodes.Any(), "Must be run with create test");
        var discountCode = Fixture.CreatedDiscountCodes.First();
        var response = await Fixture.Service.DiscountCode.GetLocationOfDiscountCodeAsync(discountCode.Code);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.DiscountCodeCreation, Fixture.MyShopifyUrl);
    }
    */

    #endregion Read
}