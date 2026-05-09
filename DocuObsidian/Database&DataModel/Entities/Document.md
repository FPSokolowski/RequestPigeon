## Description  
Represents a core of any request document. 
Approach TPT. This table represents common part of any document type. Each document consists of data from tables Document and {Type}RequestDocument.
Entity Document has no direct instances in the application. It is an abstract base class inherited by concrete request document classes, for example BusinessTripRequestDocument.
MVP active document types: Leave, Purchase, Credentials, BusinessTrip. Other document tables may exist as prepared/future types, but they are not available in MVP UI.
Entity Document is **abstract**.
  
## Columns  
| Name               | Type .NET            | Type DB                                              | Nullable | Description                                                                                                           | Notes                                           |
| ------------------ | -------------------- | ---------------------------------------------------- | :------: | :-------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------- |
| Id                 | Guid                 | uniqueidentifier                                     |    ❌     | Primary key                                                                                                           | PK                                              |
| DateTime           | DateTime             | datetime2(0)                                         |    ❌     | Date time issued (official, visible at the document)                                                                  |                                                 |
| Type               | [[DocumentTypeInfo]] | `= [[Database&DataModel/Enums/DocumentType]].dbType` |    ❌     | At .NET side it's a class which contains DocumentType DocumentType, string Header and string Description              | Needs conversion based on enum [[DocumentType]] |
| Status             | [[DocumentStatus]]   | `= [[DocumentStatus]].dbType`                        |    ❌     | Status of the document                                                                                                |                                                 |
| Priority           | [[DocumentPriority]] | `= [[DocumentPriority]].dbType`                      |    ❌     | Priority of the document                                                                                              |                                                 |
| TextContent        | string               | nvarchar(2048)                                       |    ✔     | Optional text (specification / explaination / reason / purpose / additional notes)                                    |                                                 |
| TextMessage        | string               | nvarchar(1024)                                       |    ✔     | It's just a note. Not visible at document but sent with it as a sticky note additional informal message to acceptors. |                                                 |
| RequesterId        | [[User]]             | uniqueidentifier                                     |    ❌     | User who created the request                                                                                          | FK                                              |
| Attachments        | List<[[Attachment]]> | --                                                   |    ✔     | Optional attachments                                                                                                  | *relationship*                                  |
| ApprovalSteps      | List<[[DocumentApprovalStep]]> | --                                        |    ❌     | Runtime approval workflow steps generated when the document is submitted.                                             | *relationship*                                  |
| ==[[BaseEntity]]== | --                   | --                                                   |    --    | Columns inherited from [[BaseEntity]] class.                                                                          | --                                              |
  
## Relationships  
- Many-to-one with [[User]] (as Requester)
- One-to-many with [[Attachment]]
- One-to-many with [[DocumentApprovalStep]]
## Indexes  
- IX_Document_Type 
- IX_Document_DateTime
- IX_Document_Type_Status
  
## Notes  
* Settings for document Types are located in table [[DocumentSettings]]. Post-MVP: setting data should be cached.
* Approval workflow uses [[DocumentApprovalStep]]. Legacy separate approval-link model is not used.
* When generating entities and DbContext, create prepared model for documented Post-MVP entities too, but keep Post-MVP logic/UI disabled or commented until explicitly activated.
