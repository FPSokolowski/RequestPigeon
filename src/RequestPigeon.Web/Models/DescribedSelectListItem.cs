using Microsoft.AspNetCore.Mvc.Rendering;

namespace RequestPigeon.Web.Models;

public sealed class DescribedSelectListItem : SelectListItem
{
    public string? Description { get; set; }
}
