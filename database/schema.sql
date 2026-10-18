CREATE DATABASE SistemaInventario;
GO
USE SistemaInventario;
GO
CREATE TABLE Suplidores (
	id INT PRIMARY KEY IDENTITY,
	nombre_empresa NVARCHAR(100) NOT NULL UNIQUE,
	nombre_contacto NVARCHAR(100) NOT NULL,
	telefono VARCHAR(12) NOT NULL,
	correo_electronico NVARCHAR(100) NOT NULL,
	sitio_web NVARCHAR(200),
	fecha_creacion DATE NOT NULL DEFAULT GETDATE(),
	fecha_modificacion DATE NOT NULL DEFAULT GETDATE(),
	activo BIT NOT NULL DEFAULT 1
);
GO
CREATE TABLE Imagenes (
	id INT PRIMARY KEY IDENTITY,
	datos VARBINARY(MAX) NOT NULL,
	fecha_creacion DATE NOT NULL DEFAULT GETDATE(),
	fecha_modificacion DATE NOT NULL DEFAULT GETDATE(),
	activo BIT NOT NULL DEFAULT 1
);
GO
CREATE TABLE Categorias (
	id INT PRIMARY KEY IDENTITY,
	nombre VARCHAR(100) NOT NULL UNIQUE,
	descripcion VARCHAR(500) NOT NULL,
	imagen_id INT,
	fecha_creacion DATE NOT NULL DEFAULT GETDATE(),
	fecha_modificacion DATE NOT NULL DEFAULT GETDATE(),
	activo BIT NOT NULL DEFAULT 1,
	CONSTRAINT fk_imagen FOREIGN KEY(imagen_id) REFERENCES Imagenes(id)
);
GO
CREATE TABLE Productos (
	id INT PRIMARY KEY IDENTITY,
	categoria_id INT NOT NULL,
	nombre NVARCHAR(100) NOT NULL UNIQUE,
	precio_unitario DECIMAL(10,2) NOT NULL CHECK (precio_unitario > 0),
	fecha_creacion DATE NOT NULL DEFAULT GETDATE(),
	fecha_modificacion DATE NOT NULL DEFAULT GETDATE(),
	activo BIT NOT NULL DEFAULT 1,
	CONSTRAINT fk_categoria FOREIGN KEY(categoria_id) REFERENCES Categorias(id)
);
GO
CREATE TABLE Suplidores_productos (
	id INT PRIMARY KEY IDENTITY,
	suplidor_id INT NOT NULL,
	producto_id INT NOT NULL,
	CONSTRAINT fk_suplidor FOREIGN KEY(suplidor_id) REFERENCES Suplidores(id),
	CONSTRAINT fk_producto FOREIGN KEY(producto_id) REFERENCES Productos(id)
);