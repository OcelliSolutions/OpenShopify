using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;

public class FulfillmentServiceFixture : SharedFixture, IAsyncLifetime
{
    public List<FulfillmentService> CreatedFulfillmentServices = new();
    public ShippingAndFulfillmentService Service;

    public FulfillmentServiceFixture() =>
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteFulfillmentServiceAsync_CanDelete();
    }
    
    public async Task DeleteFulfillmentServiceAsync_CanDelete()
    {
        foreach (var fulfillmentService in CreatedFulfillmentServices)
        {
            _ = await Service.FulfillmentService.DeleteFulfillmentServiceAsync(fulfillmentService.Id);
        }
        CreatedFulfillmentServices.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class FulfillmentServiceTests : IClassFixture<FulfillmentServiceFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public FulfillmentServiceTests(FulfillmentServiceFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private FulfillmentServiceFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateFulfillmentServiceAsync_CanUpdate()
    {
        var originalFulfillmentService = Fixture.CreatedFulfillmentServices.First();
        var request = new UpdateFulfillmentServiceRequest
        {
            FulfillmentService = new UpdateFulfillmentService
            {
                Id = originalFulfillmentService.Id,
                Name = $@"{Fixture.UniqueString()} New Fulfillment Service Name"
            }
        };
        var response =
            await Fixture.Service.FulfillmentService.UpdateFulfillmentServiceAsync(request.FulfillmentService.Id,
                request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillmentServices.Remove(originalFulfillmentService);
        Fixture.CreatedFulfillmentServices.Add(response.Result.FulfillmentService);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateFulfillmentServiceAsync_CanCreate()
    {
        var request = Fixture.CreateFulfillmentServiceRequest();
        var response = await Fixture.Service.FulfillmentService.CreateFulfillmentServiceAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillmentServices.Add(response.Result.FulfillmentService);
    }
    /*
    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateFulfillmentServiceAsync_EmptyBody_IsError()
    {
        var request = new CreateFulfillmentServiceRequest
        {
            FulfillmentService = new CreateFulfillmentService()
        };
        await Assert.ThrowsAsync<ApiException<FulfillmentServiceError>>(async () =>
            await Fixture.Service.FulfillmentService.CreateFulfillmentServiceAsync(request));
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateFulfillmentServiceAsync_IsUnprocessableEntityError()
    {
        var request = new CreateFulfillmentServiceRequest
        {
            FulfillmentService = new CreateFulfillmentService()
            {
                Name = Fixture.UniqueString()
            }
        };
        await Assert.ThrowsAsync<ApiException<FulfillmentServiceError>>(async () =>
            await Fixture.Service.FulfillmentService.CreateFulfillmentServiceAsync(request));
    }
    */

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListFulfillmentServicesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.FulfillmentService.ListFulfillmentServicesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var fulfillmentService in response.Result.FulfillmentServices)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(fulfillmentService, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.FulfillmentServices.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetFulfillmentServiceAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedFulfillmentServices.Any(), "Must be run with create test");
        var fulfillmentService = Fixture.CreatedFulfillmentServices.First();
        var response = await Fixture.Service.FulfillmentService.GetFulfillmentServiceAsync(fulfillmentService.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentService, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete


    [SkippableFact, TestPriority(99)]
    public async Task DeleteFulfillmentServiceAsync_CanDelete()
    {
        await Fixture.DeleteFulfillmentServiceAsync_CanDelete();
    }

    #endregion
}