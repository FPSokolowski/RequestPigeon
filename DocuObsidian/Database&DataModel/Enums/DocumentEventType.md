---
dbType: nvarchar(32)
---

| Text              | Num | DisplayName            | Description                                      |
| ----------------- | :-: | ---------------------- | ------------------------------------------------ |
| CreatedAsWorkCopy |  0  | Utworzono roboczo      | Dokument został utworzony jako wersja robocza    |
| Sent              |  1  | Wysłano                | Dokument został wysłany do akceptacji            |
| Decision          |  2  | Decyzja                | Osoba decyzyjna podjęła decyzję                  |
| Closed            |  3  | Zamknięto              | Proces dokumentu został zamknięty                |
| Returned          |  4  | Zwrócono do poprawy    | Dokument został zwrócony do autora               |
| Remake            |  5  | Poprawiono             | Autor poprawił dokument po zwróceniu             |
| Cancelled         |  6  | Anulowano              | Dokument został anulowany                        |

**Scope: MVP.** Used by [[LogDocument]].
