using RequestPigeon.Domain.Common;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(Name), IsUnique = true)]
public sealed class Role : Entity, ISoftDelete
{
    [Required]
    [StringLength(64)]
    [Display(Name = "Nazwa roli")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Rola nadrzędna")]
    public Guid? SuperiorRoleId { get; set; }

    [Display(Name = "Rola nadrzędna")]
    public Role? SuperiorRole { get; set; }

    [Display(Name = "Usunięto")]
    public bool IsDeleted { get; set; }

    [Display(Name = "Role podrzędne")]
    public ICollection<Role> SubordinateRoles { get; set; } = [];

    [Display(Name = "Użytkownicy")]
    public ICollection<User> Users { get; set; } = [];

    [Display(Name = "Uprawnienia roli")]
    public ICollection<RoleClaim> RoleClaims { get; set; } = [];
}
