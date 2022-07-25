using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.ShippingAndFulfillment;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.ShippingAndFulfillment)]
[ApiController]
public class LocationsForMoveController : LocationsForMoveControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("fulfillment_orders/{fulfillment_order_id:long}/locations_for_move.json")]
    [ProducesResponseType(typeof(LocationsForMoveList), StatusCodes.Status200OK)]
    public override Task ListLocationsThatFulfillmentOrderCanPotentiallyMoveTo([Required] long fulfillment_order_id) =>
        throw new NotImplementedException();
}