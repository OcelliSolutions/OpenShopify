using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;

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


public class AccessScopeList
{
    [JsonPropertyName("access_scopes")]
    public IEnumerable<AccessScope>? AccessScopes { get; set; }
}