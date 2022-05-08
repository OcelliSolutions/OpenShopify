using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class RefundController : RefundControllerBase
{
    public override Task RetrieveListOfRefundsForOrder(string order_id, string? fields = null, string? in_shop_currency = "false",
        string? limit = "50")
    {
        throw new NotImplementedException();
    }

    public override Task CreateRefund(string order_id, string? currency = null, string? discrepancy_reason = null, string? note = null,
        string? notify = null, string? refund_line_items = null, string? restock = null, string? shipping = null,
        string? transactions = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSpecificRefund(string order_id, string refund_id, string? fields = null,
        string? in_shop_currency = "false")
    {
        throw new NotImplementedException();
    }

    public override Task CalculateRefund(string order_id, string? currency = null, string? refund_line_items = null,
        string? shipping = null)
    {
        throw new NotImplementedException();
    }
}