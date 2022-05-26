using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum ThemeRole
{
    [EnumMember(Value = "main"), Description("The theme is published. Customers see it when they visit the online store.")]
    Main,
    [EnumMember(Value = "unpublished"), Description("The theme is unpublished. Customers can't see it.")]
    Unpublished,
    [EnumMember(Value = "demo"), Description("The theme is installed on the store as a demo. The theme can't be published until the merchant buys the full version.")]
    Demo,
    [EnumMember(Value = "development"), Description("The theme is used for development. The theme can't be published, and is temporary.")]
    Development
}
