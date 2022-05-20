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
    public override Task CreatePriceRule(CreatePriceRuleRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules.json")]
    [ProducesResponseType(typeof(PriceRuleList), StatusCodes.Status200OK)]
    public override Task ListPriceRules(DateTime? created_at_max, DateTime? created_at_min, DateTime? ends_at_max,
        DateTime? ends_at_min, int? limit, string? page_info, int? since_id, DateTime? starts_at_max, DateTime? starts_at_min,
        string? times_used, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("price_rules/{price_rule_id:long}.json")]
    [ProducesResponseType(typeof(PriceRuleItem), StatusCodes.Status200OK)]
    public override Task UpdatePriceRule(UpdatePriceRuleRequest request, long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/{price_rule_id:long}.json")]
    [ProducesResponseType(typeof(PriceRuleItem), StatusCodes.Status200OK)]
    public override Task GetPriceRule(long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("price_rules/{price_rule_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task DeleteExistingPriceRule(long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task GetCountOfAllPriceRules()
    {
        throw new NotImplementedException();
    }
}