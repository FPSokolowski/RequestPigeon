This note should contain only essential contracts.

## Interfaces


## Attributes
### MVP authorization attributes

Authorization is claim-based and generated from MVC controllers/actions.

Default authorization:
* Controllers/actions without custom authorization attributes require generated claims.
* Action claim format: `{appName}_{ControllerName}_{ActionName}_{HttpRequestType}`.
* Controller claim format: `{appName}_{ControllerName}`.

Custom authorization:
* Attribute with `string claimName` requires claim `{appName}_{claimName}`.
* Attribute disabling authorization bypasses claim checks.

Startup claim discovery:
* At app start, scan controllers/actions with reflection.
* Build a list of default controller/action claim names.
* Add all custom claim names used by authorization attributes.
* Compare generated names with [[Claim]] table and insert missing claims.

Special bypass claims:
* `SuperUser`
* `{appName}_SuperUser`
* `{appName}_{ControllerName}_SuperUser`

MVP uses claims assigned through [[RoleClaim]] only. [[UserClaim]] is Post-MVP.


## Abstracts
### ControllerCustom
Base MVC controller for all app controllers.

MVP responsibilities:
* expose current user and claims from auth cookie,
* provide simple alert collection helpers.

Post-MVP responsibilities:
* previous URL handling,
* richer redirect/alert orchestration,
* shared UI helpers.
