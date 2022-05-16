using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Events;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Events)]
[ApiController]
public class WebhookController : IWebhookController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("webhooks.json")]
    public Task RetrieveListOfWebhooksAsync(string? address, string? created_at_max, string? created_at_min, string? fields,
        string limit, string? since_id, string? topic, string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("webhooks.json")]
    public Task CreateNewWebhookAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("webhooks/count.json")]
    public Task ReceiveCountOfAllWebhooksAsync(string? address, string? topic)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("webhooks/{webhook_id}.json")]
    public Task ReceiveSingleWebhookAsync(string webhook_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("webhooks/{webhook_id}.json")]
    public Task ModifyExistingWebhookAsync(string webhook_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("webhooks/{webhook_id}.json")]
    public Task RemoveExistingWebhookAsync(string webhook_id)
    {
        throw new NotImplementedException();
    }
}