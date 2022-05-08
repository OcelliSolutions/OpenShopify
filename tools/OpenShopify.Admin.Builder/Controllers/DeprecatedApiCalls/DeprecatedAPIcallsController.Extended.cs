using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.DeprecatedApiCalls;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.DeprecatedApiCalls)]
[ApiController]
public class DeprecatedApiCallsController : DeprecatedAPICallsControllerBase
{
    public override Task RetrieveListOfDeprecatedAPICalls()
    {
        throw new NotImplementedException();
    }
}