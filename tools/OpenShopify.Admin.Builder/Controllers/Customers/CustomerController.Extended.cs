using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Customers;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Customers)]
[ApiController]
public class CustomerController : CustomerControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("customers.json")]
    [ProducesResponseType(typeof(CustomerList), StatusCodes.Status200OK)]
    public override Task ListCustomers(DateTime? created_at_max, DateTime? created_at_min, string? fields, string? ids,
        int? limit, string? page_info, int? since_id, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("customers.json")]
    [ProducesResponseType(typeof(CustomerItem), StatusCodes.Status201Created)]
    public override Task CreateCustomer([Required] CreateCustomerRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("customers/search.json")]
    [ProducesResponseType(typeof(CustomerList), StatusCodes.Status200OK)]
    public override Task SearchForCustomersThatMatchSuppliedQuery(string? fields, int? limit, string? page_info, string? order, string? query)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("customers/{customer_id:long}.json")]
    [ProducesResponseType(typeof(CustomerItem), StatusCodes.Status200OK)]
    public override Task GetCustomer([Required] long customer_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("customers/{customer_id:long}.json")]
    [ProducesResponseType(typeof(CustomerItem), StatusCodes.Status200OK)]
    public override Task UpdateCustomer([Required] UpdateCustomerRequest request, [Required] long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [IgnoreApi, HttpPost, Route("customers/{customer_id:long}/account_activation_url.invalid")]
    [ProducesResponseType(typeof(AccountActivation), StatusCodes.Status200OK)]
    public override Task CreateAccountActivationUrlForCustomer([Required] CreateCustomerRequest request, [Required] long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="CustomerControllerBase.CreateAccountActivationUrlForCustomer" />
    [HttpPost, Route("customers/{customer_id:long}/account_activation_url.json")]
    [ProducesResponseType(typeof(AccountActivation), StatusCodes.Status200OK)]
    public Task CreateAccountActivationUrlForCustomer([Required] long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [IgnoreApi, HttpPost, Route("customers/{customer_id:long}/send_invite.invalid")]
    [ProducesResponseType(typeof(CustomerInviteItem), StatusCodes.Status201Created)]
    public override Task SendAccountInviteToCustomer([Required] long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="CustomerControllerBase.SendAccountInviteToCustomer" />
    [HttpPost, Route("customers/{customer_id:long}/send_invite.json")]
    [ProducesResponseType(typeof(CustomerInviteItem), StatusCodes.Status201Created)]
    public Task SendAccountInviteToCustomer(CreateCustomerInviteRequest request, [Required] long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("customers/count.json")]
    [ProducesResponseType(typeof(CountItem), StatusCodes.Status200OK)]
    public override Task CountCustomers()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("customers/{customer_id:long}/orders.json")]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    public override Task ListOrdersThatBelongToCustomer([Required] long customer_id, string? status)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Delete a customer (UNDOCUMENTED)
    /// </summary>
    /// <param name="customer_id"></param>
    /// <returns></returns>
    [HttpDelete, Route("customers/{customer_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task DeleteCustomer([Required] long customer_id)
    {
        throw new NotImplementedException();
    }
}
