## Description  
Extends table [[Document]]s. It's one of document's types.

## Columns  
| Name       | Type .NET                                     | Type DB                 | Nullable | Description                                                                                               | Notes                                               |
| ---------- | --------------------------------------------- | ----------------------- | :------: | :-------------------------------------------------------------------------------------------------------- | --------------------------------------------------- |
| DocumentId | *This class implements abstract [[Document]]* | uniqueIdentifier        |    ❌     | For SQL DB it's a separate table. At .NET side it's a class inherits from an abstract [[Document]] class. | *Relationship with Document (core entity).* **TPT** |
| DateStart  | DateOnly                                      | date                    |    ❌     | Start date of a planned leave.                                                                            |                                                     |
| DateEnd    | DateOnly                                      | date                    |    ❌     | End date of a planned leave.                                                                              |                                                     |
| Days       | int                                           | int                     |    ❌     | Number of leave days                                                                                      |                                                     |
| LeaveType  | [[LeaveType]]                                 | `=[[LeaveType]].dbType` |    ❌     | Type of a leave (paid, sick leave, unpaid, partially paid)                                                |                                                     |

## Relationships  
- One-to-one with [[Document]]
## Indexes  
- IX_Document_LeaveType
  
## Notes  