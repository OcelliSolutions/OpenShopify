using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum CanadianTaxExemptions
{
    [EnumMember(Value = "EXEMPT_ALL"), Description("This customer is exempt from all Canadian taxes.")]
    EXEMPT_ALL,
    [EnumMember(Value = "CA_STATUS_CARD_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid STATUS_CARD_EXEMPTION in Canada.")]
    CA_STATUS_CARD_EXEMPTION,
    [EnumMember(Value = "CA_DIPLOMAT_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid DIPLOMAT_EXEMPTION in Canada.")]
    CA_DIPLOMAT_EXEMPTION,
    [EnumMember(Value = "CA_BC_RESELLER_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid RESELLER_EXEMPTION in British Columbia.")]
    CA_BC_RESELLER_EXEMPTION,
    [EnumMember(Value = "CA_MB_RESELLER_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid RESELLER_EXEMPTION in Manitoba.")]
    CA_MB_RESELLER_EXEMPTION,
    [EnumMember(Value = "CA_SK_RESELLER_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid RESELLER_EXEMPTION in Saskatchewan.")]
    CA_SK_RESELLER_EXEMPTION,
    [EnumMember(Value = "CA_BC_COMMERCIAL_FISHERY_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid COMMERCIAL_FISHERY_EXEMPTION in British Columbia.")]
    CA_BC_COMMERCIAL_FISHERY_EXEMPTION,
    [EnumMember(Value = "CA_MB_COMMERCIAL_FISHERY_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid COMMERCIAL_FISHERY_EXEMPTION in Manitoba.")]
    CA_MB_COMMERCIAL_FISHERY_EXEMPTION,
    [EnumMember(Value = "CA_NS_COMMERCIAL_FISHERY_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid COMMERCIAL_FISHERY_EXEMPTION in Nova Scotia.")]
    CA_NS_COMMERCIAL_FISHERY_EXEMPTION,
    [EnumMember(Value = "CA_PE_COMMERCIAL_FISHERY_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid COMMERCIAL_FISHERY_EXEMPTION in Prince Edward Island.")]
    CA_PE_COMMERCIAL_FISHERY_EXEMPTION,
    [EnumMember(Value = "CA_SK_COMMERCIAL_FISHERY_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid COMMERCIAL_FISHERY_EXEMPTION in Saskatchewan.")]
    CA_SK_COMMERCIAL_FISHERY_EXEMPTION,
    [EnumMember(Value = "CA_BC_PRODUCTION_AND_MACHINERY_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid PRODUCTION_AND_MACHINERY_EXEMPTION in British Columbia.")]
    CA_BC_PRODUCTION_AND_MACHINERY_EXEMPTION,
    [EnumMember(Value = "CA_SK_PRODUCTION_AND_MACHINERY_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid PRODUCTION_AND_MACHINERY_EXEMPTION in Saskatchewan.")]
    CA_SK_PRODUCTION_AND_MACHINERY_EXEMPTION,
    [EnumMember(Value = "CA_BC_SUB_CONTRACTOR_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid SUB_CONTRACTOR_EXEMPTION in British Columbia.")]
    CA_BC_SUB_CONTRACTOR_EXEMPTION,
    [EnumMember(Value = "CA_SK_SUB_CONTRACTOR_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid SUB_CONTRACTOR_EXEMPTION in Saskatchewan.")]
    CA_SK_SUB_CONTRACTOR_EXEMPTION,
    [EnumMember(Value = "CA_BC_CONTRACTOR_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid CONTRACTOR_EXEMPTION in British Columbia.")]
    CA_BC_CONTRACTOR_EXEMPTION,
    [EnumMember(Value = "CA_SK_CONTRACTOR_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid CONTRACTOR_EXEMPTION in Saskatchewan.")]
    CA_SK_CONTRACTOR_EXEMPTION,
    [EnumMember(Value = "CA_ON_PURCHASE_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid PURCHASE_EXEMPTION in Ontario.")]
    CA_ON_PURCHASE_EXEMPTION,
    [EnumMember(Value = "CA_MB_FARMER_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid FARMER_EXEMPTION in Manitoba.")]
    CA_MB_FARMER_EXEMPTION,
    [EnumMember(Value = "CA_NS_FARMER_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid FARMER_EXEMPTION in Nova Scotia.")]
    CA_NS_FARMER_EXEMPTION,
    [EnumMember(Value = "CA_SK_FARMER_EXEMPTION"), Description("This customer is exempt from specific taxes for holding a valid FARMER_EXEMPTION in Saskatchewan.")]
    CA_SK_FARMER_EXEMPTION
}