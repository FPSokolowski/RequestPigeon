using RequestPigeon.Domain.Enums;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(ExpensesType))]
public sealed class RefundRequestDocument : Document
{
    public RefundRequestDocument()
    {
        Type = DocumentType.Refund;
    }

    [Display(Name = "Data płatności")]
    public DateOnly PayDate { get; set; }

    [Display(Name = "Kwota zwrotu")]
    public decimal Amount { get; set; }

    [Required]
    [Display(Name = "Typ wydatku")]
    public ExpensesType ExpensesType { get; set; }
}
