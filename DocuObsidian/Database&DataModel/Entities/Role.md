## Description  
Roles / User Groups. At next app's development phase it's worth to consider add separate table UserGroup which would be responsible to set hierarchy (temporary Roles are for hierarchy).  
## Columns  
| Name               | Type .NET           | Type DB          | Nullable | Description                                                    | Notes                                    |
| ------------------ | ------------------- | ---------------- | :------: | :------------------------------------------------------------- | ---------------------------------------- |
| Id                 | Guid                | uniqueidentifier |    ❌     | Primary key                                                    | PK                                       |
| Name               | string              | nvarchar(64)     |    ❌     | Unique role name                                               | Unique                                   |
| SuperiorRoleId     | Guid                | uniqueidentifier |    ❌     | This FK gives possibility to create hierarchy in organization. | FK                                       |
| IsDeleted          | bool                | bit              |    ❌     | Soft delete                                                    | Default: FALSE. Implements ISoftDelete   |
| Users              | List<[[User]]>      | --               |    ❌     | Assigned users                                                 | *relationship*                           |
| RoleClaims         | List<[[RoleClaim]]> | --               |    ❌     | Assigned claims to the role.                                   | *relationship (separate table with FKs)* |
| ==[[BaseEntity]]== | --                  | --               |    --    | Columns inherited from [[BaseEntity]] class.                   | --                                       |
  
## Relationships  
- One-to-many with [[RoleClaim]] 
- One-to-many with [[User]]
## Indexes  
- IX_Role_Name (Unique)  
## Notes  
* Implements ISoftDelete, Remember to apply proper mechanizm on Create.