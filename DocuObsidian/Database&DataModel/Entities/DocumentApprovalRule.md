## Description
Approval blueprint rule. Each rule describes how to resolve one decision-maker for a new document of a given type.

Rules are used by approval policy logic when a document is submitted. The result is persisted as runtime [[DocumentApprovalStep]] rows.

## Columns
| Name               | Type .NET             | Type DB                         | Nullable | Description                                                                            | Notes |
| ------------------ | --------------------- | ------------------------------- | :------: | :------------------------------------------------------------------------------------- | ----- |
| Id                 | Guid                  | uniqueidentifier                |    ❌     | Primary key                                                                            | PK    |
| DocumentSettingsId | Guid                  | uniqueidentifier                |    ❌     | Parent settings record                                                                 | FK    |
| StepOrder          | int                   | int                             |    ❌     | Order of generated approval step                                                       |       |
| DecisionMakerType  | [[DecisionMakerType]] | `=[[DecisionMakerType]].dbType` |    ❌     | Decision-maker type, for example DirectSuperior, Role, Claim, SpecifiedUser, TeamMember |       |
| AllowSelfApproval  | bool                  | bit                             |    ❌     | If TRUE, requester may approve own request when matching this rule                      | Default: FALSE |
| UserId             | Guid                  | uniqueidentifier                |    ✔     | Filled only when DecisionMakerType == SpecifiedUser                                    | FK optional |
| RoleOrClaimName    | string                | nvarchar(64)                    |    ✔     | Filled only when DecisionMakerType is Role or Claim                                    |       |
| ==[[BaseEntity]]== | --                    | --                              |    --    | Columns inherited from [[BaseEntity]] class.                                           | --    |

## Relationships
- Many-to-one with [[DocumentSettings]]
- Optional many-to-one with [[User]]

## Indexes
* IX_DocumentApprovalRule_DocumentSettingsId_StepOrder
* IX_DocumentApprovalRule_DecisionMakerType_UserId_RoleOrClaimName

## Notes
* Post-MVP: should be cached as include to DocumentSettings.
* At first phase this one will not be available for user via UI.
* MVP supports simple role/user/direct-superior style rules.
* Future features: RequiredAll, MinApprovalsNo, fallback rules, higher-level decision replacement, delegation.
