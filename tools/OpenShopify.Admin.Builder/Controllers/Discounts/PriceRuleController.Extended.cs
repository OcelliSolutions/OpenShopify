using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Discounts;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Discounts)]
[ApiController]
public class PriceRuleController : PriceRuleControllerBase
{
    /// <inheritdoc />
    [HttpPost, Route("price_rules.json")]
    [ProducesResponseType(typeof(PriceRuleItem), StatusCodes.Status201Created)]
    public override Task CreatePriceRule(PriceRuleItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules.json")]
    [ProducesResponseType(typeof(PriceRuleList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfPriceRules(DateTime? created_at_max, DateTime? created_at_min, DateTime? ends_at_max,
        DateTime? ends_at_min, int? limit, string? page_info, int? since_id, DateTime? starts_at_max, DateTime? starts_at_min,
        string? times_used, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("price_rules/{price_rule_id:long}.json")]
    [ProducesResponseType(typeof(PriceRuleItem), StatusCodes.Status200OK)]
    public override Task UpdateExistingPriceRule(PriceRuleItem request, long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/{price_rule_id:long}.json")]
    [ProducesResponseType(typeof(PriceRuleItem), StatusCodes.Status200OK)]
    public override Task RetrieveSinglePriceRule(long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("price_rules/{price_rule_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task RemoveExistingPriceRule(long price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("price_rules/count.json")]
    [ProducesResponseType(typeof(PriceRuleCount), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfAllPriceRules()
    {
        throw new NotImplementedException();
    }
}