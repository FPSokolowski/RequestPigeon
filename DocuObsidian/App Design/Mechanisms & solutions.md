## Cache
Implement cache memory for constant values stored in db (const values, content of selects). Use cache politics for them.

**Scope: Post-MVP.** Settings and constant data can be read directly in MVP. Cache should be added later if it improves code clarity or performance.

## EF Core Interceptors
Described at [[DB Rules&Conventions]].

## DateTime
UTC DateTime should be stored in DB and it should be used at backend but UI needs always conversion to Local DateTime

## ControllerCustom
There should be one abstract ControllerCustom which should be inherited by all Controllers. It will contain common methods/interceptors/fields to handle features like: remember previous urls, simplify alerts handling(also handle redirections), take user info from cookie and store it. 

**Scope: MVP, minimal version.** Create ControllerCustom now and make all controllers inherit from it. In MVP it should handle current user/claims access from cookie and simple alert collection. Previous URL handling and richer UX helpers are Post-MVP.

## Prepare demo sandbox
I don't want to waste too much time on that topic at beginning.
**Scope: MVP.** Add a simple reseed button for demo/admin user. It deletes data from selected demo tables and seeds initial demo data again.
Reseed safety rules:
* do not allow starting reseed when another reseed is already running,
* do not allow reseed earlier than 30 minutes after previous completed reseed,
* store reseed operation logs in [[DemoReseedLog]] table, which must not be cleared by reseed.

When user opens an app first time(info stored cookie) display warning "It's demo version. Do not provide any personal or sensitive data to this app!". After close the warning should just collapse with possibility to show it again.

**Scope: Post-MVP.** Online user counter. First the number should be updated every few seconds and display at the corner (some icon with badge(on hover display info like $"{numberOfActiveUsers} users are online")). Additionally animate (small one) when the number changes. 
*The next phase the same method should check if there are any restore db request pending or any info pending. If restore db request then display to user modal with info like "One of users online requested for restore initial data (restore db). Are you ok with that? If all users will agree the service will stop working for few minutes and data will be restored." and buttons "Accept" and "Decline".*
Post-MVP: consider automatic restore by schedule, for example everyday at 4 a.m. Polish local time. MVP uses only manual reseed button with safety limits.

## Warnings/Alerts/Errors
**Scope: MVP, simple version.**
* One icon with badge toggle alerts visibility (at navbar?). Change colors. 
* Do not remove alerts but just hide them  with possibility to show them again.
* Set ~10 seconds for alerts to disappear. Also allow to close them by X button.
* It should float over page content 

## Making things more readable and smooth
* Result Pattern with operations chaining
* 
