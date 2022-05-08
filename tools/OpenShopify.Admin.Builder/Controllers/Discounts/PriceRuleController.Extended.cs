using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Discounts;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Discounts)]
[ApiController]
public class PriceRuleController : PriceRuleControllerBase
{
    public override Task CreatePriceRule()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfPriceRules(string? created_at_max = null, string? created_at_min = null, string? ends_at_max = null,
        string? ends_at_min = null, string? limit = "50", string? since_id = null, string? starts_at_max = null,
        string? starts_at_min = null, string? times_used = null, string? updated_at_max = null,
        string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateExistingPriceRule(string price_rule_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSinglePriceRule(string price_rule_id)
    {
        throw new NotImplementedException();
    }

    public override Task RemoveExistingPricerule(string price_rule_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfAllPriceRules()
    {
        throw new NotImplementedException();
    }
}