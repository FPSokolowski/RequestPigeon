---
dbType: nvarchar(16)
---
| Text         | Num | DisplayName          | Description                                |
| ------------ | :-: | -------------------- | ------------------------------------------ |
| Leave        |  0  | Urlop                | Podanie o urlop                            |
| Refund       |  1  | Zwrot kosztów        | Podanie o zwrot kosztów                    |
| Purchase     |  2  | Zakup                | Wniosek o zakup                            |
| BusinessTrip |  3  | Delegacja            | Podanie o zatwierdzenie wyjazdu służbowego |
| Credentials  |  4  | Przyznanie uprawnień | Wniosek o przyznanie uprawnień             |
| Other        |  5  | Pismo ogólne         | Wniosek  ogólny                            |

MVP active types: Leave, Purchase, BusinessTrip, Credentials.
Prepared/future types: Refund, Other.
