using System.Runtime.Serialization;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Data;
/// <inheritdoc cref="WebhookOrig.Topic"/>
public enum WebhookTopic
{
    [EnumMember(Value = "app/uninstalled")]
    AppUninstalled,
    [EnumMember(Value = "bulk_operations/finish")]
    BulkOperationsFinish,
    [EnumMember(Value = "carts/create")]
    CartsCreate,
    [EnumMember(Value = "carts/update")]
    CartsUpdate,
    [EnumMember(Value = "checkouts/create")]
    CheckoutsCreate,
    [EnumMember(Value = "checkouts/delete")]
    CheckoutsDelete,
    [EnumMember(Value = "checkouts/update")]
    CheckoutsUpdate,
    [EnumMember(Value = "collection_listings/add")]
    CollectionListingsAdd,
    [EnumMember(Value = "collection_listings/remove")]
    CollectionListingsRemove,
    [EnumMember(Value = "collection_listings/update")]
    CollectionListingsUpdate,
    [EnumMember(Value = "collections/create")]
    CollectionsCreate,
    [EnumMember(Value = "collections/delete")]
    CollectionsDelete,
    [EnumMember(Value = "collections/update")]
    CollectionsUpdate,
    [EnumMember(Value = "customer_groups/create")]
    CustomerGroupsCreate,
    [EnumMember(Value = "customer_groups/delete")]
    CustomerGroupsDelete,
    [EnumMember(Value = "customer_groups/update")]
    CustomerGroupsUpdate,
    [EnumMember(Value = "customer_payment_methods/create")]
    CustomerPaymentMethodsCreate,
    [EnumMember(Value = "customer_payment_methods/revoke")]
    CustomerPaymentMethodsRevoke,
    [EnumMember(Value = "customer_payment_methods/update")]
    CustomerPaymentMethodsUpdate,
    [EnumMember(Value = "customers/create")]
    CustomersCreate,
    [EnumMember(Value = "customers/delete")]
    CustomersDelete,
    [EnumMember(Value = "customers/disable")]
    CustomersDisable,
    [EnumMember(Value = "customers/enable")]
    CustomersEnable,
    [EnumMember(Value = "customers/update")]
    CustomersUpdate,
    [EnumMember(Value = "customers_marketing_consent/update")]
    CustomersMarketingConsentUpdate,
    [EnumMember(Value = "disputes/create")]
    DisputesCreate,
    [EnumMember(Value = "disputes/update")]
    DisputesUpdate,
    [EnumMember(Value = "domains/create")]
    DomainsCreate,
    [EnumMember(Value = "domains/destroy")]
    DomainsDestroy,
    [EnumMember(Value = "domains/update")]
    DomainsUpdate,
    [EnumMember(Value = "draft_orders/create")]
    DraftOrdersCreate,
    [EnumMember(Value = "draft_orders/delete")]
    DraftOrdersDelete,
    [EnumMember(Value = "draft_orders/update")]
    DraftOrdersUpdate,
    [EnumMember(Value = "fulfillment_events/create")]
    FulfillmentEventsCreate,
    [EnumMember(Value = "fulfillment_events/delete")]
    FulfillmentEventsDelete,
    [EnumMember(Value = "fulfillments/create")]
    FulfillmentsCreate,
    [EnumMember(Value = "fulfillments/update")]
    FulfillmentsUpdate,
    [EnumMember(Value = "inventory_items/create")]
    InventoryItemsCreate,
    [EnumMember(Value = "inventory_items/delete")]
    InventoryItemsDelete,
    [EnumMember(Value = "inventory_items/update")]
    InventoryItemsUpdate,
    [EnumMember(Value = "inventory_levels/connect")]
    InventoryLevelsConnect,
    [EnumMember(Value = "inventory_levels/disconnect")]
    InventoryLevelsDisconnect,
    [EnumMember(Value = "inventory_levels/update")]
    InventoryLevelsUpdate,
    [EnumMember(Value = "locales/create")]
    LocalesCreate,
    [EnumMember(Value = "locales/update")]
    LocalesUpdate,
    [EnumMember(Value = "locations/create")]
    LocationsCreate,
    [EnumMember(Value = "locations/delete")]
    LocationsDelete,
    [EnumMember(Value = "locations/update")]
    LocationsUpdate,
    [EnumMember(Value = "order_transactions/create")]
    OrderTransactionsCreate,
    [EnumMember(Value = "orders/cancelled")]
    OrdersCancelled,
    [EnumMember(Value = "orders/create")]
    OrdersCreate,
    [EnumMember(Value = "orders/delete")]
    OrdersDelete,
    [EnumMember(Value = "orders/edited")]
    OrdersEdited,
    [EnumMember(Value = "orders/fulfilled")]
    OrdersFulfilled,
    [EnumMember(Value = "orders/paid")]
    OrdersPaid,
    [EnumMember(Value = "orders/partially_fulfilled")]
    OrdersPartiallyFulfilled,
    [EnumMember(Value = "orders/updated")]
    OrdersUpdated,
    [EnumMember(Value = "product_listings/add")]
    ProductListingsAdd,
    [EnumMember(Value = "product_listings/remove")]
    ProductListingsRemove,
    [EnumMember(Value = "product_listings/update")]
    ProductListingsUpdate,
    [EnumMember(Value = "products/create")]
    ProductsCreate,
    [EnumMember(Value = "products/delete")]
    ProductsDelete,
    [EnumMember(Value = "products/update")]
    ProductsUpdate,
    [EnumMember(Value = "profiles/create")]
    ProfilesCreate,
    [EnumMember(Value = "profiles/delete")]
    ProfilesDelete,
    [EnumMember(Value = "profiles/update")]
    ProfilesUpdate,
    [EnumMember(Value = "refunds/create")]
    RefundsCreate,
    [EnumMember(Value = "selling_plan_groups/create")]
    SellingPlanGroupsCreate,
    [EnumMember(Value = "selling_plan_groups/delete")]
    SellingPlanGroupsDelete,
    [EnumMember(Value = "selling_plan_groups/update")]
    SellingPlanGroupsUpdate,
    [EnumMember(Value = "shop/update")]
    ShopUpdate,
    [EnumMember(Value = "subscription_billing_attempts/challenged")]
    SubscriptionBillingAttemptsChallenged,
    [EnumMember(Value = "subscription_billing_attempts/failure")]
    SubscriptionBillingAttemptsFailure,
    [EnumMember(Value = "subscription_billing_attempts/success")]
    SubscriptionBillingAttemptsSuccess,
    [EnumMember(Value = "subscription_contracts/create")]
    SubscriptionContractsCreate,
    [EnumMember(Value = "subscription_contracts/update")]
    SubscriptionContractsUpdate,
    [EnumMember(Value = "tender_transactions/create")]
    TenderTransactionsCreate,
    [EnumMember(Value = "themes/create")]
    ThemesCreate,
    [EnumMember(Value = "themes/delete")]
    ThemesDelete,
    [EnumMember(Value = "themes/publish")]
    ThemesPublish,
    [EnumMember(Value = "themes/update")]
    ThemesUpdate,
}
