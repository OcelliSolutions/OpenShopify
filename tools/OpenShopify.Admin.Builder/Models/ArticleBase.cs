using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record ArticleBase
    {
        /// <inheritdoc cref="ArticleOrig.Image"/>
        [JsonPropertyName("image")]
        public new ArticleImage? Image { get; set; }
    }
}
