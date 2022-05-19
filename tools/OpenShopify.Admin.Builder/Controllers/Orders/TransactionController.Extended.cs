using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class TransactionController : TransactionControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/transactions.json")]
    public override Task RetrieveListOfTransactions(long order_id, string? fields, bool? in_shop_currency, int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/transactions.json")]
    public override Task CreateTransactionForOrder(CreateTransactionRequest request, long order_id, string? source)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/transactions/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfOrdersTransactions(long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/transactions/{transaction_id:long}.json")]
    public override Task RetrieveSpecificTransaction(long order_id, long transaction_id, string? fields, bool? in_shop_currency)
    {
        throw new NotImplementedException();
    }
}