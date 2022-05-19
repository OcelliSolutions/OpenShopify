using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Events;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Events)]
[ApiController]
public class WebhookController : WebhookControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("webhooks.json")]
    [ProducesResponseType(typeof(WebhookList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfWebhooks(string? address, DateTime? created_at_max, DateTime? created_at_min, string? fields,
        int? limit, string? page_info, int? since_id, string? topic, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("webhooks.json")]
    [ProducesResponseType(typeof(WebhookItem), StatusCodes.Status201Created)]
    public override Task CreateNewWebhook(WebhookItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("webhooks/count.json")]
    [ProducesResponseType(typeof(WebhookCount), StatusCodes.Status200OK)]
    public override Task ReceiveCountOfAllWebhooks(string? address, string? topic)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("webhooks/{webhook_id:long}.json")]
    [ProducesResponseType(typeof(WebhookItem), StatusCodes.Status200OK)]
    public override Task ReceiveSingleWebhook(long webhook_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("webhooks/{webhook_id:long}.json")]
    [ProducesResponseType(typeof(WebhookItem), StatusCodes.Status200OK)]
    public override Task ModifyExistingWebhook(WebhookItem request, long webhook_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("webhooks/{webhook_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task RemoveExistingWebhook(long webhook_id)
    {
        throw new NotImplementedException();
    }
}
