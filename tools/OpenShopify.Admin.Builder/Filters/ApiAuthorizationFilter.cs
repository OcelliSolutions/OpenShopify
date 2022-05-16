using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.OpenApi.Extensions;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Filters;

/// <summary>
///     If there are ApiPermissions attributed to a controller action, create a concatenated string of all the assigned
///     permissions.
/// </summary>
public class ApiAuthorizationFilter : ActionFilterAttribute
{
    private readonly List<AuthorizationScope>? _apiPermissions;
    public ApiAuthorizationFilter() { }

    public ApiAuthorizationFilter(AuthorizationScope[] permissions)
    {
        _apiPermissions = new List<AuthorizationScope>();
        _apiPermissions.AddRange(permissions);
    }

    public string PermissionDescription
    {
        get
        {
            if (_apiPermissions == null || !_apiPermissions.Any()) return "<i>none</i>";
            var displayNames = _apiPermissions.Select(permission => permission.GetDisplayName());
            return string.Join(" • ", displayNames);
        }
    }
}