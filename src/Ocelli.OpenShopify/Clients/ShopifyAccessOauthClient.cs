//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v9.0.0.0)) (http://NSwag.org)
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

namespace Ocelli.OpenShopify
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial interface IAccessScopeClient
    {

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Get a list of access scopes
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ShopifyResponse<AccessScopeList>> ListAccessScopesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v9.0.0.0))")]
    internal partial class AccessScopeClient : ShopifyClientBase, IAccessScopeClient
    {
        private string _baseUrl = "https://{store_name}.myshopify.com";
        private System.Net.Http.HttpClient _httpClient;
        private System.Lazy<System.Text.Json.JsonSerializerOptions> _settings;

        public AccessScopeClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
            _settings = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerSettings);
        }

        private System.Text.Json.JsonSerializerOptions CreateSerializerSettings()
        {
            var settings = new System.Text.Json.JsonSerializerOptions();
            UpdateJsonSerializerSettings(settings);
            return settings;
        }

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        protected System.Text.Json.JsonSerializerOptions JsonSerializerSettings { get { return _settings.Value; } }

        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// Get a list of access scopes
        /// </summary>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<ShopifyResponse<AccessScopeList>> ListAccessScopesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/oauth/access_scopes.json");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<AccessScopeList>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return new ShopifyResponse<AccessScopeList>(status_, headers_, objectResponse_.Object);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        protected struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                this.Object = responseObject;
                this.Text = responseText;
            }

            public T Object { get; }

            public string Text { get; }
        }

        public bool ReadResponseAsString { get; set; }

        protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
        {
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T)!, string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var typedBody = System.Text.Json.JsonSerializer.Deserialize<T>(responseText, JsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody!, responseText);
                }
                catch (System.Text.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
                }
            }
            else
            {
                try
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        var typedBody = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(responseStream, JsonSerializerSettings, cancellationToken).ConfigureAwait(false);
                        return new ObjectResponseResult<T>(typedBody!, string.Empty);
                    }
                }
                catch (System.Text.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        private string ConvertToString(object? value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is System.Enum)
            {
                var name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute)) 
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }

                    var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                    return converted == null ? string.Empty : converted;
                }
            }
            else if (value is bool) 
            {
                return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[]) value);
            }
            else if (value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array) value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            var result = System.Convert.ToString(value, cultureInfo);
            return result == null ? "" : result;
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class AccessScope
    {

        [System.Text.Json.Serialization.JsonPropertyName("handle")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumMemberConverter))]
        public AuthorizationScope? Handle { get; set; } = default!;

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class AccessScopeList
    {

        [System.Text.Json.Serialization.JsonPropertyName("access_scopes")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public System.Collections.Generic.ICollection<AccessScope>? AccessScopes { get; set; } = default!;

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v9.0.0.0))")]
    public enum AuthorizationScope
    {

        [System.Runtime.Serialization.EnumMember(Value = @"read_content")]
        read_content = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"write_content")]
        write_content = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"read_themes")]
        read_themes = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"write_themes")]
        write_themes = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"read_products")]
        read_products = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"write_products")]
        write_products = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"read_customers")]
        read_customers = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"write_customers")]
        write_customers = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"read_orders")]
        read_orders = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"read_all_orders")]
        read_all_orders = 9,

        [System.Runtime.Serialization.EnumMember(Value = @"write_orders")]
        write_orders = 10,

        [System.Runtime.Serialization.EnumMember(Value = @"read_script_tags")]
        read_script_tags = 11,

        [System.Runtime.Serialization.EnumMember(Value = @"write_script_tags")]
        write_script_tags = 12,

        [System.Runtime.Serialization.EnumMember(Value = @"read_fulfillments")]
        read_fulfillments = 13,

        [System.Runtime.Serialization.EnumMember(Value = @"write_fulfillments")]
        write_fulfillments = 14,

        [System.Runtime.Serialization.EnumMember(Value = @"read_shipping")]
        read_shipping = 15,

        [System.Runtime.Serialization.EnumMember(Value = @"write_shipping")]
        write_shipping = 16,

        [System.Runtime.Serialization.EnumMember(Value = @"read_analytics")]
        read_analytics = 17,

        [System.Runtime.Serialization.EnumMember(Value = @"read_users")]
        read_users = 18,

        [System.Runtime.Serialization.EnumMember(Value = @"write_users")]
        write_users = 19,

        [System.Runtime.Serialization.EnumMember(Value = @"read_checkouts")]
        read_checkouts = 20,

        [System.Runtime.Serialization.EnumMember(Value = @"write_checkouts")]
        write_checkouts = 21,

        [System.Runtime.Serialization.EnumMember(Value = @"read_reports")]
        read_reports = 22,

        [System.Runtime.Serialization.EnumMember(Value = @"write_reports")]
        write_reports = 23,

        [System.Runtime.Serialization.EnumMember(Value = @"read_price_rules")]
        read_price_rules = 24,

        [System.Runtime.Serialization.EnumMember(Value = @"write_price_rules")]
        write_price_rules = 25,

        [System.Runtime.Serialization.EnumMember(Value = @"read_inventory")]
        read_inventory = 26,

        [System.Runtime.Serialization.EnumMember(Value = @"write_inventory")]
        write_inventory = 27,

        [System.Runtime.Serialization.EnumMember(Value = @"read_product_listings")]
        read_product_listings = 28,

        [System.Runtime.Serialization.EnumMember(Value = @"read_collection_listings")]
        read_collection_listings = 29,

        [System.Runtime.Serialization.EnumMember(Value = @"read_draft_orders")]
        read_draft_orders = 30,

        [System.Runtime.Serialization.EnumMember(Value = @"write_draft_orders")]
        write_draft_orders = 31,

        [System.Runtime.Serialization.EnumMember(Value = @"write_merchant_managed_fulfillment_orders")]
        write_merchant_managed_fulfillment_orders = 32,

        [System.Runtime.Serialization.EnumMember(Value = @"read_merchant_managed_fulfillment_orders")]
        read_merchant_managed_fulfillment_orders = 33,

        [System.Runtime.Serialization.EnumMember(Value = @"read_marketing_events")]
        read_marketing_events = 34,

        [System.Runtime.Serialization.EnumMember(Value = @"write_marketing_events")]
        write_marketing_events = 35,

        [System.Runtime.Serialization.EnumMember(Value = @"read_resource_feedbacks")]
        read_resource_feedbacks = 36,

        [System.Runtime.Serialization.EnumMember(Value = @"write_resource_feedbacks")]
        write_resource_feedbacks = 37,

        [System.Runtime.Serialization.EnumMember(Value = @"unauthenticated_read_checkouts")]
        unauthenticated_read_checkouts = 38,

        [System.Runtime.Serialization.EnumMember(Value = @"unauthenticated_read_collection_listings")]
        unauthenticated_read_collection_listings = 39,

        [System.Runtime.Serialization.EnumMember(Value = @"unauthenticated_read_customer_tags")]
        unauthenticated_read_customer_tags = 40,

        [System.Runtime.Serialization.EnumMember(Value = @"unauthenticated_read_customers")]
        unauthenticated_read_customers = 41,

        [System.Runtime.Serialization.EnumMember(Value = @"unauthenticated_read_product_listings")]
        unauthenticated_read_product_listings = 42,

        [System.Runtime.Serialization.EnumMember(Value = @"unauthenticated_read_product_tags")]
        unauthenticated_read_product_tags = 43,

        [System.Runtime.Serialization.EnumMember(Value = @"unauthenticated_write_checkouts")]
        unauthenticated_write_checkouts = 44,

        [System.Runtime.Serialization.EnumMember(Value = @"unauthenticated_write_customers")]
        unauthenticated_write_customers = 45,

        [System.Runtime.Serialization.EnumMember(Value = @"unauthenticated_read_content")]
        unauthenticated_read_content = 46,

        [System.Runtime.Serialization.EnumMember(Value = @"read_locations")]
        read_locations = 47,

        [System.Runtime.Serialization.EnumMember(Value = @"write_locations")]
        write_locations = 48,

        [System.Runtime.Serialization.EnumMember(Value = @"read_order_edits")]
        read_order_edits = 49,

        [System.Runtime.Serialization.EnumMember(Value = @"write_order_edits")]
        write_order_edits = 50,

        [System.Runtime.Serialization.EnumMember(Value = @"read_assigned_fulfillment_orders")]
        read_assigned_fulfillment_orders = 51,

        [System.Runtime.Serialization.EnumMember(Value = @"write_assigned_fulfillment_orders")]
        write_assigned_fulfillment_orders = 52,

        [System.Runtime.Serialization.EnumMember(Value = @"read_third_party_fulfillment_orders")]
        read_third_party_fulfillment_orders = 53,

        [System.Runtime.Serialization.EnumMember(Value = @"write_third_party_fulfillment_orders")]
        write_third_party_fulfillment_orders = 54,

        [System.Runtime.Serialization.EnumMember(Value = @"read_gift_cards")]
        read_gift_cards = 55,

        [System.Runtime.Serialization.EnumMember(Value = @"write_gift_cards")]
        write_gift_cards = 56,

        [System.Runtime.Serialization.EnumMember(Value = @"read_discounts")]
        read_discounts = 57,

        [System.Runtime.Serialization.EnumMember(Value = @"write_discounts")]
        write_discounts = 58,

        [System.Runtime.Serialization.EnumMember(Value = @"read_shopify_payments_payouts")]
        read_shopify_payments_payouts = 59,

        [System.Runtime.Serialization.EnumMember(Value = @"read_shopify_payments_disputes")]
        read_shopify_payments_disputes = 60,

        [System.Runtime.Serialization.EnumMember(Value = @"read_translations")]
        read_translations = 61,

        [System.Runtime.Serialization.EnumMember(Value = @"write_translations")]
        write_translations = 62,

        [System.Runtime.Serialization.EnumMember(Value = @"read_locales")]
        read_locales = 63,

        [System.Runtime.Serialization.EnumMember(Value = @"write_locales")]
        write_locales = 64,

        [System.Runtime.Serialization.EnumMember(Value = @"read_customer_payment_methods")]
        read_customer_payment_methods = 65,

        [System.Runtime.Serialization.EnumMember(Value = @"read_own_subscription_contracts")]
        read_own_subscription_contracts = 66,

        [System.Runtime.Serialization.EnumMember(Value = @"write_own_subscription_contracts")]
        write_own_subscription_contracts = 67,

    }



}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603