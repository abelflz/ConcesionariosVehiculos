Create database Concesionario

Go

Use Concesionario

Go

Create table automoviles(
	Id_auto Int primary Key identity (1,1),
	Marca varchar(25)not null,
	Modelo Varchar(25) not null,
	Datos_tecnicos varchar(25) not null,
	Descuento Decimal(12,2),
	Precio Decimal(12,2) not null
);
Go

Create table Concesionario(
	Id_Con Int Primary Key Identity (1,1),
	Nombre varchar(25) Not null,

);
Go

Create table Servicios_oficiales(
	NIF int primary key identity(1,1),
	Nombre Varchar(25) not null,
	Domicilio Varchar(100) not null
);
Go

Create table Vendedores(
	NIF int primary key identity(1,1),
	Nombre Varchar(25) not null,
	Domicilio Varchar(100) not null,
	Fecha_de_Nacimiento date not null,
	Ventas_Realizadas int not null
);
Go

Create table Venta_Auto(
	Id int primary key identity(1,1),
	Id_Auto int not null,
	Id_vendedor int not null,
	Precio_venta Decimal(12,2) not null,
	Modo_Pago Varchar(25) not null
);
Go