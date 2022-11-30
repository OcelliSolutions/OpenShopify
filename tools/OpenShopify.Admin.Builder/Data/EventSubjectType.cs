using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum EventSubjectType
{
    [EnumMember(Value = "Article")]
    Article,
    [EnumMember(Value = "Blog")]
    Blog,
    [EnumMember(Value = "Collection")]
    Collection,
    [EnumMember(Value = "Comment")]
    Comment,
    [EnumMember(Value = "Order")]
    Order,
    [EnumMember(Value = "Page")]
    Page,
    [EnumMember(Value = "PriceRule")]
    PriceRule,
    [EnumMember(Value = "Product")]
    Product,
    [EnumMember(Value = "ApiPermission")]
    ApiPermission
}