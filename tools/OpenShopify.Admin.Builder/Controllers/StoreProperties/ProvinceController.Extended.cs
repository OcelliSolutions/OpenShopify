using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.StoreProperties;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.StoreProperties)]
[ApiController]
public class ProvinceController : ProvinceControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("countries/{country_id:long}/provinces.json")]
    public override Task RetrieveListOfProvincesForCountry(long country_id, string? fields, int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("countries/{country_id:long}/provinces/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfProvincesForCountry(long country_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("countries/{country_id:long}/provinces/{province_id:long}.json")]
    public override Task RetrieveSingleProvinceForCountry(long country_id, long province_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("countries/{country_id:long}/provinces/{province_id:long}.json")]
    public override Task UpdateExistingProvinceForCountry(UpdateProvinceRequest request, long country_id, long province_id)
    {
        throw new NotImplementedException();
    }
}