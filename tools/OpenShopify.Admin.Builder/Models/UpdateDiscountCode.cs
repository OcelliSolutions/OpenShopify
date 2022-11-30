using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record UpdateDiscountCode
{
    [JsonIgnore] public new int? UsageCount { get; set; }
}