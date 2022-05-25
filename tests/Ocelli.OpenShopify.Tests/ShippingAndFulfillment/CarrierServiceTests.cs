using System;
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
    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CarrierServiceTests : IClassFixture<CarrierServiceFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ShippingAndFulfillmentService _service;

    public CarrierServiceTests(ITestOutputHelper testOutputHelper, CarrierServiceFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new ShippingAndFulfillmentService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private CarrierServiceFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateCarrierServiceAsync_CanCreate()
    {
        var request = new CreateCarrierServiceRequest()
        {
            CarrierService = new()
            {
                Name = $@"{Fixture.Company} CarrierService ({Fixture.BatchId})",
                CallbackUrl = Fixture.CallbackUrl, 
                ServiceDiscovery = true,
                Active = true
            }
        };
        var response = await _service.CarrierService.CreateCarrierServiceAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCarrierServices.Add(response.Result.CarrierService);
    }

    [SkippableFact, TestPriority(10)]
    public async Task CreateCarrierServiceAsync_IsUnprocessableEntityError()
    {
        var request = new CreateCarrierServiceRequest()
        {
            CarrierService = new()
            {
                Name = $@"{Fixture.Company} CarrierService ({Fixture.BatchId})"
            }
        };
        await Assert.ThrowsAsync<ApiException<CarrierServiceError>>(async () => await _service.CarrierService.CreateCarrierServiceAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task ListCarrierServicesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await _service.CarrierService.ListCarrierServicesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var carrierService in response.Result.CarrierServices)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(carrierService, Fixture.MyShopifyUrl);
            if (carrierService.CallbackUrl != null && carrierService.CallbackUrl == Fixture.CallbackUrl
                                        && !Fixture.CreatedCarrierServices.Exists(w => w.Id == carrierService.Id))
                Fixture.CreatedCarrierServices.Add(carrierService);
        }
        var list = response.Result.CarrierServices;
        Skip.If(!list.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetCarrierServiceAsync_AdditionalPropertiesAreEmpty()
    {
        var carrierServiceListResponse = await _service.CarrierService.ListCarrierServicesAsync();
        Skip.If(!carrierServiceListResponse.Result.CarrierServices.Any(), "No results returned. Unable to test");
        var response = await _service.CarrierService.GetCarrierServiceAsync(carrierServiceListResponse.Result.CarrierServices.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CarrierService, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetCarrierServiceAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCarrierServices.Any(), "No results returned. Unable to test");
        var carrierService = Fixture.CreatedCarrierServices.First();
        var response = await _service.CarrierService.GetCarrierServiceAsync(carrierService.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CarrierService, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateCarrierServiceAsync_CanUpdate()
    {
        var originalCarrierService = Fixture.CreatedCarrierServices.First();
        var request = new UpdateCarrierServiceRequest()
        {
            CarrierService = new()
            {
                Id = originalCarrierService.Id, 
                Active = false
            }
        };
        var response = await _service.CarrierService.UpdateCarrierServiceAsync(request.CarrierService.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCarrierServices.Remove(originalCarrierService);
        Fixture.CreatedCarrierServices.Add(response.Result.CarrierService);
    }

    #endregion Update

    #region Delete

    [SkippableFact, TestPriority(40)]
    public async Task DeleteCarrierServiceAsync_CanDelete()
    {
        Skip.If(Fixture.CreatedCarrierServices.Count == 0, "WARN: No data returned. Could not test");
        var errors = new List<Exception>();
        foreach (var carrierService in Fixture.CreatedCarrierServices)
        {
            try
            {
                _ = await _service.CarrierService.DeleteCarrierServiceAsync(carrierService.Id);
            }
            catch (Exception ex)
            {
                errors.Add(ex);
            }
        }

        foreach (var error in errors)
        {
            _testOutputHelper.WriteLine(error.Message);
        }
        Assert.Empty(errors);
    }
    #endregion Delete
}