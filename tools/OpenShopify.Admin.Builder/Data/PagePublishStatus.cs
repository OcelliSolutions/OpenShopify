using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum PagePublishStatus
{
    [EnumMember(Value = "published"), Description("Show only published pages.")]
    Published,
    [EnumMember(Value = "unpublished"), Description("Show only unpublished pages.")]
    Unpublished,
    [EnumMember(Value = "any"), Description("Show published and unpublished pages.")]
    Any
}