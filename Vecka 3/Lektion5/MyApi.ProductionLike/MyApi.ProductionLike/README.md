# MyApi.ProductionLike (Projekt 3)

**Mål:** Produktionslik kod (utan att bli för avancerat), med:
- ✅ Service-lager
- ✅ DI + DIP (controller beror på interface)
- ✅ DTOs + Projection (Select)
- ✅ Redo för AI-labben (plats för AI-service i Program.cs)

## Starta
```bash
dotnet restore
dotnet run
```

Öppna Swagger:
- https://localhost:7283/swagger (eller porten du får)

## Viktiga mappar
- `Models/` → Entities (databasstruktur)
- `DTOs/` → API-kontrakt (vad vi skickar/ tar emot)
- `Services/` → logik + dataåtkomst + projection
- `Controllers/` → HTTP-lager (statuskoder, routing)

## Projection
Notera att vi i `ProductService` gör:
- `Select(...)` till DTOs
Det betyder att vi aldrig skickar ut `Product`-entity direkt.

