using RequestPigeon.Domain.Common;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(RoleId), nameof(ClaimId), IsUnique = true)]
public sealed class RoleClaim : Entity
{
    [Required]
    [Display(Name = "Rola")]
    public Guid RoleId { get; set; }

    [Display(Name = "Rola")]
    public Role Role { get; set; } = null!;

    [Required]
    [Display(Name = "Uprawnienie")]
    public Guid ClaimId { get; set; }

    [Display(Name = "Uprawnienie")]
    public Claim Claim { get; set; } = null!;
}
