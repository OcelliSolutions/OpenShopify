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
    public override Task CreateDiscountCode(CreateDiscountCodeRequest request, long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/{price_rule_id:long}/discount_codes.json")]
    [ProducesResponseType(typeof(DiscountCodeList), StatusCodes.Status200OK)]
    public override Task ListDiscountCodes(long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("price_rules/{price_rule_id:long}/discount_codes/{discount_code_id:long}.json")]
    [ProducesResponseType(typeof(DiscountCodeItem), StatusCodes.Status200OK)]
    public override Task UpdateDiscountCode(UpdateDiscountCodeRequest request, long discount_code_id, long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/{price_rule_id:long}/discount_codes/{discount_code_id:long}.json")]
    [ProducesResponseType(typeof(DiscountCodeItem), StatusCodes.Status200OK)]
    public override Task GetDiscountCode(long discount_code_id, long price_rule_id)
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
    public override Task GetLocationOfDiscountCode(string code)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("discount_codes/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task GetCountOfDiscountCodesForShop(string? times_used, string? times_used_max, string? times_used_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("price_rules/{price_rule_id:long}/batch.json")]
    [ProducesResponseType(typeof(DiscountCodeCreationItem), StatusCodes.Status201Created)]
    public override Task CreateDiscountCodeCreationJob(CreateDiscountCodeRequest request, long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/{price_rule_id:long}/batch/{batch_id:long}.json")]
    [ProducesResponseType(typeof(DiscountCodeCreationItem), StatusCodes.Status200OK)]
    public override Task GetDiscountCodeCreationJob(long batch_id, long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/{price_rule_id:long}/batch/{batch_id:long}/discount_codes.json")]
    [ProducesResponseType(typeof(DiscountCodeList), StatusCodes.Status200OK)]
    public override Task ListDiscountCodesForDiscountCodeCreationJob(long batch_id, long price_rule_id)
    {
        throw new NotImplementedException();
    }
}
