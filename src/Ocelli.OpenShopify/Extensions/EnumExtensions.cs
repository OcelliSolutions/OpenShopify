using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Serialization;

namespace Ocelli.OpenShopify.Extensions;

internal static class EnumExtensions
{
    internal static string? GetDisplayName(this Enum enumValue) =>
        enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName();

    internal static T? GetEnumFromString<T>(this string? name) where T : Enum
    {
        var type = typeof(T);

        foreach (var field in type.GetFields())
        {
            if (Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) is DisplayAttribute attribute)
            {
                if (attribute.Name == name) return (T?)field.GetValue(null);
            }

            if (field.Name == name) return (T?)field.GetValue(null);
        }

        throw new ArgumentOutOfRangeException(nameof(name));
    }

    /// <summary>
    /// Reads and uses the enum's <see cref="EnumMemberAttribute"/> for serialization.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string ToSerializedString(this Enum input)
    {
        var name = input.ToString();
        var info = input.GetType().GetTypeInfo().DeclaredMembers.Where(i => i.Name == name);

        var memberInfos = info.ToList();
        if (!memberInfos.Any()) return name.ToLower();

        var attribute = memberInfos.First().GetCustomAttribute<EnumMemberAttribute>();

        if (attribute != null) return attribute.Value ?? throw new InvalidOperationException("Not a valid value.");

        return name.ToLower();
    }
}