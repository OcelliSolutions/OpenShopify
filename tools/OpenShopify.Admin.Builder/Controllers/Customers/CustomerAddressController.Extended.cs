using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Customers;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Customers)]
[ApiController]
public class CustomerAddressController : ICustomerAddressController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}/addresses.json")]
    public Task RetrieveListOfAddressesForCustomerAsync(string customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}/addresses.json")]
    public Task CreateNewAddressForCustomerAsync(string customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}/addresses/{address_id}.json")]
    public Task RetrieveDetailsForSingleCustomerAddressAsync(string address_id, string customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}/addresses/{address_id}.json")]
    public Task UpdateExistingCustomerAddressAsync(string address_id, string customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}/addresses/{address_id}.json")]
    public Task RemoveAddressFromCustomersAddressListAsync(string address_id, string customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}/addresses/set.json")]
    public Task PerformBulkOperationsForMultipleCustomerAddressesAsync(string address_ids, string customer_id, string operation)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}/addresses/{address_id}/default.json")]
    public Task SetTheDefaultAddressForCustomerAsync(string address_id, string customer_id)
    {
        throw new NotImplementedException();
    }
}