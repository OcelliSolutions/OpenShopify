using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Customers;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Customers)]
[ApiController]
public class CustomerAddressController : CustomerAddressControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("customers/{customer_id:long}/addresses.json")]
    [ProducesResponseType(typeof(CustomerAddressList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfAddressesForCustomer(long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("customers/{customer_id:long}/addresses.json")]
    [ProducesResponseType(typeof(CustomerAddressItem), StatusCodes.Status201Created)]
    public override Task CreateNewAddressForCustomer(CreateCustomerAddressRequest request, long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("customers/{customer_id:long}/addresses/{address_id:long}.json")]
    [ProducesResponseType(typeof(CustomerAddressItem), StatusCodes.Status200OK)]
    public override Task RetrieveDetailsForSingleCustomerAddress(long address_id, long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("customers/{customer_id:long}/addresses/{address_id:long}.json")]
    [ProducesResponseType(typeof(CustomerAddressItem), StatusCodes.Status200OK)]
    public override Task UpdateExistingCustomerAddress(UpdateCustomerAddressRequest request, long address_id, long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("customers/{customer_id:long}/addresses/{address_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task RemoveAddressFromCustomersAddressList(long address_id, long customer_id)
    {
        throw new NotImplementedException();
    }

    ///TODO: Validate `address_ids[]` parameter
    /// <inheritdoc />
    [HttpPut, Route("customers/{customer_id:long}/addresses/set.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task PerformBulkOperationsForMultipleCustomerAddresses(long address_ids, long customer_id, string operation)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("customers/{customer_id:long}/addresses/{address_id:long}/default.json")]
    [ProducesResponseType(typeof(CustomerAddressItem), StatusCodes.Status200OK)]
    public override Task SetDefaultAddressForCustomer(long address_id, long customer_id)
    {
        throw new NotImplementedException();
    }
}