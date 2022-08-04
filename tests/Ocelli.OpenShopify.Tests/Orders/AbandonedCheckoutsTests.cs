using System.Collections.Generic;

namespace Ocelli.OpenShopify.Tests.Orders;

public class AbandonedCheckoutFixture : SharedFixture, IAsyncLifetime
{
    public List<Checkout> CreatedAbandonedCheckouts = new();
    public IOrdersService Service;

    public AbandonedCheckoutFixture() =>
        Service = new OrdersService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class AbandonedCheckoutTests : IClassFixture<AbandonedCheckoutFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly AbandonedCheckoutMockClient _badRequestMockClient;
    private readonly AbandonedCheckoutMockClient _okEmptyMockClient;
    private readonly AbandonedCheckoutMockClient _okInvalidJsonMockClient;

    public AbandonedCheckoutTests(AbandonedCheckoutFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new AbandonedCheckoutMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new AbandonedCheckoutMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new AbandonedCheckoutMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
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


    [Fact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class AbandonedCheckoutMockClient : AbandonedCheckoutsClient, IMockTests
{
    public AbandonedCheckoutMockClient(HttpClient httpClient, AbandonedCheckoutFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        throw new XunitException("Not implemented.");
    }
}
