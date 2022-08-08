using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum CarrierServiceFormat
{
    [EnumMember(Value = "json")]
    Json,
    [EnumMember(Value = "xml")]
    Xml,
}
