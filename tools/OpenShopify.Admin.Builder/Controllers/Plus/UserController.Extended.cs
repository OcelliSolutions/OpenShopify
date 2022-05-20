using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Plus;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Plus)]
[ApiController]
public class UserController : UserControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("users.json")]
    public override Task ListUsers(int? limit, string? page_info)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("users/{user_id:long}.json")]
    public override Task GetUser([Required] long user_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("users/current.json")]
    public override Task GetCurrentlyLoggedInUser()
    {
        throw new NotImplementedException();
    }
}