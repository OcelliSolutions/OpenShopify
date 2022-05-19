using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.StoreProperties;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.StoreProperties)]
[ApiController]
public class PolicyController : PolicyControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("policies.json")]
    public override Task RetrieveListOfShopsPolicies()
    {
        throw new NotImplementedException();
    }
}