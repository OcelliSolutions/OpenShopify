using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Events;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class EventTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly EventsService _service;

    public EventTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new EventsService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    #region Create

    #endregion Create

    #region Read
    [SkippableFact]
    public async Task Counts_Events()
    {
        var response = await _service.Event.CountEventsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Assert.True(count > 0);
    }

    [SkippableFact]
    public async Task Lists_Events()
    {
        var response = await _service.Event.ListEventsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var resultEvent in response.Result.Events)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(resultEvent, Fixture.MyShopifyUrl);
        }
        var list = response.Result.Events;
        Assert.True(list.Any());
    }

    [SkippableFact]
    public async Task Gets_Events()
    {
        var allEvents = await _service.Event.ListEventsAsync(limit:1);
        var firstEvent = allEvents.Result.Events.First();
        var response = await _service.Event.GetEventAsync(firstEvent.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        var @event = response.Result.Event;
        Assert.NotNull(@event);
        //Assert.NotNull(@event.Author);
        Assert.True(@event.CreatedAt.HasValue);
        Assert.NotNull(@event.Message);
        Assert.True(@event.SubjectId > 0);
        Assert.NotNull(@event.SubjectType);
        Assert.NotNull(@event.Verb);
    }
    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}
