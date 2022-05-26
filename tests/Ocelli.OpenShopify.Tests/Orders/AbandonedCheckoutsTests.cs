using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Orders;

public class AbandonedCheckoutFixture : SharedFixture, IAsyncLifetime
{
    public List<Checkout> CreatedAbandonedCheckouts = new();
    public OrdersService Service;

    public AbandonedCheckoutFixture() =>
        Service = new OrdersService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class AbandonedCheckoutTests : IClassFixture<AbandonedCheckoutFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public AbandonedCheckoutTests(AbandonedCheckoutFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private AbandonedCheckoutFixture Fixture { get; }

    #region Read

    //TODO: needs a test to trigger an abandoned checkout
    [SkippableFact]
    [TestPriority(20)]
    public async Task ListAbandonedCheckoutsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.AbandonedCheckouts.ListAbandonedCheckoutsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var abandonedCheckout in response.Result.Checkouts)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(abandonedCheckout, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Checkouts.Any(), "No results returned. Unable to test");
    }

    #endregion Read
}