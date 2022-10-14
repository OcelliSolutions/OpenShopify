using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Orders;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Orders)]
[ApiController]
public class AbandonedCheckoutsController : AbandonedCheckoutsControllerBase
{
    /*
    /// <inheritdoc />
    [IgnoreApi]
    [HttpGet]
    [Route("checkouts.invalid")]
    [ProducesResponseType(typeof(AbandonedCheckoutList), StatusCodes.Status200OK)]
    public override Task ListAbandonedCheckouts(DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null,
        int? limit = null, string? page_info = null, long? since_id = null, string? status = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="AbandonedCheckoutsControllerBase.ListAbandonedCheckouts" />
    */

    //TODO: This is a strange anomaly where two endpoints in the docs have the same route. This may be an error on Shopify's part.
    [HttpGet]
    [Route("checkouts.json")]
    [ProducesResponseType(typeof(AbandonedCheckoutList), StatusCodes.Status200OK)]
    public Task ListAbandonedCheckouts(DateTimeOffset? created_at_max = null,
        DateTimeOffset? created_at_min = null,
        int? limit = null, string? page_info = null, long? since_id = null, AbandonedCheckoutStatusRequest? status = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("count.json")]
    [ProducesResponseType(typeof(AbandonedCheckoutList), StatusCodes.Status200OK)]
    public override Task CountCheckouts(DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null, long? since_id = null,
        string? status = null, DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null) =>
        throw new NotImplementedException();
}