namespace Ocelli.OpenShopify.Tests.Discounts;

public class DiscountCodeFixture : SharedFixture, IAsyncLifetime
{
    public List<DiscountCodeCreation> CreatedDiscountCodeCreations = new(); 
    public List<DiscountCode> CreatedDiscountCodes = new();
    public List<PriceRule> CreatedPriceRules = new();
    public DiscountCode DiscountCode = new();
    public IDiscountsService Service;

    public DiscountCodeFixture() =>
        Service = new DiscountsService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync() => CreatedPriceRules.Add(await CreatePriceRule());

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteDiscountCodeAsync_CanDelete();
        await DeletePriceRuleAsync_CanDelete();

        if (DiscountCode.Id > 0)
        {
            await Service.DiscountCode.DeleteDiscountCodeAsync(DiscountCode.Id ?? 0, DiscountCode.PriceRuleId ?? 0);
        }
    }

    public async Task DeletePriceRuleAsync_CanDelete()
    {
        foreach (var priceRule in CreatedPriceRules)
        {
            _ = await Service.PriceRule.DeletePriceRuleAsync(priceRule.Id);
        }
    }

    public async Task DeleteDiscountCodeAsync_CanDelete()
    {
        foreach (var discountCode in CreatedDiscountCodes)
        {
            if(discountCode.Id > 0 && discountCode.PriceRuleId > 0)
                _ = await Service.DiscountCode.DeleteDiscountCodeAsync(discountCode.Id ?? 0, discountCode.PriceRuleId ?? 0);
        }
        CreatedDiscountCodes.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("DiscountCodeTests")]
