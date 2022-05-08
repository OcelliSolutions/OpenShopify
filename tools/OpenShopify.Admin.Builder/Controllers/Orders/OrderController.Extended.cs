using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class OrderController : OrderControllerBase
{
    public override Task RetrieveListOfOrders(string? attribution_app_id = null, object? created_at_max = null,
        object? created_at_min = null, string? fields = null, string? financial_status = "any",
        string? fulfillment_status = "any", string? ids = null, int? limit = 100, object? processed_at_max = null,
        object? processed_at_min = null, int? since_id = null, Status? status = null, object? updated_at_max = null,
        object? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSpecificOrder(string order_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateOrder(string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteOrder(string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveOrderCount(object? created_at_max = null, object? created_at_min = null, string? financial_status = "any",
        string? fulfillment_status = "any", string? status = "open", object? updated_at_max = null,
        object? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task CloseOrder(string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task ReOpenClosedOrder(string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task CancelOrder(string order_id, string? amount = null, string? currency = null, bool? email = false, string? reason = "other",
        object? refund = null, bool? restock = false)
    {
        throw new NotImplementedException();
    }

    public override Task CreateOrder()
    {
        throw new NotImplementedException();
    }
}