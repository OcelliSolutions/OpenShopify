using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;

public class CarrierServiceFixture : SharedFixture, IAsyncLifetime
{
    public List<CarrierService> CreatedCarrierServices = new();
    public ShippingAndFulfillmentService Service;

    public CarrierServiceFixture() =>
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteCarrierServiceAsync_CanDelete();
    }
    
    public async Task DeleteCarrierServiceAsync_CanDelete()
    {
        foreach (var carrierService in CreatedCarrierServices)
        {
            _ = await Service.CarrierService.DeleteCarrierServiceAsync(carrierService.Id);
        }
        CreatedCarrierServices.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CarrierServiceTests : IClassFixture<CarrierServiceFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public CarrierServiceTests(CarrierServiceFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private CarrierServiceFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateCarrierServiceAsync_CanUpdate()
    {
        var originalCarrierService = Fixture.CreatedCarrierServices.First();
        var request = new UpdateCarrierServiceRequest
        {
            CarrierService = new UpdateCarrierService
            {
                Id = originalCarrierService.Id,
                Active = false
            }
        };
        var response =
            await Fixture.Service.CarrierService.UpdateCarrierServiceAsync(request.CarrierService.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCarrierServices.Remove(originalCarrierService);
        Fixture.CreatedCarrierServices.Add(response.Result.CarrierService);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCarrierServiceAsync_CanCreate()
    {
        var request = Fixture.CreateCarrierServiceRequest();
        var response = await Fixture.Service.CarrierService.CreateCarrierServiceAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCarrierServices.Add(response.Result.CarrierService);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCarrierServiceAsync_IsUnprocessableEntityError()
    {
        var request = new CreateCarrierServiceRequest
        {
            CarrierService = new CreateCarrierService()
        };
        await Assert.ThrowsAsync<ApiException<CarrierServiceError>>(async () =>
            await Fixture.Service.CarrierService.CreateCarrierServiceAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListCarrierServicesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.CarrierService.ListCarrierServicesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var carrierService in response.Result.CarrierServices)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(carrierService, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.CarrierServices.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetCarrierServiceAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCarrierServices.Any(), "Must be run with create test");
        var carrierService = Fixture.CreatedCarrierServices.First();
        var response = await Fixture.Service.CarrierService.GetCarrierServiceAsync(carrierService.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CarrierService, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete


    [SkippableFact, TestPriority(99)]
    public async Task DeleteCarrierServiceAsync_CanDelete()
    {
        await Fixture.DeleteCarrierServiceAsync_CanDelete();
    }

    #endregion
    }