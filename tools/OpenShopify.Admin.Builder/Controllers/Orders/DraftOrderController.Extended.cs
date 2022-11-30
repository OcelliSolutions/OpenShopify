using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class DraftOrderController : DraftOrderControllerBase
{
    /// <inheritdoc />
    [HttpPost]
    [Route("draft_orders.json")]
    [ProducesResponseType(typeof(DraftOrderItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(DraftOrderItem), StatusCodes.Status202Accepted)]
    public override Task CreateDraftOrder([Required] CreateDraftOrderRequest request) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("draft_orders.json")]
    [ProducesResponseType(typeof(DraftOrderList), StatusCodes.Status200OK)]
    public override Task ListDraftOrders(string? fieldsQuery = null, [FromQuery] IEnumerable<long>? ids = null,
        int? limit = null, string? page_info = null, long? since_id = null, string? status = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("draft_orders/{draft_order_id:long}.json")]
    [ProducesResponseType(typeof(DraftOrderItem), StatusCodes.Status200OK)]
    public override Task UpdateDraftOrder([Required] UpdateDraftOrderRequest request, [Required] long draft_order_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("draft_orders/{draft_order_id:long}.json")]
    [ProducesResponseType(typeof(DraftOrderItem), StatusCodes.Status200OK)]
    public override Task GetDraftOrder([Required] long draft_order_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("draft_orders/{draft_order_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteDraftOrder([Required] long draft_order_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("draft_orders/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountDraftOrders(long? since_id = null, string? status = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("draft_orders/{draft_order_id:long}/send_invoice.json")]
    [ProducesResponseType(typeof(DraftOrderInvoiceItem), StatusCodes.Status200OK)]
    public override Task SendInvoice([Required] SendInvoiceRequest request, long draft_order_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("draft_orders/{draft_order_id:long}/complete.json")]
    [ProducesResponseType(typeof(DraftOrderItem), StatusCodes.Status200OK)]
    public override Task CompleteDraftOrder([Required] CompleteDraftOrderRequest request, long draft_order_id) =>
        throw new NotImplementedException();
}