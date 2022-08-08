namespace Ocelli.OpenShopify.Tests.Events;

public class EventFixture : SharedFixture, IAsyncLifetime
{
    public List<Event> CreatedEvents = new();
    public IEventsService Service;

    public EventFixture() =>
        Service = new EventsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("EventTests")]
public class EventTests : IClassFixture<EventFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly EventMockClient _badRequestMockClient;
    private readonly EventMockClient _okEmptyMockClient;
    private readonly EventMockClient _okInvalidJsonMockClient;

    public EventTests(EventFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new EventMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new EventMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new EventMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private EventFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountEventsAsync_CanGet()
    {
        var response = await Fixture.Service.Event.CountEventsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListEventsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Event.ListEventsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var @event in response.Result.Events)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(@event, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Events.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetEventAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedEvents.Any(), "Must be run with create test");
        var @event = Fixture.CreatedEvents.First();
        var response = await Fixture.Service.Event.GetEventAsync(@event.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Event, Fixture.MyShopifyUrl);
    }

    #endregion Read


    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class EventMockClient : EventClient, IMockTests
{
    public EventMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnData()
    {
        ReadResponseAsString = true;
        //TODO: Validate that all methods are tested in this first section
        await Assert.ThrowsAsync<ApiException>(async () => await ListEventsAsync());
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListEventsAsync());
    }
}
