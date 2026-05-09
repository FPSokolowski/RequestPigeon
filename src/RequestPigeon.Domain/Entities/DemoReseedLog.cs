using RequestPigeon.Domain.Common;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(StartedAt))]
[Index(nameof(CompletedAt))]
public sealed class DemoReseedLog : Entity
{
    [Display(Name = "Data rozpoczęcia")]
    public DateTime StartedAt { get; set; }

    [Display(Name = "Data zakończenia")]
    public DateTime? CompletedAt { get; set; }

    [Display(Name = "Uruchomione przez użytkownika")]
    public Guid? StartedByUserId { get; set; }

    [Display(Name = "Uruchomione przez użytkownika")]
    public User? StartedByUser { get; set; }

    [Display(Name = "Zakończono sukcesem")]
    public bool? Succeeded { get; set; }

    [StringLength(1024)]
    [Display(Name = "Komunikat błędu")]
    public string? ErrorMessage { get; set; }
}
