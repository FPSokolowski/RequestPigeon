## Description  
It's an ABSTRACT class and it should be implemented by default by all entities/tables. It contains a few common columns. 
Purpose: common and unified trace/debug info and version control.
  
## Columns  
| Name               | Type .NET | Type DB      | Nullable | Description                                                                                       | Notes                                                                                   |
| ------------------ | --------- | ------------ | -------- | ------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| CreatedAt          | DateTime  | datetime2(7) | ❌        | Row add date time.                                                                                | EF Core Interceptor: **SaveChanges** at **Add** operation. Default value: GETDATE().    |
| LastModification   | DateTime  | datetime2(7) | ✔        | Date time of a last modification. It's null at **Add** row. Value updated at each **Update** row. | EF Core Interceptor: **SaveChanges** at **Update** operation. Default value: GETDATE(). |
| RowVersion         | byte[]    | timestamp    | ❌        | Row version. Prevents concurrency exceptions and helps maintain data consistency.                 | Handled automaticly by SQL DB.                                                          |
  
## Relationships  
  
## Indexes  
  
## Notes  