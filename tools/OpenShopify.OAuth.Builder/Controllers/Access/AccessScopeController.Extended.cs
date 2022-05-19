using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Common.Models;

namespace OpenShopify.OAuth.Builder.Controllers.Access;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.AccessOAuth)]
[ApiController]
public class AccessScopeController : AccessScopeControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("oauth/access_scopes.json")]
    [ProducesResponseType(typeof(AccessScopeList), StatusCodes.Status200OK)]
    public override Task GetListOfAccessScopes()
    {
        throw new NotImplementedException();
    }
}


public class AccessScopeList
{
    [JsonPropertyName("access_scopes")]
    public IEnumerable<AccessScope>? AccessScopes { get; set; }
}