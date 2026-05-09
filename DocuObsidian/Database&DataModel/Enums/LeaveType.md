---
dbType: nvarchar(16)
---

| Text          | Num | DisplayName      | Description                                |
| ------------- | :-: | ---------------- | ------------------------------------------ |
| FullPaid      |  0  | Płatny 100%      | Zwykły urlop                               |
| Unpaid        |  1  | Bezpłatny        | Podanie o zwrot kosztów                    |
| PartiallyPaid |  2  | Płatny częściowo | Urlopy częściowo płatne (macierzyński/...) |
| SickLeave     |  3  | Choroba          | Urlop chorobowy                            |

### Future features:
* Add OnDemand (paid 100% but with auto-approval if allowed to use - yearly limit of on-demand-days)
