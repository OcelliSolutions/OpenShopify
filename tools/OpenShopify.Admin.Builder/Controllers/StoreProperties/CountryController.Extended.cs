using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.StoreProperties;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.StoreProperties)]
[ApiController]
public class CountryController : CountryControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("countries.json")]
    [ProducesResponseType(typeof(CountryList), StatusCodes.Status200OK)]
    public override Task ReceiveListOfAllCountries(string? fields, int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("countries.json")]
    [ProducesResponseType(typeof(CountryItem), StatusCodes.Status201Created)]
    public override Task CreateCountry(CountryItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("countries/count.json")]
    [ProducesResponseType(typeof(CountryCount), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfCountries()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("countries/{country_id:long}.json")]
    [ProducesResponseType(typeof(CountryItem), StatusCodes.Status200OK)]
    public override Task RetrieveSpecificCounty([Required] long country_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [IgnoreApi, HttpPut, Route("countries/{country_id}.invalid")]
    public override Task UpdateExistingCountry(CountryItem request, long countryId)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="CountryControllerBase.UpdateExistingCountry" />
    [HttpPut, Route("countries/{country_id:long}.json")]
    [ProducesResponseType(typeof(CountryItem), StatusCodes.Status200OK)]
    public Task UpdateExistingCountry([Required] long country_id, [Required] CountryItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("countries/{country_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task RemoveExistingCountry([Required] long country_id)
    {
        throw new NotImplementedException();
    }
}