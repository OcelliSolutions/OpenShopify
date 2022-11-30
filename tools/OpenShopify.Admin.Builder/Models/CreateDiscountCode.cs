using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record CreateDiscountCode
{
    [JsonIgnore] public new int? UsageCount { get; set; }
}