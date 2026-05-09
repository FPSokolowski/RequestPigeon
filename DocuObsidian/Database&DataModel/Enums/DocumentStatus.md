---
dbType: nvarchar(16)
---

| Text      | Num | DisplayName            | Description                                                     |
| --------- | :-: | ---------------------- | --------------------------------------------------------------- |
| Draft     |  0  | Wersja robocza         | Dokument jest w trakcie tworzenia                               |
| InReview  |  1  | Oczekiwanie na decyzję | Dokument dotarł do osób decyzyjnych i oczekuje na zatwierdzenie |
| Approved  |  2  | Zatwierdzono           | Dokument został rozpatrzony pozytywnie                          |
| Declined  |  3  | Odrzucono              | Wniosek został rozpatrzony negatywnie                           |
| Returned  |  4  | Zwrócono do poprawy    | Wniosek został zwrócony do autora w celu poprawy                |
| Cancelled |  5  | Anulowano              | Wniosek został anulowany                                        |

