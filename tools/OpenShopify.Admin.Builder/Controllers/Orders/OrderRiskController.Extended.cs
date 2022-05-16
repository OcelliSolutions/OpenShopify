using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class OrderRiskController : IOrderRiskController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/risks.json")]
    public Task CreateOrderRiskForOrderAsync(string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/risks.json")]
    public Task RetrieveListOfAllOrderRisksForOrderAsync(string order_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/risks/{risk_id}.json")]
    public Task RetrieveSingleOrderRiskByItsIDAsync(string order_id, string risk_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/risks/{risk_id}.json")]
    public Task UpdateOrderRiskAsync(string order_id, string risk_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("orders/{order_id}/risks/{risk_id}.json")]
    public Task DeleteOrderRiskForOrderAsync(string order_id, string risk_id)
    {
        throw new NotImplementedException();
    }
}