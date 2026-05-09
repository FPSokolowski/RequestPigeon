## Description  
Authentication global settings. Single-record table!

**Scope: Post-MVP.** Generate entity/table as prepared model if convenient, but do not implement lockout/password settings logic in MVP.

## Columns  
| Name                | Type .NET | Type DB          | Nullable | Description                                                          | Notes                                          |
| ------------------- | --------- | ---------------- | :------: | :------------------------------------------------------------------- | ---------------------------------------------- |
| Id                  | Guid      | uniqueidentifier |    ❌     | Primary key                                                          | PK                                             |
| LockoutAfterXFailed | int       | int              |    ✔     | Lock after X failed login tries. Disable (set null) is **dangerous** | Default: 5. If null then feature is turned off |
| LockoutTime         | TimeSpan  | time             |    ❌     | Lockout duration after X failed login tries                          | Default: 5 minutes                             |
| ==[[BaseEntity]]==  | --        | --               |    --    | Columns inherited from [[BaseEntity]] class                          | --                                             |
  
## Relationships  
  
## Indexes  
  
## Notes  
* Single-record table
