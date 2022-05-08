using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class OrderRiskController : OrderRiskControllerBase
{
    public override Task CreateOrderRiskForOrder(string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfAllOrderRisksForOrder(string order_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleOrderRiskByItsID(string order_id, string risk_id)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateOrderRisk(string order_id, string risk_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteOrderRiskForOrder(string order_id, string risk_id)
    {
        throw new NotImplementedException();
    }
}