using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record Country
    {
        /// <summary>
        /// The name of the tax as it is referred to in the applicable province/state. For example, in Ontario, Canada the tax is referred to as HST.
        /// </summary>
        [JsonPropertyName("tax_name")]
        public string? TaxName { get; set; }

        /// <inheritdoc cref="CountryOrig.Provinces"/>
        [JsonPropertyName("provinces")]
        public new IEnumerable<Province>? Provinces { get; set; }
    }
}