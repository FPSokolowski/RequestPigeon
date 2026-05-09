## Description  
List of all available claims.

**Scope: MVP.** Claims are discovered at app startup by reflection from MVC controllers/actions and custom authorization attributes. Missing claims are inserted automatically into this table.

MVP authorization uses [[RoleClaim]] only. Direct [[UserClaim]] assignment is Post-MVP.
  
## Columns  
| Name               | Type .NET          | Type DB          | Nullable | Description                                                        | Notes |
| ------------------ | ------------------ | ---------------- | -------- | ------------------------------------------------------------------ | ----- |
| Id                 | Guid               | uniqueidentifier | ❌        | Id                                                                 | PK    |
| Name               | string             | nvarchar(128)    | ❌        | Unique claim name                                                  |       |
| ValueType          | [[ClaimValueType]] | nvarchar(16)     | ❌        | Type of claim value. MVP uses Bool only.                           | Default: Bool |
| DefaultValue       | string             | nvarchar(128)    | ❌        | Default value when claim is assigned to a role/user                 | For Bool: "true" |
| ==[[BaseEntity]]== | --                 | --               | --       | Columns inherited from [[BaseEntity]] class.                       |       |
  
## Relationships  

## Indexes  
* IX_Claims_Name (Unique)
## Notes  
* MVP: automatic seed at app start with reflection, checking controllers/actions and custom authorization attributes.
* MVP: RoleClaims only.
* Post-MVP: UserClaims and non-bool claim values.
