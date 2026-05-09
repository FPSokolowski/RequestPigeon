## Description  
Logger of app's events

**Scope: Post-MVP.** For MVP use standard `ILogger`. Generate this entity/table as prepared model only if it does not slow implementation.
  
## Columns  
| Name               | Type .NET | Type DB          | Nullable | Description                                  | Notes |
| ------------------ | --------- | ---------------- | -------- | -------------------------------------------- | ----- |
| Id                 | Guid      | uniqueidentifier | ❌        | Id                                           |       |
| LogLevel           | LogLevel  | nvarchar(8) ?    | ❌        | Log level (native enum)                      |       |
| UserId             | Guid      | uniqueidentifier | ✔        |                                              | FK    |
| Event              | string    | nvarchar(64)     | ✔        |                                              |       |
| ValueAfter         | string    | nvarchar(512)    | ✔        |                                              |       |
| Info               | string    | nvarchar(256)    | ✔        | Additional info/comment                      |       |
| ==[[BaseEntity]]== | --        | --               | --       | Columns inherited from [[BaseEntity]] class. |       |
  
## Relationships  
* Many-to-many with [[User]]
## Indexes  
* IX_LogApp_CreatedAt
* IX_LogApp_LogLevel
## Notes  
