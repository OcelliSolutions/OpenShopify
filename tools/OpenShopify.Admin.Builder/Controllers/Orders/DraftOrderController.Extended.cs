using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class DraftOrderController : DraftOrderControllerBase
{
    /// <inheritdoc />
    [HttpPost, Route("draft_orders.json")]
    [ProducesResponseType(typeof(DraftOrderItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(DraftOrderError), StatusCodes.Status422UnprocessableEntity)]
    public override Task CreateDraftOrder(CreateDraftOrderRequest request, long customer_id, bool? use_customer_default_address = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("draft_orders.json")]
    [ProducesResponseType(typeof(DraftOrderList), StatusCodes.Status200OK)]
    public override Task ListDraftOrders(string? fieldsQuery, string? ids = null, int? limit = null, string? page_info = null, long? since_id = null, string? status = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("draft_orders/{draft_order_id:long}.json")]
    [ProducesResponseType(typeof(DraftOrderItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(DraftOrderError), StatusCodes.Status422UnprocessableEntity)]
    public override Task UpdateDraftOrder([Required] UpdateDraftOrderRequest request, [Required] long draft_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("draft_orders/{draft_order_id:long}.json")]
    [ProducesResponseType(typeof(DraftOrderItem), StatusCodes.Status200OK)]
    public override Task GetDraftOrder([Required] long draft_order_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("draft_orders/{draft_order_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteDraftOrder([Required] long draft_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("draft_orders/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountDraftOrders(long? since_id = null, string? status = null, DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("draft_orders/{draft_order_id:long}/send_invoice.json")]
    [ProducesResponseType(typeof(DraftOrderInvoiceItem), StatusCodes.Status200OK)]
    public override Task SendInvoice([Required] long draft_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("draft_orders/{draft_order_id:long}/complete.json")]
    [ProducesResponseType(typeof(DraftOrderItem), StatusCodes.Status200OK)]
    public override Task CompleteDraftOrder([Required] long draft_order_id, string? payment_pending)
    {
        throw new NotImplementedException();
    }
}