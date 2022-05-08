//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

#nullable enable

using System.Text.Json;

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"

namespace OpenShopify.Admin.Builder
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]

    public abstract class ProvinceControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of provinces for a country
        /// </summary>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of fields names.</param>
        /// <param name="since_id">Restrict results to after the specified ID.</param>
        /// <returns>Retrieves a list of provinces for a country</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/countries/{country_id}/provinces.json")]
        public abstract System.Threading.Tasks.Task RetrieveListOfProvincesForCountry(string country_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? since_id = null);

        /// <summary>
        /// Retrieves a count of provinces for a country
        /// </summary>
        /// <returns>Retrieves a count of provinces for a country</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/countries/{country_id}/provinces/count.json")]
        public abstract System.Threading.Tasks.Task RetrieveCountOfProvincesForCountry(string country_id);

        /// <summary>
        /// Retrieves a single province for a country
        /// </summary>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <returns>Retrieves a single province for a country</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/countries/{country_id}/provinces/{province_id}.json")]
        public abstract System.Threading.Tasks.Task RetrieveSingleProvinceForCountry(string country_id, string province_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

        /// <summary>
        /// Updates an existing province for a country
        /// </summary>
        /// <returns>Updates an existing province for a country</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/countries/{country_id}/provinces/{province_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateExistingProvinceForCountry(string country_id, string province_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Province
    {
        /// <summary>
        /// The standard abbreviation for the province.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("code")]
        public string? Code { get; set; } = default!;

        /// <summary>
        /// The ID for the country that the province belongs to.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("country_id")]
        public string? Country_id { get; set; } = default!;

        /// <summary>
        /// The ID for the province.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string? Id { get; set; } = default!;

        /// <summary>
        /// The full name of the province.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; } = default!;

        /// <summary>
        /// The ID for the shipping zone that the province belongs to.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("shipping_zone_id")]
        public string? Shipping_zone_id { get; set; } = default!;

        /// <summary>
        /// The sales tax rate to be applied to orders made by customers from this province.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tax")]
        public string? Tax { get; set; } = default!;

        /// <summary>
        /// The name of the tax for this province.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tax_name")]
        public string? Tax_name { get; set; } = default!;

        /// <summary>
        /// The tax type. Valid values: null, normal, harmonized, or compounded.
        /// <br/>
        /// <br/> A harmonized tax is a combination of provincial and federal sales taxes.
        /// <br/>
        /// <br/> Normal and harmonized tax rates are applied to the pre-tax value of an order, but a compounded tax rate is applied on top of other tax rates.
        /// <br/> For example, if a $100 order receives a 5% normal tax rate and a 2% compound tax rate, then the post-tax total is $107.10 ((100 x 1.05) x 1.02 = 107.1).
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tax_type")]
        public string? Tax_type { get; set; } = default!;

        /// <summary>
        /// The province's tax in percent format.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tax_percentage")]
        public string? Tax_percentage { get; set; } = default!;

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

    }


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603