namespace RequestPigeon.Domain.Enums;

public enum Decision
{
    [Display(Name = "Odrzucenie", Description = "Wniosek został rozpatrzony negatywnie.")]
    Decline = 0,

    [Display(Name = "Akceptacja", Description = "Wniosek został zatwierdzony.")]
    Accept = 1,

    [Display(Name = "Do poprawy", Description = "Wniosek został zwrócony autorowi do poprawy.")]
    Return = 2
}
