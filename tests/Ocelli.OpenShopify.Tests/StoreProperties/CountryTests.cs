using System.Collections.Generic;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.StoreProperties;

[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CountryTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly List<Country> _testCountries;
    private const string CountryPrefix = "OpenShopify Country Test";
    private const string CountryCode = "US";
    private const string ProvinceCode = "CO";

    public CountryTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testCountries = new List<Country>();
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }
    /*
    /// <summary>
    /// Create an fulfillment service first
    /// </summary>
    [SkippableFact, TestPriority(10)]
    public async Task CreateCountryAsync_CanCreate()
    {
        var name = $@"{CountryPrefix} {Fixture.BatchId}";
        var service = new StorePropertiesService(Fixture.MyShopifyUrl, Fixture.AccessToken);
        var request = new CountryItem()
        {
            Country = new Country
            {
                Code = CountryCode,
                Provinces = new List<Province>() { new Province() { Code = ProvinceCode, Name = name } }
            }
        };
        var created = await service.Country.CreateCountryAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(created, Fixture.MyShopifyUrl);

        Assert.Equal(CountryCode, created.Country?.Code);
        Assert.NotNull(created.Country?.Id);
        Debug.Assert(created.Country != null, "created.Country != null");
        _testCountries.Add(created.Country);
    }

    /// <summary>
    /// Ensure that the created country can be returned
    /// </summary>
    [SkippableFact, TestPriority(20)]
    public async Task GetCountryAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        Assert.NotNull(_testCountries.First().Id);
        if (_testCountries.First() is not { Code: { } }) return;
        var testCountry = _testCountries.First();
        var service = new StorePropertiesService(Fixture.MyShopifyUrl, Fixture.AccessToken);

        var single =
            await service.Country.GetSpecificCountyAsync(testCountry.Id,
                : );
        _additionalPropertiesHelper.CheckAdditionalProperties(single, Fixture.MyShopifyUrl);

        Assert.NotNull(single.Country?.Id);
        Assert.Equal(testCountry.Code, single.Country?.Code);
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetCountOfCountriesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var service = new StorePropertiesService(Fixture.MyShopifyUrl, Fixture.AccessToken);

        var count =
            await service.Country.GetCountOfCountriesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(count, Fixture.MyShopifyUrl);

        Assert.InRange(count.Count, 1, 300);
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListCountriesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var service = new StorePropertiesService(Fixture.MyShopifyUrl, Fixture.AccessToken);
        var result = await service.Country.ListCountriesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(result, Fixture.MyShopifyUrl);

        if (result.Countries != null && !result.Countries.Any())
        {
            Skip.If(result.Countries == null || !result.Countries.Any(),
                "WARN: No data returned. Could not test");
            return;
        }

        foreach (var token in result.Countries!)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(token, Fixture.MyShopifyUrl);
        }

        Assert.NotEmpty(result.Countries);
        _testCountries.AddRange(result.Countries.Where(fs =>
            !_testCountries.Exists(e => e.Id == fs.Id) && fs.Code == CountryCode));
    }

    /// <summary>
    /// update the newly created fulfillment service
    /// </summary>
    [SkippableFact, TestPriority(30)]
    public async Task UpdateCountryAsync_CanUpdate()
    {
        var testCountry = _testCountries.First();
        Assert.NotNull(testCountry.Id);
        if (testCountry is not { Code: { } }) return;
        var service = new StorePropertiesService(Fixture.MyShopifyUrl, Fixture.AccessToken);

        var updateRequest = new CountryItem() { Country = testCountry };
        updateRequest.Country!.Tax = .15;
        updateRequest.Country!.TaxName = "Sample Tax";
        var updated =
            await service.Country.UpdateCountryAsync(updateRequest.Country.Id, updateRequest,
                );
        _additionalPropertiesHelper.CheckAdditionalProperties(updated, Fixture.MyShopifyUrl);

        Assert.NotNull(updated.Country?.Id);
        Assert.Equal(testCountry.Id, updated.Country?.Id);
    }

    [SkippableFact, TestPriority(40)]
    public async Task DeleteExistingCountryAsync_CanDelete()
    {
        Skip.If(_testCountries.Count == 0);
        var service = new StorePropertiesService(Fixture.MyShopifyUrl, Fixture.AccessToken);
        foreach (var testCountry in _testCountries)
        {
            Debug.Assert(testCountry.Provinces != null, "testCountry.Provinces != null");
            var testProvince = testCountry.Provinces.FirstOrDefault(p => p.Code == ProvinceCode);
            if (testProvince != null)
                await service.Country.DeleteExistingCountryAsync(testCountry.Id);
        }
    }
    */
}
