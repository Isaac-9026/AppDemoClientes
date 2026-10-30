# AppDemoClientes

Aplicación de escritorio Windows Forms desarrollada en C# y .NET 10.0 con arquitectura en capas (N-Tier) para la gestión integral de clientes y proveedores, conectada a la API REST backend [ClienteApi (aspnet-cliente-api)](https://github.com/Isaac-9026/aspnet-cliente-api).

---

## Arquitectura de la Solución

El proyecto implementa el patrón de arquitectura por capas desacopladas mediante interfaces e inyección de dependencias, centralizado a través de un formulario principal (`FrmMain`):

```text
┌────────────────────────────────────────────────────────────────────────┐
│                          UI (Windows Forms)                            │
│           FrmMain (Menú Principal: Clientes / Proveedores)             │
│       ├── FrmCliente (Gestión CRUD de Clientes)                       │
│       └── FrmProveedor (Gestión CRUD de Proveedores)                  │
└───────────────────────────────────┬────────────────────────────────────┘
                                    │ usa
┌───────────────────────────────────▼────────────────────────────────────┐
│                      BOL (Business Object Logic)                       │
│       ClienteBol, ProveedorBol, ReglaNegocioException                  │
└───────────────────────────────────┬────────────────────────────────────┘
                                    │ usa (IClienteDal, IProveedorDal)
┌───────────────────────────────────▼────────────────────────────────────┐
│                       DAL (Data Access Layer)                          │
│       IClienteDal, ClienteDal, IProveedorDal, ProveedorDal,            │
│       ApiException                                                     │
└───────────────────────────────────┬────────────────────────────────────┘
                                    │ HTTP / JSON
┌───────────────────────────────────▼────────────────────────────────────┐
│                         REST API (ClienteApi)                          │
│            https://github.com/Isaac-9026/aspnet-cliente-api            │
│                         https://localhost:7097                         │
└───────────────────────────────────┬────────────────────────────────────┘
                                    ▲
                                    │ referencia
┌───────────────────────────────────┴────────────────────────────────────┐
│                           Entidades (Modelo)                           │
│                           Cliente, Proveedor                           │
└────────────────────────────────────────────────────────────────────────┘
```

### Descripción de Capas

1. **Entidades (`Entidades/`)**:
   - `Cliente.cs`: Modelo de dominio del cliente (`Id`, `Dni`, `Apellidos`, `Nombres`, `Direccion`, `Telefono`, `Correo`).
   - `Proveedor.cs`: Modelo de dominio del proveedor con 5 campos de negocio (`Id`, `Ruc`, `RazonSocial`, `Direccion`, `Telefono`, `Correo`).

2. **DAL - Capa de Acceso a Datos (`DAL/`)**:
   - `IClienteDal.cs` / `ClienteDal.cs`: Contrato e implementación HTTP para operaciones CRUD sobre `/api/clientes`.
   - `IProveedorDal.cs` / `ProveedorDal.cs`: Contrato e implementación HTTP para operaciones CRUD sobre `/api/proveedores`.
   - `ApiException.cs`: Excepción especializada para capturar códigos de estado HTTP y errores devueltos por la API.

3. **BOL - Capa de Lógica de Negocio (`BOL/`)**:
   - `ClienteBol.cs`: Valida DNI (8 dígitos numéricos), nombres, apellidos, teléfono y correo electrónico.
   - `ProveedorBol.cs`: Valida RUC (11 dígitos numéricos), razón social, dirección, teléfono y correo electrónico.
   - `ReglaNegocioException.cs`: Excepción de negocio que indica el campo causante para enfocar el control en la interfaz.

