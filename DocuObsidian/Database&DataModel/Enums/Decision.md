---
dbType: nvarchar(16)
---

| Text    | Num | DisplayName | Description |
| ------- | :-: | ----------- | ----------- |
| Decline |  0  | Odrzucenie  |             |
| Accept  |  1  | Akceptacja  |             |
| Return  |  2  | Do poprawy  | Zwrócenie dokumentu do autora w celu poprawy |

At next phase add DelayedAccept - possibility to approve request but "not now"/"not yet". Example: an employee requested for a new computer in December. An approver realizes this spend is necessary/valid but isn't urgent. Budget for current year doesn't allow for any more spends. So manager decides to approve a request but with delayed consequences (till January) - so the employee will be able to buy the new device next month from a new budget.
