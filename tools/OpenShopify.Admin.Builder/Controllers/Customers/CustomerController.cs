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

    public abstract class CustomerControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of customers
        /// </summary>
        /// <remarks>
        /// Retrieves a list of customers. This endpoint implements pagination by using links that are provided in the response header. Sending the `page` parameter will return an error. To learn more, see [*Make paginated requests to the REST Admin API*](/api/usage/pagination-rest).
        /// </remarks>
        /// <param name="created_at_max">Show customers created before a specified date.  
        /// (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="created_at_min">Show customers created after a specified date.  
        /// (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <param name="ids">Restrict results to customers specified by a comma-separated list of IDs.</param>
        /// <param name="limit">The maximum number of results to show.</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        /// <param name="since_id">Restrict results to those after the specified ID.</param>
        /// <param name="updated_at_max">Show customers last updated before a specified date.  
        /// (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="updated_at_min">Show customers last updated after a specified date.  
        /// (format: 2014-04-25T16:15:47-04:00)</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customers.json")]
        public abstract System.Threading.Tasks.Task ListCustomers([Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? created_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? created_at_min = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.Collections.Generic.IEnumerable<long>? ids = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit = null, string? page_info = null, [Microsoft.AspNetCore.Mvc.FromQuery] long? since_id = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_min = null);

        /// <summary>
        /// Creates a customer
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("customers.json")]
        public abstract System.Threading.Tasks.Task CreateCustomer([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateCustomerRequest request);

        /// <summary>
        /// Searches for customers that match a supplied query
        /// </summary>
        /// <remarks>
        /// Searches for customers that match a supplied query. This endpoint implements pagination by using links that are provided in the response header. Sending the `page` parameter will return an error. To learn more, see [*Make paginated requests to the REST Admin API*](/api/usage/pagination-rest).
        /// </remarks>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <param name="limit">The maximum number of results to show.</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        /// <param name="order">Set the field and direction by which to order results.</param>
        /// <param name="query">Text to search for in the shop's customer data.**Note:** Supported queries: `accepts_marketing`,`activation_date`, `address1`, `address2`, `city`,`company`, `country`, `customer_date`, `customer_first_name`,`customer_id`, `customer_last_name`, `customer_tag`, ` email`,`email_marketing_state`, `first_name`, `first_order_date`, `id`,`last_abandoned_order_date`, `last_name`, `multipass_identifier`,`orders_count`, `order_date`, `phone`, `province`,`shop_id`, `state`, `tag`, `total_spent`,`updated_at`, `verified_email`, `product_subscriber_status`. All other queriesreturns all customers.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customers/search.json")]
        public abstract System.Threading.Tasks.Task SearchForCustomersThatMatchSuppliedQuery([Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit = null, string? page_info = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? order = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? query = null);

        /// <summary>
        /// Retrieves a single customer
        /// </summary>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}.json")]
        public abstract System.Threading.Tasks.Task GetCustomer(long customer_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

        /// <summary>
        /// Updates a customer
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateCustomer([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateCustomerRequest request, long customer_id);

        /// <summary>
        /// Deletes a customer
        /// </summary>
        /// <remarks>
        /// Deletes a customer. A customer can't be deleted if they have existing orders.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteCustomer(long customer_id);

        /// <summary>
        /// Creates an account activation URL for a customer
        /// </summary>
        /// <remarks>
        /// Generate an account activation URL for a customer whose account is not yet enabled. This is useful when you've imported a large number of customers and want to send them activation emails all at once. Using this approach, you'll need to generate and send the activation emails yourself.
        /// 
        /// The account activation URL generated by this endpoint is for one-time use and will expire after 30 days. If you make a new POST request to this endpoint, then a new URL will be generated. The new URL will be again valid for 30 days, but the previous URL will no longer be valid.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}/account_activation_url.json")]
        public abstract System.Threading.Tasks.Task CreateAccountActivationUrlForCustomer([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateAccountActivationUrlForCustomerRequest request, long customer_id);

        /// <summary>
        /// Sends an account invite to a customer
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}/send_invite.json")]
        public abstract System.Threading.Tasks.Task SendAccountInviteToCustomer([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.SendAccountInviteToCustomerRequest request, long customer_id);

        /// <summary>
        /// Retrieves a count of customers
        /// </summary>
        /// <remarks>
        /// Retrieves a count of all customers.
        /// </remarks>
        /// <param name="created_at_max">Count customers created before a specified date.  
        /// (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="created_at_min">Count customers created after a specified date.  
        /// (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="updated_at_max">Count customers last updated before a specified date.  
        /// (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="updated_at_min">Count customers last updated after a specified date.  
        /// (format: 2014-04-25T16:15:47-04:00)</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customers/count.json")]
        public abstract System.Threading.Tasks.Task CountCustomers([Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? created_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? created_at_min = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_min = null);

        /// <summary>
        /// Retrieves all orders that belong to a customer
        /// </summary>
        /// <remarks>
        /// Retrieves all orders that belong to a customer. By default, only open orders are returned. The query string parameters in the [ Order](/docs/admin-api/rest/reference/orders/order#endpoints-{{ current_version }}) resource are also available at this endpoint.
        /// </remarks>
        /// <param name="status">The status of the orders to return.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("customers/{customer_id}/orders.json")]
        public abstract System.Threading.Tasks.Task ListOrdersThatBelongToCustomer(long customer_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? status = null);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum CustomerMarketingOptInLevel
    {

        [System.Runtime.Serialization.EnumMember(Value = @"email_marketing_consent")]
        EmailMarketingConsent = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"single_opt_in")]
        SingleOptIn = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"confirmed_opt_in")]
        ConfirmedOptIn = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"unknown")]
        Unknown = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum CustomerState
    {

        [System.Runtime.Serialization.EnumMember(Value = @"disabled")]
        Disabled = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"invited")]
        Invited = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"enabled")]
        Enabled = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"declined")]
        Declined = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum CustomerTaxExemptions
    {

        [System.Runtime.Serialization.EnumMember(Value = @"EXEMPT_ALL")]
        EXEMPTALL = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_STATUS_CARD_EXEMPTION")]
        CASTATUSCARDEXEMPTION = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_DIPLOMAT_EXEMPTION")]
        CADIPLOMATEXEMPTION = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_BC_RESELLER_EXEMPTION")]
        CABCRESELLEREXEMPTION = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_MB_RESELLER_EXEMPTION")]
        CAMBRESELLEREXEMPTION = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_SK_RESELLER_EXEMPTION")]
        CASKRESELLEREXEMPTION = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_BC_COMMERCIAL_FISHERY_EXEMPTION")]
        CABCCOMMERCIALFISHERYEXEMPTION = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_MB_COMMERCIAL_FISHERY_EXEMPTION")]
        CAMBCOMMERCIALFISHERYEXEMPTION = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_NS_COMMERCIAL_FISHERY_EXEMPTION")]
        CANSCOMMERCIALFISHERYEXEMPTION = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_PE_COMMERCIAL_FISHERY_EXEMPTION")]
        CAPECOMMERCIALFISHERYEXEMPTION = 9,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_SK_COMMERCIAL_FISHERY_EXEMPTION")]
        CASKCOMMERCIALFISHERYEXEMPTION = 10,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_BC_PRODUCTION_AND_MACHINERY_EXEMPTION")]
        CABCPRODUCTIONANDMACHINERYEXEMPTION = 11,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_SK_PRODUCTION_AND_MACHINERY_EXEMPTION")]
        CASKPRODUCTIONANDMACHINERYEXEMPTION = 12,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_BC_SUB_CONTRACTOR_EXEMPTION")]
        CABCSUBCONTRACTOREXEMPTION = 13,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_SK_SUB_CONTRACTOR_EXEMPTION")]
        CASKSUBCONTRACTOREXEMPTION = 14,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_BC_CONTRACTOR_EXEMPTION")]
        CABCCONTRACTOREXEMPTION = 15,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_SK_CONTRACTOR_EXEMPTION")]
        CASKCONTRACTOREXEMPTION = 16,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_ON_PURCHASE_EXEMPTION")]
        CAONPURCHASEEXEMPTION = 17,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_MB_FARMER_EXEMPTION")]
        CAMBFARMEREXEMPTION = 18,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_NS_FARMER_EXEMPTION")]
        CANSFARMEREXEMPTION = 19,

        [System.Runtime.Serialization.EnumMember(Value = @"CA_SK_FARMER_EXEMPTION")]
        CASKFARMEREXEMPTION = 20,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record CustomerOrig
    {
        /// <summary>
        /// As of API version 2022-04, this property is deprecated. Use `email_marketing_consent` instead.Whether the customer has consented to receive marketing material by email.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("accepts_marketing")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        [System.Obsolete]
        public bool? AcceptsMarketing { get; set; } = default!;

        /// <summary>
        /// As of API version 2022-04, this property is deprecated. Use `email_marketing_consent` instead.The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format)when the customer consented or objected to receiving marketing material by email. Set this value wheneverthe customer consents or objects to marketing materials.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("accepts_marketing_updated_at")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        [System.Obsolete]
        public System.DateTimeOffset? AcceptsMarketingUpdatedAt { get; set; } = default!;

        /// <summary>
        /// A list of the ten most recently updated addresses for the customer. Each address has the following properties: * **address1**: The customer's mailing address. * **address2**: An additional field for the customer's mailing address. * **city**: The customer's city, town, or village. * **company**: The customer's company. * **country**: The customer's country. * **country_code**: The two-letter country code corresponding to the customer's country. * **country_name**: The customer's normalized country name. * **customer_id**: A unique identifier for the customer. * **default**: Whether this address is the default address for the customer. * **first_name**: The customer's first name. * **id**: A unique identifier for the address. * **last_name**: The customer's last name. * **name**: The customer's first and last names. * **phone**: The customer's phone number at this address. * **province**: The customer's region name. Typically a province, a state, or a prefecture. * **province_code**: The code for the region of the address, such as the province, state, or district. For example QC for Quebec, Canada. * **zip**: The customer's postal code, also known as zip, postcode, Eircode, etc.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("addresses")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Addresses { get; set; } = default!;

        /// <summary>
        /// The three-letter code ([ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) format) for the currency that the customer used when they paid for their last order. Defaults to the shop currency. Returns the shop currency for test orders.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("currency")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Currency { get; set; } = default!;

        /// <summary>
        /// The default address for the customer. The default address has the following properties: * **address1**: The first line of the customer's mailing address. * **address2**: An additional field for the customer's mailing address. * **city**: The customer's city, town, or village. * **company**: The customer's company. * **country**: The customer's country. * **country_code**: The two-letter country code corresponding to the customer's country. * **country_name**: The customer's normalized country name. * **customer_id**: A unique identifier for the customer. * **default**: Returns `true` for each default address. * **first_name**: The customer's first name. * **id**: A unique identifier for the address. * **last_name**: The customer's last name. * **name**: The customer's first and last names. * **phone**: The customer's phone number at this address. * **province**: The customer's region name. Typically a province, a state, or a prefecture. * **province_code**: The two-letter code for the customer's region. * **zip**: The customer's postal code, also known as zip, postcode, Eircode, etc.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("default_address")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? DefaultAddress { get; set; } = default!;

        /// <summary>
        /// The unique email address of the customer. Attempting to assign the same email address to multiple customers returns an error.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("email")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Email { get; set; } = default!;

        /// <summary>
        /// The marketing consent information when the customer consented to receiving marketing material by email. The `email` property is required to create a customer with email consent information and to update a customer for email consent that doesn't have an email recorded. The customer must have a unique email address associated to the record. The email marketing consent has the following properties: 
        /// 
        /// *   **state**: The current email marketing state for the customer. 
        /// *   **opt_in_level**: The marketing subscription opt-in level, as described in the [M3AAWG Sender Best Common Practices](https://www.m3aawg.org/sites/default/files/document/M3AAWG_Senders_BCP_Ver3-2015-02.pdf), that the customer gave when they consented to receive marketing material by email. 
        /// *   **consent_updated_at**: The date and time when the customer consented to receive marketing material by email. If no date is provided, then the date and time when the consent information was sent is used.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("email_marketing_consent")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? EmailMarketingConsent { get; set; } = default!;

        /// <summary>
        /// The customer's first name.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("first_name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? FirstName { get; set; } = default!;

        /// <summary>
        /// The customer's last name.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("last_name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? LastName { get; set; } = default!;

        /// <summary>
        /// The ID of the customer's last order.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("last_order_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public long? LastOrderId { get; set; } = default!;

        /// <summary>
        /// The name of the customer's last order. This is directly related to the `name` field on the Order resource.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("last_order_name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? LastOrderName { get; set; } = default!;

        /// <summary>
        /// Attaches additional metadata to a shop's resources: * **key** (required): An identifier for the metafield (maximum of 30 characters). * **namespace**(required): A container for a set of metadata (maximum of 20 characters). Namespaces help distinguish between metadata that you created and metadata created by another individual with a similar namespace. * **value** (required): Information to be stored as metadata. * **type** (required): The type. Refer to the [full list of types](/apps/metafields/types). * **description** (optional): Additional information about the metafield.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("metafield")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Metafield { get; set; } = default!;

        /// <summary>
        /// As of API version 2022-04, this property is deprecated. Use `email_marketing_consent` instead.The marketing subscription opt-in level, as described in the [M3AAWG Sender Best Common Practices](https://www.m3aawg.org/sites/default/files/document/M3AAWG_Senders_BCP_Ver3-2015-02.pdf), that the customer gave when they consented to receive marketing material by email.If the customer does not accept email marketing, then this property will be set to `null`.Valid values:
        /// 
        /// *   `single_opt_in` 
        /// *   `confirmed_opt_in` 
        /// *   `unknown`
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("marketing_opt_in_level")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        [System.Obsolete]
        public string? MarketingOptInLevel { get; set; } = default!;

        /// <summary>
        /// A unique identifier for the customer that's used with [Multipass login](/api/multipass).
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("multipass_identifier")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? MultipassIdentifier { get; set; } = default!;

        /// <summary>
        /// A note about the customer.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("note")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Note { get; set; } = default!;

        /// <summary>
        /// The number of orders associated with this customer. Test and archived orders aren't counted.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("orders_count")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public int? OrdersCount { get; set; } = default!;

        /// <summary>
        /// The customer's password.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("password")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Password { get; set; } = default!;

        /// <summary>
        /// The customer's password that's confirmed.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("password_confirmation")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? PasswordConfirmation { get; set; } = default!;

        /// <summary>
        /// The unique phone number ([E.164 format](https://en.wikipedia.org/wiki/E.164)) for this customer. Attempting to assign the same phone number to multiple customers returns an error. The property can be set using different formats, but each format must represent a number that can be dialed from anywhere in the world. The following formats are all valid:
        /// 
        /// *   6135551212 
        /// *   +16135551212 
        /// *   (613)555-1212 
        /// *   +1 613-555-1212
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("phone")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Phone { get; set; } = default!;

        /// <summary>
        /// The marketing consent information when the customer consented to receiving marketing material by SMS. The `phone` property is required to create a customer with SMS consent information and to perform an SMS update on a customer that doesn't have a phone number recorded. The customer must have a unique phone number associated to the record. The SMS marketing consent has the following properties: 
        /// 
        /// *   **state**: The current SMS marketing state for the customer. 
        /// *   **opt_in_level**: The marketing subscription opt-in level, as described in the [ M3AAWG Sender Best Common Practices](https://www.m3aawg.org/sites/default/files/document/M3AAWG_Senders_BCP_Ver3-2015-02.pdf), that the customer gave when they consented to receive marketing material by SMS. 
        /// *   **consent_updated_at**: The date and time when the customer consented to receive marketing material by SMS. If no date is provided, then the date and time when the consent information was sent is used. 
        /// *   **consent_collected_from**: The source for whether the customer has consented to receive marketing material by SMS.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("sms_marketing_consent")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? SmsMarketingConsent { get; set; } = default!;

        /// <summary>
        /// The state of the customer's account with a shop. Default value: `disabled`. Valid values: * **disabled**: The customer doesn't have an active account. Customer accounts can be disabled from the Shopify admin at any time. * **invited**: The customer has received an email invite to create an account. * **enabled**: The customer has created an account. * **declined**: The customer declined the email invite to create an account.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("state")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? State { get; set; } = default!;

        /// <summary>
        /// Tags that the shop owner has attached to the customer, formatted as a string of comma-separated values. A customer can have up to 250 tags. Each tag can have up to 255 characters.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tags")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Tags { get; set; } = default!;

        /// <summary>
        /// Whether the customer is exempt from paying taxes on their order. If `true`, then taxes won't be applied to an order at checkout. If `false`, then taxes will be applied at checkout.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tax_exempt")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public bool? TaxExempt { get; set; } = default!;

        /// <summary>
        /// Whether the customer is exempt from paying specific taxes on their order. Canadian taxes only. Valid values: * **EXEMPT_ALL**: This customer is exempt from all Canadian taxes. * **CA_STATUS_CARD_EXEMPTION**: This customer is exempt from specific taxes for holding a valid STATUS_CARD_EXEMPTION in Canada. * **CA_DIPLOMAT_EXEMPTION**: This customer is exempt from specific taxes for holding a valid DIPLOMAT_EXEMPTION in Canada. * **CA_BC_RESELLER_EXEMPTION**: This customer is exempt from specific taxes for holding a valid RESELLER_EXEMPTION in British Columbia. * **CA_MB_RESELLER_EXEMPTION**: This customer is exempt from specific taxes for holding a valid RESELLER_EXEMPTION in Manitoba. * **CA_SK_RESELLER_EXEMPTION**: This customer is exempt from specific taxes for holding a valid RESELLER_EXEMPTION in Saskatchewan. * **CA_BC_COMMERCIAL_FISHERY_EXEMPTION**: This customer is exempt from specific taxes for holding a valid COMMERCIAL_FISHERY_EXEMPTION in British Columbia. * **CA_MB_COMMERCIAL_FISHERY_EXEMPTION**: This customer is exempt from specific taxes for holding a valid COMMERCIAL_FISHERY_EXEMPTION in Manitoba. * **CA_NS_COMMERCIAL_FISHERY_EXEMPTION**: This customer is exempt from specific taxes for holding a valid COMMERCIAL_FISHERY_EXEMPTION in Nova Scotia. * **CA_PE_COMMERCIAL_FISHERY_EXEMPTION**: This customer is exempt from specific taxes for holding a valid COMMERCIAL_FISHERY_EXEMPTION in Prince Edward Island. * **CA_SK_COMMERCIAL_FISHERY_EXEMPTION**: This customer is exempt from specific taxes for holding a valid COMMERCIAL_FISHERY_EXEMPTION in Saskatchewan. * **CA_BC_PRODUCTION_AND_MACHINERY_EXEMPTION**: This customer is exempt from specific taxes for holding a valid PRODUCTION_AND_MACHINERY_EXEMPTION in British Columbia. * **CA_SK_PRODUCTION_AND_MACHINERY_EXEMPTION**: This customer is exempt from specific taxes for holding a valid PRODUCTION_AND_MACHINERY_EXEMPTION in Saskatchewan. * **CA_BC_SUB_CONTRACTOR_EXEMPTION**: This customer is exempt from specific taxes for holding a valid SUB_CONTRACTOR_EXEMPTION in British Columbia. * **CA_SK_SUB_CONTRACTOR_EXEMPTION**: This customer is exempt from specific taxes for holding a valid SUB_CONTRACTOR_EXEMPTION in Saskatchewan. * **CA_BC_CONTRACTOR_EXEMPTION**: This customer is exempt from specific taxes for holding a valid CONTRACTOR_EXEMPTION in British Columbia. * **CA_SK_CONTRACTOR_EXEMPTION**: This customer is exempt from specific taxes for holding a valid CONTRACTOR_EXEMPTION in Saskatchewan. * **CA_ON_PURCHASE_EXEMPTION**: This customer is exempt from specific taxes for holding a valid PURCHASE_EXEMPTION in Ontario. * **CA_MB_FARMER_EXEMPTION**: This customer is exempt from specific taxes for holding a valid FARMER_EXEMPTION in Manitoba. * **CA_NS_FARMER_EXEMPTION**: This customer is exempt from specific taxes for holding a valid FARMER_EXEMPTION in Nova Scotia. * **CA_SK_FARMER_EXEMPTION**: This customer is exempt from specific taxes for holding a valid FARMER_EXEMPTION in Saskatchewan.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tax_exemptions")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public System.Collections.Generic.List<string>? TaxExemptions { get; set; } = default!;

        /// <summary>
        /// The total amount of money that the customer has spent across their order history.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("total_spent")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public decimal? TotalSpent { get; set; } = default!;

        /// <summary>
        /// Whether the customer has verified their email address.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("verified_email")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public bool? VerifiedEmail { get; set; } = default!;

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