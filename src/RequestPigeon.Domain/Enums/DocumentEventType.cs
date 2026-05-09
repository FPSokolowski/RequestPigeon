namespace RequestPigeon.Domain.Enums;

public enum DocumentEventType
{
    [Display(Name = "Utworzono roboczo", Description = "Dokument został utworzony jako wersja robocza.")]
    CreatedAsWorkCopy = 0,

    [Display(Name = "Wysłano", Description = "Dokument został wysłany do akceptacji.")]
    Sent = 1,

    [Display(Name = "Decyzja", Description = "Osoba decyzyjna podjęła decyzję.")]
    Decision = 2,

    [Display(Name = "Zamknięto", Description = "Proces dokumentu został zamknięty.")]
    Closed = 3,

    [Display(Name = "Zwrócono do poprawy", Description = "Dokument został zwrócony autorowi.")]
    Returned = 4,

    [Display(Name = "Poprawiono", Description = "Autor poprawił dokument po zwróceniu.")]
    Remake = 5,

    [Display(Name = "Anulowano", Description = "Dokument został anulowany.")]
    Cancelled = 6
}
