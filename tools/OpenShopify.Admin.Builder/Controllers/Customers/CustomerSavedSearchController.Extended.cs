using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Customers;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Customers)]
[ApiController]
public class CustomerSavedSearchController : ICustomerSavedSearchController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches.json")]
    public Task RetrieveListOfCustomerSavedSearchesAsync(string? fields, string limit, string? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches.json")]
    public Task CreateCustomerSavedSearchAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches/count.json")]

    public Task RetrieveCountOfAllCustomerSavedSearchesAsync(string? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches/{customer_saved_search_id}.json")]
    public Task RetrieveSingleCustomerSavedSearchAsync(string customer_saved_search_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches/{customer_saved_search_id}.json")]
    public Task UpdateCustomerSavedSearchAsync(string customer_saved_search_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches/{customer_saved_search_id}.json")]
    public Task DeleteCustomerSavedSearchAsync(string customer_saved_search_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customer_saved_searches/{customer_saved_search_id}/customers.json")]
    public Task RetrieveAllCustomersReturnedByCustomerSavedSearchAsync(string customer_saved_search_id, string? fields,
        string limit, string order)
    {
        throw new NotImplementedException();
    }
}