namespace Ocelli.OpenShopify.Tests.ShopifyPayments;

public class DisputeFixture : SharedFixture, IAsyncLifetime
{
    public List<Dispute> CreatedDisputes = new();
    public IShopifyPaymentsService Service;

    public DisputeFixture() =>
        Service = new ShopifyPaymentsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("DisputeTests")]
public class DisputeTests : IClassFixture<DisputeFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly DisputeMockClient _badRequestMockClient;
    private readonly DisputeMockClient _okEmptyMockClient;
    private readonly DisputeMockClient _okInvalidJsonMockClient;

    public DisputeTests(DisputeFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new DisputeMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new DisputeMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new DisputeMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private DisputeFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListDisputesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Dispute.ListDisputesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var dispute in response.Result.Disputes)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(dispute, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Disputes.Any(), "No results returned. Unable to test");
        Fixture.CreatedDisputes.AddRange(response.Result.Disputes);
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetDisputeAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedDisputes.Any(), "Must be run with the list test");
        var dispute = Fixture.CreatedDisputes.First();
        var response = await Fixture.Service.Dispute.GetDisputeAsync(dispute.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Dispute, Fixture.MyShopifyUrl);
    }

    #endregion Read


    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class DisputeMockClient : DisputeClient, IMockTests
{
    public DisputeMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        //TODO: Validate that all methods are tested in this first section
        await Assert.ThrowsAsync<ApiException>(async () => await ListDisputesAsync());
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListDisputesAsync());
    }
}
