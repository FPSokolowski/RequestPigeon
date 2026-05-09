namespace RequestPigeon.Domain.Enums;

public enum AppLogLevel
{
    [Display(Name = "Ślad", Description = "Najbardziej szczegółowy poziom logowania.")]
    Trace = 0,

    [Display(Name = "Debug", Description = "Informacje pomocne podczas diagnozowania działania aplikacji.")]
    Debug = 1,

    [Display(Name = "Informacja", Description = "Standardowa informacja o działaniu aplikacji.")]
    Information = 2,

    [Display(Name = "Ostrzeżenie", Description = "Sytuacja nietypowa, ale nieblokująca działania aplikacji.")]
    Warning = 3,

    [Display(Name = "Błąd", Description = "Błąd wymagający obsługi lub analizy.")]
    Error = 4,

    [Display(Name = "Błąd krytyczny", Description = "Błąd krytyczny wpływający na działanie aplikacji.")]
    Critical = 5
}
