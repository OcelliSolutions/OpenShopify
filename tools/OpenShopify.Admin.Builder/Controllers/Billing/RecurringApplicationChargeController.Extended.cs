using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Billing;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Billing)]
[ApiController]
public class RecurringApplicationChargeController : RecurringApplicationChargeControllerBase
{
    /// <inheritdoc />
    [HttpPost]
    [Route("recurring_application_charges.json")]
    [ProducesResponseType(typeof(RecurringApplicationChargeItem), StatusCodes.Status201Created)]
    public override Task CreateRecurringApplicationCharge([Required] CreateRecurringApplicationChargeRequest request) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("recurring_application_charges.json")]
    [ProducesResponseType(typeof(RecurringApplicationChargeList), StatusCodes.Status200OK)]
    public override Task ListRecurringApplicationCharges(string? fields = null, long? since_id = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("recurring_application_charges/{recurring_application_charge_id:long}.json")]
    [ProducesResponseType(typeof(RecurringApplicationChargeItem), StatusCodes.Status200OK)]
    public override Task GetRecurringApplicationCharge([Required] long recurring_application_charge_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("recurring_application_charges/{recurring_application_charge_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task CancelRecurringApplicationCharge([Required] CancelRecurringApplicationChargeRequest request,
        long recurring_application_charge_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [IgnoreApi]
    [HttpPut]
    [Route("recurring_application_charges/{recurring_application_charge_id:long}/customize.invalid")]
    [ProducesResponseType(typeof(RecurringApplicationChargeItem), StatusCodes.Status200OK)]
    public override Task UpdateCappedAmountOfRecurringApplicationCharge(
        [Required] UpdateCappedAmountOfRecurringApplicationChargeRequest request,
        [Required] long recurring_application_charge_id) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="RecurringApplicationChargeControllerBase.UpdateCappedAmountOfRecurringApplicationCharge" />
    [HttpPut]
    [Route("recurring_application_charges/{recurring_application_charge_id:long}/customize.json")]
    [ProducesResponseType(typeof(RecurringApplicationChargeItem), StatusCodes.Status200OK)]
    public Task UpdateCappedAmountOfRecurringApplicationCharge([Required] long recurring_application_charge_id,
        [FromQuery(Name = "recurring_application_charge[capped_amount]")]
        decimal capped_amount) =>
        throw new NotImplementedException();
}