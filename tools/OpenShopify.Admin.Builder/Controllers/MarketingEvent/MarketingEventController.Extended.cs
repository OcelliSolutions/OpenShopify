using System.ComponentModel;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.MarketingEvent;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.MarketingEvent)]
[ApiController]
public class MarketingEventController : MarketingEventControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("marketing_events.json")]
    [ProducesResponseType(typeof(MarketingEventList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfAllMarketingEvents(int? limit, string? page_info, string? offset)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("marketing_events.json")]
    [ProducesResponseType(typeof(MarketingEventItem), StatusCodes.Status201Created)]
    public override Task CreateMarketingEvent(MarketingEventItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("marketing_events/count.json")]
    [ProducesResponseType(typeof(MarketingEventCount), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfAllMarketingEvents()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("marketing_events/{marketing_event_id:long}.json")]
    [ProducesResponseType(typeof(MarketingEventItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleMarketingEvent(long marketing_event_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("marketing_events/{marketing_event_id:long}.json")]
    [ProducesResponseType(typeof(MarketingEventItem), StatusCodes.Status200OK)]
    public override Task UpdateMarketingEvent(MarketingEventItem request, long marketing_event_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("marketing_events/{marketing_event_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteMarketingEvent(long marketing_event_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("marketing_events/{marketing_event_id:long}/engagements.json")]
    [ProducesResponseType(typeof(EngagementList), StatusCodes.Status201Created)]
    public override Task CreateMarketingEngagementsOnMarketingEvent(MarketingEventItem request, long marketing_event_id, string occurred_on,
        string? ad_spend, string? clicks_count, string? comments_count, string? favorites_count, string? impressions_count,
        string? is_cumulative, string? shares_count, string? views_count)
    {
        throw new NotImplementedException();
    }
}