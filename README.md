# ObscurusShop

?? **ObscurusShop** to prosty projekt ASP.NET Core, który pokazuje CRUD dla gitar z API i interaktywnym UI.

---

## ?? Struktura projektu

ObscurusShop/
+¦¦ ObscurusShop.Api/ # ASP.NET Core Web API
+¦¦ ObscurusShop.UI/ # ASP.NET Core MVC - frontend
+¦¦ ObscurusShop.Tests/ # Testy jednostkowe i integracyjne
L¦¦ ObscurusShop.sln # Solution


---

## ? Technologie

- C# / .NET 8 (lub .NET 7)
- ASP.NET Core Web API
- ASP.NET Core MVC (UI)
- Entity Framework Core (SQL Server / InMemory)
- xUnit – testy jednostkowe
- Docker (opcjonalnie do uruchomienia lokalnej bazy danych)

---

## ?? Uruchomienie projektu lokalnie

### 1?? Wymagania
- .NET SDK 7/8
- Visual Studio 2022/2023 lub VS Code
- (Opcjonalnie) Docker do bazy danych SQL Server

### 2?? Uruchomienie API
1. Otwórz projekt `ObscurusShop.sln`.
2. Ustaw projekt startowy na `ObscurusShop.Api`.
3. Uruchom aplikacjê (F5 / Ctrl+F5).
4. API bêdzie dostêpne pod np. `https://localhost:5001`.

### 3?? Uruchomienie UI
1. Ustaw projekt startowy na `ObscurusShop.UI`.
2. Uruchom aplikacjê.
3. UI bêdzie dostêpne pod np. `https://localhost:5003/Guitars`.

---

## ?? Funkcjonalnoœci

- Wyœwietlanie listy gitar z API
- Dodawanie nowej gitary
- Edycja ceny istniej¹cej gitary
- Usuwanie gitary
- Obs³uga testów jednostkowych i integracyjnych

---

## ??? Testy

- Projekt `ObscurusShop.Tests` u¿ywa **xUnit**.
- Baza w testach jest symulowana przez **InMemoryDatabase**.
- Aby uruchomiæ testy:  
  ```bash
  dotnet test ObscurusShop.Tests
