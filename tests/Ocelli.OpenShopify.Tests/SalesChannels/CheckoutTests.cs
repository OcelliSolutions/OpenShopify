using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.SalesChannels;
public class CheckoutFixture : SharedFixture, IAsyncLifetime
{
    public SalesChannelsService Service;
    public List<Checkout> CreatedCheckouts = new();

    public CheckoutFixture()
    {
        Service = new SalesChannelsService(MyShopifyUrl, AccessToken);
    }
    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}
/*
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CheckoutTests : IClassFixture<CheckoutFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    public CheckoutTests(CheckoutFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private CheckoutFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateCheckoutAsync_CanCreate()
    {
        var request = new CreateCheckoutRequest()
        {
            Checkout = new()
            {
                Topic = CheckoutTopic.FulfillmentEventsCreate,
                Address = $@"{Fixture.CallbackUrl}/fulfillment_events_create"
            }
        };
        var response = await Fixture.Service.Checkout.CreateCheckoutAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCheckouts.Add(response.Result.Checkout);
    }

    [SkippableFact, TestPriority(10)]
    public async Task CreateCheckoutAsync_IsUnprocessableEntityError()
    {
        var request = new CreateCheckoutRequest()
        {
            Checkout = new()
        };
        await Assert.ThrowsAsync<ApiException<CheckoutError>>(async () => await Fixture.Service.Checkout.CreateCheckoutAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountCheckoutsAsync_CanGet()
    {
        var response = await Fixture.Service.Checkout.CountCheckoutsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListCheckoutsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Checkout.ListCheckoutsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var checkout in response.Result.Checkouts)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(checkout, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.Checkouts.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetCheckoutAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCheckouts.Any(), "Must be run with create test");
        var checkout = Fixture.CreatedCheckouts.First();
        var response = await Fixture.Service.Checkout.GetCheckoutAsync(checkout.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Checkout, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateCheckoutAsync_CanUpdate()
    {
        var originalCheckout = Fixture.CreatedCheckouts.First();
        var request = new UpdateCheckoutRequest()
        {
            Checkout = new()
            {
                Id = originalCheckout.Id,
                Fields = new List<string> { "id" }
            }
        };
        var response = await Fixture.Service.Checkout.UpdateCheckoutAsync(request.Checkout.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCheckouts.Remove(originalCheckout);
        Fixture.CreatedCheckouts.Add(response.Result.Checkout);
    }

    #endregion Update
}
*/