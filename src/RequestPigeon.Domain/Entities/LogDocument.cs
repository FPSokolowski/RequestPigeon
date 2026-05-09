using RequestPigeon.Domain.Common;
using RequestPigeon.Domain.Enums;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(CreatedAt))]
public sealed class LogDocument : Entity
{
    [Display(Name = "Dokument")]
    public Guid? DocumentId { get; set; }

    [Display(Name = "Dokument")]
    public Document? Document { get; set; }

    [Required]
    [Display(Name = "Typ zdarzenia")]
    public DocumentEventType EventType { get; set; }

    [Display(Name = "Użytkownik")]
    public Guid? UserId { get; set; }

    [Display(Name = "Użytkownik")]
    public User? User { get; set; }

    [StringLength(64)]
    [Display(Name = "Co zmieniono")]
    public string? WhatChanged { get; set; }

    [StringLength(512)]
    [Display(Name = "Wartość po zmianie")]
    public string? ValueAfter { get; set; }

    [Display(Name = "Poprzedni status")]
    public DocumentStatus? StatusBefore { get; set; }

    [Display(Name = "Nowy status")]
    public DocumentStatus? StatusAfter { get; set; }

    [StringLength(256)]
    [Display(Name = "Informacja")]
    public string? Info { get; set; }
}
