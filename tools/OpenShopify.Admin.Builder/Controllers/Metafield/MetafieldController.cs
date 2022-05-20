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

namespace OpenShopify.Admin.Builder.Controllers
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]

    public abstract class MetafieldControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieve a list of metafields from the resource's endpoint
        /// </summary>
        /// <param name="created_at_max">Show metafields created before date (format: 2022-02-25T16:15:47-04:00)</param>
        /// <param name="created_at_min">Show metafields created after date (format: 2022-02-25T16:15:47-04:00)</param>
        /// <param name="fields">Retrieve only certain fields, specified by a comma-separated list of fields names.</param>
        /// <param name="key">Show metafields with given key</param>
        /// <param name="limit">The maximum number of results to show on a page.</param>
        /// <param name="@namespace">Show metafields with given namespace</param>
        /// <param name="since_id">Show metafields created after the specified ID.</param>
        /// <param name="type">The type of data that the metafield stores in the `value` field.
        /// <br/>Refer to the list of &lt;a href="/apps/metafields/types"&gt;supported types&lt;/a&gt;.</param>
        /// <param name="updated_at_max">Show metafields last updated before date (format: 2022-02-25T16:15:47-04:00)</param>
        /// <param name="updated_at_min">Show metafields last updated after date (format: 2022-02-25T16:15:47-04:00)</param>
        /// <param name="value_type">The legacy type information for the stored value. Replaced by `type`</param>
        /// <returns>Retrieve a list of metafields from the resource's endpoint</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("metafields.json")]
        public abstract System.Threading.Tasks.Task ListMetafieldsFromResourcesEndpoint([Microsoft.AspNetCore.Mvc.FromQuery] DateTime? created_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? created_at_min, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields, [Microsoft.AspNetCore.Mvc.FromQuery] string? key, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit, string? page_info, [Microsoft.AspNetCore.Mvc.FromQuery(Name = "namespace")] string? @namespace, [Microsoft.AspNetCore.Mvc.FromQuery] int? since_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? type, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_min, [Microsoft.AspNetCore.Mvc.FromQuery] string? value_type);

        /// <summary>
        /// Create a metafield
        /// </summary>
        /// <returns>Create a metafield</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("metafields.json")]
        public abstract System.Threading.Tasks.Task CreateMetafield([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateMetafieldRequest request);

        /// <summary>
        /// Retrieve a count of a resource's metafields.
        /// </summary>
        /// <returns>Retrieve a count of a resource's metafields.</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("metafields/count.json")]
        public abstract System.Threading.Tasks.Task GetCountOfResourcesMetafields();

        /// <summary>
        /// Retrieve a specific metafield
        /// </summary>
        /// <param name="fields">Retrieve only certain fields, specified by a comma-separated list of fields names.</param>
        /// <returns>Retrieve a specific metafield</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("metafields/{metafield_id}.json")]
        public abstract System.Threading.Tasks.Task GetSpecificMetafield(long metafield_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields);

        /// <summary>
        /// Updates a metafield
        /// </summary>
        /// <returns>Updates a metafield</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("metafields/{metafield_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateMetafield([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateMetafieldRequest request, long metafield_id);

        /// <summary>
        /// Deletes a metafield by its ID
        /// </summary>
        /// <returns>Deletes a metafield by its ID</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("metafields/{metafield_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteMetafieldByItsID(long metafield_id);

    }

    


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603