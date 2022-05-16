using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class DraftOrderController : IDraftOrderController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("draft_orders.json")]
    public Task CreateNewDraftOrderAsync(string? customer_id, string? use_customer_default_address)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("draft_orders.json")]
    public Task RetrieveListOfDraftOrdersAsync(string? fieldsQuery, string? ids, string limit, string? since_id, string? status,
        string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("draft_orders/{draft_order_id}.json")]
    public Task ModifyExistingDraftOrderAsync(string draft_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("draft_orders/{draft_order_id}.json")]
    public Task ReceiveSingleDraftOrderAsync(string draft_order_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("draft_orders/{draft_order_id}.json")]
    public Task RemoveExistingDraftOrderAsync(string draft_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("draft_orders/count.json")]
    public Task ReceiveCountOfAllDraftOrdersAsync(string? since_id, string status, string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("draft_orders/{draft_order_id}/send_invoice.json")]
    public Task SendInvoiceAsync(string draft_order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("draft_orders/{draft_order_id}/complete.json")]
    public Task CompleteDraftOrderAsync(string draft_order_id, string? payment_pending)
    {
        throw new NotImplementedException();
    }
}