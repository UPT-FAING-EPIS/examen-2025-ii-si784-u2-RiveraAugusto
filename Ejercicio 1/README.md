# Transport Library - Sistema de Cálculo de Costos de Entrega

[![CI/CD Pipeline](https://github.com/username/repo/actions/workflows/ci-cd.yml/badge.svg)](https://github.com/username/repo/actions/workflows/ci-cd.yml)
[![Coverage](https://img.shields.io/badge/coverage-100%25-brightgreen)](https://username.github.io/repo/coverage/)

## Descripción

Este proyecto implementa un sistema de cálculo de costos de entrega para diferentes tipos de transporte utilizando el patrón Factory. El sistema incluye tres tipos de transporte: Camión (Truck), Barco (Ship) y Avión (Airbus).

## Estructura del Proyecto

```
Ejercicio 1/
├── TransportLib/                 # Biblioteca principal
│   ├── Transports/              # Clases de transporte
│   │   ├── Truck.cs
│   │   ├── Ship.cs
│   │   └── Airbus.cs
│   ├── Factories/               # Fábricas de transporte
│   │   ├── ITransportFactory.cs
│   │   ├── TruckFactory.cs
│   │   ├── ShipFactory.cs
│   │   └── AirbusFactory.cs
│   └── Interfaces/
│       └── ITransport.cs
├── TransportApp/                # Aplicación de consola
│   └── Program.cs
├── TransportLib.Tests/          # Pruebas unitarias
│   ├── TransportTests.cs
│   └── FactoryTests.cs
├── TransportLib.Specs/          # Pruebas BDD
│   └── TransportCostCalculationBDDTests.cs
└── .github/workflows/           # CI/CD con GitHub Actions
    └── ci-cd.yml
```

## Características

- **Patrón Factory**: Implementación del patrón Factory para la creación de objetos de transporte
- **Cálculo de Costos**: Cada tipo de transporte tiene su propia fórmula de cálculo de costos
- **Validación**: Validación de distancias negativas con excepciones apropiadas
- **Pruebas Unitarias**: Cobertura de código del 100%
- **Pruebas BDD**: Pruebas de comportamiento siguiendo metodología Given-When-Then
- **CI/CD**: Pipeline automatizado con GitHub Actions

## Tipos de Transporte y Costos

### Camión (Truck)
- **Costo base**: $50
- **Costo por km**: $2.5
- **Fórmula**: `50 + (distancia * 2.5)`

### Barco (Ship)
- **Costo base**: $100
- **Costo por km**: $1.5
- **Fórmula**: `100 + (distancia * 1.5)`

### Avión (Airbus)
- **Costo base**: $200
- **Costo por km**: $5.0
- **Fórmula**: `200 + (distancia * 5.0)`

## Requisitos

- .NET 9.0 o superior
- Visual Studio 2022 o VS Code

## Instalación y Uso

1. **Clonar el repositorio**:
   ```bash
   git clone <repository-url>
   cd "Ejercicio 1"
   ```

2. **Restaurar dependencias**:
   ```bash
   dotnet restore
   ```

3. **Compilar el proyecto**:
   ```bash
   dotnet build
   ```

4. **Ejecutar la aplicación**:
   ```bash
   dotnet run --project TransportApp
   ```

## Ejecutar Pruebas

### Pruebas Unitarias
```bash
dotnet test TransportLib.Tests --verbosity normal
```

### Pruebas BDD
```bash
dotnet test TransportLib.Specs --verbosity normal
```

### Todas las Pruebas con Cobertura
```bash
dotnet test --collect:"XPlat Code Coverage"
```

### Generar Reporte de Cobertura
```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator -reports:"TestResults/**/coverage.cobertura.xml" -targetdir:"CoverageReport" -reporttypes:Html
```

## CI/CD Pipeline

El proyecto incluye un pipeline de CI/CD configurado con GitHub Actions que:

- ✅ Ejecuta todas las pruebas automáticamente
- 📊 Genera reportes de cobertura de código
- 🚀 Despliega los reportes a GitHub Pages
- 💬 Comenta en Pull Requests con resultados de pruebas

## Ejemplo de Uso

```csharp
using TransportLib.Factories;

// Crear fábrica de camión
var truckFactory = new TruckFactory();
var truck = truckFactory.CreateTransport();

// Calcular costo de entrega
double cost = truck.GetDeliveryCost(100); // $300 (50 + 100*2.5)
Console.WriteLine($"Costo de entrega: ${cost}");

// Usando la fábrica directamente
double factoryCost = truckFactory.CalculateDeliveryCost(100);
Console.WriteLine($"Costo calculado por fábrica: ${factoryCost}");
```

## Contribuir

1. Fork el proyecto
2. Crear una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

## Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.