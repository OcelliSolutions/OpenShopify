namespace Ocelli.OpenShopify.Tests.StoreProperties;

public class CurrencyFixture : SharedFixture, IAsyncLifetime
{
    public List<Currency> CreatedCurrencies = new();
    public IStorePropertiesService Service;

    public CurrencyFixture() =>
        Service = new StorePropertiesService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("CurrencyTests")]
public class CurrencyTests : IClassFixture<CurrencyFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CurrencyMockClient _badRequestMockClient;
    private readonly CurrencyMockClient _okEmptyMockClient;
    private readonly CurrencyMockClient _okInvalidJsonMockClient;

    public CurrencyTests(CurrencyFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new CurrencyMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new CurrencyMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new CurrencyMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private CurrencyFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListCurrenciesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Currency.ListCurrenciesEnabledOnShopAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var currency in response.Result.Currencies)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(currency, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Currencies.Any(), "No results returned. Currencies must be added manually. https://help.shopify.com/en/manual/payments/shopify-payments/multi-currency/setup");
    }

    #endregion Read

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class CurrencyMockClient : CurrencyClient, IMockTests
{
    public CurrencyMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        //TODO: Validate that all methods are tested in this first section
        await Assert.ThrowsAsync<ApiException>(async () => await ListCurrenciesEnabledOnShopAsync(CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListCurrenciesEnabledOnShopAsync(CancellationToken.None));
    }
}
