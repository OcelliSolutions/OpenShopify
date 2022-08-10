using System.ComponentModel.DataAnnotations;
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
    [HttpGet]
    [Route("customer_saved_searches.json")]
    [ProducesResponseType(typeof(CustomerSavedSearchList), StatusCodes.Status200OK)]
    public override Task ListCustomerSavedSearches(string? fields = null, int? limit = null, string? page_info = null,
        long? since_id = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPost]
    [Route("customer_saved_searches.json")]
    [ProducesResponseType(typeof(CustomerSavedSearchItem), StatusCodes.Status201Created)]
    public override Task CreateCustomerSavedSearch([Required] CreateCustomerSavedSearchRequest request) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("customer_saved_searches/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountCustomerSavedSearches(long? since_id = null) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("customer_saved_searches/{customer_saved_search_id:long}.json")]
    [ProducesResponseType(typeof(CustomerSavedSearchItem), StatusCodes.Status200OK)]
    public override Task GetCustomerSavedSearch([Required] long customer_saved_search_id, string? fields = null) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpPut]
    [Route("customer_saved_searches/{customer_saved_search_id:long}.json")]
    [ProducesResponseType(typeof(CustomerSavedSearchItem), StatusCodes.Status200OK)]
    public override Task UpdateCustomerSavedSearch([Required] UpdateCustomerSavedSearchRequest request,
        [Required] long customer_saved_search_id) => throw new NotImplementedException();

    /// <inheritdoc />
    [HttpDelete]
    [Route("customer_saved_searches/{customer_saved_search_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteCustomerSavedSearch([Required] long customer_saved_search_id) =>
        throw new NotImplementedException();

    /// <inheritdoc />
    [HttpGet]
    [Route("customer_saved_searches/{customer_saved_search_id:long}/customers.json")]
    [ProducesResponseType(typeof(CustomerList), StatusCodes.Status200OK)]
    public override Task ListCustomersByCustomerSavedSearch(long customer_saved_search_id, string? fields = null,
        int? limit = null,
        string? page_info = null, string? order = null) =>
        throw new NotImplementedException();
}