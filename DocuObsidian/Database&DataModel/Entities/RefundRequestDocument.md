## Description  
Extends table [[Document]]s. It's one of document's types.

**Scope: Post-MVP.** Generate entity/table as prepared model if convenient, but keep logic and UI disabled/commented in MVP.

## Columns  
| Name         | Type .NET                                     | Type DB                    | Nullable | Description                                                                                               | Notes                                               |
| ------------ | --------------------------------------------- | -------------------------- | :------: | :-------------------------------------------------------------------------------------------------------- | --------------------------------------------------- |
| DocumentId   | *This class implements abstract [[Document]]* | uniqueIdentifier           |    ❌     | For SQL DB it's a separate table. At .NET side it's a class inherits from an abstract [[Document]] class. | *Relationship with Document (core entity).* **TPT** |
| PayDate      | DateOnly                                      | date                       |    ❌     | Payment date (in case of a series of payments it's date of the last one)                                  |                                                     |
| Amount       | decimal                                       | decimal(12,2)              |    ❌     | Refund amount                                                                                             |                                                     |
| ExpensesType | [[ExpensesType]]                              | `=[[ExpensesType]].dbType` |    ❌     | Expenses category                                                                                         |                                                     |
 
## Relationships  
- One-to-one with [[Document]]
## Indexes  
- IX_Document_SpendType
## Notes  
* Future: add Budgets table and here add possibility to assign a refund to a budget.
