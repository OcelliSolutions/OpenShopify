using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum RiskRecommendation
{
    [EnumMember(Value = "cancel"), Description("There is a high level of risk that this order is fraudulent. The merchant should cancel the order.")]
    Cancel,
    [EnumMember(Value = "investigate"), Description("There is a medium level of risk that this order is fraudulent. The merchant should investigate the order.")]
    Investigate,
    [EnumMember(Value = "accept"), Description("There is a low level of risk that this order is fraudulent. The order risk found no indication of fraud.")]
    Accept

}
