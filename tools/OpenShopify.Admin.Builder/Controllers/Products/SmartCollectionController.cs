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

    public abstract class SmartCollectionControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of smart collections
        /// </summary>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <param name="handle">Filter results by smart collection handle.</param>
        /// <param name="ids">Show only the smart collections specified by a comma-separated list of IDs.</param>
        /// <param name="limit">The number of results to show.</param>
        /// <param name="product_id">Show smart collections that includes the specified product.</param>
        /// <param name="published_at_max">Show smart collections published before this date. (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="published_at_min">Show smart collections published after this date. (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="published_status">Filter results based on the published status of smart collections.</param>
        /// <param name="since_id">Restrict results to after the specified ID.</param>
        /// <param name="title">Show smart collections with the specified title.</param>
        /// <param name="updated_at_max">Show smart collections last updated before this date. (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="updated_at_min">Show smart collections last updated after this date. (format: 2014-04-25T16:15:47-04:00)</param>
        /// <returns>Retrieves a list of smart collections</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("smart_collections.json")]
        public abstract System.Threading.Tasks.Task ListSmartCollections([Microsoft.AspNetCore.Mvc.FromQuery] string? fields, [Microsoft.AspNetCore.Mvc.FromQuery] string? handle, [Microsoft.AspNetCore.Mvc.FromQuery] string? ids, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit, string? page_info, [Microsoft.AspNetCore.Mvc.FromQuery] long? product_id, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? published_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? published_at_min, [Microsoft.AspNetCore.Mvc.FromQuery] string? published_status, [Microsoft.AspNetCore.Mvc.FromQuery] int? since_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? title, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_min);

        /// <summary>
        /// Creates a smart collection
        /// </summary>
        /// <returns>Creates a smart collection</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("smart_collections.json")]
        public abstract System.Threading.Tasks.Task CreateSmartCollection([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateSmartCollectionRequest request);

        /// <summary>
        /// Retrieves a count of smart collections
        /// </summary>
        /// <param name="product_id">Show smart collections that include the specified product.</param>
        /// <param name="published_at_max">Show smart collections published before this date.  (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="published_at_min">Show smart collections published after this date.  (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="published_status">Filter results based on the published status of smart collections.</param>
        /// <param name="title">Show smart collections with the specified title.</param>
        /// <param name="updated_at_max">Show smart collections last updated before this date.  (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="updated_at_min">Show smart collections last updated after this date. (format: 2014-04-25T16:15:47-04:00)</param>
        /// <returns>Retrieves a count of smart collections</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("smart_collections/count.json")]
        public abstract System.Threading.Tasks.Task GetCountOfSmartCollections([Microsoft.AspNetCore.Mvc.FromQuery] long? product_id, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? published_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? published_at_min, [Microsoft.AspNetCore.Mvc.FromQuery] string? published_status, [Microsoft.AspNetCore.Mvc.FromQuery] string? title, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_min);

        /// <summary>
        /// Retrieves a single smart collection
        /// </summary>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <returns>Retrieves a single smart collection</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("smart_collections/{smart_collection_id}.json")]
        public abstract System.Threading.Tasks.Task GetSmartCollection(long smart_collection_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields);

        /// <summary>
        /// Updates an existing smart collection
        /// </summary>
        /// <returns>Updates an existing smart collection</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("smart_collections/{smart_collection_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateSmartCollection([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateSmartCollectionRequest request, long smart_collection_id);

        /// <summary>
        /// Removes a smart collection
        /// </summary>
        /// <returns>Removes a smart collection</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("smart_collections/{smart_collection_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteSmartCollection(long smart_collection_id);

        /// <summary>
        /// Updates the ordering type of products in a smart collection
        /// </summary>
        /// <param name="products">An array of product IDs, in the order that you want them to appear at the top of the collection. When &lt;code&gt;products&lt;/code&gt; is specified but empty, any previously sorted products are cleared.</param>
        /// <param name="sort_order">The type of sorting to apply. Valid values are listed in the &lt;a href="#properties"&gt;Properties&lt;/a&gt; section above.</param>
        /// <returns>Updates the ordering type of products in a smart collection</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("smart_collections/{smart_collection_id}/order.json")]
        public abstract System.Threading.Tasks.Task UpdateOrderingTypeOfProductsInSmartCollection([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateSmartCollectionRequest request, long smart_collection_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? products, [Microsoft.AspNetCore.Mvc.FromQuery] string? sort_order = "(current value)");

    }

    


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603