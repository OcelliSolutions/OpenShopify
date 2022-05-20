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
    public override Task ListTransactions([Required] long order_id, string? fields, bool? in_shop_currency, int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("orders/{order_id:long}/transactions.json")]
    public override Task CreateTransactionForOrder([Required] CreateTransactionRequest request, [Required] long order_id, string? source)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/transactions/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountOrdersTransactions([Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/transactions/{transaction_id:long}.json")]
    public override Task GetSpecificTransaction([Required] long order_id, [Required] long transaction_id, string? fields, bool? in_shop_currency)
    {
        throw new NotImplementedException();
    }
}