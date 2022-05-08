using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Events;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Events)]
[ApiController]
public class WebhookController : WebhookControllerBase
{
    public override Task RetrieveListOfWebhooks(string? address = null, string? created_at_max = null, string? created_at_min = null,
        string? fields = null, string? limit = "50", string? since_id = null, string? topic = null,
        string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateNewWebhook()
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveCountOfAllWebhooks(string? address = null, string? topic = null)
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveSingleWebhook(string webhook_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task ModifyExistingWebhook(string webhook_id)
    {
        throw new NotImplementedException();
    }

    public override Task RemoveExistingWebhook(string webhook_id)
    {
        throw new NotImplementedException();
    }
}