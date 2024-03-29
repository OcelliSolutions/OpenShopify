using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.MarketingEvent;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.MarketingEvent)]
[ApiController]
public class MarketingEventController : MarketingEventControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("marketing_events.json")]
    [ProducesResponseType(typeof(MarketingEventList), StatusCodes.Status200OK)]
    public override Task ListMarketingEvents(int? limit = null, string? page_info = null, int? offset = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("marketing_events.json")]
    [ProducesResponseType(typeof(MarketingEventItem), StatusCodes.Status201Created)]
    public override Task CreateMarketingEvent([Required] CreateMarketingEventRequest request) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("marketing_events/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountMarketingEvents() => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("marketing_events/{marketing_event_id:long}.json")]
    [ProducesResponseType(typeof(MarketingEventItem), StatusCodes.Status200OK)]
    public override Task GetMarketingEvent([Required] long marketing_event_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("marketing_events/{marketing_event_id:long}.json")]
    [ProducesResponseType(typeof(MarketingEventItem), StatusCodes.Status200OK)]
    public override Task UpdateMarketingEvent([Required] UpdateMarketingEventRequest request,
        [Required] long marketing_event_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("marketing_events/{marketing_event_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteMarketingEvent([Required] long marketing_event_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("marketing_events/{marketing_event_id:long}/engagements.json")]
    [ProducesResponseType(typeof(EngagementList), StatusCodes.Status201Created)]
    //TODO: wrong request type
    public override Task CreateMarketingEngagementsOnMarketingEvent(
        [Required] CreateMarketingEngagementsOnMarketingEventRequest request, [Required] long marketing_event_id) =>
        throw new NotImplementedException();
}