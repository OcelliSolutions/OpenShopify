namespace Ocelli.OpenShopify.Tests.StoreProperties;

public class ProvinceFixture : SharedFixture, IAsyncLifetime
{
    public List<Country> Countries = new();
    public List<Province> Provinces = new();
    public IStorePropertiesService Service;

    public ProvinceFixture() =>
        Service = new StorePropertiesService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync() => await GetCountries();

    public Task DisposeAsync() => Task.CompletedTask;

    private async Task GetCountries()
    {
        var response = await Service.Country.ListCountriesAsync("id, name");
        Countries.AddRange(response.Result.Countries);
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("ProvinceTests")]
public class ProvinceTests : IClassFixture<ProvinceFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ProvinceMockClient _badRequestMockClient;
    private readonly ProvinceMockClient _okEmptyMockClient;
    private readonly ProvinceMockClient _okInvalidJsonMockClient;

    public ProvinceTests(ProvinceFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ProvinceMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new ProvinceMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new ProvinceMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private ProvinceFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateProvinceAsync_CanUpdate()
    {
        Skip.If(!Fixture.Provinces.Any(), "No provinces exist for store. Follow https://help.shopify.com/en/manual/shipping/setting-up-and-managing-your-shipping/setting-up-shipping-zones#add-a-shipping-zone to add a shipping zone manually first.");
        var originalProvince = Fixture.Provinces.First();
        var request = new UpdateProvinceRequest
        {
            Province = new UpdateProvince
            {
                CountryId = originalProvince.CountryId,
                Id = originalProvince.Id, Code = "SAMPLE"
            }
        };
        var response =
            await Fixture.Service.Province.UpdateProvinceAsync(request.Province.CountryId ?? 0,
                request.Province.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.Provinces.Remove(originalProvince);
        Fixture.Provinces.Add(response.Result.Province);
    }

    #endregion Update

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountProvincesAsync_CanGet()
    {
        var response = await Fixture.Service.Province.CountProvincesAsync(Fixture.Countries.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No provinces exist for store. Follow https://help.shopify.com/en/manual/shipping/setting-up-and-managing-your-shipping/setting-up-shipping-zones#add-a-shipping-zone to add a shipping zone manually first.");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListProvincesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Province.ListProvincesAsync(Fixture.Countries.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var province in response.Result.Provinces)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(province, Fixture.MyShopifyUrl);
        }

        Fixture.Provinces.AddRange(response.Result.Provinces);
        Skip.If(!response.Result.Provinces.Any(), "No provinces exist for store. Follow https://help.shopify.com/en/manual/shipping/setting-up-and-managing-your-shipping/setting-up-shipping-zones#add-a-shipping-zone to add a shipping zone manually first.");
    }

    [SkippableFact]
    [TestPriority(21)]
    public async Task GetProvinceAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.Provinces.Any(), "No provinces exist for store. Follow https://help.shopify.com/en/manual/shipping/setting-up-and-managing-your-shipping/setting-up-shipping-zones#add-a-shipping-zone to add a shipping zone manually first.");
        var province = Fixture.Provinces.First();
        var response = await Fixture.Service.Province.GetProvinceAsync(province.CountryId ?? 0, province.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Province, Fixture.MyShopifyUrl);
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

internal class ProvinceMockClient : ProvinceClient, IMockTests
{
    public ProvinceMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListProvincesAsync(0));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListProvincesAsync(0));
    }
}