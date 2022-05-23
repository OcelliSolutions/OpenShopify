using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;

[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class FulfillmentServiceTests : IClassFixture<SharedFixture>
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ShippingAndFulfillmentService _service;
    private const string FulfillmentServicePrefix = "OpenShopify Fulfillment Test";

    public FulfillmentServiceTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new ShippingAndFulfillmentService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    #region Create
    [SkippableFact, TestPriority(10)]
    public async Task CreateFulfillmentServiceAsync_CanCreate()
    {
        var name = $@"{FulfillmentServicePrefix} {Fixture.BatchId}";
        var email = $@"open+{Fixture.BatchId}@sample.com";
        var request = new CreateFulfillmentServiceRequest()
        {
            FulfillmentService = new CreateFulfillmentService()
            {
                Name = name,
                Email = email,
                Format = FulfillmentServiceFormat.json,
                CallbackUrl = "http://sample.com/callback"
            }
        };
        var response =
            await _service.FulfillmentService.CreateFulfillmentServiceAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Assert.Equal(name, response.Result.FulfillmentService.Name);
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

        foreach (var token in response.Result.FulfillmentServices)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(token, Fixture.MyShopifyUrl);
        }

        Assert.NotEmpty(response.Result.FulfillmentServices);
        Fixture.CreatedFulfillmentServices.AddRange(response.Result.FulfillmentServices.Where(fs =>
            !Fixture.CreatedFulfillmentServices.Exists(e => e.Id == fs.Id) &&
            fs.Name.StartsWith(FulfillmentServicePrefix)));
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
