using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Events;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Events)]
[ApiController]
public class EventController : EventControllerBase
{
    public override Task RetrieveListOfEvents(string? created_at_max = null, string? created_at_min = null, string? fields = null,
        string? filter = null, string? limit = "50", string? since_id = null, string? verb = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleEvent(string event_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfEvents(string? created_at_max = null, string? created_at_min = null)
    {
        throw new NotImplementedException();
    }
}