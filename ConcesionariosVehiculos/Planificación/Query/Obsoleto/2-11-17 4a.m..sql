USE [master]
GO
/****** Object:  Database [Concesionarios]    Script Date: 2/11/2017 12:46:03 a. m. ******/
DROP DATABASE [Concesionarios]
GO
CREATE DATABASE [Concesionarios]
GO
ALTER DATABASE [Concesionarios] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Concesionarios] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Concesionarios] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Concesionarios] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Concesionarios] SET ARITHABORT OFF 
GO
ALTER DATABASE [Concesionarios] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Concesionarios] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Concesionarios] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Concesionarios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Concesionarios] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Concesionarios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Concesionarios] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Concesionarios] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Concesionarios] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Concesionarios] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Concesionarios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Concesionarios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Concesionarios] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Concesionarios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Concesionarios] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Concesionarios] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Concesionarios] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Concesionarios] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Concesionarios] SET  MULTI_USER 
GO
ALTER DATABASE [Concesionarios] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Concesionarios] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Concesionarios] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Concesionarios] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Concesionarios] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Concesionarios]
GO
/****** Object:  Table [dbo].[Equipamientos]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipamientos](
	[EquipamientoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[Precio] [numeric](8, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[EquipamientoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Logs](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](max) NULL,
	[Fechacreacion] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[MarcaId] [int] IDENTITY(1,1) NOT NULL,
	[MarcaDescripcion] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MarcaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Modelos]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelos](
	[ModeloId] [int] IDENTITY(1,1) NOT NULL,
	[MarcaId] [int] NOT NULL,
	[ModeloDescripcion] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[ModeloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ServiciosOficiales]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiciosOficiales](
	[ServOficialId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Direccion] [nvarchar](255) NULL,
	[NIF] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ServOficialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Contrasena] [varchar](255) NOT NULL,
	[FechaCreacion] [datetime] NULL DEFAULT (getdate()),
	[Estado] [bit] NOT NULL DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vehiculos]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vehiculos](
	[VehiculoId] [int] IDENTITY(1,1) NOT NULL,
	[ModeloId] [int] NOT NULL,
	[Color] [varchar](60) NULL,
	[Descuento] [numeric](8, 2) NULL,
	[Precio] [numeric](8, 2) NOT NULL,
	[Cilindrada] [nvarchar](5) NULL,
	[PotenciaMaxima] [nvarchar](50) NULL,
	[Puertas] [int] NOT NULL,
	[Combustible] [nvarchar](15) NULL,
	[Ano] [nvarchar](5) NULL,
	[VehiculoTipo] [varchar](60) NULL,
	[Estado] [bit] NOT NULL DEFAULT ((1)),
	[Chasis] [varchar](20) NULL,
	[Traccion] [varchar](50) NOT NULL DEFAULT ('2WD'),
	[Pasajeros] [int] NOT NULL DEFAULT ((2)),
	[Equipamientos] [varchar](max) NULL,
	[PrecioTotalEquipamientos] [numeric](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[VehiculoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehiculosEquipamientos]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiculosEquipamientos](
	[VehEquipId] [int] IDENTITY(1,1) NOT NULL,
	[VehiculoId] [int] NOT NULL,
	[EquipamientoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[VehEquipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VehiculoVenta]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiculoVenta](
	[VehVentaId] [int] IDENTITY(1,1) NOT NULL,
	[VentaId] [int] NOT NULL,
	[PrecioTotal] [numeric](8, 2) NULL,
	[VehiculoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehVentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendedores]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendedores](
	[VendedorId] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](80) NULL,
	[Apellidos] [nvarchar](80) NULL,
	[ServOficialId] [int] NULL,
	[Cedula] [nvarchar](20) NOT NULL,
	[VentasRealizadas] [int] NULL,
	[NIF] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[VendedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ventas](
	[VentaId] [int] IDENTITY(1,1) NOT NULL,
	[FechaVenta] [datetime] NULL,
	[VendedorId] [int] NOT NULL,
	[TipoPago] [varchar](50) NULL,
	[TotalMonto] [numeric](8, 2) NULL,
	[VehiculoID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[vw_VEHICULOS]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--ACTUALIZACIÓN DE VISTA
CREATE VIEW [dbo].[vw_VEHICULOS] AS
SELECT Vehiculos.Chasis Chasis,Marcas.MarcaDescripcion Marca, Modelos.ModeloDescripcion Modelo, 
Vehiculos.Ano Año, Vehiculos.Color, Vehiculos.VehiculoTipo Tipo,Vehiculos.Puertas [Cantidad de Puertas],Vehiculos.Pasajeros [Cantidad de Pasajeros],
Vehiculos.Cilindrada, Vehiculos.Combustible, Vehiculos.PotenciaMaxima [Potencia Máxima], Vehiculos.Equipamientos, 
IIF(Estado = 1, 'Sí', 'No') [¿En Stock?],
IIF(Precio IS NULL,0,Precio) Precio, Vehiculos.PrecioTotalEquipamientos [Precio Equipamiento],
IIF(Vehiculos.Descuento IS NULL, 0,Vehiculos.Descuento) Descuento
FROM Vehiculos 
JOIN Modelos ON Modelos.ModeloId = Vehiculos.ModeloId
JOIN Marcas ON Marcas.MarcaId = Modelos.MarcaId
GO
/****** Object:  View [dbo].[vw_VEHICULOS2]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_VEHICULOS2] AS
SELECT *, 
IIF([Precio Equipamiento] IS NULL,CONVERT(FLOAT,(Precio + 0) * (1 - Descuento)),CONVERT(FLOAT,(Precio + [Precio Equipamiento]) * (1 - Descuento))) AS [Precio Calculado] 
FROM vw_VEHICULOS
GO
/****** Object:  View [dbo].[vw_CarSold]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_CarSold] as
SELECT v.VentaId, v.FechaVenta [Fecha de Venta], ve.Cedula [Cédula], ve.Nombres+' '+ve.Apellidos [Nombre del Vendedor],
veh.Chasis, ma.MarcaDescripcion+' '+m.ModeloDescripcion [Vehículo], v.TotalMonto [Monto], v.TipoPago [Tipo de Pago]
FROM Ventas v 
JOIN Vendedores ve ON v.VendedorId = ve.VendedorId
JOIN Vehiculos veh ON veh.VehiculoId = v.VehiculoId
JOIN Modelos m ON veh.ModeloId = m.ModeloId
JOIN Marcas ma ON m.MarcaId = ma.MarcaId	
GO
/****** Object:  View [dbo].[vw_Vendedores]    Script Date: 2/11/2017 12:46:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[vw_Vendedores] as
SELECT 
      [Nombres]
      ,[Apellidos]
      ,s.Nombre as ServicioOficial
      ,[Cedula]
  FROM [Concesionarios].[dbo].[Vendedores] v left
   join ServiciosOficiales s
  on
  v.ServOficialId=s.ServOficialId left
   join Ventas t
  on
  v.VendedorId=t.VendedorId

GO
USE [Concesionarios]
GO

/** Object:  View [dbo].[vw_ServOfic]    Script Date: 30/10/2017 01:28:54 a.m. **/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_ServOfic] AS
SELECT Nombre, Direccion[Dirección],NIF
FROM ServiciosOficiales
GO

