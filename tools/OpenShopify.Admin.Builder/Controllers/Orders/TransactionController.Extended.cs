using System.ComponentModel.DataAnnotations;
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
    [ProducesResponseType(typeof(TransactionList), StatusCodes.Status200OK)]
    public override Task ListTransactions([Required] long order_id, string? fields = null, bool? in_shop_currency = null, long? since_id = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/transactions.json")]
    [ProducesResponseType(typeof(TransactionItem), StatusCodes.Status201Created)]
    public override Task CreateTransactionForOrder([Required] CreateTransactionRequest request, [Required] long order_id, string? source = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/transactions/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountOrdersTransactions(long? order_id = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/transactions/{transaction_id:long}.json")]
    [ProducesResponseType(typeof(TransactionItem), StatusCodes.Status200OK)]
    public override Task GetSpecificTransaction([Required] long order_id, [Required] long transaction_id, string? fields = null, bool? in_shop_currency = null)
    {
        throw new NotImplementedException();
    }
}