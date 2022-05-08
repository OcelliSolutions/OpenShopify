using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class AssetController : AssetControllerBase
{
    public override Task RetrieveListOfAssetsForTheme(string theme_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateOrUpdatesAssetForTheme(string theme_id, string? source_key = null, string? src = null)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAssetFromTheme(string assetkey, string theme_id)
    {
        throw new NotImplementedException();
    }
}