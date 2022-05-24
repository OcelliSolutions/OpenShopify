using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum FulfillmentServiceScope
{
    [EnumMember(Value = "all")]
    All,
    [EnumMember(Value = "current_client")]
    CurrentClient
}
