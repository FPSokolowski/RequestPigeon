namespace RequestPigeon.Domain.Enums;

public enum BusinessTripPurpose
{
    [Display(Name = "Praca / świadczenie usług", Description = "Wyjazd związany z wykonywaniem pracy lub świadczeniem usług.")]
    Work = 0,

    [Display(Name = "Reprezentacja / negocjacje", Description = "Wyjazd reprezentacyjny albo negocjacyjny.")]
    Representation = 1,

    [Display(Name = "Integracja zespołu", Description = "Wyjazd związany z budowaniem zespołu.")]
    TeamBuilding = 2,

    [Display(Name = "Szkolenie", Description = "Wyjazd szkoleniowy.")]
    Training = 3,

    [Display(Name = "Inne", Description = "Inny cel wyjazdu służbowego.")]
    Other = 4
}
