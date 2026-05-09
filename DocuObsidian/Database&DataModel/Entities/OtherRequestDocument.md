## Description  
Extends table [[Document]]s. It's one of document's types.

**Scope: Post-MVP.** Generate entity/table as prepared model if convenient, but keep logic and UI disabled/commented in MVP.

## Columns  
| Name                      | Type .NET                                     | Type DB          | Nullable | Description                                                                                               | Notes                                               |
| ------------------------- | --------------------------------------------- | ---------------- | :------: | :-------------------------------------------------------------------------------------------------------- | --------------------------------------------------- |
| DocumentId                | *This class implements abstract [[Document]]* | uniqueIdentifier |    ❌     | For SQL DB it's a separate table. At .NET side it's a class inherits from an abstract [[Document]] class. | *Relationship with Document (core entity).* **TPT** |
| TextHeader                | string                                        | nvarchar(256)    |    ✔     | First additional text field                                                                               |                                                     |
| AdditionalDate            | DateOnly                                      | date             |    ✔     | Additional date field                                                                                     |                                                     |
| AmountFirst               | decimal                                       | decimal(12,2)    |    ✔     | First additional amount field                                                                             |                                                     |
| AmountSecond              | decimal                                       | decimal(12,2)    |    ✔     | Second additional amount field                                                                            |                                                     |
| TextAdditionalFieldOne    | string                                        | nvarchar(2048)   |    ✔     | First additional text field                                                                               |                                                     |
| TestAdditionalFieldSecond | string                                        | nvarchar(2048)   |    ✔     | Final real cost                                                                                           |                                                     |

## Relationships  
- One-to-one with [[Document]]
## Indexes  
  
## Notes  
* For other than standard requests. 
* Not for now. It's future's feature.
