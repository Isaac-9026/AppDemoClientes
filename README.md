# AppDemoClientes

Aplicación de escritorio Windows Forms desarrollada en C# y .NET 10.0 con arquitectura en capas (N-Tier) para la gestión integral de clientes, conectada a la API REST backend [ClienteApi (aspnet-cliente-api)](https://github.com/Isaac-9026/aspnet-cliente-api).

---

## Arquitectura de la Solución

El proyecto implementa el patrón de arquitectura por capas desacopladas mediante interfaces e inyección de dependencias:

```text
┌────────────────────────────────────────────────────────┐
│                   UI (Windows Forms)                  │
│       FrmCliente, FrmCliente.Designer, Program         │
└───────────────────────────┬────────────────────────────┘
                            │ usa
┌───────────────────────────▼────────────────────────────┐
│              BOL (Business Object Logic)               │
│        ClienteBol, ReglaNegocioException               │
└───────────────────────────┬────────────────────────────┘
                            │ usa (IClienteDal)
┌───────────────────────────▼────────────────────────────┐
│               DAL (Data Access Layer)                  │
│        IClienteDal, ClienteDal, ApiException           │
└───────────────────────────┬────────────────────────────┘
                            │ HTTP / JSON
┌───────────────────────────▼────────────────────────────┐
│                 REST API (ClienteApi)                  │
│       https://github.com/Isaac-9026/aspnet-cliente-api │
│                 https://localhost:7097                 │
└────────────────────────────────────────────────────────┘
                            ▲
                            │ referencia
┌───────────────────────────┴────────────────────────────┐
│                   Entidades (Modelo)                   │
│                        Cliente                         │
└────────────────────────────────────────────────────────┘
```

### Descripción de Capas

1. **Entidades (`Entidades/`)**:
   - `Cliente.cs`: Modelo de dominio con propiedades principales (`Id`, `Dni`, `Apellidos`, `Nombres`, `Direccion`, `Telefono`, `Correo`, `Activo`, `CreadoEn`).

2. **DAL - Capa de Acceso a Datos (`DAL/`)**:
   - `IClienteDal.cs`: Contrato asíncrono para operaciones CRUD (`ListarAsync`, `ObtenerAsync`, `CrearAsync`, `ActualizarAsync`, `EliminarAsync`).
   - `ClienteDal.cs`: Implementación que consume los endpoints REST mediante `HttpClient` y `System.Net.Http.Json`.
   - `ApiException.cs`: Excepción especializada para capturar códigos de estado HTTP y errores devueltos por la API.

3. **BOL - Capa de Lógica de Negocio (`BOL/`)**:
   - `ClienteBol.cs`: Valida reglas de negocio previas al envío a la API:
     - DNI requerido y exactamente de 8 dígitos numéricos (`^\d{8}$`).
     - Nombres y apellidos obligatorios con normalización de espacios.
     - Teléfono de 9 dígitos numéricos si es provisto (`^\d{9}$`).
     - Correo electrónico con estructura válida (`MailAddress`).
   - `ReglaNegocioException.cs`: Excepción de negocio que indica el campo específico causante de la infracción para feedback directo al usuario.

4. **UI - Interfaz Gráfica (`UI/`)**:
   - `FrmCliente.cs`: Formulario con listado en `DataGridView`, búsqueda con filtro por texto, edición directa, creación de nuevos clientes y eliminación con confirmación.
   - `Program.cs`: Punto de entrada que configura `HttpClient` hacia `https://localhost:7097/`, establece timeout de 15 segundos e inyecta las dependencias hacia `FrmCliente`.

---

## Requisitos Previos

- **.NET 10.0 SDK** o superior.
- **Visual Studio 2022 / 2026** (con la carga de trabajo *.NET Desktop Development*).
- **Backend API (`ClienteApi`)**: Proyecto REST disponible en el repositorio [Isaac-9026/aspnet-cliente-api](https://github.com/Isaac-9026/aspnet-cliente-api), ejecutándose localmente:
  - HTTPS: `https://localhost:7097`
  - HTTP: `http://localhost:5273`

---

## Puesta en Marcha

### 1. Iniciar la API Backend

Clone o abra el repositorio backend ([aspnet-cliente-api](https://github.com/Isaac-9026/aspnet-cliente-api)) y ejecútelo desde una terminal independiente:

```bash
cd C:\Users\SENATI\source\repos\ClienteApi\ClienteApi
dotnet run
```

Verifique que el backend esté escuchando en `https://localhost:7097`.

### 2. Compilar la Solución de Escritorio

```bash
cd C:\Users\SENATI\source\repos\AppDemoClientes
dotnet build AppDemoClientes.slnx
```

### 3. Ejecutar la Aplicación

```bash
dotnet run --project UI
```

---

## Endpoints REST Consumidos

La aplicación interactúa con los siguientes recursos en `https://localhost:7097/api/clientes`:

| Método | Endpoint | Descripción |
|---|---|---|
| `GET` | `/api/clientes?buscar={filtro}` | Lista clientes filtrados por DNI, nombres o apellidos. |
| `GET` | `/api/clientes/{id}` | Obtiene el detalle de un cliente por su identificador. |
| `POST` | `/api/clientes` | Registra un nuevo cliente validado. |
| `PUT` | `/api/clientes/{id}` | Actualiza la información de un cliente existente. |
| `DELETE` | `/api/clientes/{id}` | Elimina físicamente un cliente. |

---

## Estructura del Repositorio

```text
AppDemoClientes/
├── AppDemoClientes.slnx       # Solución .NET
├── Entidades/
│   ├── Cliente.cs             # Entidad de dominio Cliente
│   └── Entidades.csproj
├── DAL/
│   ├── IClienteDal.cs         # Interfaz de acceso a datos
│   ├── ClienteDal.cs          # Implementación HTTP Client REST
│   ├── ApiException.cs        # Excepción HTTP personalizada
│   └── DAL.csproj
├── BOL/
│   ├── ClienteBol.cs          # Validaciones y reglas de negocio
│   ├── ReglaNegocioException.cs # Excepción de validación
│   └── BOL.csproj
└── UI/
    ├── FrmCliente.cs          # Lógica de presentación y eventos
    ├── FrmCliente.Designer.cs # Componentes y controles gráficos
    ├── Program.cs             # Configuración DI y arranque
    └── UI.csproj
```

---

## Tecnologías y Librerías

- **Lenguaje:** C# 13 / .NET 10.0
- **Framework de Presentación:** Windows Forms (.NET Windows Desktop)
- **Cliente HTTP:** `System.Net.Http.Json` con `HttpClientHandler`
- **Control de Versiones:** Git / GitHub
- **API Backend Vinculada:** [Isaac-9026/aspnet-cliente-api](https://github.com/Isaac-9026/aspnet-cliente-api)
