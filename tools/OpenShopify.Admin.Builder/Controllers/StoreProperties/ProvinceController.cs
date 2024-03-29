//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
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

namespace OpenShopify.Admin.Builder.Models
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]

    public abstract class ProvinceControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of provinces for a country
        /// </summary>
        /// <remarks>
        /// Retrieves a list of provinces
        /// </remarks>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of fields names.</param>
        /// <param name="since_id">Restrict results to after the specified ID.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("countries/{country_id}/provinces.json")]
        public abstract System.Threading.Tasks.Task ListProvinces(long country_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null, [Microsoft.AspNetCore.Mvc.FromQuery] long? since_id = null);

        /// <summary>
        /// Retrieves a count of provinces for a country
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("countries/{country_id}/provinces/count.json")]
        public abstract System.Threading.Tasks.Task CountProvinces(long? country_id = null);

        /// <summary>
        /// Retrieves a single province for a country
        /// </summary>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("countries/{country_id}/provinces/{province_id}.json")]
        public abstract System.Threading.Tasks.Task GetProvince(long country_id, long province_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

        /// <summary>
        /// Updates an existing province for a country
        /// </summary>
        /// <remarks>
        /// &lt;aside class="note caution"&gt; 
        /// 
        /// #### Caution
        /// 
        /// As of version 2020-10, the tax field is deprecated.
        /// &lt;/aside&gt;Updates an existing province for a country.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("countries/{country_id}/provinces/{province_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateProvince([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateProvinceRequest request, long country_id, long province_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum ProvinceTaxType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"normal")]
        Normal = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"harmonized")]
        Harmonized = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"compounded")]
        Compounded = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record ProvinceOrig
    {
        /// <summary>
        /// The standard abbreviation for the province.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("code")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Code { get; set; } = default!;

        /// <summary>
        /// The ID for the country that the province belongs to.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("country_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public long? CountryId { get; set; } = default!;

        /// <summary>
        /// The full name of the province.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Name { get; set; } = default!;

        /// <summary>
        /// The ID for the shipping zone that the province belongs to.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("shipping_zone_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public long? ShippingZoneId { get; set; } = default!;

        /// <summary>
        /// The sales tax rate to be applied to orders made by customers from this province.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tax")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public decimal? Tax { get; set; } = default!;

        /// <summary>
        /// The name of the tax for this province.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tax_name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? TaxName { get; set; } = default!;

        /// <summary>
        /// The tax type. Valid values: `null`, `normal`, `harmonized`, or `compounded`. 
        /// 
        /// A harmonized tax is a combination of provincial and federal sales taxes.
        /// 
        /// Normal and harmonized tax rates are applied to the pre-tax value of an order, but a compounded tax rate is applied on top of other tax rates. For example, if a $100 order receives a 5% normal tax rate and a 2% compound tax rate, then the post-tax total is $107.10 (`(100 x 1.05) x 1.02 = 107.1`).
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tax_type")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? TaxType { get; set; } = default!;

        /// <summary>
        /// The province's tax in percent format.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tax_percentage")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public decimal? TaxPercentage { get; set; } = default!;

        private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
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