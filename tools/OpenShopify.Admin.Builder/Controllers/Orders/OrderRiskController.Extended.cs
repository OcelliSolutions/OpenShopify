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
    public override Task CreateOrderRiskForOrder([Required] CreateOrderRiskRequest request, [Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/risks.json")]
    public override Task ListOrderRisksForOrder([Required] long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/risks/{risk_id:long}.json")]
    public override Task GetOrderRiskByItsID([Required] long order_id, [Required] long risk_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("orders/{order_id:long}/risks/{risk_id:long}.json")]
    public override Task UpdateOrderRisk([Required] UpdateOrderRiskRequest request, [Required] long order_id, [Required] long risk_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("orders/{order_id:long}/risks/{risk_id:long}.json")]
    public override Task DeleteOrderRiskForOrder([Required] long order_id, [Required] long risk_id)
    {
        throw new NotImplementedException();
    }
}