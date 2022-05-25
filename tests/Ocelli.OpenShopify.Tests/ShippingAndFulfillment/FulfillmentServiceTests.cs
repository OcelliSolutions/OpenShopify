using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class FulfillmentServiceTests : IClassFixture<FulfillmentServiceFixture>
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ShippingAndFulfillmentService _service;

    public FulfillmentServiceTests(ITestOutputHelper testOutputHelper, FulfillmentServiceFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new ShippingAndFulfillmentService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private FulfillmentServiceFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateFulfillmentServiceAsync_CanCreate()
    {
        var request = Fixture.CreateFulfillmentServiceRequest;
        var response =
            await _service.FulfillmentService.CreateFulfillmentServiceAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentService, Fixture.MyShopifyUrl);

        Assert.Equal(request.FulfillmentService.Name, response.Result.FulfillmentService.Name);
        Assert.True(response.Result.FulfillmentService.Id > 0);
        Debug.Assert(response.Result.FulfillmentService != null, "created.CreatedFulfillmentServices != null");
        Fixture.CreatedFulfillmentServices.Add(response.Result.FulfillmentService);
    }

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task GetFulfillmentServiceAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        Skip.If(!Fixture.CreatedFulfillmentServices.Any(), "WARN: No data returned. Could not test");
        if (Fixture.CreatedFulfillmentServices.First() is not { Handle: { } }) return;
        var testFulfillmentService = Fixture.CreatedFulfillmentServices.First();

        var response =
            await _service.FulfillmentService.GetFulfillmentServiceAsync(testFulfillmentService.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Assert.True(response.Result.FulfillmentService.Id > 0);
        Assert.Equal(testFulfillmentService.Handle, response.Result.FulfillmentService.Handle);
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListFulfillmentServicesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var response =
            await _service.FulfillmentService.ListFulfillmentServicesAsync(FulfillmentServiceScope
                .current_client);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        if (!response.Result.FulfillmentServices.Any())
        {
            Skip.If(!response.Result.FulfillmentServices.Any(), "WARN: No data returned. Could not test");
            return;
        }

        foreach (var fulfillmentService in response.Result.FulfillmentServices)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(fulfillmentService, Fixture.MyShopifyUrl);
            if (fulfillmentService.CallbackUrl != null && fulfillmentService.CallbackUrl.Contains(Fixture.CreateFulfillmentServiceRequest.FulfillmentService.CallbackUrl!)
                                                   && !Fixture.CreatedFulfillmentServices.Exists(w => w.Id == fulfillmentService.Id))
                Fixture.CreatedFulfillmentServices.Add(fulfillmentService);
        }
        Skip.If(!response.Result.FulfillmentServices.Any(), "No results returned. Unable to test");
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateFulfillmentServiceAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedFulfillmentServices.Any(), "WARN: No data returned. Could not test");
        var createdFulfillmentService = Fixture.CreatedFulfillmentServices.First();
        var updateRequest = new UpdateFulfillmentServiceRequest()
        {
            FulfillmentService = new UpdateFulfillmentService()
            {
                Id = createdFulfillmentService.Id, 
                Name = createdFulfillmentService.Name, 
                Email = @"open@sample.com"
            }
        };
        var response =
            await _service.FulfillmentService.UpdateFulfillmentServiceAsync(
                updateRequest.FulfillmentService.Id, updateRequest);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        
        Assert.Equal(createdFulfillmentService.Id, response.Result.FulfillmentService.Id);

        // Reset the id so the Fixture can properly delete this object.
        Fixture.CreatedFulfillmentServices.Remove(createdFulfillmentService);
        Fixture.CreatedFulfillmentServices.Add(response.Result.FulfillmentService);
    }

    #endregion Update

    #region Delete

    [SkippableFact, TestPriority(40)]
    public async Task DeleteFulfillmentServiceAsync_CanDelete()
    {
        Skip.If(Fixture.CreatedFulfillmentServices.Count == 0, "WARN: No data returned. Could not test");
        var errors = new List<Exception>();
        foreach (var fulfillmentService in Fixture.CreatedFulfillmentServices)
        {
            try
            {
                var response = await _service.FulfillmentService.DeleteFulfillmentServiceAsync(fulfillmentService.Id);
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