4. **UI - Interfaz Gráfica (`UI/`)**:
   - `FrmMain.cs`: Menú de navegación principal con accesos directos a "Gestión de Clientes" y "Gestión de Proveedores".
   - `FrmCliente.cs`: Formulario CRUD completo para clientes con búsqueda filtrada y validaciones.
   - `FrmProveedor.cs`: Formulario CRUD completo para proveedores con búsqueda filtrada y validaciones.
   - `Program.cs`: Configuración de inyección de dependencias (`HttpClient` -> DAL -> BOL) y arranque en `FrmMain`.

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

Al iniciar, se mostrará el formulario principal `FrmMain`, desde el cual podrá abrir `FrmCliente` o `FrmProveedor`.

---

## Endpoints REST Consumidos

La aplicación interactúa con los siguientes recursos en `https://localhost:7097`:

### Módulo Clientes (`/api/clientes`)

| Método | Endpoint | Descripción |
|---|---|---|
| `GET` | `/api/clientes?buscar={filtro}` | Lista clientes filtrados por DNI, nombres o apellidos. |
| `GET` | `/api/clientes/{id}` | Obtiene el detalle de un cliente por su identificador. |
| `POST` | `/api/clientes` | Registra un nuevo cliente validado. |
| `PUT` | `/api/clientes/{id}` | Actualiza la información de un cliente existente. |
| `DELETE` | `/api/clientes/{id}` | Elimina físicamente un cliente. |

### Módulo Proveedores (`/api/proveedores`)

| Método | Endpoint | Descripción |
|---|---|---|
| `GET` | `/api/proveedores?buscar={filtro}` | Lista proveedores filtrados por RUC, razón social o dirección. |
| `GET` | `/api/proveedores/{id}` | Obtiene el detalle de un proveedor por su identificador. |
| `POST` | `/api/proveedores` | Registra un nuevo proveedor validado (RUC de 11 dígitos único). |
| `PUT` | `/api/proveedores/{id}` | Actualiza la información de un proveedor existente. |
| `DELETE` | `/api/proveedores/{id}` | Elimina físicamente un proveedor. |

---

## Estructura del Repositorio

```text
AppDemoClientes/
├── AppDemoClientes.slnx       # Solución .NET
├── Entidades/
│   ├── Cliente.cs             # Modelo Cliente
│   ├── Proveedor.cs           # Modelo Proveedor (5 campos)
│   └── Entidades.csproj
├── DAL/
│   ├── IClienteDal.cs         # Interfaz de acceso a Clientes
│   ├── ClienteDal.cs          # Implementación HTTP para Clientes
│   ├── IProveedorDal.cs       # Interfaz de acceso a Proveedores
│   ├── ProveedorDal.cs        # Implementación HTTP para Proveedores
│   ├── ApiException.cs        # Excepción HTTP personalizada
│   └── DAL.csproj
├── BOL/
│   ├── ClienteBol.cs          # Validaciones de Clientes
│   ├── ProveedorBol.cs        # Validaciones de Proveedores
│   ├── ReglaNegocioException.cs # Excepción de validación
│   └── BOL.csproj
└── UI/
    ├── FrmMain.cs             # Menú principal (Clientes / Proveedores)
    ├── FrmMain.Designer.cs
    ├── FrmCliente.cs          # Módulo CRUD Clientes
    ├── FrmCliente.Designer.cs
    ├── FrmProveedor.cs        # Módulo CRUD Proveedores
    ├── FrmProveedor.Designer.cs
    ├── Program.cs             # Configuración DI y arranque de FrmMain
    └── UI.csproj
```

---

## Tecnologías y Librerías

- **Lenguaje:** C# 13 / .NET 10.0
- **Framework de Presentación:** Windows Forms (.NET Windows Desktop)
- **Cliente HTTP:** `System.Net.Http.Json` con `HttpClientHandler`
- **Control de Versiones:** Git / GitHub
- **API Backend Vinculada:** [Isaac-9026/aspnet-cliente-api](https://github.com/Isaac-9026/aspnet-cliente-api)
- **Repositorio Cliente:** [Isaac-9026/AppDemoClientes](https://github.com/Isaac-9026/AppDemoClientes)
