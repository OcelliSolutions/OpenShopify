using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.DeprecatedApiCalls;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.DeprecatedApiCalls)]
[ApiController]
public class DeprecatedApiCallsController : IDeprecatedAPICallsController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("deprecated_api_calls.json")]
    public Task RetrieveListOfDeprecatedAPICallsAsync()
    {
        throw new NotImplementedException();
    }
}