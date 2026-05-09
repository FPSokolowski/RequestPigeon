using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RequestPigeon.Web.Models;

namespace RequestPigeon.Web.TagHelpers;

[HtmlTargetElement("select", Attributes = ItemsAttributeName)]
public sealed class DescribedSelectTagHelper : TagHelper
{
    private const string ForAttributeName = "asp-for";
    private const string ItemsAttributeName = "asp-described-items";
    private const string OptionLabelAttributeName = "asp-option-label";

    [HtmlAttributeName(ForAttributeName)]
    public ModelExpression? For { get; set; }

    [HtmlAttributeName(ItemsAttributeName)]
    public IEnumerable<DescribedSelectListItem> Items { get; set; } = [];

    [HtmlAttributeName(OptionLabelAttributeName)]
    public string? OptionLabel { get; set; }

    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext ViewContext { get; set; } = null!;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "select";
        output.TagMode = TagMode.StartTagAndEndTag;

        ApplyModelBindingAttributes(output);

        output.Content.Clear();

        if (!string.IsNullOrWhiteSpace(OptionLabel))
        {
            output.Content.AppendHtml(BuildOption(string.Empty, OptionLabel, null, false, false));
        }

        var selectedValues = GetSelectedValues();

        foreach (var item in Items)
        {
            var value = item.Value ?? item.Text;
            var selected = item.Selected || selectedValues.Contains(value);

            output.Content.AppendHtml(BuildOption(value, item.Text, item.Description, selected, item.Disabled));
        }
    }

    private void ApplyModelBindingAttributes(TagHelperOutput output)
    {
        if (For is null)
        {
            return;
        }

        var fullName = ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(For.Name);
        var id = TagBuilder.CreateSanitizedId(fullName, "_");

        output.Attributes.SetAttribute("name", fullName);

        if (!output.Attributes.ContainsName("id"))
        {
            output.Attributes.SetAttribute("id", id);
        }
    }

    private HashSet<string> GetSelectedValues()
    {
        return For?.Model switch
        {
            null => new HashSet<string>(StringComparer.Ordinal),
            string stringValue => new HashSet<string>([stringValue], StringComparer.Ordinal),
            IEnumerable values => values
                .Cast<object?>()
                .Where(value => value is not null)
                .Select(value => value!.ToString()!)
                .ToHashSet(StringComparer.Ordinal),
            var value => new HashSet<string>([value.ToString()!], StringComparer.Ordinal)
        };
    }

    private static TagBuilder BuildOption(
        string value,
        string text,
        string? description,
        bool selected,
        bool disabled)
    {
        var option = new TagBuilder("option");
        option.Attributes["value"] = value;

        if (!string.IsNullOrWhiteSpace(description))
        {
            option.Attributes["title"] = description;
            option.Attributes["data-description"] = description;
        }

        if (selected)
        {
            option.Attributes["selected"] = "selected";
        }

        if (disabled)
        {
            option.Attributes["disabled"] = "disabled";
        }

        option.InnerHtml.Append(text);

        return option;
    }
}
