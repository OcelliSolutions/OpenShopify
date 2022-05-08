using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class TransactionController : TransactionControllerBase
{
    public override Task RetrieveListOfTransactions(string order_id, string? fields = null, string? in_shop_currency = "false",
        string? since_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateTransactionForOrder(string order_id, string? source = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfOrdersTransactions(string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSpecificTransaction(string order_id, string transaction_id, string? fields = null,
        string? in_shop_currency = "false")
    {
        throw new NotImplementedException();
    }
}