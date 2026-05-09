## Description  
Connection between [[User]] and [[Claim]]s.

**Scope: Post-MVP.** Generate entity/table as prepared model if convenient, but keep usage and UI disabled in MVP. MVP authorization uses [[RoleClaim]] only.
## Columns  
| Name               | Type .NET | Type DB          | Nullable | Description                                      | Notes |
| ------------------ | --------- | ---------------- | :------: | :----------------------------------------------- | ----- |
| Id                 | Guid      | uniqueidentifier |    ❌     | Primary key                                      | PK    |
| UserId             | Guid      | uniqueidentifier |    ❌     | User                                             | FK    |
| ClaimId            | Guid      | uniqueidentifier |    ❌     | Claim                                            | FK    |
| ==[[BaseEntity]]== | --        | --               |    --    | Columns inherited from [[BaseEntity]] class.     | --    |
  
## Relationships  
- Many-to-one with [[User]]
- Many-to-one with [[Claim]]
## Indexes  
- IX_UserClaim_UserId_ClaimId (Unique)
## Notes  
* Post-MVP: direct per-user permissions for exceptional cases.
* Post-MVP: add field Value to handle various claim types with automatic parsing.
