USE master;

IF NOT EXISTS (SELECT* FROM sysdatabases WHERE name = 'VentasST') BEGIN
	CREATE DATABASE VentasST;
END

GO
USE VentasST

GO
IF EXISTS (SELECT* FROM INFORMATION_SCHEMA.TABLES T WHERE T.TABLE_NAME = 'VentaDetalle') BEGIN
	DROP TABLE VentaDetalle;
END
GO
IF EXISTS (SELECT* FROM INFORMATION_SCHEMA.TABLES T WHERE T.TABLE_NAME = 'Venta') BEGIN
	DROP TABLE Venta;
END
GO
IF EXISTS (SELECT* FROM INFORMATION_SCHEMA.TABLES T WHERE T.TABLE_NAME = 'Producto') BEGIN
	DROP TABLE Producto;
END
GO
IF EXISTS (SELECT* FROM INFORMATION_SCHEMA.TABLES T WHERE T.TABLE_NAME = 'Cliente') BEGIN
	DROP TABLE Cliente;
END


GO
CREATE TABLE Cliente (
	ClienteId int identity(1,1) NOT NULL,
	Cedula nvarchar(20) NOT NULL,
	Nombre nvarchar(50) NOT NULL,
	Apellido nvarchar(50) NOT NULL,
	Telefono nvarchar(50),

	CONSTRAINT PK_Cliente PRIMARY KEY (ClienteId),
	CONSTRAINT UQ_Cliente_001 UNIQUE (Cedula)
)

GO
CREATE TABLE Producto (
	ProductoId int identity(1,1) NOT NULL,
	Nombre nvarchar(50) NOT NULL,
	ValorUnitario decimal NOT NULL,

	CONSTRAINT PK_Producto PRIMARY KEY (ProductoId)
)

GO
CREATE TABLE Venta (
	VentaId int identity(1,1) NOT NULL,
	ClienteId int NOT NULL,
	Fecha datetime NOT NULL,

	CONSTRAINT PK_Venta PRIMARY KEY (VentaId),
	CONSTRAINT FK_Venta_001 FOREIGN KEY (ClienteId) REFERENCES Cliente(ClienteId)
)

GO
CREATE TABLE VentaDetalle (
	VentaDetalleId int identity(1,1) NOT NULL,
	VentaId int NOT NULL,
	ProductoId int NOT NULL,
	Cantidad decimal NOT NULL,
	ValorUnitario decimal NOT NULL,

	CONSTRAINT PK_VentaDetalle PRIMARY KEY (VentaDetalleId),
	CONSTRAINT FK_VentaDetalle_001 FOREIGN KEY (VentaId) REFERENCES Venta(VentaId),
	CONSTRAINT FK_VentaDetalle_002 FOREIGN KEY (ProductoId) REFERENCES Producto(ProductoId)
)