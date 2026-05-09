using RequestPigeon.Domain.Common;

namespace RequestPigeon.Domain.Entities;

public sealed class AuthenticationSettings : Entity
{
    [Display(Name = "Liczba błędnych logowań do blokady")]
    public int? LockoutAfterXFailed { get; set; } = 5;

    [Display(Name = "Czas blokady")]
    public TimeSpan LockoutTime { get; set; } = TimeSpan.FromMinutes(5);
}
