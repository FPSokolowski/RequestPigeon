 #RequestPigeon
# RequestPigeon  

*Aplikacja RequestPigeon (wersja demo) jest tworzona jako szybkie (plan 2-tygodnie do ~MVP) portfolio na githuba mające pokazać umiejętność skutecznego tworzenia oprogramowania z użyciem współczesnych narzędzi.*
*Tworzona przy wykorzystaniu narzędzi AI (głównie Codex, ChatGPT, Stitch).*

Główną funkcjonalnością aplikacji ma być przepływ dokumentów typu request w organizacji.
Początkowo planowane jest obsługiwanie akcji takich jak **tworzenie**, **edycja**, **przypisywanie/wysyłanie**, **akceptacja/odrzucenie**, **zwrócenie do poprawy**, **anulowanie**, **archiwizowanie** dla dokumentów/requestów typu **wniosek o urlop**, **zakup**, **przyznanie uprawnień**, **wyjazd służbowy**.
Model danych może być przygotowany pod kolejne typy dokumentów, ale w MVP dostępne w UI będą tylko wymienione wyżej typy.

## Tech stack:
### Backend
.NET 10, C# 14 
MVC, Razor, requesty Http lub 
Baza danych SQL. Model i użycie przy pomocy EF Core.
### Frontend
Technologie będą dobierane w trakcie tworzenia projektu. W pierwszej fazie frontend nie jest dla mnie priorytetem - ma być po prostu funkcjonalny. Jeśli produkt miałby zostać skomercjalizowany to trzeba będzie przemyśleć cały UI/UX i przepisać na nowo w technologiach które pozwolą na łatwe dostosowanie do urządzeń mobilnych. Prawdopodobnie użyję Razora, HTML, CSS (z jakąś biblioteką np. Bootstrap), JS (z jQuery) do skryptów.




W przyszłości można zająć się kolejnymi funkcjonalnościami [[Future features ideas (wide)]].
