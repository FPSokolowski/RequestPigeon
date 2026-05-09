using RequestPigeon.Domain.Enums;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(LeaveType))]
public sealed class LeaveRequestDocument : Document
{
    public LeaveRequestDocument()
    {
        Type = DocumentType.Leave;
    }

    [Display(Name = "Data rozpoczęcia")]
    public DateOnly DateStart { get; set; }

    [Display(Name = "Data zakończenia")]
    public DateOnly DateEnd { get; set; }

    [Display(Name = "Liczba dni")]
    public int Days { get; set; }

    [Required]
    [Display(Name = "Rodzaj urlopu")]
    public LeaveType LeaveType { get; set; }
}
