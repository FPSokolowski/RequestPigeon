namespace RequestPigeon.Domain.Enums;

public enum ApprovalStepStatus
{
    [Display(Name = "Oczekuje", Description = "Krok czeka na zakończenie wcześniejszych kroków.")]
    Waiting = 0,

    [Display(Name = "Do decyzji", Description = "Krok jest aktywny i oczekuje na decyzję.")]
    Pending = 1,

    [Display(Name = "Zatwierdzono", Description = "Krok został zatwierdzony.")]
    Approved = 2,

    [Display(Name = "Odrzucono", Description = "Krok został odrzucony.")]
    Declined = 3,

    [Display(Name = "Do poprawy", Description = "Dokument został zwrócony do autora.")]
    Returned = 4,

    [Display(Name = "Pominięto", Description = "Krok został pominięty przez reguły workflow.")]
    Skipped = 5
}
