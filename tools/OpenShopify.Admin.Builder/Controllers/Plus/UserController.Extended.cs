using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Plus;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Plus)]
[ApiController]
public class UserController : UserControllerBase
{
    public override Task RetrieveListOfAllUsers(string? limit = "50", string? page_info = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleUser(string user_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveTheCurrentlyLoggedInUser()
    {
        throw new NotImplementedException();
    }
}