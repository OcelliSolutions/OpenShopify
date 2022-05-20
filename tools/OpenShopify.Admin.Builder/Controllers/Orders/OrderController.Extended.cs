using Microsoft.AspNetCore.Mvc;
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
    [HttpGet, Route("orders.json")]
    public override Task ListOrders(long? attribution_app_id, DateTime? created_at_max, DateTime? created_at_min,
        string? fields, string financial_status, string fulfillment_status, string? ids, int? limit, string? page_info,
        DateTime? processed_at_max, DateTime? processed_at_min, int? since_id, Status? status, DateTime? updated_at_max,
        DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders.json")]
    public override Task CreateOrder(CreateOrderRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}.json")]
    public override Task GetSpecificOrder(long order_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("orders/{order_id:long}.json")]
    public override Task UpdateOrder(UpdateOrderRequest request, long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("orders/{order_id:long}.json")]
    public override Task DeleteOrder(long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task GetOrderCount(DateTime? created_at_max, DateTime? created_at_min, string financial_status,
        string fulfillment_status, string status, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/close.json")]
    public override Task CloseOrder(long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/open.json")]
    public override Task ReOpenClosedOrder(long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/cancel.json")]
    public override Task CancelOrder(long order_id, string? amount, string? currency, bool? email, string reason, object? refund,
        bool? restock)
    {
        throw new NotImplementedException();
    }
}