USE [Concesionarios]
GO

/** Object:  View [dbo].[vw_VentAuto]    Script Date: 30/10/2017 01:32:35 a.m. **/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_VentAuto] As
Select Ventas.FechaVenta[Fecha de Venta],Ventas.TipoPago[Tipo de Pago],Ventas.TotalMonto[Monto Total], Vendedores.Nombres, Vehiculos.Chasis 
From Ventas
Join Vendedores on Ventas.VendedorId = Vendedores.Nombres
join Vehiculos on Vehiculos.Chasis = Vehiculos.Chasis

GO

SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([LogId], [Descripcion], [Fechacreacion]) VALUES (1, N'System.Data.SqlClient.SqlException (0x80131904): Invalid object name ''vw_Automovil''.
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataTable[] dataTables, Int32 startRecord, Int32 maxRecords, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataTable dataTable)
   en ConcesionariosVehiculos.FrmAutomovil.btnBuscar_Click(Object sender, EventArgs e) en C:\Users\ENVY\Documents\UNAPEC\9no\ConcesionariosVehiculos\ConcesionariosVehiculos\FrmAutomovil.cs:línea 84
ClientConnectionId:429dce26-6712-4f6e-8519-d77d5b732bbd
Error Number:208,State:1,Class:16', CAST(N'2017-10-29 20:33:44.573' AS DateTime))
INSERT [dbo].[Logs] ([LogId], [Descripcion], [Fechacreacion]) VALUES (2, N'System.Data.SqlClient.SqlException (0x80131904): Invalid object name ''vw_Automovil''.
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataTable[] dataTables, Int32 startRecord, Int32 maxRecords, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataTable dataTable)
   en ConcesionariosVehiculos.FrmAutomovil.btnBuscar_Click(Object sender, EventArgs e) en C:\Users\ENVY\Documents\UNAPEC\9no\ConcesionariosVehiculos\ConcesionariosVehiculos\FrmAutomovil.cs:línea 84
