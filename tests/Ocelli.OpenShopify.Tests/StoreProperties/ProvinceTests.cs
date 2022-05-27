using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.StoreProperties;

public class ProvinceFixture : SharedFixture, IAsyncLifetime
{
    public List<Country> Countries = new();
    public List<Province> Provinces = new();
    public StorePropertiesService Service;

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
public class ProvinceTests : IClassFixture<ProvinceFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public ProvinceTests(ProvinceFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private ProvinceFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateProvinceAsync_CanUpdate()
    {
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
        Skip.If(count == 0, "No results returned. Unable to test");
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
        Skip.If(!response.Result.Provinces.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(21)]
    public async Task GetProvinceAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.Provinces.Any(), "Must be run with create test");
        var province = Fixture.Provinces.First();
        var response = await Fixture.Service.Province.GetProvinceAsync(province.CountryId ?? 0, province.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Province, Fixture.MyShopifyUrl);
    }

    #endregion Read
}