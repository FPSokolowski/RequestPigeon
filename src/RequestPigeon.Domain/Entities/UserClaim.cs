using RequestPigeon.Domain.Common;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(UserId), nameof(ClaimId), IsUnique = true)]
public sealed class UserClaim : Entity
{
    [Required]
    [Display(Name = "Użytkownik")]
    public Guid UserId { get; set; }

    [Display(Name = "Użytkownik")]
    public User User { get; set; } = null!;

    [Required]
    [Display(Name = "Uprawnienie")]
    public Guid ClaimId { get; set; }

    [Display(Name = "Uprawnienie")]
    public Claim Claim { get; set; } = null!;
}
