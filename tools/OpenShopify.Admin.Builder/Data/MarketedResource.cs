using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum MarketedResource
{
    [EnumMember(Value = "product")]
    Product,
    [EnumMember(Value = "collection")]
    Collection,
    [EnumMember(Value = "price_rule"), Obsolete("Replaced by price_rule after April 20, 2017.")]
    PriceRule,
    [EnumMember(Value = "page")]
    Page,
    [EnumMember(Value = "article")]
    Article,
    [EnumMember(Value = "homepage"), Description("Doesn't have an id.")]
    Homepage
}
