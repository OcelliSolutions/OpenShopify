using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class ThemeController : ThemeControllerBase
{
    public override Task RetrieveListOfThemes(string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateTheme()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleThemeByItsID(string theme_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task ModifyExistingTheme(string theme_id)
    {
        throw new NotImplementedException();
    }

    public override Task RemoveExistingTheme(string theme_id)
    {
        throw new NotImplementedException();
    }
}