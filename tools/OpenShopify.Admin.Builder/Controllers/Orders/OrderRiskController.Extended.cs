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
    public override Task CreateOrderRiskForOrder(CreateOrderRiskRequest request, long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/risks.json")]
    public override Task RetrieveListOfAllOrderRisksForOrder(long order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("orders/{order_id:long}/risks/{risk_id:long}.json")]
    public override Task RetrieveSingleOrderRiskByItsID(long order_id, long risk_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("orders/{order_id:long}/risks/{risk_id:long}.json")]
    public override Task UpdateOrderRisk(UpdateOrderRiskRequest request, long order_id, long risk_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("orders/{order_id:long}/risks/{risk_id:long}.json")]
    public override Task DeleteOrderRiskForOrder(long order_id, long risk_id)
    {
        throw new NotImplementedException();
    }
}