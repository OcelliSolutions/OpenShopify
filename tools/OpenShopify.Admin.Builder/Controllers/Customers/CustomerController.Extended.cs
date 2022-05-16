using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Customers;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Customers)]
[ApiController]
public class CustomerController : ICustomerController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customers.json")]

    public Task RetrieveListOfCustomersAsync(string? created_at_max, string? created_at_min, string? fields, string? ids,
        string limit, string? since_id, string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("customers.json")]
    public Task CreateCustomerAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customers/search.json")]
    public Task SearchForCustomersThatMatchSuppliedQueryAsync(string? fields, string limit, string order, string? query)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}.json")]
    public Task RetrieveSingleCustomerAsync(string customer_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}.json")]
    public Task UpdateCustomerAsync(string customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}/account_activation_url.json")]
    public Task CreateAccountActivationURLForCustomerAsync(string customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}/send_invite.json")]
    public Task SendAccountInviteToCustomerAsync(string customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customers/count.json")]
    public Task RetrieveCountOfCustomersAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}/orders.json")]
    public Task RetrieveAllOrdersThatBelongToCustomerAsync(string customer_id, string? status)
    {
        throw new NotImplementedException();
    }
}