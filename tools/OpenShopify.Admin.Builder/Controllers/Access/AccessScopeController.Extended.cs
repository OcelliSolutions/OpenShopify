using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Access;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Access)]
[ApiController]
public class AccessScopeController : AccessScopeControllerBase
{
    /// <inheritdoc />
    [ProducesResponseType(typeof(AccessScopeList), StatusCodes.Status200OK)]
    public override Task GetListOfAccessScopes()
    {
        throw new NotImplementedException();
    }
}
