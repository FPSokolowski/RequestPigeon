namespace RequestPigeon.Domain.Common;

public abstract class BaseEntity
{
    [Display(Name = "Data utworzenia")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "Data ostatniej modyfikacji")]
    public DateTime? LastModification { get; set; }

    [Display(Name = "Wersja rekordu")]
    public byte[] RowVersion { get; set; } = [];
}
