﻿namespace Ocelli.OpenShopify.Tests.StoreProperties;

public class CountryFixture : SharedFixture, IAsyncLifetime
{
    public IStorePropertiesService Service;
    public List<Country> CreatedCountries = new();

    public CountryFixture()
    {
        Service = new StorePropertiesService(MyShopifyUrl, AccessToken);
    }

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteCountryAsync_CanDelete();

    [SkippableFact, TestPriority(99)]
    public async Task DeleteCountryAsync_CanDelete()
    {
        foreach (var country in CreatedCountries)
        {
            _ = await Service.Country.DeleteCountryAsync(country.Id, CancellationToken.None);
        }
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("CountryTests")]
public class CountryTests : IClassFixture<CountryFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CountryMockClient _badRequestMockClient;
    private readonly CountryMockClient _okEmptyMockClient;
    private readonly CountryMockClient _okInvalidJsonMockClient;

    public CountryTests(CountryFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new CountryMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new CountryMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new CountryMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private CountryFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateCountryAsync_CanCreate()
    {
        var request = new CreateCountryRequest()
        {
            Country = new()
            {
                Code = "GB"
            }
        };
        var response = await Fixture.Service.Country.CreateCountryAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCountries.Add(response.Result.Country);
    }

    [SkippableFact, TestPriority(10)]
    public async Task CreateCountryAsync_IsUnprocessableEntityError()
    {
        var request = new CreateCountryRequest()
        {
            Country = new()
        };
        await Assert.ThrowsAsync<ApiException>(async () => await Fixture.Service.Country.CreateCountryAsync(request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountCountriesAsync_CanGet()
    {
        var response = await Fixture.Service.Country.CountCountriesAsync(CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListCountriesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Country.ListCountriesAsync(cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var country in response.Result.Countries)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(country, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.Countries.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetCountryAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCountries.Any(), "Must be run with create test");
        var country = Fixture.CreatedCountries.First();
        var response = await Fixture.Service.Country.GetCountyAsync(country.Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Country, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateCountryAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedCountries.Any(), "Must be run with create test");
        var originalCountry = Fixture.CreatedCountries.First();
        var request = new UpdateCountryRequest()
        {
            Country = new()
            {
                Id = originalCountry.Id,
                Tax = (decimal)0.05
            }
        };
        var response = await Fixture.Service.Country.UpdateCountryAsync(request.Country.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCountries.Remove(originalCountry);
        Fixture.CreatedCountries.Add(response.Result.Country);
    }

    #endregion Update

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class CountryMockClient : CountryClient, IMockTests
{
    public CountryMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await CountCountriesAsync(CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await CountCountriesAsync(CancellationToken.None));
    }
}
