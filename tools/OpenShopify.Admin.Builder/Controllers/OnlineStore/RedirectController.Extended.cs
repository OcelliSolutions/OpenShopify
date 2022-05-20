using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class RedirectController : RedirectControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("redirects.json")]
    public override Task ListUrlRedirects(string? fields, int? limit, string? page_info, string? path, int? since_id, string? target)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("redirects.json")]
    public override Task CreateRedirect([Required] CreateRedirectRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("redirects/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountUrlRedirects(string? path, string? target)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("redirects/{redirect_id:long}.json")]
    public override Task GetRedirect([Required] long redirect_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("redirects/{redirect_id:long}.json")]
    public override Task UpdateRedirect([Required] UpdateRedirectRequest request, [Required] long redirect_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("redirects/{redirect_id:long}.json")]
    public override Task DeleteRedirect([Required] long redirect_id)
    {
        throw new NotImplementedException();
    }
}
