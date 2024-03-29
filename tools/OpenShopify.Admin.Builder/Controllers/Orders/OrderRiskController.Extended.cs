using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class OrderRiskController : OrderRiskControllerBase
{
    /// <inheritdoc />
    [HttpPost]
    [Route("orders/{order_id:long}/risks.json")]
    [ProducesResponseType(typeof(OrderRiskItem), StatusCodes.Status201Created)]
    public override Task CreateOrderRiskForOrder(CreateOrderRiskForOrderRequest request, long order_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("orders/{order_id:long}/risks.json")]
    [ProducesResponseType(typeof(OrderRiskList), StatusCodes.Status200OK)]
    public override Task ListOrderRisksForOrder(long order_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("orders/{order_id:long}/risks/{risk_id:long}.json")]
    [ProducesResponseType(typeof(OrderRiskItem), StatusCodes.Status200OK)]
    public override Task GetOrderRisk([Required] long order_id, [Required] long risk_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("orders/{order_id:long}/risks/{risk_id:long}.json")]
    [ProducesResponseType(typeof(OrderRiskItem), StatusCodes.Status200OK)]
    public override Task UpdateOrderRisk([Required] UpdateOrderRiskRequest request, [Required] long order_id,
        [Required] long risk_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("orders/{order_id:long}/risks/{risk_id:long}.json")]
    [ProducesResponseType(typeof(OrderRiskItem), StatusCodes.Status200OK)]
    public override Task DeleteOrderRiskForOrder(long order_id, long risk_id) => throw new NotImplementedException();
}