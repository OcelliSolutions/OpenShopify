using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Discounts;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Discounts)]
[ApiController]
public class PriceRuleController : IPriceRuleController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("price_rules.json")]
    public Task CreatePriceRuleAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules.json")]
    public Task RetrieveListOfPriceRulesAsync(string? created_at_max, string? created_at_min, string? ends_at_max,
        string? ends_at_min, string limit, string? since_id, string? starts_at_max, string? starts_at_min,
        string? times_used, string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}.json")]
    public Task UpdateExistingPriceRuleAsync(string price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}.json")]
    public Task RetrieveSinglePriceRuleAsync(string price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}.json")]
    public Task RemoveExistingPriceRuleAsync(string price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/count.json")]
    public Task RetrieveCountOfAllPriceRulesAsync()
    {
        throw new NotImplementedException();
    }
}