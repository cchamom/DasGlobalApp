
# Prueba Técnica - DAS GLOBAL S.A.


## Stack Tecnológico
- **Backend:** ASP.NET Core Web API (.NET 10), Entity Framework Core, SQL Server
- **Frontend:** React, Vite, Tailwind CSS

## Requisitos Previos
- .NET SDK 10.0
- SQL Server
- Node.js (v18 o superior)

## 1. Base de Datos (SQL Server)
1. Ejecuta el script SQL en SQL Server para crear la base de datos `DasGlobalDb_CristianChamo` y las tablas `Empresas`, `Sucursales` y `Colaboradores` con eliminación en cascada.
2. Verifica que la cadena de conexión `DefaultConnection` en `DasGlobalApp.Web/appsettings.json` apunte a tu servidor y base de datos.

## 2. Ejecutar el Backend (API)
Abre una terminal en la carpeta `DasGlobalApp.Web`, asegúrate de que exista la carpeta `wwwroot` (`mkdir wwwroot`) y ejecuta:

```powershell
cd DasGlobalApp.Web
mkdir wwwroot
dotnet restore
dotnet run --urls "http://localhost:5147"

```

* **API Base:** `http://localhost:5147/api/Empresa`
* **Swagger UI:** `http://localhost:5147/swagger`

### Endpoints Principales

* `POST /api/Empresa/cargar-json` — Carga e inserta el archivo `.json` en SQL Server.
* `GET /api/Empresa` — Lista las sucursales y sus colaboradores desde la base de datos.
* `PATCH /api/Empresa/sucursal/{id}` — Actualiza parcialmente una sucursal.
* `DELETE /api/Empresa/sucursal/{id}` — Elimina una sucursal y sus colaboradores asociados.

## 3. Ejecutar el Frontend (React)

En otra terminal, entra a la carpeta `frontend`, instala dependencias e inicia el servidor de desarrollo:

```powershell
cd frontend
npm install
npm run dev

```

Abre `http://localhost:5173` en el navegador para usar la aplicación.

### Estructura del Frontend

* `src/services/servicioApi.js` — Comunicación con la API (`GET`, `POST`, `PATCH`, `DELETE`).
* `src/Components/CargaJson.jsx` — Carga y envío del archivo `.json`.
* `src/Components/SucursalesPanel.jsx` — Listado, edición y eliminación de sucursales y colaboradores.

