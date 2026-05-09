## Description  
Extends table [[Document]]s. It's one of document's types.

## Columns  
| Name           | Type .NET                                     | Type DB          | Nullable | Description                                                                                               | Notes                                               |
| -------------- | --------------------------------------------- | ---------------- | :------: | :-------------------------------------------------------------------------------------------------------- | --------------------------------------------------- |
| DocumentId     | *This class implements abstract [[Document]]* | uniqueIdentifier |    ❌     | For SQL DB it's a separate table. At .NET side it's a class inherits from an abstract [[Document]] class. | *Relationship with Document (core entity).* **TPT** |
| Credential     | string                                        | nvarchar(256)    |    ❌     | Name/description of a credential                                                                          |                                                     |
| ExpirationDate | DateOnly                                      | date             |    ✔     | Optional credential expiration date (if a credential would be requested as temporary)                     |                                                     |

## Relationships  
- One-to-one with [[Document]]
## Indexes    
## Notes  