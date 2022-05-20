using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.DeprecatedApiCalls;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.DeprecatedApiCalls)]
[ApiController]
public class DeprecatedApiCallsController : DeprecatedAPICallsControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("deprecated_api_calls.json")]
    [ProducesResponseType(typeof(DeprecatedApiCallList), StatusCodes.Status200OK)]
    public override Task ListDeprecatedAPICalls()
    {
        throw new NotImplementedException();
    }
}