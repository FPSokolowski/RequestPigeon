## Description  
User/Employee/Board Member. At first phase employees, organization members and app users are simplified and combined into one table. There is IsActiveAccount variable to distinct only employee/member from employee/member with access to the app.

## Columns  
| Name               | Type .NET           | Type DB          | Nullable | Description                                                                                                                                                                                  | Notes                                                       |
| ------------------ | ------------------- | ---------------- | :------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------- |
| Id                 | Guid                | uniqueidentifier |    ❌     | Primary key                                                                                                                                                                                  | PK                                                          |
| IsActiveAccount    | bool                | bit              |    ❌     | This one distinct if the record represents only organization member (employee/ board member/ external employee) without app's account from organization members with access to app's account | Default FALSE at create. At first login turn to true.       |
| IsDemo             | bool                | bit              |    ✔     | Only for demo app version! Normally it should be null or FALSE.<br>When TRUE the user can't: be deleted, change password, remove permissions, block (manually), etc.                         | **Always NULL or FALSE (one exception: demo app version).** |
| UserName           | string              | nvarchar(64)     |    ❌     | Unique login/userName                                                                                                                                                                        | Unique                                                      |
| FirstName          | string              | nvarchar(64)     |    ❌     | First name                                                                                                                                                                                   |                                                             |
| Surname            | string              | nvarchar(128)    |    ❌     | Surname                                                                                                                                                                                      |                                                             |
| Email              | string              | nvarchar(128)    |    ✔     | Email address. For login, sending notifications, password reset, etc. If email is null then password change is possible only by admin                                                        | Regex validation                                            |
| Phone              | string              | nvarchar(16)     |    ✔     | Phone number                                                                                                                                                                                 | Regex validation                                            |
| Password           | string              | nvarchar(64)     |    ✔     | Hashed password with salt                                                                                                                                                                    | BCrypt                                                      |
| LockedFailedLog    | DateTime            | datetime2(0)     |    ✔     | Post-MVP account locked by excess number of login tries. Blockade expiration time.                                                                                                           | Generate/commented or unused in MVP                         |
| FailedLoginCount   | int                 | int              |    ❌     | Post-MVP number of failed logins. Max failed login tries specified in [[AuthenticationSettings]]                                                                                              | Generate/commented or unused in MVP                         |
| LockedOut          | bool                | bit              |    ❌     | Post-MVP account locked out by administrator                                                                                                                                                  | Generate/commented or unused in MVP                         |
| PassChangeRequired | bool                | bit              |    ❌     | Post-MVP password change is required                                                                                                                                                          | Generate/commented or unused in MVP                         |
| IsDeleted          | bool                | bit              |    ❌     | Soft delete                                                                                                                                                                                  | Default: FALSE. Implements ISoftDelete                      |
| Role               | Guid                | uniqueidentifier |    ❌     | Assign to role (there roles works also like user groups)                                                                                                                                     |                                                             |
| UserClaims         | List<[[UserClaim]]> | --               |    ✔     | Post-MVP direct claims assigned to the user. MVP uses role claims only.                                                                                                                       | *Post-MVP relationship*                                     |
| ==[[BaseEntity]]== | --                  | --               |    --    | Columns inherited from [[BaseEntity]] class.                                                                                                                                                 | --                                                          |
  
## Relationships  
- Many-to-one with [[Role]]
- Post-MVP many-to-many with [[Claim]] through [[UserClaim]]
  
## Indexes  
- IX_User_UserName (Unique)
- 
  
## Notes  
* Implements ISoftDelete, Remember to apply proper mechanizm on Create.
* MVP: create a few seeded demo accounts and roles.
* MVP: cookie auth uses role claims from [[RoleClaim]].
* Post-MVP: block password change, remove permissions, delete account, block account manually for demo users.
