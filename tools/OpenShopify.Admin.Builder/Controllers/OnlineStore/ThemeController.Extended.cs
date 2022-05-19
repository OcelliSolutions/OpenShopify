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
    public override Task RetrieveListOfThemes(string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("themes.json")]
    public override Task CreateTheme(ThemeItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("themes/{theme_id:long}.json")]
    public override Task RetrieveSingleThemeByItsID(long theme_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("themes/{theme_id:long}.json")]
    public override Task ModifyExistingTheme(ThemeItem request, long theme_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("themes/{theme_id:long}.json")]
    public override Task RemoveExistingTheme(long theme_id)
    {
        throw new NotImplementedException();
    }
}