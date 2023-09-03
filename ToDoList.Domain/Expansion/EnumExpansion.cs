using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ToDoList.Domain.Expansion
{
    public static class EnumExpansion
    {
        public static string GetDisplayName(this System.Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<DisplayAttribute>()?.GetName() ?? "Undefined";
        }
    }
}