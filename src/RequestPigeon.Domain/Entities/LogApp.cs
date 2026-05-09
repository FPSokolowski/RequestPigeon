using RequestPigeon.Domain.Common;
using RequestPigeon.Domain.Enums;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(CreatedAt))]
[Index(nameof(LogLevel))]
public sealed class LogApp : Entity
{
    [Required]
    [Display(Name = "Poziom logu")]
    public AppLogLevel LogLevel { get; set; }

    [Display(Name = "Użytkownik")]
    public Guid? UserId { get; set; }

    [Display(Name = "Użytkownik")]
    public User? User { get; set; }

    [StringLength(64)]
    [Display(Name = "Zdarzenie")]
    public string? Event { get; set; }

    [StringLength(512)]
    [Display(Name = "Wartość po zmianie")]
    public string? ValueAfter { get; set; }

    [StringLength(256)]
    [Display(Name = "Informacja")]
    public string? Info { get; set; }
}
