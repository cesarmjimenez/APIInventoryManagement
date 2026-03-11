# 📦 APIInventoryManagement
API REST para el sistema de control de inventario. Permite gestionar salidas de inventario entre bodegas y sucursales, con autenticación JWT y control de acceso por roles.

## 🛠️ Tecnologías
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- MediatR (CQRS)
- AutoMapper
- Ardalis.Specification (Patrón Repositorio)

## 🏗️ Arquitectura
El proyecto sigue Onion Architecture dividida en 4 capas:
```
APIInventoryManagement/
├── API/              → Controladores, configuración, punto de entrada
├── Application/      → Commands, Queries, DTOs, Interfaces
├── Domain/           → Entidades, enums, contratos base
└── Infrastructure/   → DbContext, repositorios, migraciones, seed data
```
### Patrones utilizados
- **CQRS** — separación de Commands (escritura) y Queries (lectura) con MediatR
- **Repositorio** — acceso a datos abstraído con `IRepositoryAsync<T>` y Ardalis.Specification
- **Mediador** — desacoplamiento entre controladores y lógica de negocio
- **AutoMapper** — transformación automática entre entidades y DTOs

## ⚙️ Configuración

### Requisitos previos
- .NET 8 SDK
- SQL Server

## 🗄️ Diagrama de la base de datos
![Diagrama DB](assets/Diagrama%20DB.jpeg)

## 🔐 Autenticación
Todos los endpoints requieren `Bearer token` en el header `Authorization`, excepto `POST /api/Users/Login`.

## 📡 Endpoints

### 👤 Users

#### POST /api/Users/Login
Endpoint público.

Request body:
```json
{
  "userName": "cgonzalez",
  "passwordHash": "tu_contraseña"
}
```

Response 200 OK:
```json
{
  "succeeded": true,
  "message": "Login exitoso",
  "errors": [],
  "data": {
    "flag": true,
    "message": "Login exitoso",
    "token": "eyJhbGciOiJI..."
  }
}
```

### 💊 Products

#### GET /api/Products/GetActiveProducts
Requiere token. Retorna productos activos con relación a lotes de producto con costo unitario.

### 🏪 Locations

#### GET /api/Locations/GetBranches
Requiere token. Retorna sucursales destino disponibles (excluye bodegas).

### 📤 Outbounds

#### POST /api/Outbounds/CreateOutbound
Requiere token. Rol requerido: Jefe de Bodega.
Aplica FEFO (First Expired, First Out) automáticamente.
La sucursal destino no puede superar L 5,000 en salidas pendientes.

Request body:
```json
{
  "destinationId": "33333333-3333-3333-3333-333333333333",
  "items": [
    { "productId": "00000001-0000-0000-0000-000000000001", "quantity": 10 }
  ]
}
```

#### POST /api/Outbounds/RecievedOutbound
Requiere token. Marca una salida como recibida, registra usuario y fecha.

Request body:
```json
{ "outboundId": "40000001-0000-0000-0000-000000000001" }
```

#### GET /api/Outbounds/GetOutbounds
Requiere token. Lista salidas con filtros opcionales.

Query params:
- FromDate (DateTime) — fecha inicio
- ToDate (DateTime) — fecha fin
- DestinationId (Guid) — sucursal destino

## 👥 Roles
- 🏭 **Jefe de Bodega** — crear salidas de inventario
- 👷 **Operario de Bodega** — consultar listados, marcar salidas como recibidas

## 🌱 Usuarios de prueba
| Usuario | Rol |
|---|---|
| cgonzalez | Jefe de Bodega |
| mperez | Operario de Bodega |
