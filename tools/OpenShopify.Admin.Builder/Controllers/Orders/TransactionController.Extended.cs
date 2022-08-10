using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class TransactionController : TransactionControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("orders/{order_id:long}/transactions.json")]
    [ProducesResponseType(typeof(TransactionList), StatusCodes.Status200OK)]
    public override Task ListTransactions([Required] long order_id, string? fields = null,
        bool? in_shop_currency = null, long? since_id = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("orders/{order_id:long}/transactions.json")]
    [ProducesResponseType(typeof(TransactionItem), StatusCodes.Status201Created)]
    public override Task CreateTransaction([Required] CreateTransactionRequest forOrderRequest,
        [Required] long order_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("orders/{order_id:long}/transactions/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountOrdersTransactions(long? order_id = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("orders/{order_id:long}/transactions/{transaction_id:long}.json")]
    [ProducesResponseType(typeof(TransactionItem), StatusCodes.Status200OK)]
    public override Task GetTransaction([Required] long order_id, [Required] long transaction_id, string? fields = null,
        bool? in_shop_currency = null) => throw new NotImplementedException();
}