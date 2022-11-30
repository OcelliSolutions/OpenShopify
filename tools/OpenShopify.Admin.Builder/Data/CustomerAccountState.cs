using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum CustomerAccountState
{
    [EnumMember(Value = "disabled"), Description("The customer doesn't have an active account. Customer accounts can be disabled from the Shopify admin at any time.")]
    Disabled,
    [EnumMember(Value = "invited"), Description("The customer has received an email invite to create an account.")]
    Invited,
    [EnumMember(Value = "enabled"), Description("The customer has created an account.")]
    Enabled,
    [EnumMember(Value = "declined"), Description("The customer declined the email invite to create an account.")]
    Declined
}