namespace RequestPigeon.Domain.Enums;

public enum ClaimValueType
{
    [Display(Name = "Bool", Description = "Uprawnienie typu prawda/fałsz. Typ używany w MVP.")]
    Bool = 0,

    [Display(Name = "Tekst", Description = "Tekstowa wartość uprawnienia. Post-MVP.")]
    Text = 1,

    [Display(Name = "Liczba", Description = "Liczbowa wartość uprawnienia. Post-MVP.")]
    Number = 2,

    [Display(Name = "Data", Description = "Wartość daty. Post-MVP.")]
    Date = 3,

    [Display(Name = "JSON", Description = "Strukturalna wartość uprawnienia. Post-MVP.")]
    Json = 4
}
