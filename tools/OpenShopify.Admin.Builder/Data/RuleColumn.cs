using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum RuleColumn
{
    [EnumMember(Value = "title"), Description("The product title.")]
    Title,
    [EnumMember(Value = "type"), Description("The product type.")]
    Type,
    [EnumMember(Value = "vendor"), Description("The name of the product vendor.")]
    Vendor,
    [EnumMember(Value = "variant_title"), Description("The title of a product variant.")]
    VariantTitle,
    [EnumMember(Value = "variant_compare_at_price"), Description("The compare price.")]
    VariantCompareAtPrice,
    [EnumMember(Value = "variant_weight"), Description("The weight of the product.")]
    VariantWeight,
    [EnumMember(Value = "variant_inventory"), Description("The inventory stock. Note: not_equals does not work with this property.")]
    VariantInventory,
    [EnumMember(Value = "variant_price"), Description("product price.")]
    VariantPrice,
    [EnumMember(Value = "tag"), Description("A tag associated with the product.")]
    Tag

}
