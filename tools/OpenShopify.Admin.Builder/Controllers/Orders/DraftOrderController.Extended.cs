using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class DraftOrderController : DraftOrderControllerBase
{
    public override Task CreateNewDraftorder(string? customer_id = null, string? use_customer_default_address = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfDraftOrders(string? fieldsQuery = null, string? ids = null, string? limit = "50",
        string? since_id = null, string? status = null, string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task ModifyExistingDraftorder(string draft_order_id)
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveSingleDraftorder(string draft_order_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task RemoveExistingDraftorder(string draft_order_id)
    {
        throw new NotImplementedException();
    }

    public override Task ReceiveCountOfAllDraftorders(string? since_id = null, string? status = "open", string? updated_at_max = null,
        string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task SendInvoice(string draft_order_id)
    {
        throw new NotImplementedException();
    }

    public override Task CompleteDraftOrder(string draft_order_id, string? payment_pending = null)
    {
        throw new NotImplementedException();
    }
}