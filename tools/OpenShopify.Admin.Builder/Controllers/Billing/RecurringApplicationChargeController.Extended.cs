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
    public override Task CreateRecurringApplicationCharge([Required] RecurringApplicationChargeItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("recurring_application_charges.json")]
    [ProducesResponseType(typeof(RecurringApplicationChargeList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfRecurringApplicationCharges(string? fields, int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("recurring_application_charges/{recurring_application_charge_id:long}.json")]
    [ProducesResponseType(typeof(RecurringApplicationChargeItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleCharge(long recurring_application_charge_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("recurring_application_charges/{recurring_application_charge_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task CancelRecurringApplicationCharge(long recurring_application_charge_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [IgnoreApi, HttpPut, Route("recurring_application_charges/{recurring_application_charge_id:long}/customize.invalid")]
    [ProducesResponseType(typeof(RecurringApplicationChargeItem), StatusCodes.Status200OK)]
    public override Task UpdateCappedAmountOfRecurringApplicationCharge(RecurringApplicationChargeItem request,
        long recurring_application_charge_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="RecurringApplicationChargeControllerBase.UpdateTheCappedAmountOfRecurringApplicationCharge" />
    [HttpPut, Route("recurring_application_charges/{recurring_application_charge_id:long}/customize.json")]
    [ProducesResponseType(typeof(RecurringApplicationChargeItem), StatusCodes.Status200OK)]
    public Task UpdateTheCappedAmountOfRecurringApplicationCharge(long recurring_application_charge_id, decimal capped_amount)
    {
        throw new NotImplementedException();
    }
}