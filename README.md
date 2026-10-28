# AppDemoClientes

Aplicación de escritorio Windows Forms desarrollada en C# y .NET 10.0 con arquitectura en capas (N-Tier) para la gestión de clientes.

## Arquitectura de la Solución

El proyecto está organizado en las siguientes capas:

- **Entidades**: Modelos de datos del dominio compartidos entre las capas.
- **DAL (Data Access Layer)**: Capa de acceso a datos para comunicación con fuentes de datos externas o APIs.
- **BOL (Business Object Logic)**: Capa de lógica de negocio y validación de reglas.
- **UI (User Interface)**: Interfaz gráfica de usuario construida con Windows Forms (.NET 10.0).

## Requisitos

- .NET 10.0 SDK
- Visual Studio 2022 / 2026 o superior con la carga de trabajo de desarrollo de escritorio de .NET

## Estructura del Proyecto

```text
AppDemoClientes/
├── AppDemoClientes.slnx   # Solución .NET
├── Entidades/             # Modelos de entidades
├── DAL/                   # Acceso a datos
├── BOL/                   # Lógica de negocio
└── UI/                    # Interfaz Windows Forms
```

## Compilación y Ejecución

Para compilar la solución desde la consola:

```bash
dotnet build
```

Para ejecutar el proyecto de interfaz de usuario:

```bash
dotnet run --project UI
```
