using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
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
    [ProducesResponseType(typeof(PolicyList), StatusCodes.Status200OK)]
    public override Task ListShopsPolicies()
    {
        throw new NotImplementedException();
    }
}