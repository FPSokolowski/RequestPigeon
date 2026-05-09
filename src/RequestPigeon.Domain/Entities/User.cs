using RequestPigeon.Domain.Common;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(UserName), IsUnique = true)]
public sealed class User : Entity, ISoftDelete
{
    [Display(Name = "Aktywne konto")]
    public bool IsActiveAccount { get; set; }

    [Display(Name = "Użytkownik demo")]
    public bool? IsDemo { get; set; }

    [Required]
    [StringLength(64)]
    [Display(Name = "Nazwa użytkownika")]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [StringLength(64)]
    [Display(Name = "Imię")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(128)]
    [Display(Name = "Nazwisko")]
    public string Surname { get; set; } = string.Empty;

    [StringLength(128)]
    [EmailAddress]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [StringLength(16)]
    [Phone]
    [Display(Name = "Telefon")]
    public string? Phone { get; set; }

    [StringLength(256)]
    [Display(Name = "Hasło")]
    public string? Password { get; set; }

    [Display(Name = "Blokada po błędnych logowaniach")]
    public DateTime? LockedFailedLog { get; set; }

    [Display(Name = "Liczba błędnych logowań")]
    public int FailedLoginCount { get; set; }

    [Display(Name = "Zablokowane")]
    public bool LockedOut { get; set; }

    [Display(Name = "Wymagana zmiana hasła")]
    public bool PassChangeRequired { get; set; } = true;

    [Display(Name = "Usunięto")]
    public bool IsDeleted { get; set; }

    [Required]
    [Display(Name = "Rola")]
    public Guid RoleId { get; set; }

    [Display(Name = "Rola")]
    public Role Role { get; set; } = null!;

    [Display(Name = "Uprawnienia użytkownika")]
    public ICollection<UserClaim> UserClaims { get; set; } = [];

    [Display(Name = "Dokumenty użytkownika")]
    public ICollection<Document> RequestedDocuments { get; set; } = [];

    [Display(Name = "Kroki akceptacji")]
    public ICollection<DocumentApprovalStep> ApprovalSteps { get; set; } = [];
}
