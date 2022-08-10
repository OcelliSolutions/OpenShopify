using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Products;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Products)]
[ApiController]
public class CollectController : CollectControllerBase
{
    /// <inheritdoc />
    [IgnoreApi]
    [HttpPost]
    [Route("collects.invalid")]
    [ProducesResponseType(typeof(CollectItem), StatusCodes.Status201Created)]
    public override Task AddProductToCustomCollection() => throw new NotImplementedException();

    /// <inheritdoc cref="CollectControllerBase.AddProductToCustomCollection" />
    [HttpPost]
    [Route("collects.json")]
    [ProducesResponseType(typeof(CollectItem), StatusCodes.Status201Created)]
    public Task AddProductToCustomCollection(CollectItem request) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("collects.json")]
    [ProducesResponseType(typeof(CollectList), StatusCodes.Status200OK)]
    public override Task ListCollects(string? fields = null, int? limit = null, string? page_info = null,
        long? since_id = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("collects/{collect_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteProductFromCollection([Required] long collect_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("collects/{collect_id:long}.json")]
    [ProducesResponseType(typeof(CollectItem), StatusCodes.Status200OK)]
    public override Task GetCollect([Required] long collect_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("collects/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountCollects() => throw new NotImplementedException();
}