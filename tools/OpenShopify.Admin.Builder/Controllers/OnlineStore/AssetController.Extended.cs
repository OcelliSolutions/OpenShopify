using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class AssetController : AssetControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("themes/{theme_id:long}/assets.json")]
    [ProducesResponseType(typeof(AssetList), StatusCodes.Status200OK)]
    public override Task ListAssetsForTheme([Required] long theme_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("themes/{theme_id:long}/assets.json")]
    [ProducesResponseType(typeof(AssetItem), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public override Task CreateOrUpdatesAssetForTheme([Required] CreateAssetRequest request, [Required] long theme_id, string? source_key = null, string? src = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [IgnoreApi, HttpDelete, Route("themes/{theme_id:long}/assets.invalid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteAssetFromTheme(string? assetkey = null, long? theme_id = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="AssetControllerBase.DeleteAssetFromTheme" />
    [HttpDelete, Route("themes/{theme_id:long}/assets.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task DeleteAssetFromTheme(long theme_id, [FromQuery(Name = "asset[key]")] string asset_key)
    {
        throw new NotImplementedException();
    }
}