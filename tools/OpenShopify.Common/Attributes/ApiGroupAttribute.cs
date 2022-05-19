using OpenShopify.Common.Data;

namespace OpenShopify.Common.Attributes;

public class ApiGroupAttribute : Attribute
{
    public ApiGroupAttribute(params ApiGroupNames[] name)
    {
        GroupName = name;
    }
    public ApiGroupNames[] GroupName { get; set; }
}

