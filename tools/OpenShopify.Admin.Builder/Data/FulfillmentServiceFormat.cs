using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum FulfillmentServiceFormat
{
    [EnumMember(Value = "json")]
    Json,
    [EnumMember(Value = "xml")]
    Xml,
}
