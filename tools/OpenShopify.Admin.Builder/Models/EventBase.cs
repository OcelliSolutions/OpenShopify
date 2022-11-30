using System.Text.Json.Serialization;
//using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record EventBase
    {
        /// <summary>
        /// Undocumented by Shopify
        /// </summary>
        [JsonPropertyName("author")]
        public string? Author { get; set; }
        
        /// <inheritdoc cref="EventOrig.SubjectType"/>
        [JsonPropertyName("subject_type")]
        public new EventSubjectType? SubjectType { get; set; } = default!;
    }
}
