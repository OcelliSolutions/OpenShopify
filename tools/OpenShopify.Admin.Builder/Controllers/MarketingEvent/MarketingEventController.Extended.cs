using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.MarketingEvent;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.MarketingEvent)]
[ApiController]
public class MarketingEventController : MarketingEventControllerBase
{
    public override Task RetrieveListOfAllMarketingEvents(string? limit = "50", string? offset = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateMarketingEvent()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfAllMarketingEvents()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleMarketingEvent(string marketing_event_id)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateMarketingEvent(string marketing_event_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteMarketingEvent(string marketing_event_id)
    {
        throw new NotImplementedException();
    }

    public override Task CreateMarketingEngagementsOnMarketingEvent(string marketing_event_id, string occurred_on, string? ad_spend = null,
        string? clicks_count = null, string? comments_count = null, string? favorites_count = null,
        string? impressions_count = null, string? is_cumulative = null, string? shares_count = null,
        string? views_count = null)
    {
        throw new NotImplementedException();
    }
}