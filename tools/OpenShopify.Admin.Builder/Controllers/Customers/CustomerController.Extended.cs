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
    public override Task RetrieveListOfCustomers(DateTime? created_at_max, DateTime? created_at_min, string? fields, string? ids,
        int? limit, string? page_info, int? since_id, DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("customers.json")]
    [ProducesResponseType(typeof(CustomerItem), StatusCodes.Status201Created)]
    public override Task CreateCustomer(CustomerItem request)
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
    public override Task RetrieveSingleCustomer(long customer_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("customers/{customer_id:long}.json")]
    [ProducesResponseType(typeof(CustomerItem), StatusCodes.Status200OK)]
    public override Task UpdateCustomer(CustomerItem request, long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("customers/{customer_id:long}/account_activation_url.json")]
    [ProducesResponseType(typeof(AccountActivation), StatusCodes.Status200OK)]
    public override Task CreateAccountActivationURLForCustomer(CustomerItem request, long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("customers/{customer_id:long}/send_invite.json")]
    [ProducesResponseType(typeof(CustomerInvite), StatusCodes.Status201Created)]
    public override Task SendAccountInviteToCustomer(long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("customers/count.json")]
    [ProducesResponseType(typeof(CustomerCount), StatusCodes.Status200OK)]
    public override Task RetrieveCountOfCustomers()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("customers/{customer_id:long}/orders.json")]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    public override Task RetrieveAllOrdersThatBelongToCustomer(long customer_id, string? status)
    {
        throw new NotImplementedException();
    }
}
