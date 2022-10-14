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
    [HttpGet]
    [Route("orders/{order_id:long}/refunds.json")]
    [ProducesResponseType(typeof(RefundList), StatusCodes.Status200OK)]
    public override Task ListRefundsForOrder(long order_id, string? fields = null, bool? in_shop_currency = null, int? limit = null,
        string? page_info = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("orders/{order_id:long}/refunds.json")]
    [ProducesResponseType(typeof(RefundItem), StatusCodes.Status201Created)]
    public override Task CreateRefund([Required] CreateRefundRequest request, long order_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("orders/{order_id:long}/refunds/{refund_id:long}.json")]
    [ProducesResponseType(typeof(RefundItem), StatusCodes.Status200OK)]
    public override Task GetRefund([Required] long order_id, [Required] long refund_id, string? fields = null,
        bool? in_shop_currency = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("orders/{order_id:long}/refunds/calculate.json")]
    [ProducesResponseType(typeof(RefundItem), StatusCodes.Status200OK)]
    public override Task CalculateRefund([Required] CalculateRefundRequest request, long order_id) =>
        throw new NotImplementedException();
}