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
    public override Task CreateDraftOrder([Required] CreateDraftOrderRequest request, long? customer_id, string? use_customer_default_address)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("draft_orders.json")]
    public override Task ListDraftOrders(string? fieldsQuery, string? ids, int? limit, string? page_info, int? since_id, string? status,
        DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("draft_orders/{draft_order_id:long}.json")]
    public override Task UpdateDraftOrder([Required] UpdateDraftOrderRequest request, [Required] long draft_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("draft_orders/{draft_order_id:long}.json")]
    public override Task GetDraftOrder([Required] long draft_order_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("draft_orders/{draft_order_id:long}.json")]
    public override Task DeleteDraftOrder([Required] long draft_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("draft_orders/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountDraftOrders(int? since_id, string status, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("draft_orders/{draft_order_id:long}/send_invoice.json")]
    public override Task SendInvoice([Required] long draft_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("draft_orders/{draft_order_id:long}/complete.json")]
    public override Task CompleteDraftOrder([Required] long draft_order_id, string? payment_pending)
    {
        throw new NotImplementedException();
    }
}