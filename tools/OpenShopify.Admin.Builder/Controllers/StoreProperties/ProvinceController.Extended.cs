using System.ComponentModel.DataAnnotations;
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
    public override Task ListProvincesForCountry([Required] long country_id, string? fields = null, long? since_id = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("countries/{country_id:long}/provinces/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountProvincesForCountry(long? country_id = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("countries/{country_id:long}/provinces/{province_id:long}.json")]
    public override Task GetProvinceForCountry([Required] long country_id, [Required] long province_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("countries/{country_id:long}/provinces/{province_id:long}.json")]
    public override Task UpdateProvinceForCountry([Required] UpdateProvinceRequest request, [Required] long country_id, [Required] long province_id)
    {
        throw new NotImplementedException();
    }
}