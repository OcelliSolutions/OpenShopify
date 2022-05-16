using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.MarketingEvent;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.MarketingEvent)]
[ApiController]
public class MarketingEventController : IMarketingEventController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("marketing_events.json")]
    public Task RetrieveListOfAllMarketingEventsAsync(string limit, string? offset)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("marketing_events.json")]
    public Task CreateMarketingEventAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("marketing_events/count.json")]
    public Task RetrieveCountOfAllMarketingEventsAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("marketing_events/{marketing_event_id}.json")]
    public Task RetrieveSingleMarketingEventAsync(string marketing_event_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("marketing_events/{marketing_event_id}.json")]
    public Task UpdateMarketingEventAsync(string marketing_event_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("marketing_events/{marketing_event_id}.json")]
    public Task DeleteMarketingEventAsync(string marketing_event_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("marketing_events/{marketing_event_id}/engagements.json")]
    public Task CreateMarketingEngagementsOnMarketingEventAsync(string marketing_event_id, string occurred_on, string? ad_spend,
        string? clicks_count, string? comments_count, string? favorites_count, string? impressions_count,
        string? is_cumulative, string? shares_count, string? views_count)
    {
        throw new NotImplementedException();
    }
}