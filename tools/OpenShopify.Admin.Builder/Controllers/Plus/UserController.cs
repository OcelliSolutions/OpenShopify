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

    public abstract class UserControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of all users
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users. **Note:** As of version 2021-01, this endpoint implements pagination by using links that are provided in the response header. Sending the `page` parameter will return an error. To learn more, see [*Make paginated requests to the REST Admin API*](/api/usage/pagination-rest).
        /// </remarks>
        /// <param name="limit">The maximum number of results to show on a page.</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("users.json")]
        public abstract System.Threading.Tasks.Task ListUsers([Microsoft.AspNetCore.Mvc.FromQuery] int? limit = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? page_info = null);

        /// <summary>
        /// Retrieves a single user
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("users/{user_id}.json")]
        public abstract System.Threading.Tasks.Task GetUser(long user_id);

        /// <summary>
        /// Retrieves the currently logged-in user
        /// </summary>
        /// <remarks>
        /// Retrieves information about the user account associated with the access token used to make this API request. This request works only when the access token was created for a specific user of the shop.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("users/current.json")]
        public abstract System.Threading.Tasks.Task GetCurrentlyLoggedInUser();

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum UserPermissions
    {

        [System.Runtime.Serialization.EnumMember(Value = @"applications")]
        Applications = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"billing_application_charges")]
        BillingApplicationCharges = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"billing_charges")]
        BillingCharges = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"billing_invoices_view")]
        BillingInvoicesView = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"billing_payment_methods_view")]
        BillingPaymentMethodsView = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"customers")]
        Customers = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"dashboard")]
        Dashboard = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"domains")]
        Domains = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"draft_orders")]
        DraftOrders = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"edit_orders")]
        EditOrders = 9,

        [System.Runtime.Serialization.EnumMember(Value = @"edit_private_apps")]
        EditPrivateApps = 10,

        [System.Runtime.Serialization.EnumMember(Value = @"export_customers")]
        ExportCustomers = 11,

        [System.Runtime.Serialization.EnumMember(Value = @"export_draft_orders")]
        ExportDraftOrders = 12,

        [System.Runtime.Serialization.EnumMember(Value = @"export_products")]
        ExportProducts = 13,

        [System.Runtime.Serialization.EnumMember(Value = @"export_orders")]
        ExportOrders = 14,

        [System.Runtime.Serialization.EnumMember(Value = @"gift_cards")]
        GiftCards = 15,

        [System.Runtime.Serialization.EnumMember(Value = @"links")]
        Links = 16,

        [System.Runtime.Serialization.EnumMember(Value = @"locations")]
        Locations = 17,

        [System.Runtime.Serialization.EnumMember(Value = @"marketing")]
        Marketing = 18,

        [System.Runtime.Serialization.EnumMember(Value = @"marketing_section")]
        MarketingSection = 19,

        [System.Runtime.Serialization.EnumMember(Value = @"orders")]
        Orders = 20,

        [System.Runtime.Serialization.EnumMember(Value = @"overviews")]
        Overviews = 21,

        [System.Runtime.Serialization.EnumMember(Value = @"pages")]
        Pages = 22,

        [System.Runtime.Serialization.EnumMember(Value = @"preferences")]
        Preferences = 23,

        [System.Runtime.Serialization.EnumMember(Value = @"products")]
        Products = 24,

        [System.Runtime.Serialization.EnumMember(Value = @"reports")]
        Reports = 25,

        [System.Runtime.Serialization.EnumMember(Value = @"shopify_payments_accounts")]
        ShopifyPaymentsAccounts = 26,

        [System.Runtime.Serialization.EnumMember(Value = @"shopify_payments_transfers")]
        ShopifyPaymentsTransfers = 27,

        [System.Runtime.Serialization.EnumMember(Value = @"staff_audit_log_view")]
        StaffAuditLogView = 28,

        [System.Runtime.Serialization.EnumMember(Value = @"staff_management_activation")]
        StaffManagementActivation = 29,

        [System.Runtime.Serialization.EnumMember(Value = @"staff_management_create")]
        StaffManagementCreate = 30,

        [System.Runtime.Serialization.EnumMember(Value = @"staff_management_delete")]
        StaffManagementDelete = 31,

        [System.Runtime.Serialization.EnumMember(Value = @"staff_management_update")]
        StaffManagementUpdate = 32,

        [System.Runtime.Serialization.EnumMember(Value = @"themes")]
        Themes = 33,

        [System.Runtime.Serialization.EnumMember(Value = @"view_private_apps")]
        ViewPrivateApps = 34,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum UserReceiveAnnouncements
    {

        [System.Runtime.Serialization.EnumMember(Value = @"0")]
        _0 = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"1")]
        _1 = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum UserUserType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"regular")]
        Regular = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"restricted")]
        Restricted = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"invited")]
        Invited = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"collaborator")]
        Collaborator = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record UserOrig
    {
        /// <summary>
        /// Whether the user is the owner of the Shopify account.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("account_owner")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public bool? AccountOwner { get; set; } = default!;

        /// <summary>
        /// The description the user has written for themselves.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("bio")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Bio { get; set; } = default!;

        /// <summary>
        /// The user's email address.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("email")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Email { get; set; } = default!;

        /// <summary>
        /// The user's first name.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("first_name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? FirstName { get; set; } = default!;

        /// <summary>
        /// The user's IM account address.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("im")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Im { get; set; } = default!;

        /// <summary>
        /// The user's last name.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("last_name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? LastName { get; set; } = default!;

        /// <summary>
        /// The permissions granted to the user's staff account. Valid values:
        /// 
        /// *   **applications**: The user can authorize the installation of applications. 
        /// *   **billing_application_charges**: The user can approve application charges. 
        /// *   **billing_charges**: The user can view and export billing charges. 
        /// *   **billing_invoices_view**: The user can view billing invoices. 
        /// *   **billing_payment_methods_view**: The user can view billing payment methods. 
        /// *   **customers**: The user can view, create, edit, and delete customers, and respond to customer messages in Shopify Ping. 
        /// *   **dashboard**: The user can view the **Home** page, which includes sales information and other store data. 
        /// *   **domains**: The user can view, buy, and manage domains. 
        /// *   **draft_orders**: The user can create, update, and delete draft orders. 
        /// *   **edit_orders**: The user can edit orders. 
        /// *   **edit_private_apps**: The user can give permission to private apps to read, write, and make changes to the store. 
        /// *   **export_customers**: The user can export customers. 
        /// *   **export_draft_orders**: The user can export draft orders. 
        /// *   **export_products**: The user can export products and inventory. 
        /// *   **export_orders**: The user can export orders. 
        /// *   **gift_cards**: The user can view, create, issue, and export gift cards to a CSV file. 
        /// *   **links**: The user can view and modify links and navigation menus. 
        /// *   **locations**: The user can create, update, and delete locations where you stock or manage inventory. 
        /// *   **marketing**: The user can view and create discount codes and automatic discounts, and export discounts to a CSV file. 
        /// *   **marketing_section**: The user can view, create, and automate marketing campaigns. 
        /// *   **orders**: The user can view, create, update, delete, and cancel orders, and receive order notifications. 
        /// *   **overviews**: The user can view the **Overview** and **Live view** pages, which include sales information, and other store and sales channels data. 
        /// *   **pages**: The user can view, create, update, publish, and delete blog posts and pages. 
        /// *   **preferences**: The user can view the preferences and configuration of a shop. 
        /// *   **products**: The user can view, create, import, and update products, collections, and inventory. 
        /// *   **reports**: The user can view and create all reports, which includes sales information and other store data. 
        /// *   **shopify_payments_accounts**: The user can view Shopify Payments account details. 
        /// *   **shopify_payments_transfers**: The user can view Shopify Payments payouts. 
        /// *   **staff_audit_log_view**: The user can view Shopify admin browser sessions. 
        /// *   **staff_management_activation**: The user can activate or deactivate staff in the store. 
        /// *   **staff_management_create**: The user can add staff to the store. 
        /// *   **staff_management_delete**: The user can delete staff from the store. 
        /// *   **staff_management_update**: The user can update staff in the store. 
        /// *   **themes**: The user can view, update, and publish themes. 
        /// *   **view_private_apps**: The user can view private apps installed on the store.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("permissions")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public System.Collections.Generic.List<string>? Permissions { get; set; } = default!;

        /// <summary>
        /// The user's phone number.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("phone")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Phone { get; set; } = default!;

        /// <summary>
        /// Whether this account will receive email announcements from Shopify. Valid values: `0`, `1`
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("receive_announcements")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public bool? ReceiveAnnouncements { get; set; } = default!;

        /// <summary>
        /// This property is deprecated.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("screen_name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        [System.Obsolete]
        public string? ScreenName { get; set; } = default!;

        /// <summary>
        /// The user's homepage or other web address.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("url")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Url { get; set; } = default!;

        /// <summary>
        /// The user's preferred locale. Locale values use the format `language` or `language-COUNTRY`, where `language` is a two-letter language code, and `COUNTRY` is a two-letter country code. For example: `en` or `en-US`
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("locale")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Locale { get; set; } = default!;

        /// <summary>
        /// The type of account the user has. Valid values:
        /// 
        /// *   **regular**: The user's account can access the Shopify admin. 
        /// *   **restricted**: The user's account cannot access the Shopify admin. 
        /// *   **invited**: The user has not yet accepted the invitation to create staff. 
        /// *   **collaborator**: The user account of a partner who collaborates with the merchant.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("user_type")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? UserType { get; set; } = default!;

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