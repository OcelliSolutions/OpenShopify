using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum ScriptTagEvent
{
    [EnumMember(Value = "onload")]
    Onload
}
