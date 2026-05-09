using System.ComponentModel.DataAnnotations;
using System.Reflection;
using RequestPigeon.Web.Models;

namespace RequestPigeon.Web.Extensions;

public static class EnumSelectListExtensions
{
    public static IReadOnlyList<DescribedSelectListItem> ToDescribedSelectList<TEnum>(TEnum? selected = null)
        where TEnum : struct, Enum
    {
        var selectedValue = selected?.ToString();

        return [.. Enum.GetValues<TEnum>()
            .Select(value => value.ToDescribedSelectListItem(selectedValue))
        ];
    }

    public static IReadOnlyList<DescribedSelectListItem> ToDescribedSelectList<TEnum>(IEnumerable<TEnum> selectedValues)
        where TEnum : struct, Enum
    {
        var selectedSet = selectedValues
            .Select(value => value.ToString())
            .ToHashSet(StringComparer.Ordinal);

        return [.. Enum.GetValues<TEnum>()
            .Select(value => value.ToDescribedSelectListItem(selectedSet))
        ];
    }

    private static DescribedSelectListItem ToDescribedSelectListItem<TEnum>(this TEnum value, string? selectedValue)
        where TEnum : struct, Enum
    {
        var display = value.GetDisplayAttribute();
        var enumValue = value.ToString();

        return new DescribedSelectListItem
        {
            Value = enumValue,
            Text = display?.GetName() ?? enumValue,
            Description = display?.GetDescription(),
            Selected = string.Equals(enumValue, selectedValue, StringComparison.Ordinal)
        };
    }

    private static DescribedSelectListItem ToDescribedSelectListItem<TEnum>(this TEnum value, HashSet<string> selectedValues)
        where TEnum : struct, Enum
    {
        var display = value.GetDisplayAttribute();
        var enumValue = value.ToString();

        return new DescribedSelectListItem
        {
            Value = enumValue,
            Text = display?.GetName() ?? enumValue,
            Description = display?.GetDescription(),
            Selected = selectedValues.Contains(enumValue)
        };
    }

    private static DisplayAttribute? GetDisplayAttribute<TEnum>(this TEnum value)
        where TEnum : struct, Enum
    {
        return typeof(TEnum)
            .GetMember(value.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DisplayAttribute>();
    }
}
