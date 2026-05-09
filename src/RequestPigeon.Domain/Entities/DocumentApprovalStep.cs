using RequestPigeon.Domain.Common;
using RequestPigeon.Domain.Enums;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(DocumentId), nameof(StepOrder))]
[Index(nameof(ApproverId), nameof(Status))]
public sealed class DocumentApprovalStep : Entity
{
    [Required]
    [Display(Name = "Dokument")]
    public Guid DocumentId { get; set; }

    [Display(Name = "Dokument")]
    public Document Document { get; set; } = null!;

    [Required]
    [Display(Name = "Osoba decyzyjna")]
    public Guid ApproverId { get; set; }

    [Display(Name = "Osoba decyzyjna")]
    public User Approver { get; set; } = null!;

    [Display(Name = "Kolejność kroku")]
    public int StepOrder { get; set; }

    [Required]
    [Display(Name = "Status kroku")]
    public ApprovalStepStatus Status { get; set; }

    [Display(Name = "Decyzja")]
    public Decision? Decision { get; set; }

    [Display(Name = "Data przekazania")]
    public DateTime? DateTimeIssued { get; set; }

    [Display(Name = "Data decyzji")]
    public DateTime? DateTimeDecision { get; set; }

    [StringLength(1024)]
    [Display(Name = "Komentarz")]
    public string? Comment { get; set; }
}
