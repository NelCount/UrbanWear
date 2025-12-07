🧵 UrbanWear — Sistema de Gestión Comercial

Aplicación de escritorio desarrollada en C# (.NET / Windows Forms) para la gestión integral de productos, clientes y ventas.
Este proyecto académico simula el funcionamiento de un sistema real utilizado en comercios minoristas, especialmente en el rubro indumentaria.

---

🚀 Descripción general

UrbanWear permite administrar todas las operaciones principales de un negocio:

✔️ Productos: altas, bajas, modificaciones, búsqueda por filtros, control de bajo stock

✔️ Clientes: registro, edición, eliminación, búsqueda dinámica

✔️ Ventas: creación, consulta, filtros avanzados, impresión

✔️ Estadísticas: gráficos de ventas por mes, cliente o vendedor

✔️ Cotizaciones y pantallas de apoyo adicionales

El proyecto está diseñado con una arquitectura modular, separación de capas lógicas y uso de ADO.NET para la interacción con la base de datos.

---

🧩 Tecnologías utilizadas

✔️ C# (.NET Framework)

✔️ Windows Forms

✔️ ADO.NET

✔️ Base de datos Access (MDB)

✔️ Componentes Chart para estadísticas

✔️ Newtonsoft.Json (dependencias gestionadas con NuGet)

---

🗂️ Estructura del proyecto

UrbanWear/
 ├── .vs/
 ├── Properties/
 ├── Resources/
 ├── packages/
 │    └── Newtonsoft.Json.13.0.3/
 ├── App.config
 ├── Program.cs
 ├── UrbanWear.csproj
 ├── UrbanWear.sln
 ├── packages.config
 ├── .gitignore

 ├── Form1.cs
 ├── Form1.Designer.cs
 ├── Form1.resx

 ├── clsCategoria.cs
 ├── clsCliente.cs
 ├── clsDetalleVenta.cs
 ├── clsEstadisticaVenta.cs
 ├── clsLocalidad.cs
 ├── clsProducto.cs
 ├── clsVendedor.cs
 ├── clsVenta.cs

 ├── frmAcercaDe.cs
 ├── frmAcercaDe.Designer.cs
 ├── frmAcercaDe.resx

 ├── frmBuscarCliente.cs
 ├── frmBuscarCliente.Designer.cs
 ├── frmBuscarCliente.resx

 ├── frmBuscarProducto.cs
 ├── frmBuscarProducto.Designer.cs
 ├── frmBuscarProducto.resx

 ├── frmBuscarVenta.cs
 ├── frmBuscarVenta.Designer.cs
 ├── frmBuscarVenta.resx

 ├── frmCotizacion.cs
 ├── frmCotizacion.Designer.cs
 ├── frmCotizacion.resx

 ├── frmEstadisticaVentas.cs
 ├── frmEstadisticaVentas.Designer.cs
 ├── frmEstadisticaVentas.resx

 ├── frmModificarCliente.cs
 ├── frmModificarCliente.Designer.cs
 ├── frmModificarCliente.resx

 ├── frmModificarProducto.cs
 ├── frmModificarProducto.Designer.cs
 ├── frmModificarProducto.resx

 ├── frmNuevaVenta.cs
 ├── frmNuevaVenta.Designer.cs
 ├── frmNuevaVenta.resx

 ├── frmNuevoCliente.cs
 ├── frmNuevoCliente.Designer.cs
 ├── frmNuevoCliente.resx

 ├── frmNuevoProducto.cs
 ├── frmNuevoProducto.Designer.cs
 ├── frmNuevoProducto.resx

 ├── frmStock.cs
 ├── frmStock.Designer.cs
 ├── frmStock.resx

---

🧾 Funcionalidades principales

📦 Gestión de productos

Alta, baja y modificación

Filtro combinados por nombre, categoría, talle y color

Control automático de stock bajo

Formularios dedicados + validaciones

👥 Gestión de clientes

Registro y edición completa de información

Búsqueda dinámica (DNI, nombre, apellido, localidad)

Validación estricta para evitar datos incompletos

💲 Ventas

Registro de nuevas ventas

Listado con filtros múltiples

Impresión del resultado filtrado

Cálculo automático de totales

📊 Estadísticas

Ventas por mes

Ventas por cliente

Ventas por vendedor

Actualización dinámica del Chart según selección

📄 Pantallas adicionales

Acerca de

Cotización

Stock general

---

📹 Demo del sistema

https://drive.google.com/file/d/1-rukmT5Se6Ng73T8gQkmHAizBK8VxR_W/view?usp=sharing
