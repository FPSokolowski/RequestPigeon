using RequestPigeon.Domain.Common;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(DocumentId))]
[Index(nameof(Extension))]
public sealed class Attachment : Entity
{
    [Required]
    [Display(Name = "Dokument")]
    public Guid DocumentId { get; set; }

    [Display(Name = "Dokument")]
    public Document Document { get; set; } = null!;

    [Required]
    [StringLength(128)]
    [Display(Name = "Nazwa pliku")]
    public string FileName { get; set; } = string.Empty;

    [StringLength(1024)]
    [Display(Name = "Opis")]
    public string? Description { get; set; }

    [Required]
    [StringLength(8)]
    [RegularExpression("^(jpg|jpeg|pdf)$", ErrorMessage = "Dozwolone rozszerzenia: jpg, jpeg, pdf.")]
    [Display(Name = "Rozszerzenie", Description = "Dozwolone rozszerzenia w MVP: jpg, jpeg, pdf.")]
    public string Extension { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Zawartość pliku", Description = "Maksymalny rozmiar załącznika w MVP: 5 MB.")]
    public byte[] Content { get; set; } = [];
}
