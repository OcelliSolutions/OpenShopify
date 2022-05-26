using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Events;

public class EventFixture : SharedFixture, IAsyncLifetime
{
    public List<Event> CreatedEvents = new();
    public EventsService Service;

    public EventFixture() =>
        Service = new EventsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class EventTests : IClassFixture<EventFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public EventTests(EventFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
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
}