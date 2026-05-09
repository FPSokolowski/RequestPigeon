namespace RequestPigeon.Domain.Enums;

public enum ExpensesType
{
    [Display(Name = "IT", Description = "Wydatek IT, np. sprzęt lub oprogramowanie.")]
    IT = 0,

    [Display(Name = "Podróż służbowa", Description = "Koszty związane z podróżą służbową.")]
    BusinessTrip = 1,

    [Display(Name = "Materiały eksploatacyjne", Description = "Materiały eksploatacyjne.")]
    Consumables = 2,

    [Display(Name = "Reprezentacja", Description = "Wydatki reprezentacyjne.")]
    Representation = 3,

    [Display(Name = "Integracja", Description = "Wydatki związane z integracją zespołu.")]
    Integration = 4,

    [Display(Name = "Inne usługi", Description = "Pozostałe usługi.")]
    OtherServices = 5,

    [Display(Name = "Inne przedmioty", Description = "Pozostałe przedmioty lub towary.")]
    OtherItems = 6
}
