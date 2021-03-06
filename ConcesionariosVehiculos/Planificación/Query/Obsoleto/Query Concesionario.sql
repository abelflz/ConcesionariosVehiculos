USE [master]
GO
/****** Object:  Database [Concesionario]    Script Date: 10/23/2017 7:13:03 PM ******/
CREATE DATABASE [Concesionario]
GO
ALTER DATABASE [Concesionario] SET COMPATIBILITY_LEVEL = 120
GO
ALTER DATABASE [Concesionario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Concesionario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Concesionario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Concesionario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Concesionario] SET ARITHABORT OFF 
GO
ALTER DATABASE [Concesionario] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Concesionario] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Concesionario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Concesionario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Concesionario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Concesionario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Concesionario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Concesionario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Concesionario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Concesionario] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Concesionario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Concesionario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Concesionario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Concesionario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Concesionario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Concesionario] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Concesionario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Concesionario] SET RECOVERY FULL 
GO
ALTER DATABASE [Concesionario] SET  MULTI_USER 
GO
ALTER DATABASE [Concesionario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Concesionario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Concesionario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Concesionario] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Concesionario] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Concesionario', N'ON'
GO
USE [Concesionario]
GO
CREATE TABLE [dbo].[Automovil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [varchar](25) NOT NULL,
	[Modelo] [varchar](25) NOT NULL,
	[Descuento] [decimal](12, 2) NULL,
	[Precio] [decimal](12, 2) NOT NULL,
	[Motor] [nvarchar](255) NULL,
	[Color] [nvarchar](255) NULL,
	[Combustible] [nvarchar](255) NULL,
	[Tipo] [nvarchar](255) NULL,
	[Puertas] [nvarchar](255) NULL,
	[Pasajeros] [nvarchar](255) NULL,
	[Traccion] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Concesionario]    Script Date: 10/23/2017 7:13:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Concesionario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nchar](10) NULL,
	[Clave] [nchar](10) NULL,
	[Nombre] [varchar](25) NOT NULL,
 CONSTRAINT [PK__Concesio__5EE02F1064F703D6] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ServiciosOficiales]    Script Date: 10/23/2017 7:13:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiciosOficiales](
	[NIF] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Domicilio] [varchar](100) NOT NULL,
	[IdConcesionario] [int] NOT NULL,
 CONSTRAINT [PK__Servicio__C7DEC3311C0001A3] PRIMARY KEY CLUSTERED 
(
	[NIF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendedores]    Script Date: 10/23/2017 7:13:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendedores](
	[NIF] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Domicilio] [varchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[IdConcesionario] [int] NULL,
	[VentasRealizadas] [int] NOT NULL,
 CONSTRAINT [PK__Vendedor__C7DEC3317E1D656D] PRIMARY KEY CLUSTERED 
(
	[NIF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VentaAuto]    Script Date: 10/23/2017 7:13:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VentaAuto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAuto] [int] NOT NULL,
	[IdVendedor] [int] NOT NULL,
	[PrecioVenta] [decimal](12, 2) NOT NULL,
	[ModoPago] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ServiciosOficiales]  WITH CHECK ADD FOREIGN KEY([IdConcesionario])
REFERENCES [dbo].[Concesionario] ([Id])
GO
ALTER TABLE [dbo].[Vendedores]  WITH CHECK ADD  CONSTRAINT [FK_Vendedores_Concesionario] FOREIGN KEY([IdConcesionario])
REFERENCES [dbo].[Concesionario] ([Id])
GO
ALTER TABLE [dbo].[Vendedores] CHECK CONSTRAINT [FK_Vendedores_Concesionario]
GO
ALTER TABLE [dbo].[VentaAuto]  WITH CHECK ADD  CONSTRAINT [FK_VentaAuto_Automovil] FOREIGN KEY([IdAuto])
REFERENCES [dbo].[Automovil] ([Id])
GO
ALTER TABLE [dbo].[VentaAuto] CHECK CONSTRAINT [FK_VentaAuto_Automovil]
GO
ALTER TABLE [dbo].[VentaAuto]  WITH CHECK ADD  CONSTRAINT [FK_VentaAuto_Vendedores] FOREIGN KEY([IdAuto])
REFERENCES [dbo].[Vendedores] ([NIF])
GO
ALTER TABLE [dbo].[VentaAuto] CHECK CONSTRAINT [FK_VentaAuto_Vendedores]
GO
USE [master]
GO
ALTER DATABASE [Concesionario] SET  READ_WRITE 
GO
