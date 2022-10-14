using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;

namespace OpenShopify.Admin.Builder.Controllers.Metafield;

/// <inheritdoc />
public partial class MetafieldController : MetafieldControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("draft_orders/{draft_order_id}/metafields/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountMetafieldsAttachedToDraftOrder(long? draft_order_id = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("draft_orders/{draft_order_id}/metafields.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status201Created)]
    public override Task CreateMetafieldForDraftOrder([Required] CreateMetafieldForDraftOrderRequest request, [Required] long draft_order_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("draft_orders/{draft_order_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteMetafieldForDraftOrder([Required] long draft_order_id, [Required] long metafield_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("draft_orders/{draft_order_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task GetMetafieldAttachedToDraftOrder([Required] long metafield_id, [Required] long draft_order_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [IgnoreApi]
    [HttpGet]
    [Route("draft_orders/{draft_order_id}/metafields.invalid")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task ListMetafieldsAttachedToDraftOrder([Required] long draft_order_id, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? fields = null, string? key = null, int? limit = null,
        string? page_info = null, string? @namespace = null, long? since_id = null, string? type = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="MetafieldControllerBase.ListMetafieldsAttachedToDraftOrder" />
    [HttpGet]
    [Route("draft_orders/{draft_order_id}/metafields.json")]
    [ProducesResponseType(typeof(MetafieldList), StatusCodes.Status200OK)]
    public Task ListMetafieldsAttachedToDraftOrder([Required] long draft_order_id, DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null, string? fields = null, string? key = null, int? limit = null,
        string? page_info = null, string? @namespace = null, long? since_id = null, MetafieldType? type = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("draft_orders/{draft_order_id}/metafields/{metafield_id}.json")]
    [ProducesResponseType(typeof(MetafieldItem), StatusCodes.Status200OK)]
    public override Task
        UpdateMetafieldForDraftOrder([Required] UpdateMetafieldForDraftOrderRequest request, [Required] long draft_order_id, [Required] long metafield_id) =>
        throw new NotImplementedException();
}