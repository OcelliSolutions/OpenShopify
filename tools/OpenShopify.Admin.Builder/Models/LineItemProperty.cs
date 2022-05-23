

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a properties for <see cref="LineItem.Properties"/>
    /// </summary>
    public partial record LineItemProperty
    {
        /// <summary>
        /// The name of the note attribute.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The value of the note attribute.
        /// </summary>
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}
