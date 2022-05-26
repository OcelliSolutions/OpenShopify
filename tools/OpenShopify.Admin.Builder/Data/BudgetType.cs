using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum BudgetType
{
    [EnumMember(Value = "daily")]
    Daily,
    [EnumMember(Value = "lifetime")] 
    Lifetime
}
