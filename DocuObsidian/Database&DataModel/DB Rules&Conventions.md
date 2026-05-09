## Enums
There are 2 solid approaches to store enum values at db: by int or by nvarchar. Both have some advantages: int is more efficient but nvarchar is more human-friendly.
At this project I decided to store enums values as text (nvarchar type) to make it easier to debug (especially before extended diagnostic logger will be implemented).
### Complex types conversion
Sometimes simple enum is not enough. That situations I prefer to store enum in db and convert it with EF Core to a class/struct with predefined or cached values.

## EF Core Interceptors
Use interceptors in order to automate common operations.
At SaveChanges intercept delete and add operations and if *ISoftDelete* is implemented modify behavior (instead of delete just change *IsDeleted* property to *true*). Also deal with common properties declared in [[BaseEntity]]: at Add operation set *CreatedAt*, when Update set new value to *LastModification*.

MVP decision: use EF Core SaveChanges interceptor if implementation cost stays small. If interceptor starts adding noise, fallback to DbContext SaveChanges override is acceptable, but interceptor is preferred because it demonstrates EF Core extensibility.
