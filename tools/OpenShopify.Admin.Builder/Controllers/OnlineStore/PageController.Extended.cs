using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.OnlineStore;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.OnlineStore)]
[ApiController]
public class PageController : PageControllerBase
{
    /// <inheritdoc />
    [IgnoreApi]
    [HttpGet]
    [Route("pages.invalid")]
    [ProducesResponseType(typeof(PageList), StatusCodes.Status200OK)]
    public override Task ListPages(DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null,
        string? fields = null, string? handle = null,
        int? limit = null, string? page_info = null, DateTimeOffset? published_at_max = null,
        DateTimeOffset? published_at_min = null, string? published_status = null, long? since_id = null,
        string? title = null, DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="PageControllerBase.ListPages" />
    [HttpGet]
    [Route("pages.json")]
    [ProducesResponseType(typeof(PageList), StatusCodes.Status200OK)]
    public Task ListPages(DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null,
        string? fields = null, string? handle = null,
        int? limit = null, string? page_info = null, DateTimeOffset? published_at_max = null,
        DateTimeOffset? published_at_min = null, PagePublishStatus? published_status = null, long? since_id = null,
        string? title = null, DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("pages.json")]
    [ProducesResponseType(typeof(PageItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(PageError), StatusCodes.Status400BadRequest)]
    public override Task CreatePage([Required] CreatePageRequest request) => throw new NotImplementedException();

    /// <inheritdoc />
    [IgnoreApi]
    [HttpGet]
    [Route("pages/count.invalid")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task GetPageCount(DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null,
        DateTimeOffset? published_at_max = null,
        DateTimeOffset? published_at_min = null, string? published_status = null, string? title = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();


    /// <inheritdoc cref="PageControllerBase.GetPageCount" />
    [HttpGet]
    [Route("pages/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public Task GetPageCount(DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null,
        DateTimeOffset? published_at_max = null,
        DateTimeOffset? published_at_min = null, PagePublishStatus? published_status = null, string? title = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("pages/{page_id:long}.json")]
    [ProducesResponseType(typeof(PageItem), StatusCodes.Status200OK)]
    public override Task GetPage([Required] long page_id, string? fields = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("pages/{page_id:long}.json")]
    [ProducesResponseType(typeof(PageItem), StatusCodes.Status200OK)]
    public override Task UpdatePage([Required] UpdatePageRequest request, [Required] long page_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("pages/{page_id:long}.json")]
    [ProducesResponseType(typeof(PageItem), StatusCodes.Status200OK)]
    public override Task DeletePage([Required] long page_id) => throw new NotImplementedException();
}