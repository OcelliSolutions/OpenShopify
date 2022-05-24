using System.ComponentModel.DataAnnotations;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public partial record WebhookBase
{
    /// <inheritdoc cref="WebhookOrig.Topic"/>
    [Required]
    public new WebhookTopic Topic { get; set; }

    /// <inheritdoc cref="WebhookOrig.Format"/>
    public new WebhookFormat? Format { get; set; }
}
