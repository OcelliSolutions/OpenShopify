using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.StoreProperties;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.StoreProperties)]
[ApiController]
public class ProvinceController : IProvinceController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("countries/{country_id}/provinces.json")]
    public Task RetrieveListOfProvincesForCountryAsync(string country_id, string? fields, string? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("countries/{country_id}/provinces/count.json")]
    public Task RetrieveCountOfProvincesForCountryAsync(string country_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("countries/{country_id}/provinces/{province_id}.json")]
    public Task RetrieveSingleProvinceForCountryAsync(string country_id, string province_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("countries/{country_id}/provinces/{province_id}.json")]
    public Task UpdateExistingProvinceForCountryAsync(string country_id, string province_id)
    {
        throw new NotImplementedException();
    }
}