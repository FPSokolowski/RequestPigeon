namespace RequestPigeon.Domain.Enums;

public enum DecisionMakerType
{
    [Display(Name = "Bezpośredni przełożony", Description = "Decyzję podejmuje bezpośredni przełożony wnioskującego.")]
    DirectSuperior = 0,

    [Display(Name = "Wskazany użytkownik", Description = "Decyzję podejmuje konkretnie wskazany użytkownik.")]
    SpecifiedUser = 1,

    [Display(Name = "Uprawnienie", Description = "Decyzję podejmuje osoba posiadająca wskazane uprawnienie.")]
    Claim = 2,

    [Display(Name = "Członek zespołu", Description = "Decyzję podejmuje członek zespołu.")]
    TeamMember = 3,

    [Display(Name = "Rola", Description = "Decyzję podejmuje osoba z określoną rolą.")]
    Role = 4
}
