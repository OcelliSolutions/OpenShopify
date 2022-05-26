using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum DiscountCodeCreationStatus
{
    [EnumMember(Value = "queued"), Description("The job is acknowledged, but not started.")]
    Queued,
    [EnumMember(Value = "running"), Description("The job is in process.")]
    Running,
    [EnumMember(Value = "completed"), Description("The job has finished.")]
    Completed

}