public class DiscountCodeTests : IClassFixture<DiscountCodeFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly DiscountCodeMockClient _badRequestMockClient;
    private readonly DiscountCodeMockClient _okEmptyMockClient;
    private readonly DiscountCodeMockClient _okInvalidJsonMockClient;

    public DiscountCodeTests(DiscountCodeFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new DiscountCodeMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new DiscountCodeMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new DiscountCodeMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }
    private DiscountCodeFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateDiscountCodeAsync_CanUpdate()
    {
        var priceRule = Fixture.CreatedPriceRules.First();
        Skip.If(!Fixture.CreatedDiscountCodes.Any(), "Please run this with the create test");
        var originalDiscountCode = Fixture.CreatedDiscountCodes.First();
        var request = new UpdateDiscountCodeRequest
        {
            DiscountCode = new UpdateDiscountCode
            {
                Id = originalDiscountCode.Id,
                PriceRuleId = originalDiscountCode.PriceRuleId,
                Code = $@"{originalDiscountCode.Code}_{Fixture.BatchId}"
            }
        };
        var response = await Fixture.Service.DiscountCode.UpdateDiscountCodeAsync(request.DiscountCode.Id ?? 0,
            priceRule.Id, request);
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
        var priceRule = Fixture.CreatedPriceRules.First();
        var request = Fixture.CreateDiscountCodeRequest(priceRule.Id);
        var response = await Fixture.Service.DiscountCode.CreateDiscountCodeAsync(priceRule.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedDiscountCodes.Add(response.Result.DiscountCode);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateDiscountCodeCreationJobAsync_CanCreate()
    {
        var priceRule = Fixture.CreatedPriceRules.First();
        var request = new CreateDiscountCodeBatchRequest
        {
            DiscountCodes = new List<CreateDiscountCode>
            {
                new() { Code = @"SUMMER0", PriceRuleId = priceRule.Id }, //this one can cause an error message
                new() { Code = $@"SUMMER1_{Fixture.BatchId}", PriceRuleId = priceRule.Id },
                new() { Code = $@"SUMMER2_{Fixture.BatchId}", PriceRuleId = priceRule.Id },
                new() { Code = $@"SUMMER3_{Fixture.BatchId}", PriceRuleId = priceRule.Id }
            }
        };
        var response =
            await Fixture.Service.DiscountCode.CreateDiscountCodeCreationJobAsync(priceRule.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        var batch = response.Result.DiscountCodeCreation;
        Fixture.CreatedDiscountCodeCreations.Add(batch);
        var list = await Fixture.Service.DiscountCode.ListDiscountCodesForDiscountCodeCreationJobAsync(batch.Id ?? 0,
            priceRule.Id);
        Fixture.CreatedDiscountCodes.AddRange(list.Result.DiscountCodes);
    }

    /*
    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateDiscountCodeAsync_IsUnprocessableEntityError()
    {
        var priceRule = Fixture.CreatedPriceRules.First();
        var request = new CreateDiscountCodeRequest
        {
            DiscountCode = new CreateDiscountCode()
        };
        await Assert.ThrowsAsync<ApiException<DiscountCodeError>>(async () =>
            await Fixture.Service.DiscountCode.CreateDiscountCodeAsync(priceRule.Id, request));
    }
    */

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
        var priceRule = Fixture.CreatedPriceRules.First();
        var response = await Fixture.Service.DiscountCode.ListDiscountCodesAsync(priceRule.Id);
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
        var priceRule = Fixture.CreatedPriceRules.First();
        Skip.If(!Fixture.CreatedDiscountCodeCreations.Any(), "Must be run with create test");
        var batch = Fixture.CreatedDiscountCodeCreations.First();
        var response =
            await Fixture.Service.DiscountCode.ListDiscountCodesForDiscountCodeCreationJobAsync(batch.Id ?? 0,
                priceRule.Id);
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
        var priceRule = Fixture.CreatedPriceRules.First();
        Skip.If(!Fixture.CreatedDiscountCodes.Any(), "Must be run with create test");
        var discountCode = Fixture.CreatedDiscountCodes.First();
        var response =
            await Fixture.Service.DiscountCode.GetDiscountCodeAsync(discountCode.Id ?? 0, priceRule.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.DiscountCode, Fixture.MyShopifyUrl);
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetDiscountCodeCreationJobAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        var priceRule = Fixture.CreatedPriceRules.First();
        Skip.If(!Fixture.CreatedDiscountCodeCreations.Any(), "Must be run with create test");
        var batch = Fixture.CreatedDiscountCodeCreations.First();
        var response =
            await Fixture.Service.DiscountCode.GetDiscountCodeCreationJobAsync(batch.Id ?? 0, priceRule.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.DiscountCodeCreation,
            Fixture.MyShopifyUrl);
    }
    
     //TODO: this endpoint is not documented to return a standard response. debug later.
    [SkippableFact, TestPriority(20)]
    public async Task GetLocationOfDiscountCodeAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedDiscountCodes.Any(), "Must be run with create test");
        var discountCode = Fixture.CreatedDiscountCodes.First();
        var response = await Fixture.Service.DiscountCode.GetLocationOfDiscountCodeAsync(discountCode.Code);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.DiscountCode,
            Fixture.MyShopifyUrl);
    }

    #endregion Read
    
    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class DiscountCodeMockClient : DiscountCodeClient, IMockTests
{
    public DiscountCodeMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public async Task TestAllMethodsThatReturnData()
    {
        await Assert.ThrowsAsync<ApiException>(async () => await ListDiscountCodesForDiscountCodeCreationJobAsync(0, 0));
        await Assert.ThrowsAsync<ApiException>(async () => await ListDiscountCodesAsync(0));
        await Assert.ThrowsAsync<ApiException>(async () => await GetDiscountCodeCreationJobAsync(0, 0));
        await Assert.ThrowsAsync<ApiException>(async () => await GetDiscountCodeAsync(0, 0));
        await Assert.ThrowsAsync<ApiException>(async () => await GetLocationOfDiscountCodeAsync("NA"));
        await Assert.ThrowsAsync<ApiException>(async () => await CreateDiscountCodeCreationJobAsync(0, new CreateDiscountCodeBatchRequest()));
        await Assert.ThrowsAsync<ApiException>(async () => await CreateDiscountCodeAsync(0, new CreateDiscountCodeRequest()));
        await Assert.ThrowsAsync<ApiException>(async () => await UpdateDiscountCodeAsync(0, 0, new UpdateDiscountCodeRequest()));
        await Assert.ThrowsAsync<ApiException>(async () => await DeleteDiscountCodeAsync(0, 0));
    }
}
