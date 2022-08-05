using System;

namespace Ocelli.OpenShopify.Tests.MarketingEvent;

public class MarketingEventFixture : SharedFixture, IAsyncLifetime
{
    public List<OpenShopify.MarketingEvent> CreatedMarketingEvents = new();
    public IMarketingEventService Service;

    public MarketingEventFixture() =>
        Service = new MarketingEventService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteMarketingEventAsync_CanDelete();
    
    public async Task DeleteMarketingEventAsync_CanDelete()
    {
        foreach (var marketingEvent in CreatedMarketingEvents)
        {
            _ = await Service.MarketingEvent.DeleteMarketingEventAsync(marketingEvent.Id);
        }
        CreatedMarketingEvents.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("MarketingEventTests")]
public class MarketingEventTests : IClassFixture<MarketingEventFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly MarketingEventMockClient _badRequestMockClient;
    private readonly MarketingEventMockClient _okEmptyMockClient;
    private readonly MarketingEventMockClient _okInvalidJsonMockClient;

    public MarketingEventTests(MarketingEventFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new MarketingEventMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new MarketingEventMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new MarketingEventMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private MarketingEventFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateMarketingEventAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedMarketingEvents.Any(), "Must be run with create test");
        var originalMarketingEvent = Fixture.CreatedMarketingEvents.First();
        var request = new UpdateMarketingEventRequest
        {
            MarketingEvent = new UpdateMarketingEvent
            {
                Id = originalMarketingEvent.Id,
                RemoteId = $@"1000:2000:{Fixture.BatchId}",
                StartedAt = DateTimeOffset.Now.AddMonths(-1),
                EndedAt = DateTimeOffset.Now.AddDays(-1),
                ScheduledToEndAt = DateTimeOffset.Now,
                Budget = "11.1",
                BudgetType = BudgetType.Daily,
                Currency = "CAD",
                UtmMedium = "other",
                EventType = EventType.Ad,
                ReferringDomain = "instagram.com"
            }
        };
        var response =
            await Fixture.Service.MarketingEvent.UpdateMarketingEventAsync(originalMarketingEvent.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMarketingEvents.Remove(originalMarketingEvent);
        Fixture.CreatedMarketingEvents.Add(response.Result.MarketingEvent);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMarketingEventAsync_CanCreate()
    {
        var request = Fixture.CreateMarketingEventRequest();
        var response = await Fixture.Service.MarketingEvent.CreateMarketingEventAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMarketingEvents.Add(response.Result.MarketingEvent);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMarketingEventAsync_IsUnprocessableEntityError()
    {
        var request = new CreateMarketingEventRequest
        {
            MarketingEvent = new CreateMarketingEvent()
        };
        await Assert.ThrowsAsync<ApiException<MarketingEventError>>(async () =>
            await Fixture.Service.MarketingEvent.CreateMarketingEventAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountMarketingEventsAsync_CanGet()
    {
        var response = await Fixture.Service.MarketingEvent.CountMarketingEventsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListMarketingEventsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.MarketingEvent.ListMarketingEventsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var marketingEvent in response.Result.MarketingEvents)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(marketingEvent, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.MarketingEvents.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetMarketingEventAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedMarketingEvents.Any(), "Must be run with create test");
        var marketingEvent = Fixture.CreatedMarketingEvents.First();
        var response = await Fixture.Service.MarketingEvent.GetMarketingEventAsync(marketingEvent.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.MarketingEvent, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteMarketingEventAsync_CanDelete()
    {
        await Fixture.DeleteMarketingEventAsync_CanDelete();
    }

    #endregion Delete


    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class MarketingEventMockClient : MarketingEventClient, IMockTests
{
    public MarketingEventMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        Skip.If(0==1,"Not implemented.");
        return Task.CompletedTask;
    }
}
