using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum Weight
{
    [EnumMember(Value = "oz")]
    Oz,
    [EnumMember(Value = "lb")]
    Lb,
    [EnumMember(Value = "g")]
    G,
    [EnumMember(Value = "kg")]
    Kg
}