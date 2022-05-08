using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Customers;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Customers)]
[ApiController]
public class CustomerSavedSearchController : CustomerSavedSearchControllerBase
{
    public override Task RetrieveListOfCustomerSavedSearches(string? fields = null, string? limit = "50", string? since_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateCustomerSavedSearch()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfAllCustomerSavedSearches(string? since_id = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleCustomerSavedSearch(string customer_saved_search_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateCustomerSavedSearch(string customer_saved_search_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteCustomerSavedSearch(string customer_saved_search_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveAllCustomersReturnedByCustomerSavedSearch(string customer_saved_search_id, string? fields = null,
        string? limit = "50", string? order = "last_order_date DESC")
    {
        throw new NotImplementedException();
    }
}