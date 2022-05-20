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

    public abstract class DraftOrderControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Create a new DraftOrder
        /// </summary>
        /// <param name="customer_id">Used to load the customer. When a customer is loaded, the customer’s email address  is also associated.</param>
        /// <param name="use_customer_default_address">An optional boolean that you can send as part of a draft order object
        /// <br/>        to load customer shipping information. Valid values: true or false.</param>
        /// <returns>Create a new DraftOrder</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("draft_orders.json")]
        public abstract System.Threading.Tasks.Task CreateDraftOrder([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateDraftOrderRequest request, [Microsoft.AspNetCore.Mvc.FromQuery] [System.ComponentModel.DataAnnotations.Required] long? customer_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? use_customer_default_address);

        /// <summary>
        /// Retrieves a list of draft orders
        /// </summary>
        /// <param name="fieldsQuery">A comma-separated list of fields to include in the response</param>
        /// <param name="ids">Filter by list of IDs</param>
        /// <param name="limit">Amount of results</param>
        /// <param name="since_id">Restrict results to after the specified ID</param>
        /// <param name="updated_at_max">Show orders last updated before date (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="updated_at_min">Show orders last updated after date (format: 2014-04-25T16:15:47-04:00)</param>
        /// <returns>Retrieves a list of draft orders</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("draft_orders.json")]
        public abstract System.Threading.Tasks.Task ListDraftOrders([Microsoft.AspNetCore.Mvc.FromQuery(Name = "fields")] string? fieldsQuery, [Microsoft.AspNetCore.Mvc.FromQuery] string? ids, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit, string? page_info, [Microsoft.AspNetCore.Mvc.FromQuery] int? since_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? status, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_min);

        /// <summary>
        /// Modify an existing DraftOrder
        /// </summary>
        /// <returns>Modify an existing DraftOrder</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("draft_orders/{draft_order_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateDraftOrder([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateDraftOrderRequest request, [System.ComponentModel.DataAnnotations.Required] long draft_order_id);

        /// <summary>
        /// Receive a single DraftOrder
        /// </summary>
        /// <param name="fields">A comma-separated list of fields to include in the response</param>
        /// <returns>Receive a single DraftOrder</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("draft_orders/{draft_order_id}.json")]
        public abstract System.Threading.Tasks.Task GetDraftOrder([System.ComponentModel.DataAnnotations.Required] long draft_order_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields);

        /// <summary>
        /// Remove an existing DraftOrder
        /// </summary>
        /// <returns>Remove an existing DraftOrder</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("draft_orders/{draft_order_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteDraftOrder([System.ComponentModel.DataAnnotations.Required] long draft_order_id);

        /// <summary>
        /// Receive a count of all DraftOrders
        /// </summary>
        /// <param name="since_id">Count draft orders after the specified ID.</param>
        /// <param name="status">Count draft orders that have a given status.</param>
        /// <param name="updated_at_max">Count draft orders last updated before the specified date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="updated_at_min">Count draft orders last updated after the specified date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <returns>Receive a count of all DraftOrders</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("draft_orders/count.json")]
        public abstract System.Threading.Tasks.Task CountDraftOrders([Microsoft.AspNetCore.Mvc.FromQuery] int? since_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? status, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_min);

        /// <summary>
        /// Send an invoice
        /// </summary>
        /// <returns>Send an invoice</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("draft_orders/{draft_order_id}/send_invoice.json")]
        public abstract System.Threading.Tasks.Task SendInvoice([System.ComponentModel.DataAnnotations.Required] long draft_order_id);

        /// <summary>
        /// Complete a draft order
        /// </summary>
        /// <returns>Complete a draft order</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("draft_orders/{draft_order_id}/complete.json")]
        public abstract System.Threading.Tasks.Task CompleteDraftOrder([System.ComponentModel.DataAnnotations.Required] long draft_order_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? payment_pending);

    }

    


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603