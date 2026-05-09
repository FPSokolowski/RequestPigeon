namespace RequestPigeon.Domain.Enums;

public enum DocumentStatus
{
    [Display(Name = "Wersja robocza", Description = "Dokument jest w trakcie tworzenia.")]
    Draft = 0,

    [Display(Name = "Oczekiwanie na decyzję", Description = "Dokument oczekuje na zatwierdzenie.")]
    InReview = 1,

    [Display(Name = "Zatwierdzono", Description = "Dokument został rozpatrzony pozytywnie.")]
    Approved = 2,

    [Display(Name = "Odrzucono", Description = "Dokument został rozpatrzony negatywnie.")]
    Declined = 3,

    [Display(Name = "Zwrócono do poprawy", Description = "Dokument został zwrócony autorowi do poprawy.")]
    Returned = 4,

    [Display(Name = "Anulowano", Description = "Dokument został anulowany.")]
    Cancelled = 5
}
