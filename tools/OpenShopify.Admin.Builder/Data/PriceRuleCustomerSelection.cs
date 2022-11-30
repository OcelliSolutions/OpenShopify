using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum PriceRuleCustomerSelection
{
    [EnumMember(Value = "all"), Description("The price rule is valid for all customers.")]
    All,
    [EnumMember(Value = "prerequisite"), Description("The customer must either belong to one of the customer segments specified by `customer_segment_prerequisite_ids`, or be one of the customers specified by `prerequisite_customer_ids`")]
    Prerequisite
}