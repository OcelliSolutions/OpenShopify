using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class AssetController : IAssetController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("themes/{theme_id}/assets.json")]
    public Task RetrieveListOfAssetsForThemeAsync(string theme_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("themes/{theme_id}/assets.json")]
    public Task CreateOrUpdatesAssetForThemeAsync(string theme_id, string? source_key, string? src)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("themes/{theme_id}/assets.json")]
    public Task DeleteAssetFromThemeAsync(string assetkey, string theme_id)
    {
        throw new NotImplementedException();
    }
}