## Description  
Extends table [[Document]]s. It's one of document's types.

**Scope: MVP.** Keep purchase request simple: planned due date, estimated cost and expense type. Post-approval purchasing/accounting fields can be generated in the model but should stay unused/commented in MVP logic and UI.

## Columns  
| Name                   | Type .NET                                     | Type DB                    | Nullable | Description                                                                                               | Notes                                                                                                                                              |
| ---------------------- | --------------------------------------------- | -------------------------- | :------: | :-------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| DocumentId             | *This class implements abstract [[Document]]* | uniqueIdentifier           |    ❌     | For SQL DB it's a separate table. At .NET side it's a class inherits from an abstract [[Document]] class. | *Relationship with Document (core entity).* **TPT**                                                                                                |
| PlannedPurchaseDueDate | DateOnly                                      | date                       |    ✔     | Planned due date of a purchase                                                                            |                                                                                                                                                    |
| PlannedEstimatedCost   | decimal                                       | decimal(12,2)              |    ❌     | Estimated cost                                                                                            |                                                                                                                                                    |
| RealPurchaseDate       | DateOnly                                      | date                       |    ✔     | Post-MVP final date of a purchase event                                                                   | Generate/commented or unused in MVP                                                                                                                |
| RealCost               | decimal                                       | decimal(12,2)              |    ✔     | Post-MVP final real cost                                                                                  | Generate/commented or unused in MVP                                                                                                                |
| AccountantsRecorded    | bool                                          | bit                        |    ❌     | Post-MVP marker that blocks modify/add attachments after accounting close.                                | Generate/commented or unused in MVP                                                                                                                |
| ExpensesType           | [[ExpensesType]]                              | `=[[ExpensesType]].dbType` |    ❌     | Expenses category                                                                                         |                                                                                                                                                    |

## Relationships  
- One-to-one with [[Document]]
## Indexes  
- IX_Document_ExpensesType
  
## Notes  
* Post-MVP: allow assign final purchase data after approval.
* Post-MVP: AccountantsRecorded locks any modifications (also adding attachments).
* Future: add currency and exchange rate to base currency
* Future: Budgets
