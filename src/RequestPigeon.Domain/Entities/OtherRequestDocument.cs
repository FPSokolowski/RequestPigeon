using RequestPigeon.Domain.Enums;

namespace RequestPigeon.Domain.Entities;

public sealed class OtherRequestDocument : Document
{
    public OtherRequestDocument()
    {
        Type = DocumentType.Other;
    }

    [StringLength(256)]
    [Display(Name = "Nagłówek dodatkowy")]
    public string? TextHeader { get; set; }

    [Display(Name = "Data dodatkowa")]
    public DateOnly? AdditionalDate { get; set; }

    [Display(Name = "Pierwsza kwota")]
    public decimal? AmountFirst { get; set; }

    [Display(Name = "Druga kwota")]
    public decimal? AmountSecond { get; set; }

    [StringLength(2048)]
    [Display(Name = "Pierwsze pole tekstowe")]
    public string? TextAdditionalFieldOne { get; set; }

    [StringLength(2048)]
    [Display(Name = "Drugie pole tekstowe")]
    public string? TextAdditionalFieldSecond { get; set; }
}
