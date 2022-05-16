using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Discounts;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Discounts)]
[ApiController]
public class DiscountCodeController : IDiscountCodeController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes.json")]
    public Task CreateDiscountCodeAsync(string price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes.json")]
    public Task RetrieveListOfDiscountCodesAsync(string price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes/{discount_code_id}.json")]
    public Task UpdateExistingDiscountCodeAsync(string discount_code_id, string price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes/{discount_code_id}.json")]
    public Task RetrieveSingleDiscountCodeAsync(string discount_code_id, string price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes/{discount_code_id}.json")]
    public Task DeleteDiscountCodeAsync(string discount_code_id, string price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("discount_codes/lookup.json")]
    public Task RetrieveTheLocationOfDiscountCodeAsync(string code)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("discount_codes/count.json")]
    public Task RetrieveCountOfDiscountCodesForShopAsync(string? times_used, string? times_used_max, string? times_used_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/batch.json")]
    public Task CreateDiscountCodeCreationJobAsync(string price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/batch/{batch_id}.json")]
    public Task RetrieveDiscountCodeCreationJobAsync(string batch_id, string price_rule_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/batch/{batch_id}/discount_codes.json")]
    public Task RetrieveListOfDiscountCodesForDiscountCodeCreationJobAsync(string batch_id, string price_rule_id)
    {
        throw new NotImplementedException();
    }
}