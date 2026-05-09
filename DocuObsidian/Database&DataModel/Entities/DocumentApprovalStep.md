## Description
Runtime approval workflow step generated for a submitted [[Document]].

On submit:
1. Resolve approval path using approval policy.
2. Convert approval path into persisted DocumentApprovalStep rows.
3. First step starts as Pending, next steps start as Waiting.

This entity replaces the old separate approval-link model.

## Columns
| Name               | Type .NET                | Type DB          | Nullable | Description                                                                 | Notes |
| ------------------ | ------------------------ | ---------------- | :------: | :-------------------------------------------------------------------------- | ----- |
| Id                 | Guid                     | uniqueidentifier |    ❌     | Primary key                                                                 | PK    |
| DocumentId         | Guid                     | uniqueidentifier |    ❌     | Parent document                                                             | FK    |
| ApproverId         | Guid                     | uniqueidentifier |    ❌     | User assigned to make the decision for this step                            | FK    |
| StepOrder          | int                      | int              |    ❌     | Order of the approval step in the workflow                                  |       |
| Status             | [[ApprovalStepStatus]]   | nvarchar(16)     |    ❌     | Runtime status of this approval step                                        |       |
| Decision           | [[Decision]]             | nvarchar(16)     |    ✔     | Final decision made in this step                                            | Null until decision |
| DateTimeIssued     | DateTime                 | datetime2(0)     |    ✔     | Date/time when the step became visible/actionable for approver              |       |
| DateTimeDecision   | DateTime                 | datetime2(0)     |    ✔     | Date/time of decision                                                       |       |
| Comment            | string                   | nvarchar(1024)   |    ✔     | Optional note, for example reason or legal basis                            |       |
| ==[[BaseEntity]]== | --                       | --               |    --    | Columns inherited from [[BaseEntity]] class.                                | --    |

## Relationships
- Many-to-one with [[Document]]
- Many-to-one with [[User]] as Approver

## Indexes
- IX_DocumentApprovalStep_DocumentId_StepOrder
- IX_DocumentApprovalStep_ApproverId_Status

## Notes
* MVP does not support higher-level decision replacement or delegation.
* One workflow step represents one approver decision.
* If a future rule requires many approvers for the same logical stage, create multiple steps with the same StepOrder or introduce a grouping entity in a later phase.
