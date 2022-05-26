using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum SortOrder
{
    [EnumMember(Value = "alpha-asc"), Description("The products are sorted alphabetically from A to Z.")]
    AlphaAsc,
    [EnumMember(Value = "alpha-des"), Description("The products are sorted alphabetically from Z to A.")]
    AlphaDes,
    [EnumMember(Value = "best-selling"), Description("The products are sorted by number of sales.")]
    BestSelling,
    [EnumMember(Value = "created"), Description("The products are sorted by the date they were created, from oldest to newest.")]
    Created,
    [EnumMember(Value = "created-desc"), Description("The products are sorted by the date they were created, from newest to oldest.")]
    CreatedDesc,
    [EnumMember(Value = "manual"), Description("The products are manually sorted by the shop owner.")]
    Manual,
    [EnumMember(Value = "price-asc"), Description("The products are sorted by price from lowest to highest.")]
    PriceAsc,
    [EnumMember(Value = "price-desc"), Description("The products are sorted by price from highest to lowest.")]
    PriceDesc
}
