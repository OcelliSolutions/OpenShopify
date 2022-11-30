using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record UpdateCustomerAddressRequest
{
    [JsonPropertyName("customer_address"), Required]
    public UpdateCustomerAddress CustomerAddress { get; set; } = null!;
}