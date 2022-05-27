using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Events;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Events)]
[ApiController]
public class WebhookController : WebhookControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("webhooks.json")]
    [ProducesResponseType(typeof(WebhookList), StatusCodes.Status200OK)]
    public override Task ListWebhooks(string? address = null, DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null, string? fields = null,
        int? limit = null, string? page_info = null, long? since_id = null, string? topic = null, DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("webhooks.json")]
    [ProducesResponseType(typeof(WebhookItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(WebhookError), StatusCodes.Status422UnprocessableEntity)]
    public override Task CreateWebhook([Required] CreateWebhookRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("webhooks/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountWebhooks(string? address = null, string? topic = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("webhooks/{webhook_id:long}.json")]
    [ProducesResponseType(typeof(WebhookItem), StatusCodes.Status200OK)]
    public override Task GetWebhook([Required] long webhook_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("webhooks/{webhook_id:long}.json")]
    [ProducesResponseType(typeof(WebhookItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(WebhookError), StatusCodes.Status422UnprocessableEntity)]
    public override Task UpdateWebhook([Required] UpdateWebhookRequest request, [Required] long webhook_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("webhooks/{webhook_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteWebhook([Required] long webhook_id)
    {
        throw new NotImplementedException();
    }
}
