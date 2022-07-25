using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.StoreProperties;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.StoreProperties)]
[ApiController]
public class ProvinceController : ProvinceControllerBase
{
    /// <inheritdoc />
    [HttpGet]
    [Route("countries/{country_id:long}/provinces.json")]
    [ProducesResponseType(typeof(ProvinceList), StatusCodes.Status200OK)]
    public override Task ListProvinces([Required] long country_id, string? fields = null, long? since_id = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("countries/{country_id:long}/provinces/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountProvinces(long? country_id = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("countries/{country_id:long}/provinces/{province_id:long}.json")]
    [ProducesResponseType(typeof(ProvinceItem), StatusCodes.Status200OK)]
    public override Task GetProvince([Required] long country_id, [Required] long province_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("countries/{country_id:long}/provinces/{province_id:long}.json")]
    [ProducesResponseType(typeof(ProvinceItem), StatusCodes.Status200OK)]
    public override Task UpdateProvince([Required] UpdateProvinceRequest updateProvinceRequest,
        [Required] long country_id, [Required] long province_id) => throw new NotImplementedException();
}