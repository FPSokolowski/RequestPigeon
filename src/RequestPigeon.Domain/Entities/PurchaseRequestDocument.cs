using RequestPigeon.Domain.Enums;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(ExpensesType))]
public sealed class PurchaseRequestDocument : Document
{
    public PurchaseRequestDocument()
    {
        Type = DocumentType.Purchase;
    }

    [Display(Name = "Planowana data zakupu")]
    public DateOnly? PlannedPurchaseDueDate { get; set; }

    [Display(Name = "Szacowany koszt")]
    public decimal PlannedEstimatedCost { get; set; }

    [Display(Name = "Rzeczywista data zakupu")]
    public DateOnly? RealPurchaseDate { get; set; }

    [Display(Name = "Rzeczywisty koszt")]
    public decimal? RealCost { get; set; }

    [Display(Name = "Zaksięgowane")]
    public bool AccountantsRecorded { get; set; }

    [Required]
    [Display(Name = "Typ wydatku")]
    public ExpensesType ExpensesType { get; set; }
}
