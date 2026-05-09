---
dbType: nvarchar(16)
---

| Text     | Num | DisplayName       | Description                                                      |
| -------- | :-: | ----------------- | ---------------------------------------------------------------- |
| Waiting  |  0  | Oczekuje          | Krok czeka na zakończenie wcześniejszych kroków                  |
| Pending  |  1  | Do decyzji        | Krok jest aktywny i oczekuje na decyzję osoby zatwierdzającej    |
| Approved |  2  | Zatwierdzono      | Krok został zatwierdzony                                         |
| Declined |  3  | Odrzucono         | Krok został odrzucony                                            |
| Returned |  4  | Do poprawy        | Dokument został zwrócony do autora w celu poprawy                |
| Skipped  |  5  | Pominięto         | Krok został pominięty przez reguły workflow                      |

MVP does not include Overridden status because higher-level decision replacement is out of MVP scope.
