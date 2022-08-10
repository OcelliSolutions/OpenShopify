using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class RedirectController : RedirectControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("redirects.json")]
    [ProducesResponseType(typeof(RedirectList), StatusCodes.Status200OK)]
    public override Task ListUrlRedirects(string? fields = null, int? limit = null, string? page_info = null,
        string? path = null, long? since_id = null, string? target = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("redirects.json")]
    [ProducesResponseType(typeof(RedirectItem), StatusCodes.Status201Created)]
    public override Task CreateRedirect([Required] CreateRedirectRequest request) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("redirects/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountUrlRedirects(string? path = null, string? target = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("redirects/{redirect_id:long}.json")]
    [ProducesResponseType(typeof(RedirectItem), StatusCodes.Status200OK)]
    public override Task GetRedirect([Required] long redirect_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("redirects/{redirect_id:long}.json")]
    [ProducesResponseType(typeof(RedirectItem), StatusCodes.Status200OK)]
    public override Task UpdateRedirect([Required] UpdateRedirectRequest request, [Required] long redirect_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("redirects/{redirect_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteRedirect([Required] long redirect_id) => throw new NotImplementedException();
}