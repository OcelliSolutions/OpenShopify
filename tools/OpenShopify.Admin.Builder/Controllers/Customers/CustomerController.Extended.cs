using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Customers;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Customers)]
[ApiController]
public class CustomerController : CustomerControllerBase
{
    public override Task RetrieveListOfCustomers(string? created_at_max = null, string? created_at_min = null, string? fields = null,
        string? ids = null, string? limit = "50", string? since_id = null, string? updated_at_max = null,
        string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateCustomer()
    {
        throw new NotImplementedException();
    }

    public override Task SearchForCustomersThatMatchSuppliedQuery(string? fields = null, string? limit = "50",
        string? order = "last_order_date DESC", string? query = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleCustomer(string customer_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateCustomer(string customer_id)
    {
        throw new NotImplementedException();
    }

    public override Task CreateAccountActivationURLForCustomer(string customer_id)
    {
        throw new NotImplementedException();
    }

    public override Task SendAccountInviteToCustomer(string customer_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveCountOfCustomers()
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveAllOrdersThatBelongToCustomer(string customer_id, string? status = null)
    {
        throw new NotImplementedException();
    }
}