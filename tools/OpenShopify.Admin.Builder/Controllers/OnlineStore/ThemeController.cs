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

    public abstract class ThemeControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of themes
        /// </summary>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <returns>Retrieves a list of themes</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/themes.json")]
        public abstract System.Threading.Tasks.Task RetrieveListOfThemes([Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

        /// <summary>
        /// Creates a theme
        /// </summary>
        /// <returns>Creates a theme</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/themes.json")]
        public abstract System.Threading.Tasks.Task CreateTheme();

        /// <summary>
        /// Retrieves a single theme by its ID
        /// </summary>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <returns>Retrieves a single theme by its ID</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/themes/{theme_id}.json")]
        public abstract System.Threading.Tasks.Task RetrieveSingleThemeByItsID(string theme_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

        /// <summary>
        /// Modify an existing Theme
        /// </summary>
        /// <returns>Modify an existing Theme</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/themes/{theme_id}.json")]
        public abstract System.Threading.Tasks.Task ModifyExistingTheme(string theme_id);

        /// <summary>
        /// Remove an existing Theme
        /// </summary>
        /// <returns>Remove an existing Theme</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/themes/{theme_id}.json")]
        public abstract System.Threading.Tasks.Task RemoveExistingTheme(string theme_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Theme
    {
        /// <summary>
        /// The date and time when the theme was created. (format: 2014-04-25T16:15:47-04:00)
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("created_at")]
        public string? Created_at { get; set; } = default!;

        /// <summary>
        /// The unique numeric identifier for the theme.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string? Id { get; set; } = default!;

        /// <summary>
        /// The name of the theme.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; } = default!;

        /// <summary>
        /// Whether the theme can currently be previewed.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("previewable")]
        public string? Previewable { get; set; } = default!;

        /// <summary>
        /// Whether files are still being copied into place for this theme.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("processing")]
        public string? Processing { get; set; } = default!;

        /// <summary>
        /// Specifies how the theme is being used within the shop. Valid values:
        /// <br/> 
        /// <br/> main: The theme is published. Customers see it when they visit the online store.
        /// <br/> unpublished: The theme is unpublished. Customers can't see it.
        /// <br/> demo: The theme is installed on the store as a demo. The theme can't be published until the merchant buys the full version.
        /// <br/> development: The theme is used for development. The theme can't be published, and is temporary.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("role")]
        public string? Role { get; set; } = default!;

        /// <summary>
        /// A unique identifier applied to Shopify-made themes that are installed from the Shopify Theme Store Theme Store.
        /// <br/> Not all themes available in the Theme Store are developed by Shopify. Returns null if the store's theme isn't made by Shopify, or if it wasn't installed from the Theme Store.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("theme_store_id")]
        public string? Theme_store_id { get; set; } = default!;

        /// <summary>
        /// The date and time of when the theme was last updated. (format: 2014-04-25T16:15:47-04:00)
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
        public string? Updated_at { get; set; } = default!;

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