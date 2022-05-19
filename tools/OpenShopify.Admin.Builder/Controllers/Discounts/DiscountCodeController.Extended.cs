using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Discounts;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Discounts)]
[ApiController]
public class DiscountCodeController : DiscountCodeControllerBase
{
    /// <inheritdoc />
    [HttpPost, Route("price_rules/{price_rule_id:long}/discount_codes.json")]
    [ProducesResponseType(typeof(DiscountCodeItem), StatusCodes.Status201Created)]
    public override Task CreateDiscountCode(DiscountCodeItem request, long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/{price_rule_id:long}/discount_codes.json")]
    [ProducesResponseType(typeof(DiscountCodeList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfDiscountCodes(long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("price_rules/{price_rule_id:long}/discount_codes/{discount_code_id:long}.json")]
    [ProducesResponseType(typeof(DiscountCodeItem), StatusCodes.Status200OK)]
    public override Task UpdateExistingDiscountCode(DiscountCodeItem request, long discount_code_id, long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/{price_rule_id:long}/discount_codes/{discount_code_id:long}.json")]
    [ProducesResponseType(typeof(DiscountCodeItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleDiscountCode(long discount_code_id, long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("price_rules/{price_rule_id:long}/discount_codes/{discount_code_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task DeleteDiscountCode(long discount_code_id, long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("discount_codes/lookup.json")]
    [ProducesResponseType(StatusCodes.Status303SeeOther)]
    public override Task RetrieveLocationOfDiscountCode(string code)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("discount_codes/count.json")]
    [ProducesResponseType(typeof(DiscountCodeCount), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfDiscountCodesForShop(string? times_used, string? times_used_max, string? times_used_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("price_rules/{price_rule_id:long}/batch.json")]
    [ProducesResponseType(typeof(DiscountCodeCreationItem), StatusCodes.Status201Created)]
    public override Task CreateDiscountCodeCreationJob(DiscountCodeItem request, long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/{price_rule_id:long}/batch/{batch_id:long}.json")]
    [ProducesResponseType(typeof(DiscountCodeCreationItem), StatusCodes.Status200OK)]
    public override Task RetrieveDiscountCodeCreationJob(long batch_id, long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/{price_rule_id:long}/batch/{batch_id:long}/discount_codes.json")]
    [ProducesResponseType(typeof(DiscountCodeList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfDiscountCodesForDiscountCodeCreationJob(long batch_id, long price_rule_id)
    {
        throw new NotImplementedException();
    }
}
