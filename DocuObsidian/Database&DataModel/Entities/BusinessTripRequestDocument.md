## Description  
Extends table [[Document]]s. It's one of document's types.

## Columns  
| Name                   | Type .NET                                     | Type DB                           | Nullable | Description                                                                                               | Notes                                               |
| ---------------------- | --------------------------------------------- | --------------------------------- | :------: | :-------------------------------------------------------------------------------------------------------- | --------------------------------------------------- |
| DocumentId             | *This class implements abstract [[Document]]* | uniqueIdentifier                  |    ❌     | For SQL DB it's a separate table. At .NET side it's a class inherits from an abstract [[Document]] class. | *Relationship with Document (core entity).* **TPT** |
| Purpose                | [[BusinessTripPurpose]]                       | `=[[BusinessTripPurpose]].dbType` |    ❌     | Purpose of a business trip                                                                                |                                                     |
| DateStart              | DateOnly                                      | date                              |    ❌     | Planned business trip start date                                                                          |                                                     |
| DateEnd                | DateOnly                                      | date                              |    ❌     | Planned business trip end date                                                                            |                                                     |
| AdvancePaymentAmount   | decimal                                       | decimal(12,2)                     |    ✔     | Optional advance payment for costs request                                                                |                                                     |
| AdvancePaymentCurrency | string                                        | nvarchar(3)                       |    ✔     | Is required if AdvancePaymentAmount is not null.                                                          | (ISO4217)                                           |
| Country                | string                                        | nvarchar(3)                       |    ✔     | Country code                                                                                              | (ISO3166)                                           |

## Relationships  
- One-to-one with [[Document]]
## Indexes  
- IX_BusinessTripRequestDocument_Purpose
- IX_BusinessTripRequestDocument_Country
- IX_BusinessTripRequestDocument_DateStart
  
## Notes  