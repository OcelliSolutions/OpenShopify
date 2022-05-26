using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum RuleRelation
{
    [EnumMember(Value = "greater_than"), Description("The column value is greater than the condition.")]
    GreaterThan,
    [EnumMember(Value = "less_than"), Description("The column value is less than the condition.")]
    LessThan,
    [EnumMember(Value = "equals"), Description("Checks if the column value is equal to the condition value.")]
    Equals,
    [EnumMember(Value = "not_equals"), Description("Checks if the column value is not equal to the condition value.")]
    NotEquals,
    [EnumMember(Value = "starts_with"), Description("Checks if the column value starts with the condition value.")]
    StartsWith,
    [EnumMember(Value = "ends_with"), Description("Checks if the column value ends with the condition value.")]
    EndsWith,
    [EnumMember(Value = "contains"), Description("Checks if the column value contains the condition value.")]
    Contains,
    [EnumMember(Value = "not_contains"), Description("Checks if the column value does not contain the condition value.")]
    NotContains
}
