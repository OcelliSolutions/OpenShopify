namespace OpenShopify.Admin.Builder.Data;

public enum ApplicationChargeStatus
{
    pending,
    [Obsolete("Removed in version 2021-01")]
    accepted,
    active,
    declined,
    expired
}
