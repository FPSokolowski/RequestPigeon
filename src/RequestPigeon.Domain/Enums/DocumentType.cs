namespace RequestPigeon.Domain.Enums;

public enum DocumentType
{
    [Display(Name = "Urlop", Description = "Wniosek o urlop.")]
    Leave = 0,

    [Display(Name = "Zwrot kosztów", Description = "Wniosek o zwrot kosztów. Post-MVP.")]
    Refund = 1,

    [Display(Name = "Zakup", Description = "Wniosek o zakup.")]
    Purchase = 2,

    [Display(Name = "Wyjazd służbowy", Description = "Wniosek o zatwierdzenie wyjazdu służbowego.")]
    BusinessTrip = 3,

    [Display(Name = "Przyznanie uprawnień", Description = "Wniosek o przyznanie uprawnień.")]
    Credentials = 4,

    [Display(Name = "Pismo ogólne", Description = "Ogólny typ dokumentu. Post-MVP.")]
    Other = 5
}
