using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Events;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Events)]
[ApiController]
public class EventController : EventControllerBase
{
    /// <inheritdoc />
    [HttpGet, Microsoft.AspNetCore.Mvc.Route("events.json")]
    [ProducesResponseType(typeof(EventList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfEvents(DateTime? created_at_max, DateTime? created_at_min, string? fields, string? filter,
        int? limit, string? page_info, int? since_id, string? verb)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Microsoft.AspNetCore.Mvc.Route("events/{event_id:long}.json")]
    [ProducesResponseType(typeof(EventItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleEvent(long event_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Microsoft.AspNetCore.Mvc.Route("events/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfEvents(DateTime? created_at_max, DateTime? created_at_min)
    {
        throw new NotImplementedException();
    }
}
