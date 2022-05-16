using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Events;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Events)]
[ApiController]
public class EventController : IEventController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("events.json")]
    public Task RetrieveListOfEventsAsync(string? created_at_max, string? created_at_min, string? fields, string? filter,
        string limit, string? since_id, string? verb)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("events/{event_id}.json")]
    public Task RetrieveSingleEventAsync(string event_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("events/count.json")]
    public Task RetrieveCountOfEventsAsync(string? created_at_max, string? created_at_min)
    {
        throw new NotImplementedException();
    }
}