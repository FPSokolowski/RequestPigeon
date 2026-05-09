Jak opisano w notatce [[Idea]] użyję bazy danych SQL. Do zaprojektowania tabel, robienia zapytań(itd.) użyję EF Core.
Docelowa baza dla Demo-MVP: **SQL Server Express**. Dzięki temu dokumentacja typów DB (`uniqueidentifier`, `nvarchar`, `datetime2`, `rowversion`, `varbinary(max)`) jest spójna z implementacją i można użyć typowych mechanizmów SQL Server, np. optimistic concurrency przez `rowversion`.

Te notatki będą służyły mi za dokumentację więc spróbuję tu rozplanować tabele w taki sposób żeby zapewnić obsłużenie obecnych potrzeb oraz umożliwić płynny rozwój aplikacji. 

W pierwszej wersji zależy mi na szybkim postawieniu wersji Demo-MVP więc świadomie decyduję się na pominięcie logiki/UI dla wielu przydatnych funkcji, które powstaną w kolejnych wersjach.

## Scope convention
* **MVP** - implementować logikę i UI teraz.
* **Post-MVP** - encje/kolumny można wygenerować w modelu i DbContext od razu, ale logika aplikacyjna, kontrolery, widoki i konfiguracja relacji mogą być zakomentowane albo nieużywane do czasu aktywacji funkcji.
* **Future** - pomysł kierunkowy; dokumentacja zostaje, ale nie blokuje MVP.
