using RequestPigeon.Domain.Enums;

namespace RequestPigeon.Domain.Entities;

[Index(nameof(Purpose))]
[Index(nameof(Country))]
[Index(nameof(DateStart))]
public sealed class BusinessTripRequestDocument : Document
{
    public BusinessTripRequestDocument()
    {
        Type = DocumentType.BusinessTrip;
    }

    [Required]
    [Display(Name = "Cel wyjazdu")]
    public BusinessTripPurpose Purpose { get; set; }

    [Display(Name = "Data rozpoczęcia")]
    public DateOnly DateStart { get; set; }

    [Display(Name = "Data zakończenia")]
    public DateOnly DateEnd { get; set; }

    [Display(Name = "Kwota zaliczki")]
    public decimal? AdvancePaymentAmount { get; set; }

    [StringLength(3)]
    [RegularExpression("^[A-Z]{3}$", ErrorMessage = "Waluta musi być kodem ISO 4217, np. PLN.")]
    [Display(Name = "Waluta zaliczki", Description = "Kod waluty ISO 4217.")]
    public string? AdvancePaymentCurrency { get; set; }

    [StringLength(3)]
    [RegularExpression("^[A-Z]{3}$", ErrorMessage = "Kraj musi być kodem ISO 3166 alpha-3, np. POL.")]
    [Display(Name = "Kraj", Description = "Kod kraju ISO 3166 alpha-3.")]
    public string? Country { get; set; }
}
