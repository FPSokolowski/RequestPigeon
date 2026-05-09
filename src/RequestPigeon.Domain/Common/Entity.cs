namespace RequestPigeon.Domain.Common;

public abstract class Entity : BaseEntity
{
    [Display(Name = "Identyfikator")]
    public Guid Id { get; set; }
}
