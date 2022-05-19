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

    public abstract class CollectionListingControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieve collection listings that are published to your app
        /// </summary>
        /// <param name="limit">Amount of results</param>
        /// <returns>Retrieve collection listings that are published to your app</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("collection_listings.json")]
        public abstract System.Threading.Tasks.Task RetrieveCollectionListingsThatArePublishedToYourApp([Microsoft.AspNetCore.Mvc.FromQuery] int? limit, string? page_info);

        /// <summary>
        /// Retrieve &lt;code&gt;product_ids&lt;/code&gt; that are published to a &lt;code&gt;collection_id&lt;/code&gt;
        /// </summary>
        /// <param name="limit">Amount of results</param>
        /// <returns>Retrieve &lt;code&gt;product_ids&lt;/code&gt; that are published to a &lt;code&gt;collection_id&lt;/code&gt;</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("collection_listings/{collection_listing_id}/product_ids.json")]
        public abstract System.Threading.Tasks.Task RetrieveProductIdsThatArePublishedToCollectionId(long collection_listing_id, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit, string? page_info);

        /// <summary>
        /// Retrieve a specific collection listing that is published to your app
        /// </summary>
        /// <returns>Retrieve a specific collection listing that is published to your app</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("collection_listings/{collection_listing_id}.json")]
        public abstract System.Threading.Tasks.Task RetrieveSpecificCollectionListingThatIsPublishedToYourApp(long collection_listing_id);

        /// <summary>
        /// Create a collection listing to publish a collection to your app
        /// </summary>
        /// <returns>Create a collection listing to publish a collection to your app</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("collection_listings/{collection_listing_id}.json")]
        public abstract System.Threading.Tasks.Task CreateCollectionListingToPublishCollectionToYourApp([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CollectionListingItem request, long collection_listing_id);

        /// <summary>
        /// Delete a collection listing to unpublish a collection from your app
        /// </summary>
        /// <returns>Delete a collection listing to unpublish a collection from your app</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("collection_listings/{collection_listing_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteCollectionListingToUnpublishCollectionFromYourApp(long collection_listing_id);

    }

    


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603