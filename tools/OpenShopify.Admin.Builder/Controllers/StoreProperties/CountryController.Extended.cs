using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.StoreProperties;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.StoreProperties)]
[ApiController]
public class CountryController : CountryControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("countries.json")]
    [ProducesResponseType(typeof(CountryList), StatusCodes.Status200OK)]
    public override Task ListCountries(string? fields = null, long? since_id = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("countries.json")]
    [ProducesResponseType(typeof(CountryItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CountryError), StatusCodes.Status400BadRequest)]
    public override Task CreateCountry([Required] CreateCountryRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("countries/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountCountries()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("countries/{country_id:long}.json")]
    [ProducesResponseType(typeof(CountryItem), StatusCodes.Status200OK)]
    public override Task GetCounty([Required] long country_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("countries/{country_id}.json")]
    [ProducesResponseType(typeof(CountryItem), StatusCodes.Status200OK)]
    public override Task UpdateCountry([Required] UpdateCountryRequest request, [Required] long country_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("countries/{country_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteCountry([Required] long country_id)
    {
        throw new NotImplementedException();
    }
}