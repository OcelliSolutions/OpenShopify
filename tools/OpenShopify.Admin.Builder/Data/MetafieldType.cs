using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum MetafieldType
{
    [EnumMember(Value = "boolean")] [Description("A true or false value.")]
    Boolean,

    [EnumMember(Value = "color")] [Description("The hexadecimal code for a color.")]
    Color,

    [EnumMember(Value = "date")] [Description("A date in ISO 8601 format without a presumed timezone.")]
    Date,

    [EnumMember(Value = "date_time")] [Description("A date and time in ISO 8601 format without a presumed timezone")]
    DateTime,

    [EnumMember(Value = "dimension")]
    [Description("A value and a unit of length. Valid unit values: in, ft, yd, mm, cm, m")]
    Dimension,

    [EnumMember(Value = "file_reference")]
    [Description(
        "A reference to a file on the online store. The default value is GenericFile. You can use validations to add other file types (for example, Image).")]
    FileReference,

    [EnumMember(Value = "json")]
    [Description(
        "A JSON-serializable value. This can be an object, an array, a string, a number, a boolean, or a null value.")]
    Json,

    [EnumMember(Value = "multi_line_text_field")] [Description("A multi-line text field.")]
    MultiLineTextField,

    [EnumMember(Value = "number_decimal")]
    [Description("A number with decimal places in the range of +/-9999999999999.999999999.")]
    NumberDecimal,

    [EnumMember(Value = "number_integer")] [Description("A whole number in the range of +/-9,007,199,254,740,991.")]
    NumberInteger,

    [EnumMember(Value = "page_reference")] [Description("A reference to a page on the online store.")]
    PageReference,

    [EnumMember(Value = "product_reference")] [Description("A reference to a product on the online store.")]
    ProductReference,

    [EnumMember(Value = "rating")]
    [Description("A rating measured on a specified scale. Validations are required for ratings.")]
    Rating,

    [EnumMember(Value = "single_line_text_field")] [Description("A single-line text field.")]
    SingleLineTextField,

    [EnumMember(Value = "variant_reference")] [Description("A reference to a product variant on the online store.")]
    VariantReference,

    [EnumMember(Value = "volume")]
    [Description(
        "A value and a unit of volume. Valid unit values: ml, cl, l, m3 (cubic meters), us_fl_oz, us_pt, us_qt, us_gal, imp_fl_oz, imp_pt, imp_qt, imp_gal.")]
    Volume,

    [EnumMember(Value = "weight")] [Description("A value and a unit of weight. Valid unit values: oz, lb, g, kg")]
    Weight
}