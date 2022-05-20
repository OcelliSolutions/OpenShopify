using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class AssetController : AssetControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("themes/{theme_id:long}/assets.json")]
    public override Task ListAssetsForTheme([Required] long theme_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("themes/{theme_id:long}/assets.json")]
    public override Task CreateOrUpdatesAssetForTheme([Required] CreateAssetRequest request, [Required] long theme_id, string? source_key, string? src)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("themes/{theme_id:long}/assets.json")]
    public override Task DeleteAssetFromTheme(string assetkey, [Required] long theme_id)
    {
        throw new NotImplementedException();
    }
}