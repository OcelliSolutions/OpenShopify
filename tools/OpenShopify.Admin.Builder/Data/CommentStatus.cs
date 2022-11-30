using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum CommentStatus
{
    [EnumMember(Value = "pending"), Description("The comment has been created but is awaiting spam detection. Depending on the result of the spam detection and the shop owner's comment preferences, this property will be transitioned to either `spam`, `unapproved`, or `approved`.")]
    Pending,
    [EnumMember(Value = "unapproved"), Description("The comment is awaiting approval by the shop owner. It's not visible to the readers of the blog.")]
    Unapproved,
    [EnumMember(Value = "published"), Description("The comment has been approved (if the blog requires comments to be approved) and is visible to readers of the blog.")]
    Published,
    [EnumMember(Value = "spam"), Description("The comment has been marked as spam and removed from the Shopify admin. It's not visible to readers of the blog.")]
    Spam,
    [EnumMember(Value = "removed"), Description("The comment has been removed by the shop owner. It's not visible to readers of the blog.")]
    Removed
}