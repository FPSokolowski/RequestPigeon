---
dbType: nvarchar(16)
---

| Text     | Num | DisplayName | Description                                      |
| -------- | :-: | ----------- | ------------------------------------------------ |
| Bool     |  0  | Bool        | True/false permission. MVP uses this type only.  |
| Text     |  1  | Text        | Post-MVP free text claim value                   |
| Number   |  2  | Number      | Post-MVP numeric claim value                     |
| Date     |  3  | Date        | Post-MVP date claim value                        |
| Json     |  4  | JSON        | Post-MVP structured claim value                  |

**MVP decision:** only Bool is used in authorization logic. Other values are documented for future extensibility and can stay unused until needed.
