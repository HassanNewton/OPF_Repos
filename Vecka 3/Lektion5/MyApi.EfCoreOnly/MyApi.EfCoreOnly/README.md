# MyApi.EfCoreOnly (Projekt 2)

**Mål:** Samma API som Projekt 1, men nu med:
- ✅ EF Core
- ✅ Riktig databas
- ✅ Async
- ✅ (Medvetet) ingen service ännu — controller pratar direkt med DbContext som ett mellanläge.

## Starta projektet
```bash
dotnet restore
dotnet run
```

Öppna Swagger:
- https://localhost:7182/swagger (eller den port du får i terminalen)

## Databas
Projektet använder LocalDB (Windows) via connection string i `appsettings.json`.

### För att köra direkt (lättast i undervisning)
I `Program.cs` kör vi:
- `db.Database.EnsureCreated();`
- samt seedar 2 produkter om tabellen är tom.

Det gör att projektet funkar direkt utan migrationer.

### Vill du köra \"riktig\" EF Core-workflow (rekommenderat i kursen)
1) Kommentera bort `EnsureCreated()`-delen i `Program.cs`
2) Kör migrationer:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Varför detta är ett mellanläge
Detta projekt visar en förbättring (riktig databas + async), men:
- controllern känner fortfarande till EF Core
- controllern gör fortfarande för mycket

➡ Projekt 3 löser detta med Service-lager + DI + DIP.