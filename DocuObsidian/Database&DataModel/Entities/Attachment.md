## Description  
Document's attachments. Simple MVP version stores files directly in DB as byte array.

Allowed extensions in MVP: jpg, jpeg, pdf.
Max file size in MVP: 5 MB.
## Columns  
| Name               | Type .NET | Type DB          | Nullable | Description                              | Notes                        |
| ------------------ | --------- | ---------------- | :------: | :--------------------------------------- | ---------------------------- |
| Id                 | Guid      | uniqueidentifier |    ❌     | Primary key                              | PK                           |
| DocumentId         | Guid      | uniqueIdentifier |    ❌     | Parent document                          | FK                           |
| FileName           | string    | nvarchar(128)    |    ❌     | Original uploaded file name              |                              |
| Description        | string    | nvarchar(1024)   |    ✔     | Optional short description               |                              |
| Extension          | string    | nvarchar(8)      |    ❌     | File extension without dot               | Allowed: jpg, jpeg, pdf      |
| Content            | byte[]    | varbinary(max)   |    ❌     | File content                             | *MaxLength(5 * 1024 * 1024)* |
| ==[[BaseEntity]]== | --        | --               |    --    | Columns inherited from [[BaseEntity]] class. CreatedAt is attachment add date. | -- |

## Relationships  
- One-to-many with [[Document]]
## Indexes  
- IX_Attachment_DocumentId
- IX_Attachment_Extension

## Notes  
* Validate extension and max size before saving to DB.
* Content type can be derived from extension in MVP.
