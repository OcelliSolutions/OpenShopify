using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class OrderController : IOrderController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders.json")]
    public Task RetrieveListOfOrdersAsync(string? attribution_app_id, DateTime? created_at_max, DateTime? created_at_min,
        string? fields, string financial_status, string fulfillment_status, string? ids, int limit,
        DateTime? processed_at_max, DateTime? processed_at_min, int? since_id, Status? status, DateTime? updated_at_max,
        DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("orders.json")]
    public Task CreateOrderAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}.json")]
    public Task RetrieveSpecificOrderAsync(string order_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}.json")]
    public Task UpdateOrderAsync(string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}.json")]
    public Task DeleteOrderAsync(string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/count.json")]
    public Task RetrieveOrderCountAsync(DateTime? created_at_max, DateTime? created_at_min, string financial_status,
        string fulfillment_status, string status, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/close.json")]
    public Task CloseOrderAsync(string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/open.json")]
    public Task ReOpenClosedOrderAsync(string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/cancel.json")]
    public Task CancelOrderAsync(string order_id, string? amount, string? currency, bool email, string reason, object? refund,
        bool restock)
    {
        throw new NotImplementedException();
    }
}
