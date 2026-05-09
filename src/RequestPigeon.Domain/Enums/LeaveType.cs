namespace RequestPigeon.Domain.Enums;

public enum LeaveType
{
    [Display(Name = "Płatny 100%", Description = "Zwykły urlop płatny.")]
    FullPaid = 0,

    [Display(Name = "Bezpłatny", Description = "Urlop bezpłatny.")]
    Unpaid = 1,

    [Display(Name = "Płatny częściowo", Description = "Urlop częściowo płatny.")]
    PartiallyPaid = 2,

    [Display(Name = "Choroba", Description = "Urlop chorobowy.")]
    SickLeave = 3
}
