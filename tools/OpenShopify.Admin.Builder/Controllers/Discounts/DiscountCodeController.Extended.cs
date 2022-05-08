using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Discounts;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Discounts)]
[ApiController]
public class DiscountCodeController : DiscountCodeControllerBase
{
    public override Task CreateDiscountCode(string price_rule_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfDiscountCodes(string price_rule_id)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateExistingDiscountCode(string discount_code_id, string price_rule_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleDiscountCode(string discount_code_id, string price_rule_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteDiscountCode(string discount_code_id, string price_rule_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveTheLocationOfDiscountCode(string code)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfDiscountCodesForShop(string? times_used = null, string? times_used_max = null,
        string? times_used_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateDiscountCodeCreationJob(string price_rule_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveDiscountCodeCreationJob(string batch_id, string price_rule_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveListOfDiscountCodesForDiscountCodeCreationJob(string batch_id, string price_rule_id)
    {
        throw new NotImplementedException();
    }
}