using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum MarketingChannel
{
    [EnumMember(Value = "search")] Search,
    [EnumMember(Value = "display")] Display,
    [EnumMember(Value = "social")] Social,
    [EnumMember(Value = "email")] Email,
    [EnumMember(Value = "referral")] Referral
}