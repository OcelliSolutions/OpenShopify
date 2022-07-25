using System.ComponentModel.DataAnnotations;
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
    [HttpGet]
    [Route("events.json")]
    [ProducesResponseType(typeof(EventList), StatusCodes.Status200OK)]
    public override Task ListEvents(DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null,
        string? fields = null, string? filter = null,
        int? limit = null, string? page_info = null, long? since_id = null, string? verb = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("events/{event_id:long}.json")]
    [ProducesResponseType(typeof(EventItem), StatusCodes.Status200OK)]
    public override Task GetEvent([Required] long event_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("events/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountEvents(DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null) =>
        throw new NotImplementedException();
}