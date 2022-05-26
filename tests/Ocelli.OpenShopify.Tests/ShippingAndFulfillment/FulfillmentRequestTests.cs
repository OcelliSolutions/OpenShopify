using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
public class FulfillmentRequestFixture : SharedFixture, IAsyncLifetime
{
    public EventsService Service;
    public List<FulfillmentRequest> CreatedFulfillmentRequests = new();

    public FulfillmentRequestFixture()
    {
        Service = new EventsService(MyShopifyUrl, AccessToken);
    }
    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
    }
}

/*
 //TODO: this is non-standard and will require more work.
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class FulfillmentRequestTests : IClassFixture<FulfillmentRequestFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    public FulfillmentRequestTests(FulfillmentRequestFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private FulfillmentRequestFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateFulfillmentRequestAsync_CanCreate()
    {
        var request = Fixture.CreateFulfillmentRequestRequest();
        var response = await Fixture.Service.FulfillmentRequest.CreateFulfillmentRequestAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillmentRequests.Add(response.Result.FulfillmentRequest);
    }

    [SkippableFact, TestPriority(10)]
    public async Task CreateFulfillmentRequestAsync_IsUnprocessableEntityError()
    {
        var request = new CreateFulfillmentRequestRequest()
        {
            FulfillmentRequest = new()
        };
        await Assert.ThrowsAsync<ApiException<FulfillmentRequestError>>(async () => await Fixture.Service.FulfillmentRequest.CreateFulfillmentRequestAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountFulfillmentRequestsAsync_CanGet()
    {
        var response = await Fixture.Service.FulfillmentRequest.CountFulfillmentRequestsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListFulfillmentRequestsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.FulfillmentRequest.ListFulfillmentRequestsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var fulfillmentRequest in response.Result.FulfillmentRequests)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(fulfillmentRequest, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.FulfillmentRequests.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetFulfillmentRequestAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedFulfillmentRequests.Any(), "Must be run with create test");
        var fulfillmentRequest = Fixture.CreatedFulfillmentRequests.First();
        var response = await Fixture.Service.FulfillmentRequest.GetFulfillmentRequestAsync(fulfillmentRequest.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentRequest, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateFulfillmentRequestAsync_CanUpdate()
    {
        var originalFulfillmentRequest = Fixture.CreatedFulfillmentRequests.First();
        var request = new UpdateFulfillmentRequestRequest()
        {
            FulfillmentRequest = new()
            {
                Id = originalFulfillmentRequest.Id,
                Fields = new List<string> { "id" }
            }
        };
        var response = await Fixture.Service.FulfillmentRequest.UpdateFulfillmentRequestAsync(originalFulfillmentRequest.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillmentRequests.Remove(originalFulfillmentRequest);
        Fixture.CreatedFulfillmentRequests.Add(response.Result.FulfillmentRequest);
    }

    #endregion Update
}
*/