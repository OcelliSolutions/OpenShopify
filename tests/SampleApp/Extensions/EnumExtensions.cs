using System.Reflection;
using System.Runtime.Serialization;

namespace SampleApp.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// Get the EnumMember Value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string? GetEnumMemberValue<T>(T value)
        where T : Enum
    {
        return typeof(T)
            .GetTypeInfo()
            .DeclaredMembers
            .SingleOrDefault(x => x.Name == value.ToString())
            ?.GetCustomAttribute<EnumMemberAttribute>(false)
            ?.Value;
    }

}
