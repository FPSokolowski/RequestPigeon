namespace RequestPigeon.Domain.Enums;

public enum DocumentPriority
{
    [Display(Name = "Niski", Description = "Sprawa niewymagająca szybkiej reakcji.")]
    Low = 0,

    [Display(Name = "Normalny", Description = "Standardowy priorytet dokumentu.")]
    Medium = 1,

    [Display(Name = "Wysoki", Description = "Sprawa wymagająca szybszej reakcji.")]
    High = 2,

    [Display(Name = "Wysoki pilny", Description = "Sprawa pilna, do obsłużenia możliwie szybko.")]
    HighASAP = 3,

    [Display(Name = "Krytyczny", Description = "Najwyższy priorytet demonstracyjny.")]
    PeopleAreDying = 4
}
