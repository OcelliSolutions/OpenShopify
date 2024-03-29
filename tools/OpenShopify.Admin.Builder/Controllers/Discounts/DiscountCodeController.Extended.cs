using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Discounts;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Discounts)]
[ApiController]
public class DiscountCodeController : DiscountCodeControllerBase
{
    /// <inheritdoc />
    [HttpPost]
    [Route("price_rules/{price_rule_id:long}/discount_codes.json")]
    [ProducesResponseType(typeof(DiscountCodeItem), StatusCodes.Status201Created)]
    public override Task CreateDiscountCode([Required] CreateDiscountCodeRequest creationJobRequest,
        [Required] long price_rule_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("price_rules/{price_rule_id:long}/discount_codes.json")]
    [ProducesResponseType(typeof(DiscountCodeList), StatusCodes.Status200OK)]
    public override Task ListDiscountCodes([Required] long price_rule_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("price_rules/{price_rule_id:long}/discount_codes/{discount_code_id:long}.json")]
    [ProducesResponseType(typeof(DiscountCodeItem), StatusCodes.Status200OK)]
    public override Task UpdateDiscountCode([Required] UpdateDiscountCodeRequest request,
        [Required] long discount_code_id, [Required] long price_rule_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("price_rules/{price_rule_id:long}/discount_codes/{discount_code_id:long}.json")]
    [ProducesResponseType(typeof(DiscountCodeItem), StatusCodes.Status200OK)]
    public override Task GetDiscountCode([Required] long discount_code_id, [Required] long price_rule_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("price_rules/{price_rule_id:long}/discount_codes/{discount_code_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task DeleteDiscountCode([Required] long discount_code_id, [Required] long price_rule_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("discount_codes/lookup.json")]
    [ProducesResponseType(typeof(DiscountCodeItem), StatusCodes.Status200OK)]
    public override Task GetLocationOfDiscountCode(string code) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("discount_codes/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountDiscountCodesForShop(int? times_used = null, int? times_used_max = null,
        int? times_used_min = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [IgnoreApi]
    [HttpPost]
    [Route("price_rules/{price_rule_id:long}/batch.invalid")]
    [ProducesResponseType(typeof(DiscountCodeCreationItem), StatusCodes.Status201Created)]
    public override Task CreateDiscountCodeCreationJob(
        [Required] CreateDiscountCodeCreationJobRequest creationJobRequest, [Required] long price_rule_id) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="DiscountCodeControllerBase.CreateDiscountCodeCreationJob" />
    [HttpPost]
    [Route("price_rules/{price_rule_id:long}/batch.json")]
    [ProducesResponseType(typeof(DiscountCodeCreationItem), StatusCodes.Status201Created)]
    public Task CreateDiscountCodeCreationJob([Required] CreateDiscountCodeBatchRequest request,
        [Required] long price_rule_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("price_rules/{price_rule_id:long}/batch/{batch_id:long}.json")]
    [ProducesResponseType(typeof(DiscountCodeCreationItem), StatusCodes.Status200OK)]
    public override Task GetDiscountCodeCreationJob([Required] long batch_id, [Required] long price_rule_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("price_rules/{price_rule_id:long}/batch/{batch_id:long}/discount_codes.json")]
    [ProducesResponseType(typeof(DiscountCodeList), StatusCodes.Status200OK)]
    public override Task ListDiscountCodesForDiscountCodeCreationJob([Required] long batch_id,
        [Required] long price_rule_id) => throw new NotImplementedException();
}