## Description  
Settings for documents. One record per [[DocumentType]] - each type can have different rules.
  
## Columns  
| Name                 | Type .NET                         | Type DB                                              | Nullable | Description                                                                                                                              | Notes                                   |
| -------------------- | --------------------------------- | ---------------------------------------------------- | :------: | :--------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------- |
| Id                   | Guid                              | uniqueidentifier                                     |    ❌     | Primary key                                                                                                                              | PK //or maybe Type is sufficient as PK? |
| Type                 | [[DocumentType]]                  | `= [[Database&DataModel/Enums/DocumentType]].dbType` |    ❌     | Document Type                                                                                                                            |                                         |
| Header               | string                            | nvarchar(128)                                        |    ❌     | Document's header                                                                                                                        |                                         |
| DefaultTextContent   | string                            | nvarchar(2048)                                       |    ✔     | Optional text (specification / explanation / reason / purpose / additional notes)                                                        |                                         |
| ApprovalRules        | List<[[DocumentApprovalRule]]>    | --                                                   |    ❌     | Blueprint rules used to generate [[DocumentApprovalStep]] rows when a document is submitted.                                             | *relationship*                          |
| ==[[BaseEntity]]==   | --                                | --                                                   |    --    | Columns inherited from [[BaseEntity]] class.                                                                                             | --                                      |
  
## Relationships  
- One-to-many with [[DocumentApprovalRule]]
  
## Indexes  
- IX_DocumentTypeSettings_Type (Unique) 
  
## Notes  
* Post-MVP: should be cached.
* At first phase this one will not be available for user via UI
* MVP does not include higher-level decision replacement, delegation, fallback rules or complex approval combinations.
