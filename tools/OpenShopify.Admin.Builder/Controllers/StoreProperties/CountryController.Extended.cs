using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.StoreProperties;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.StoreProperties)]
[ApiController]
public class CountryController : CountryControllerBase
{
    public override Task ReceiveListOfAllCountries(string? fields = null, string? since_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateCountry()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfCountries()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSpecificCounty(string country_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateExistingCountry(string country_id)
    {
        throw new NotImplementedException();
    }

    public override Task RemoveExistingCountry(string country_id)
    {
        throw new NotImplementedException();
    }
}