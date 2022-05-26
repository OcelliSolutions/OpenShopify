using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class RefundController : RefundControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/refunds.json")]
    [ProducesResponseType(typeof(RefundList), StatusCodes.Status200OK)]
    public override Task ListRefundsForOrder([Required] long order_id, string? fields = null, bool? in_shop_currency = null, int? limit = null, string? page_info = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/refunds.json")]
    [ProducesResponseType(typeof(RefundItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(RefundError), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(CreateRefundRequestError), StatusCodes.Status400BadRequest)]
    public override Task CreateRefund(CreateRefundRequest request, long order_id, string? currency = null,
        string? discrepancy_reason = null, string? note = null, string? notify = null, string? refund_line_items = null,
        bool? restock = null, string? shipping = null, string? transactions = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/refunds/{refund_id:long}.json")]
    [ProducesResponseType(typeof(RefundItem), StatusCodes.Status200OK)]
    public override Task GetRefund([Required] long order_id, [Required] long refund_id, string? fields = null, bool? in_shop_currency = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/refunds/calculate.json")]
    [ProducesResponseType(typeof(RefundItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RefundError), StatusCodes.Status422UnprocessableEntity)]
    public override Task CalculateRefund([Required] long order_id, string? currency, string? refund_line_items, string? shipping)
    {
        throw new NotImplementedException();
    }
}