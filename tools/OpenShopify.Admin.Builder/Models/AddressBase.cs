using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;
public partial record AddressItem
{
    [JsonPropertyName("address"), Required]
    public Address Address { get; set; } = null!;
}

public partial record AddressList
{
    [JsonPropertyName("addresses"), Required]
    public IEnumerable<Address> Addresses { get; set; } = null!;
}

public partial record Address : CustomerAddress { }

public partial record CustomerAddressBase : CustomerAddressOrig { }


public partial record CustomerAddressItem
{
    [JsonPropertyName("customer_address"), Required]
    public CustomerAddress CustomerAddress { get; set; } = null!;
}

public partial record CustomerAddressList
{
    [JsonPropertyName("customer_addresses"), Required]
    public IEnumerable<CustomerAddress> CustomerAddresses { get; set; } = null!;
}
public partial record CreateCustomerAddressRequest
{
    [JsonPropertyName("customer_address"), Required]
    public CreateCustomerAddress CustomerAddress { get; set; } = null!;
}

public partial record CreateCustomerAddress : CustomerAddressBase { }
public partial record UpdateCustomerAddressRequest
{
    [JsonPropertyName("customer_address"), Required]
    public UpdateCustomerAddress CustomerAddress { get; set; } = null!;
}

public partial record UpdateCustomerAddress : CustomerAddress { }


public partial record CustomerAddress : CustomerAddressBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
}

public partial record CustomerAddressBase : Models.CustomerAddressOrig { }