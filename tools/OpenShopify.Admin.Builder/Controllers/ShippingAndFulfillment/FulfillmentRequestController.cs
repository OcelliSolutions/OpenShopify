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

    public abstract class FulfillmentRequestControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Sends a fulfillment request
        /// </summary>
        /// <param name="fulfillment_order_line_items">The fulfillment order line items to be requested for fulfillment. If left blank, all line items of the fulfillment order are requested for fulfillment.</param>
        /// <param name="message">An optional message for the fulfillment request.</param>
        /// <returns>Sends a fulfillment request</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/fulfillment_orders/{fulfillment_order_id}/fulfillment_request.json")]
        public abstract System.Threading.Tasks.Task SendFulfillmentRequest(string fulfillment_order_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fulfillment_order_line_items = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? message = null);

        /// <summary>
        /// Accepts a fulfillment request
        /// </summary>
        /// <param name="message">An optional reason for accepting the fulfillment request.</param>
        /// <returns>Accepts a fulfillment request</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/fulfillment_orders/{fulfillment_order_id}/fulfillment_request/accept.json")]
        public abstract System.Threading.Tasks.Task AcceptFulfillmentRequest(string fulfillment_order_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? message = null);

        /// <summary>
        /// Rejects a fulfillment request
        /// </summary>
        /// <param name="message">An optional reason for rejecting the fulfillment request.</param>
        /// <returns>Rejects a fulfillment request</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/fulfillment_orders/{fulfillment_order_id}/fulfillment_request/reject.json")]
        public abstract System.Threading.Tasks.Task RejectFulfillmentRequest(string fulfillment_order_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? message = null);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class FulfillmentRequest
    {

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