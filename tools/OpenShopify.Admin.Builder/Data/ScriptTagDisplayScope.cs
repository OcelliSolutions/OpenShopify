using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum ScriptTagDisplayScope
{
    [EnumMember(Value = "online_store"), Description("Include the script only on the web storefront.")]
    OnlineStore,
    [EnumMember(Value = "order_status"), Description("Include the script only on the order status page.")] 
    OrderStatus,
    [EnumMember(Value = "all"), Description("Include the script on both the web storefront and the order status page.")]
    All
}
