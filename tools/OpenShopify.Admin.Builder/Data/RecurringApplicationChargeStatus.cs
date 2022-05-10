namespace OpenShopify.Admin.Builder.Data;

public enum RecurringApplicationChargeStatus
{
    pending,
    [Obsolete("Removed in version 2021-01")]
    accepted,
    active,
    declined,
    expired,
    frozen,
    cancelled
}
