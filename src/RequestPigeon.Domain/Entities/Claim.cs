using RequestPigeon.Domain.Common;
using RequestPigeon.Domain.Enums;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(Name), IsUnique = true)]
public sealed class Claim : Entity
{
    [Required]
    [StringLength(128)]
    [Display(Name = "Nazwa uprawnienia")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Typ wartości")]
    public ClaimValueType ValueType { get; set; } = ClaimValueType.Bool;

    [Required]
    [StringLength(128)]
    [Display(Name = "Wartość domyślna")]
    public string DefaultValue { get; set; } = "true";

    [Display(Name = "Uprawnienia ról")]
    public ICollection<RoleClaim> RoleClaims { get; set; } = [];

    [Display(Name = "Uprawnienia użytkowników")]
    public ICollection<UserClaim> UserClaims { get; set; } = [];
}
