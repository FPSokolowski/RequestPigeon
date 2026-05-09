using RequestPigeon.Domain.Common;
using RequestPigeon.Domain.Enums;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(Type))]
[Index(nameof(DateTime))]
[Index(nameof(Type), nameof(Status))]
public abstract class Document : Entity
{
    [Display(Name = "Data dokumentu")]
    public DateTime DateTime { get; set; }

    [Required]
    [Display(Name = "Typ")]
    public DocumentType Type { get; protected set; }

    [Required]
    [Display(Name = "Status")]
    public DocumentStatus Status { get; set; } = DocumentStatus.Draft;

    [Required]
    [Display(Name = "Priorytet")]
    public DocumentPriority Priority { get; set; } = DocumentPriority.Medium;

    [StringLength(2048)]
    [Display(Name = "Treść", Description = "Uzasadnienie, cel albo dodatkowy opis dokumentu.")]
    public string? TextContent { get; set; }

    [StringLength(1024)]
    [Display(Name = "Wiadomość", Description = "Nieformalna wiadomość wysyłana razem z dokumentem.")]
    public string? TextMessage { get; set; }

    [Required]
    [Display(Name = "Wnioskujący")]
    public Guid RequesterId { get; set; }

    [Display(Name = "Wnioskujący")]
    public User Requester { get; set; } = null!;

    [Display(Name = "Załączniki")]
    public ICollection<Attachment> Attachments { get; set; } = [];

    [Display(Name = "Kroki akceptacji")]
    public ICollection<DocumentApprovalStep> ApprovalSteps { get; set; } = [];

    [Display(Name = "Historia dokumentu")]
    public ICollection<LogDocument> Logs { get; set; } = [];
}
