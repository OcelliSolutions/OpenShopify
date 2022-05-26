using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.StoreProperties;

public class CountryFixture : SharedFixture, IAsyncLifetime
{
    public StorePropertiesService Service;
    public List<Country> CreatedCountries = new();

    public CountryFixture()
    {
        Service = new StorePropertiesService(MyShopifyUrl, AccessToken);
    }

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteCountryAsync_CanDelete();
    }

    [SkippableFact, TestPriority(99)]
    public async Task DeleteCountryAsync_CanDelete()
    {
        foreach (var country in CreatedCountries)
        {
            _ = await Service.Country.DeleteCountryAsync(country.Id);
        }
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CountryTests : IClassFixture<CountryFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    public CountryTests(CountryFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
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
                Code = "FR"
            }
        };
        var response = await Fixture.Service.Country.CreateCountryAsync(request);
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
        await Assert.ThrowsAsync<ApiException<CountryError>>(async () => await Fixture.Service.Country.CreateCountryAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountCountriesAsync_CanGet()
    {
        var response = await Fixture.Service.Country.CountCountriesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListCountriesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Country.ListCountriesAsync();
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
        var response = await Fixture.Service.Country.GetCountyAsync(country.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Country, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateCountryAsync_CanUpdate()
    {
        var originalCountry = Fixture.CreatedCountries.First();
        var request = new UpdateCountryRequest()
        {
            Country = new()
            {
                Id = originalCountry.Id,
                Tax = (decimal)0.05
            }
        };
        var response = await Fixture.Service.Country.UpdateCountryAsync(request.Country.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCountries.Remove(originalCountry);
        Fixture.CreatedCountries.Add(response.Result.Country);
    }

    #endregion Update
}
