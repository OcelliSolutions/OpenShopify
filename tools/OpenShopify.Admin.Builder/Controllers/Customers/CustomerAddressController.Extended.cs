using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Customers;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Customers)]
[ApiController]
public class CustomerAddressController : CustomerAddressControllerBase
{
    public override Task RetrieveListOfAddressesForCustomer(string customer_id)
    {
        throw new NotImplementedException();
    }

    public override Task CreateNewAddressForCustomer(string customer_id)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveDetailsForSingleCustomerAddress(string address_id, string customer_id)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateExistingCustomerAddress(string address_id, string customer_id)
    {
        throw new NotImplementedException();
    }

    public override Task RemoveAddressFromCustomerSAddressList(string address_id, string customer_id)
    {
        throw new NotImplementedException();
    }

    public override Task PerformBulkOperationsForMultipleCustomerAddresses(string address_ids, string customer_id, string operation)
    {
        throw new NotImplementedException();
    }

    public override Task SetTheDefaultAddressForCustomer(string address_id, string customer_id)
    {
        throw new NotImplementedException();
    }
}