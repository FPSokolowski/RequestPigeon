using RequestPigeon.Domain.Common;
using RequestPigeon.Domain.Enums;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(DocumentSettingsId), nameof(StepOrder))]
[Index(nameof(DecisionMakerType), nameof(UserId), nameof(RoleOrClaimName))]
public sealed class DocumentApprovalRule : Entity
{
    [Required]
    [Display(Name = "Ustawienia dokumentu")]
    public Guid DocumentSettingsId { get; set; }

    [Display(Name = "Ustawienia dokumentu")]
    public DocumentSettings DocumentSettings { get; set; } = null!;

    [Display(Name = "Kolejność kroku")]
    public int StepOrder { get; set; }

    [Required]
    [Display(Name = "Typ osoby decyzyjnej")]
    public DecisionMakerType DecisionMakerType { get; set; }

    [Display(Name = "Zezwól na samoakceptację")]
    public bool AllowSelfApproval { get; set; }

    [Display(Name = "Użytkownik")]
    public Guid? UserId { get; set; }

    [Display(Name = "Użytkownik")]
    public User? User { get; set; }

    [StringLength(64)]
    [Display(Name = "Nazwa roli lub uprawnienia")]
    public string? RoleOrClaimName { get; set; }
}
