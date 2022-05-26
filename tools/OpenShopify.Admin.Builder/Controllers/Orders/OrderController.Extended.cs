using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class OrderController : OrderControllerBase
{
    /// <inheritdoc />
    [IgnoreApi, HttpGet, Route("orders.invalid")]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    public override Task ListOrders(long attribution_app_id, DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null,
        string? fields = null, string? financial_status = null, string? fulfillment_status = null, string? ids = null, int? limit = null, string? page_info = null,
        DateTimeOffset? processed_at_max = null, DateTimeOffset? processed_at_min = null, long? since_id = null, string? status = null, DateTimeOffset? updated_at_max = null,
        DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="OrderControllerBase.ListOrders" />
    [HttpGet, Route("orders.json")]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    public Task ListOrders(long? attribution_app_id, DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null,
        string? fields = null, string? financial_status = null, string? fulfillment_status = null, string? ids = null,
        int? limit = null, string? page_info = null, DateTimeOffset? processed_at_max = null,
        DateTimeOffset? processed_at_min = null, long? since_id = null, string? status = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders.json")]
    [ProducesResponseType(typeof(OrderItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(OrderError), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(CreateOrderRequestError), StatusCodes.Status400BadRequest)]
    public override Task CreateOrder([Required] CreateOrderRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}.json")]
    [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]
    public override Task GetOrder([Required] long order_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("orders/{order_id:long}.json")]
    [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OrderError), StatusCodes.Status422UnprocessableEntity)]
    public override Task UpdateOrder([Required] UpdateOrderRequest request, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("orders/{order_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteOrder([Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountOrders(DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null, string? financial_status = null,
        string? fulfillment_status = null, string? status = null, DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/close.json")]
    [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]
    public override Task CloseOrder([Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/open.json")]
    [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]
    public override Task ReOpenClosedOrder([Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [IgnoreApi, HttpPost, Route("orders/{order_id:long}/cancel.invalid")]
    [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]
    public override Task CancelOrder(long order_id, decimal? amount = null, string? currency = null, bool? email = null,
        string? reason = null, string? refund = null, bool? restock = null)
    {
        throw new NotImplementedException();
    }


    /// <inheritdoc cref="OrderControllerBase.CancelOrder" />
    [HttpPost, Route("orders/{order_id:long}/cancel.json")]
    [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]
    public Task CancelOrder(long order_id, decimal? amount = null, string? currency = null, bool? email = null,
        CancelReason? reason = null, CreateRefund? refund = null, bool? restock = null)
    {
        throw new NotImplementedException();
    }
}