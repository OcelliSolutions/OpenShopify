using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum EventType
{
    [EnumMember(Value = "ad")]
    Ad,
    [EnumMember(Value = "post")]
    Post,
    [EnumMember(Value = "message")]
    Message,
    [EnumMember(Value = "retargeting")]
    Retargeting,
    [EnumMember(Value = "transactional")]
    Transactional,
    [EnumMember(Value = "affiliate")]
    Affiliate,
    [EnumMember(Value = "loyalty")]
    Loyalty,
    [EnumMember(Value = "newsletter")]
    Newsletter,
    [EnumMember(Value = "abandoned_cart")]
    AbandonedCart
}
