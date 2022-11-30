using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record AddressList
{
    [JsonPropertyName("addresses"), Required]
    public IEnumerable<Address> Addresses { get; set; } = null!;
}