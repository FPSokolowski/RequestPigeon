## Description
Log of demo data reseed operations.

**Scope: MVP.** This table must not be cleared by reseed. It is used to prevent concurrent reseeds and reseeding more often than once per 30 minutes after the last completed reseed.

## Columns
| Name               | Type .NET | Type DB          | Nullable | Description                                      | Notes |
| ------------------ | --------- | ---------------- | :------: | :----------------------------------------------- | ----- |
| Id                 | Guid      | uniqueidentifier |    ❌     | Primary key                                      | PK    |
| StartedAt          | DateTime  | datetime2(0)     |    ❌     | Reseed start UTC datetime                        |       |
| CompletedAt        | DateTime  | datetime2(0)     |    ✔     | Reseed completed UTC datetime                    | Null while running |
| StartedByUserId    | Guid      | uniqueidentifier |    ✔     | User who started reseed                          | FK optional |
| Succeeded          | bool      | bit              |    ✔     | Whether reseed completed successfully            | Null while running |
| ErrorMessage       | string    | nvarchar(1024)   |    ✔     | Error message if reseed failed                   |       |
| ==[[BaseEntity]]== | --        | --               |    --    | Columns inherited from [[BaseEntity]] class.     | --    |

## Relationships
- Optional many-to-one with [[User]]

## Indexes
- IX_DemoReseedLog_StartedAt
- IX_DemoReseedLog_CompletedAt

## Notes
* MVP reseed is explicit button/action, not automatic scheduled restore.
* Post-MVP: online user consent, scheduled restore, richer operational status.
