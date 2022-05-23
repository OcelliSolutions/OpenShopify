using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class ThemeController : ThemeControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("themes.json")]
    public override Task ListThemes(string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("themes.json")]
    public override Task CreateTheme([Required] CreateThemeRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("themes/{theme_id:long}.json")]
    public override Task GetThemeByItsID([Required] long theme_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("themes/{theme_id:long}.json")]
    public override Task UpdateTheme([Required] UpdateThemeRequest request, [Required] long theme_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("themes/{theme_id:long}.json")]
    public override Task DeleteTheme([Required] long theme_id)
    {
        throw new NotImplementedException();
    }
}