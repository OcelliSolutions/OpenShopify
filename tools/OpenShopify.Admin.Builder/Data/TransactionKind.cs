using System.ComponentModel;
using System.Runtime.Serialization;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Data;

/// <inheritdoc cref="TransactionOrig.Kind"/>
public enum TransactionKind
{
    [EnumMember(Value = "authorization"), Description("Money that the customer has agreed to pay. The authorization period can be between 7 and 30 days (depending on your payment service) while a store waits for a payment to be captured.")]
    Authorization,
    [EnumMember(Value = "capture"), Description("A transfer of money that was reserved during the authorization of a shop.")]
    Capture,
    [EnumMember(Value = "sale"), Description("The authorization and capture of a payment performed in one single step.")]
    Sale,
    [EnumMember(Value = "void"), Description("The cancellation of a pending authorization or capture.")]
    Void,
    [EnumMember(Value = "refund"), Description("The partial or full return of captured money to the customer.")]
    Refund
}
