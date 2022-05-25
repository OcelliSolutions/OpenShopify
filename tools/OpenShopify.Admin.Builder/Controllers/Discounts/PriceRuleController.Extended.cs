using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Discounts;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Discounts)]
[ApiController]
public class PriceRuleController : PriceRuleControllerBase
{
    /// <inheritdoc />
    [HttpPost, Route("price_rules.json")]
    [ProducesResponseType(typeof(PriceRuleItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(PriceRuleError), StatusCodes.Status422UnprocessableEntity)]
    public override Task CreatePriceRule([Required] CreatePriceRuleRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules.json")]
    [ProducesResponseType(typeof(PriceRuleList), StatusCodes.Status200OK)]
    public override Task ListPriceRules(DateTimeOffset? created_at_max = null, DateTimeOffset? created_at_min = null, DateTimeOffset? ends_at_max = null,
        DateTimeOffset? ends_at_min = null, int? limit = null, string? page_info = null, long? since_id = null, DateTimeOffset? starts_at_max = null, DateTimeOffset? starts_at_min = null,
        int? times_used = null, DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("price_rules/{price_rule_id:long}.json")]
    [ProducesResponseType(typeof(PriceRuleItem), StatusCodes.Status200OK)]
    public override Task UpdatePriceRule([Required] UpdatePriceRuleRequest request, [Required] long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/{price_rule_id:long}.json")]
    [ProducesResponseType(typeof(PriceRuleItem), StatusCodes.Status200OK)]
    public override Task GetPriceRule([Required] long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("price_rules/{price_rule_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task DeletePriceRule([Required] long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountPriceRules()
    {
        throw new NotImplementedException();
    }
}