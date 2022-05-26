using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum ResourceFeedbackState
{
    [EnumMember(Value = "requires_action"), Description("Indicates that your app requires the merchant to resolve an issue with their shop.")]
    RequiresAction,
    [EnumMember(Value = "success"), Description("Indicates that the app does not have any outstanding issues with this shop.")]
    Success
}