ClientConnectionId:1e2f875f-7e82-46e5-94b8-7f313c4cc1b9
Error Number:208,State:1,Class:16', CAST(N'2017-10-29 20:33:54.700' AS DateTime))
INSERT [dbo].[Logs] ([LogId], [Descripcion], [Fechacreacion]) VALUES (3, N'System.ArgumentException: No hay ninguna asignación de tipo de objeto System.Windows.Forms.TextBox a un tipo nativo de un proveedor administrado conocido.
   en System.Data.SqlClient.MetaType.GetMetaTypeFromValue(Type dataType, Object value, Boolean inferLen, Boolean streamAllowed)
   en System.Data.SqlClient.SqlParameter.GetMetaTypeOnly()
   en System.Data.SqlClient.SqlParameter.Validate(Int32 index, Boolean isCommandProc)
   en System.Data.SqlClient.SqlCommand.BuildParamList(TdsParser parser, SqlParameterCollection parameters, Boolean includeReturnValue)
   en System.Data.SqlClient.SqlCommand.BuildExecuteSql(CommandBehavior behavior, String commandText, SqlParameterCollection parameters, _SqlRPC& rpc)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en ConcesionariosVehiculos.FrmVendedores.btnCrear_Click(Object sender, EventArgs e) en C:\Users\ENVY\Documents\UNAPEC\9no\ConcesionariosVehiculos\ConcesionariosVehiculos\FrmVendedores.cs:línea 279', CAST(N'2017-10-29 23:37:13.743' AS DateTime))
SET IDENTITY_INSERT [dbo].[Logs] OFF
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (1, N'Audi')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (2, N'BMW')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (3, N'BYD')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (4, N'Chevrolet')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (5, N'Citroen')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (6, N'Ferrari')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (7, N'Fiat')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (8, N'Ford')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (9, N'Honda')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (10, N'Hyundai')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (11, N'Infinity')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (12, N'Isuzu')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (13, N'Jaguar')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (14, N'Jeep')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (15, N'Kia')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (16, N'Lamborghini')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (17, N'Land Rover')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (18, N'Lexus')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (19, N'Maserati')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (20, N'Mazda')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (21, N'Mercedes')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (22, N'Mitsubishi')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (23, N'Nissan')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (24, N'Peugeot')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (25, N'Porshe')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (26, N'Renault')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (27, N'Skoda')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (28, N'Subaru')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (29, N'Suzuki')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (30, N'Toyota')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (31, N'Volkswagen')
INSERT [dbo].[Marcas] ([MarcaId], [MarcaDescripcion]) VALUES (32, N'Volvo')
SET IDENTITY_INSERT [dbo].[Marcas] OFF
SET IDENTITY_INSERT [dbo].[Modelos] ON 

INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (1, 1, N'A4')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (2, 1, N'A8')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (3, 1, N'A5')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (4, 1, N'Q3')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (5, 2, N'Serie 3')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (6, 2, N'Serie 7')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (7, 2, N'Z4')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (8, 2, N'X6')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (9, 3, N'E6')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (10, 4, N'Cruze')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (11, 4, N'Spark')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (12, 4, N'Camaro')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (13, 5, N'Grand C4 Picasso')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (14, 5, N'Nemo')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (15, 5, N'Berlingo')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (16, 6, N'488')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (17, 6, N'California')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (18, 6, N'F12')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (19, 7, N'Panda')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (20, 7, N'Freemont')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (21, 8, N'Fiesta')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (22, 8, N'Focus')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (23, 8, N'Mustang')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (24, 8, N'Explorer')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (25, 9, N'Accord')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (26, 9, N'Civic')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (27, 9, N'CR-V')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (28, 9, N'HR-V')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (29, 10, N'I20')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (30, 10, N'Elantra')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (31, 10, N'Santa Fe')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (32, 10, N'Tucson')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (33, 11, N'Q70')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (34, 11, N'QX50')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (35, 11, N'Q30')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (36, 12, N'D-Max')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (37, 13, N'XE')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (38, 13, N'F-Pace')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (39, 14, N'Grand Cherokee')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (40, 14, N'Renegade')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (41, 15, N'Picanto')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (42, 15, N'Rio')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (43, 15, N'Optima')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (44, 15, N'Sorento')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (45, 16, N'Aventador')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (46, 16, N'Huracan')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (47, 17, N'Defender')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (48, 17, N'Range Rover')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (49, 17, N'Discovery')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (50, 18, N'GS')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (51, 18, N'LC')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (52, 19, N'GranCabrio')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (53, 19, N'Levante')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (54, 20, N'CX-5')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (55, 20, N'CX-9')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (56, 20, N'Mazda6')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (57, 21, N'Clase C')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (58, 21, N'Vito')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (59, 21, N'AMG GT')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (60, 22, N'Montero')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (61, 22, N'ASX')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (62, 22, N'I-MiEv')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (63, 23, N'X-Trail')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (64, 24, N'QASHQAI')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (65, 24, N'Navara')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (66, 25, N'308')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (67, 25, N'Partner')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (68, 26, N'Cayenne')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (69, 26, N'Cayman')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (70, 27, N'Fluence')
INSERT [dbo].[Modelos] ([ModeloId], [MarcaId], [ModeloDescripcion]) VALUES (71, 27, N'Latitude')
SET IDENTITY_INSERT [dbo].[Modelos] OFF
SET IDENTITY_INSERT [dbo].[ServiciosOficiales] ON 

INSERT [dbo].[ServiciosOficiales] ([ServOficialId], [Nombre], [Direccion], [NIF]) VALUES (1, N'DeltaComercial', N'Ave. Luperon #3', N'1478924525')
INSERT [dbo].[ServiciosOficiales] ([ServOficialId], [Nombre], [Direccion], [NIF]) VALUES (2, N'Agencia Bella', N'John F. Kennedy #45', N'8778246925')
INSERT [dbo].[ServiciosOficiales] ([ServOficialId], [Nombre], [Direccion], [NIF]) VALUES (3, N'Avelino Abreu', N'Autopista Duarte Km 13 ', N'6847945365')
INSERT [dbo].[ServiciosOficiales] ([ServOficialId], [Nombre], [Direccion], [NIF]) VALUES (4, N'Hyundai Boutique', N'Calle El Sol #34', N'4779562325')
SET IDENTITY_INSERT [dbo].[ServiciosOficiales] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([UsuarioId], [Nombre], [Contrasena], [FechaCreacion], [Estado]) VALUES (1, N'ahidalgo', N'123456', CAST(N'2017-10-28 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Usuarios] ([UsuarioId], [Nombre], [Contrasena], [FechaCreacion], [Estado]) VALUES (2, N'ivan', N'ivan12', CAST(N'2017-10-28 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Usuarios] ([UsuarioId], [Nombre], [Contrasena], [FechaCreacion], [Estado]) VALUES (3, N'abel', N'1234', CAST(N'2017-10-28 00:00:00.000' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
SET IDENTITY_INSERT [dbo].[Vehiculos] ON 

INSERT [dbo].[Vehiculos] ([VehiculoId], [ModeloId], [Color], [Descuento], [Precio], [Cilindrada], [PotenciaMaxima], [Puertas], [Combustible], [Ano], [VehiculoTipo], [Estado], [Chasis], [Traccion], [Pasajeros], [Equipamientos], [PrecioTotalEquipamientos]) VALUES (1, 1, N'Amarillo', CAST(0.05 AS Numeric(8, 2)), CAST(650000.00 AS Numeric(8, 2)), N'6', NULL, 4, N'gasolina', N'2009', N'Sedan', 1, NULL, N'2WD', 2, NULL, NULL)
INSERT [dbo].[Vehiculos] ([VehiculoId], [ModeloId], [Color], [Descuento], [Precio], [Cilindrada], [PotenciaMaxima], [Puertas], [Combustible], [Ano], [VehiculoTipo], [Estado], [Chasis], [Traccion], [Pasajeros], [Equipamientos], [PrecioTotalEquipamientos]) VALUES (2, 21, N'Amarillo', NULL, CAST(450000.00 AS Numeric(8, 2)), N'2', NULL, 4, N'gas', N'2010', N'Sedan', 1, NULL, N'2WD', 2, NULL, NULL)
INSERT [dbo].[Vehiculos] ([VehiculoId], [ModeloId], [Color], [Descuento], [Precio], [Cilindrada], [PotenciaMaxima], [Puertas], [Combustible], [Ano], [VehiculoTipo], [Estado], [Chasis], [Traccion], [Pasajeros], [Equipamientos], [PrecioTotalEquipamientos]) VALUES (4, 32, N'Amarillo', CAST(0.10 AS Numeric(8, 2)), CAST(950000.00 AS Numeric(8, 2)), N'6', NULL, 6, N'gasolina', N'2011', N'Sedan', 1, NULL, N'2WD', 2, NULL, NULL)
INSERT [dbo].[Vehiculos] ([VehiculoId], [ModeloId], [Color], [Descuento], [Precio], [Cilindrada], [PotenciaMaxima], [Puertas], [Combustible], [Ano], [VehiculoTipo], [Estado], [Chasis], [Traccion], [Pasajeros], [Equipamientos], [PrecioTotalEquipamientos]) VALUES (5, 64, N'Amarillo', CAST(0.05 AS Numeric(8, 2)), CAST(380000.00 AS Numeric(8, 2)), N'2', NULL, 4, N'gas', N'2002', N'Sedan', 1, NULL, N'2WD', 2, NULL, NULL)
INSERT [dbo].[Vehiculos] ([VehiculoId], [ModeloId], [Color], [Descuento], [Precio], [Cilindrada], [PotenciaMaxima], [Puertas], [Combustible], [Ano], [VehiculoTipo], [Estado], [Chasis], [Traccion], [Pasajeros], [Equipamientos], [PrecioTotalEquipamientos]) VALUES (6, 10, N'Negro', CAST(0.10 AS Numeric(8, 2)), CAST(655568.00 AS Numeric(8, 2)), N'V2', N'300CV', 2, N'Gasolina', N'1977', N'Sedán', 1, N'djnkfnj', N'Trasera', 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Vehiculos] OFF
SET IDENTITY_INSERT [dbo].[Vendedores] ON 

INSERT [dbo].[Vendedores] ([VendedorId], [Nombres], [Apellidos], [ServOficialId], [Cedula], [VentasRealizadas], [NIF]) VALUES (1, N'Ivan Eduardo', N'Serrata Bermudez', 1, N'40268413210', NULL, NULL)
INSERT [dbo].[Vendedores] ([VendedorId], [Nombres], [Apellidos], [ServOficialId], [Cedula], [VentasRealizadas], [NIF]) VALUES (3, N'Abel Abraham', N'Feliz Soto', 2, N'40287963241', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Vendedores] OFF
ALTER TABLE [dbo].[Ventas] ADD  DEFAULT (getdate()) FOR [FechaVenta]
GO
ALTER TABLE [dbo].[Modelos]  WITH CHECK ADD FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marcas] ([MarcaId])
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD FOREIGN KEY([ModeloId])
REFERENCES [dbo].[Modelos] ([ModeloId])
GO
ALTER TABLE [dbo].[VehiculosEquipamientos]  WITH CHECK ADD FOREIGN KEY([EquipamientoId])
REFERENCES [dbo].[Equipamientos] ([EquipamientoId])
GO
ALTER TABLE [dbo].[VehiculosEquipamientos]  WITH CHECK ADD FOREIGN KEY([VehiculoId])
REFERENCES [dbo].[Vehiculos] ([VehiculoId])
GO
ALTER TABLE [dbo].[VehiculoVenta]  WITH CHECK ADD FOREIGN KEY([VehiculoId])
REFERENCES [dbo].[Vehiculos] ([VehiculoId])
GO
ALTER TABLE [dbo].[VehiculoVenta]  WITH CHECK ADD FOREIGN KEY([VentaId])
REFERENCES [dbo].[Ventas] ([VentaId])
GO
ALTER TABLE [dbo].[Vendedores]  WITH CHECK ADD FOREIGN KEY([ServOficialId])
REFERENCES [dbo].[ServiciosOficiales] ([ServOficialId])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([VehiculoID])
REFERENCES [dbo].[Vehiculos] ([VehiculoId])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([VendedorId])
REFERENCES [dbo].[Vendedores] ([VendedorId])
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [check_combustible] CHECK  (([Combustible]='gasoil' OR [Combustible]='gas' OR [Combustible]='gasolina'))
GO
ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [check_combustible]
GO
USE [master]
GO
ALTER DATABASE [Concesionarios] SET  READ_WRITE 
GO
