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
    [HttpPost, Route("orders/{order_id:long}/risks.json")]
    [ProducesResponseType(typeof(OrderRiskItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(OrderRiskError), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(OrderRiskGeneralError), StatusCodes.Status400BadRequest)]
    public override Task CreateOrderRisk([Required] CreateOrderRiskRequest forOrderRequest, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/risks.json")]
    [ProducesResponseType(typeof(OrderRiskList), StatusCodes.Status200OK)]
    public override Task ListOrderRisks([Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/risks/{risk_id:long}.json")]
    [ProducesResponseType(typeof(OrderRiskItem), StatusCodes.Status200OK)]
    public override Task GetOrderRisk([Required] long order_id, [Required] long risk_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("orders/{order_id:long}/risks/{risk_id:long}.json")]
    [ProducesResponseType(typeof(OrderRiskItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OrderRiskError), StatusCodes.Status422UnprocessableEntity)]
    public override Task UpdateOrderRisk([Required] UpdateOrderRiskRequest request, [Required] long order_id, [Required] long risk_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("orders/{order_id:long}/risks/{risk_id:long}.json")]
    [ProducesResponseType(typeof(OrderRiskItem), StatusCodes.Status200OK)]
    public override Task DeleteOrderRisk([Required] long order_id, [Required] long risk_id)
    {
        throw new NotImplementedException();
    }
}