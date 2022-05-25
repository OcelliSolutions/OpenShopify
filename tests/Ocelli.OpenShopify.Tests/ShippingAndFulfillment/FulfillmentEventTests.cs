using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class FulfillmentEventTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ShippingAndFulfillmentService _service;

    public FulfillmentEventTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new ShippingAndFulfillmentService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    /*
    //TODO:complete after fulfillment tests
    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateFulfillmentEventAsync_CanCreate()
    {
        var request = new CreateFulfillmentEventRequest()
        {
            FulfillmentEvent = new()
            {
                Status = FulfillmentEventStatus.in_transit
            }
        };
        var response = await _service.FulfillmentEvent.CreateFulfillmentEventAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillmentEvents.Add(response.Result.FulfillmentEvent);
    }

    [SkippableFact, TestPriority(10)]
    public async Task CreateFulfillmentEventAsync_IsUnprocessableEntityError()
    {
        var request = new CreateFulfillmentEventRequest()
        {
            FulfillmentEvent = new()
            {
                Topic = FulfillmentEventTopic.app_uninstalled
            }
        };
        await Assert.ThrowsAsync<ApiException<FulfillmentEventError>>(async () => await _service.FulfillmentEvent.CreateFulfillmentEventAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountFulfillmentEventsAsync_CanGet()
    {
        var response = await _service.FulfillmentEvent.CountFulfillmentEventsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListFulfillmentEventsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await _service.FulfillmentEvent.ListFulfillmentEventsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var fulfillmentEvent in response.Result.FulfillmentEvents)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(fulfillmentEvent, Fixture.MyShopifyUrl);
            if (fulfillmentEvent.Address != null && fulfillmentEvent.Address.Contains(Domain)
                                        && !Fixture.CreatedFulfillmentEvents.Exists(w => w.Id == fulfillmentEvent.Id))
                Fixture.CreatedFulfillmentEvents.Add(fulfillmentEvent);
        }
        var list = response.Result.FulfillmentEvents;
        Skip.If(!list.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetFulfillmentEventAsync_AdditionalPropertiesAreEmpty()
    {
        var fulfillmentEventListResponse = await _service.FulfillmentEvent.ListFulfillmentEventsAsync(limit: 1);
        Skip.If(!fulfillmentEventListResponse.Result.FulfillmentEvents.Any(), "No results returned. Unable to test");
        var response = await _service.FulfillmentEvent.GetFulfillmentEventAsync(fulfillmentEventListResponse.Result.FulfillmentEvents.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentEvent, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetFulfillmentEventAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedFulfillmentEvents.Any(), "No results returned. Unable to test");
        var fulfillmentEvent = Fixture.CreatedFulfillmentEvents.First();
        var response = await _service.FulfillmentEvent.GetFulfillmentEventAsync(fulfillmentEvent.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentEvent, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateFulfillmentEventAsync_CanUpdate()
    {
        var originalFulfillmentEvent = Fixture.CreatedFulfillmentEvents.First();
        var request = new UpdateFulfillmentEventRequest()
        {
            FulfillmentEvent = new()
            {
                Id = originalFulfillmentEvent.Id,
                Fields = new List<string>() { "id" }
            }
        };
        var response = await _service.FulfillmentEvent.UpdateFulfillmentEventAsync(request.FulfillmentEvent.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillmentEvents.Remove(originalFulfillmentEvent);
        Fixture.CreatedFulfillmentEvents.Add(response.Result.FulfillmentEvent);
    }

    #endregion Update

    #region Delete

    [SkippableFact, TestPriority(40)]
    public async Task DeleteFulfillmentEventAsync_CanDelete()
    {
        Skip.If(Fixture.CreatedFulfillmentEvents.Count == 0, "WARN: No data returned. Could not test");
        var errors = new List<Exception>();
        foreach (var fulfillmentEvent in Fixture.CreatedFulfillmentEvents)
        {
            try
            {
                _ = await _service.FulfillmentEvent.DeleteFulfillmentEventAsync(fulfillmentEvent.Id);
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
    */
}