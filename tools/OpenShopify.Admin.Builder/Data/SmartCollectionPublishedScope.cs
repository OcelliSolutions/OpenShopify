using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum SmartCollectionPublishedScope
{
    [EnumMember(Value = "web"), Description("The smart collection is published to the Online Store channel but not published to the Point of Sale channel.")]
    Web,
    [EnumMember(Value = "global"), Description("The smart collection is published to both the Online Store channel and the Point of Sale channel.")]
    Global
}
