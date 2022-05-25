using System.ComponentModel.DataAnnotations;
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
    [ProducesResponseType(typeof(AddressList), StatusCodes.Status200OK)]
    public override Task ListAddressesForCustomer([Required] long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("customers/{customer_id:long}/addresses.json")]
    [ProducesResponseType(typeof(CustomerAddressItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CustomerAddressError), StatusCodes.Status422UnprocessableEntity)]
    public override Task CreateAddressForCustomer([Required] CreateCustomerAddressRequest request, [Required] long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("customers/{customer_id:long}/addresses/{address_id:long}.json")]
    [ProducesResponseType(typeof(CustomerAddressItem), StatusCodes.Status200OK)]
    public override Task GetCustomerAddress([Required] long address_id, [Required] long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("customers/{customer_id:long}/addresses/{address_id:long}.json")]
    [ProducesResponseType(typeof(CustomerAddressItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CustomerAddressError), StatusCodes.Status422UnprocessableEntity)]
    public override Task UpdateCustomerAddress([Required] UpdateCustomerAddressRequest request, [Required] long address_id, [Required] long customer_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("customers/{customer_id:long}/addresses/{address_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteAddressFromCustomersAddressList([Required] long address_id, [Required] long customer_id)
    {
        throw new NotImplementedException();
    }

    ///TODO: Validate `address_ids[]` parameter
    /// <inheritdoc />
    [HttpPut, Route("customers/{customer_id:long}/addresses/set.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task PerformBulkOperationsForMultipleCustomerAddresses(string? address_ids = null, long? customer_id = null,
        string? operation = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("customers/{customer_id:long}/addresses/{address_id:long}/default.json")]
    [ProducesResponseType(typeof(CustomerAddressItem), StatusCodes.Status200OK)]
    public override Task SetDefaultAddressForCustomer([Required] long address_id, [Required] long customer_id)
    {
        throw new NotImplementedException();
    }
}