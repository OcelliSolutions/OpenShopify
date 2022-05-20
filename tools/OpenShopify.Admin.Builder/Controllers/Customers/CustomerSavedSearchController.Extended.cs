using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Customers;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Customers)]
[ApiController]
public class CustomerSavedSearchController : CustomerSavedSearchControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("customer_saved_searches.json")]
    [ProducesResponseType(typeof(CustomerSavedSearchList), StatusCodes.Status200OK)]
    public override Task ListCustomerSavedSearches(string? fields, int? limit, string? page_info, int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("customer_saved_searches.json")]
    [ProducesResponseType(typeof(CustomerSavedSearchItem), StatusCodes.Status201Created)]
    public override Task CreateCustomerSavedSearch(CreateCustomerSavedSearchRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("customer_saved_searches/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task GetCountOfAllCustomerSavedSearches(int? since_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("customer_saved_searches/{customer_saved_search_id:long}.json")]
    [ProducesResponseType(typeof(CustomerSavedSearchItem), StatusCodes.Status200OK)]
    public override Task GetCustomerSavedSearch(long customer_saved_search_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("customer_saved_searches/{customer_saved_search_id:long}.json")]
    [ProducesResponseType(typeof(CustomerSavedSearchItem), StatusCodes.Status200OK)]
    public override Task UpdateCustomerSavedSearch(UpdateCustomerSavedSearchRequest request, long customer_saved_search_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("customer_saved_searches/{customer_saved_search_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteCustomerSavedSearch(long customer_saved_search_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("customer_saved_searches/{customer_saved_search_id:long}/customers.json")]
    [ProducesResponseType(typeof(CustomerList), StatusCodes.Status200OK)]
    public override Task GetAllCustomersReturnedByCustomerSavedSearch(long customer_saved_search_id, string? fields,
        int? limit, string? page_info, string? order)
    {
        throw new NotImplementedException();
    }
}