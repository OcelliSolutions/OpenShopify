using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.StoreProperties;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.StoreProperties)]
[ApiController]
public class PolicyController : PolicyControllerBase
{
    public override Task RetrieveListOfTheShopsPolicies()
    {
        throw new NotImplementedException();
    }
}