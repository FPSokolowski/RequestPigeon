## Description  
Connection between [[Role]] and [[Claim]]s.

**Scope: MVP.** RoleClaim is the only source of app authorization claims in MVP.
## Columns  
| Name               | Type .NET | Type DB          | Nullable | Description                                      | Notes |
| ------------------ | --------- | ---------------- | :------: | :----------------------------------------------- | ----- |
| Id                 | Guid      | uniqueidentifier |    ❌     | Primary key                                      | PK    |
| RoleId             | Guid      | uniqueidentifier |    ❌     | Role                                             | FK    |
| ClaimId            | Guid      | uniqueidentifier |    ❌     | Claim                                            | FK    |
| ==[[BaseEntity]]== | --        | --               |    --    | Columns inherited from [[BaseEntity]] class.     | --    |
  
## Relationships  
- Many-to-one with [[Role]]
- Many-to-one with [[Claim]]
## Indexes  
- IX_RoleClaim_RoleId_ClaimId (Unique)

## Notes  
* MVP uses bool-style claims. Existence of RoleClaim means role has this claim.
* Post-MVP: add field Value to handle various claim types with automatic parsing.
