using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum TransactionErrorCode
{
    [EnumMember(Value = "incorrect_number")]
    IncorrectNumber,
    [EnumMember(Value = "invalid_number")]
    InvalidNumber,
    [EnumMember(Value = "invalid_expiry_date")]
    InvalidExpiryDate,
    [EnumMember(Value = "invalid_cvc")]
    InvalidCvc,
    [EnumMember(Value = "expired_card")]
    ExpiredCard,
    [EnumMember(Value = "incorrect_cvc")]
    IncorrectCvc,
    [EnumMember(Value = "incorrect_zip")]
    IncorrectZip,
    [EnumMember(Value = "incorrect_address")]
    IncorrectAddress,
    [EnumMember(Value = "card_declined")]
    CardDeclined,
    [EnumMember(Value = "processing_error")]
    ProcessingError,
    [EnumMember(Value = "call_issuer")]
    CallIssuer,
    [EnumMember(Value = "pick_up_card")]
    PickUpCard
}
