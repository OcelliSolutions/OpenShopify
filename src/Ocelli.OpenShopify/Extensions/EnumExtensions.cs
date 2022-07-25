using System.Reflection;
using System.Runtime.Serialization;

namespace Ocelli.OpenShopify.Extensions;

internal static class EnumExtensions
{
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