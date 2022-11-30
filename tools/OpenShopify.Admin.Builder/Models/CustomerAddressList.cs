using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record CustomerAddressList
{
    [JsonPropertyName("customer_addresses"), Required]
    public IEnumerable<CustomerAddress> CustomerAddresses { get; set; } = null!;
}