using RequestPigeon.Domain.Enums;

namespace RequestPigeon.Domain.Entities;

public sealed class CredentialsRequestDocument : Document
{
    public CredentialsRequestDocument()
    {
        Type = DocumentType.Credentials;
    }

    [Required]
    [StringLength(256)]
    [Display(Name = "Uprawnienie", Description = "Nazwa lub opis uprawnienia, o które wnioskuje użytkownik.")]
    public string Credential { get; set; } = string.Empty;

    [Display(Name = "Data wygaśnięcia")]
    public DateOnly? ExpirationDate { get; set; }
}
