using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;
public enum AbandonedCheckoutStatusRequest
{
    [EnumMember(Value = "open")]
    Open,
    [EnumMember(Value = "closed")]
    Closed,
}
