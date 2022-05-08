using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Attributes;

public class ApiGroupAttribute : Attribute
{
    public ApiGroupAttribute(params ApiGroupNames[] name)
    {
        GroupName = name;
    }
    public ApiGroupNames[] GroupName { get; set; }
}

