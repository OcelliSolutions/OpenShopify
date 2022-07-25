using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Plus;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Plus)]
[ApiController]
public class UserController : UserControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("users.json")]
    [ProducesResponseType(typeof(UserList), StatusCodes.Status200OK)]
    public override Task ListUsers(int? limit = null, string? page_info = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("users/{user_id:long}.json")]
    [ProducesResponseType(typeof(UserItem), StatusCodes.Status200OK)]
    public override Task GetUser([Required] long user_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("users/current.json")]
    [ProducesResponseType(typeof(UserItem), StatusCodes.Status200OK)]
    public override Task GetCurrentlyLoggedInUser() => throw new NotImplementedException();
}