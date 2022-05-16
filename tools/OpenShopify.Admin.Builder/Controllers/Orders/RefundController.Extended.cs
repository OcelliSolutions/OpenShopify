using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class RefundController : IRefundController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/refunds.json")]
    public Task RetrieveListOfRefundsForOrderAsync(string order_id, string? fields, string in_shop_currency, string limit)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/refunds.json")]
    public Task CreateRefundAsync(string order_id, string? currency, string? discrepancy_reason, string? note, string? notify,
        string? refund_line_items, string? restock, string? shipping, string? transactions)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/refunds/{refund_id}.json")]
    public Task RetrieveSpecificRefundAsync(string order_id, string refund_id, string? fields, string in_shop_currency)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/refunds/calculate.json")]
    public Task CalculateRefundAsync(string order_id, string? currency, string? refund_line_items, string? shipping)
    {
        throw new NotImplementedException();
    }
}