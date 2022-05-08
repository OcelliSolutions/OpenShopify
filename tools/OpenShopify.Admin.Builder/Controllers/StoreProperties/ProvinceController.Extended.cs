using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.StoreProperties;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.StoreProperties)]
[ApiController]
public class ProvinceController : ProvinceControllerBase
{
    public override Task RetrieveListOfProvincesForCountry(string country_id, string? fields = null, string? since_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfProvincesForCountry(string country_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleProvinceForCountry(string country_id, string province_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateExistingProvinceForCountry(string country_id, string province_id)
    {
        throw new NotImplementedException();
    }
}