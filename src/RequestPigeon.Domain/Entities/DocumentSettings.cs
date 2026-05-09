using RequestPigeon.Domain.Common;
using RequestPigeon.Domain.Enums;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(Type), IsUnique = true)]
public sealed class DocumentSettings : Entity
{
    [Required]
    [Display(Name = "Typ dokumentu")]
    public DocumentType Type { get; set; }

    [Required]
    [StringLength(128)]
    [Display(Name = "Nagłówek")]
    public string Header { get; set; } = string.Empty;

    [StringLength(2048)]
    [Display(Name = "Domyślna treść")]
    public string? DefaultTextContent { get; set; }

    [Display(Name = "Reguły akceptacji")]
    public ICollection<DocumentApprovalRule> ApprovalRules { get; set; } = [];
}
