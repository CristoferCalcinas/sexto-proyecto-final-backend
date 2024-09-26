CREATE DATABASE libreria;

USE libreria;

CREATE TABLE libreria.dbo.Carrito_Compras (
    Id INT IDENTITY(1,1) NOT NULL,
    Cliente_ID INT NOT NULL,
    Fecha_Creación DATE NOT NULL,
    Estado_Carrito NVARCHAR(50) NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE libreria.dbo.Categoría (
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre_Categoria NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    PRIMARY KEY (Id)
);

CREATE TABLE libreria.dbo.Cliente (
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre_Cliente NVARCHAR(100) NOT NULL,
    Correo_Electrónico NVARCHAR(100) NOT NULL,
    Fecha_Registro DATE NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE libreria.dbo.Compra (
    Id INT IDENTITY(1,1) NOT NULL,
    Fecha_Compra DATE NOT NULL,
    Cliente_ID INT NOT NULL,
    Total_Compra DECIMAL(10, 2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE libreria.dbo.Cupones (
    Id INT IDENTITY(1,1) NOT NULL,
    Codigo_Cupon NVARCHAR(50) NOT NULL,
    Descripción NVARCHAR(255),
    Descuento DECIMAL(5, 2) NOT NULL,
    Fecha_Expiracion DATE NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    Clientes_Aplicados INT NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE libreria.dbo.Detalle_Carrito (
    Id INT IDENTITY(1,1) NOT NULL,
    Carrito_ID INT NOT NULL,
    Producto_ID INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio_Unitario DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE libreria.dbo.Detalle_Compra (
    Id INT IDENTITY(1,1) NOT NULL,
    Compra_ID INT NOT NULL,
    Producto_ID INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio_Unitario DECIMAL(10, 2) NOT NULL,
    Subtotal DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE libreria.dbo.Detalle_Pedido_Proveedor (
    Id INT IDENTITY(1,1) NOT NULL,
    Pedido_Proveedor_ID INT NOT NULL,
    Producto_ID INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio_Unitario DECIMAL(10, 2) NOT NULL,
    Subtotal DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE libreria.dbo.Empleado (
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre_Empleado NVARCHAR(100) NOT NULL,
    Correo_Electrónico NVARCHAR(100) NOT NULL,
    Teléfono NVARCHAR(15),
    Cargo NVARCHAR(50) NOT NULL,
    Fecha_Contratación DATE NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE libreria.dbo.Inventario (
    Id INT IDENTITY(1,1) NOT NULL,
    Producto_ID INT NOT NULL,
    Cantidad_Entrante INT NOT NULL,
    Fecha_Entrada DATE NOT NULL,
    Proveedor_ID INT NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE libreria.dbo.Pedido_Proveedor (
    Id INT IDENTITY(1,1) NOT NULL,
    Proveedor_ID INT NOT NULL,
    Fecha_Pedido DATE NOT NULL,
    Estado_Pedido NVARCHAR(50) NOT NULL,
    Total_Pedido DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE libreria.dbo.Producto (
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre_Producto NVARCHAR(100) NOT NULL,
    Descripción NVARCHAR(255),
    Precio DECIMAL(10, 2) NOT NULL,
    Cantidad_Stock INT NOT NULL,
    Categoría_ID INT NOT NULL,
    Fecha_Ingreso DATE NOT NULL,
    Proveedor_ID INT NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE libreria.dbo.Promociones (
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre_Promocion NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Fecha_Inicio DATE NOT NULL,
    Fecha_Fin DATE NOT NULL,
    Descuento DECIMAL(5, 2) NOT NULL,
    Productos_Aplicados INT NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE libreria.dbo.Proveedor (
    Id INT IDENTITY(1,1) NOT NULL,
    Teléfono NVARCHAR(15),
    Correo_Electrónico NVARCHAR(100),
    Dirección NVARCHAR(255),
    PRIMARY KEY (Id)
);

ALTER TABLE libreria.dbo.Carrito_Compras ADD CONSTRAINT FK_Carrito_Compras_Cliente FOREIGN KEY (Cliente_ID) REFERENCES libreria.dbo.Cliente (Id);
ALTER TABLE libreria.dbo.Compra ADD CONSTRAINT FK_Compra_Cliente FOREIGN KEY (Cliente_ID) REFERENCES libreria.dbo.Cliente (Id);
ALTER TABLE libreria.dbo.Cupones ADD CONSTRAINT FK_Cupones_Cliente FOREIGN KEY (Clientes_Aplicados) REFERENCES libreria.dbo.Cliente (Id);
ALTER TABLE libreria.dbo.Detalle_Carrito ADD CONSTRAINT FK_Detalle_Carrito_Carrito FOREIGN KEY (Carrito_ID) REFERENCES libreria.dbo.Carrito_Compras (Id);
ALTER TABLE libreria.dbo.Detalle_Carrito ADD CONSTRAINT FK_Detalle_Carrito_Producto FOREIGN KEY (Producto_ID) REFERENCES libreria.dbo.Producto (Id);
ALTER TABLE libreria.dbo.Detalle_Compra ADD CONSTRAINT FK_Detalle_Compra_Compra FOREIGN KEY (Compra_ID) REFERENCES libreria.dbo.Compra (Id);
ALTER TABLE libreria.dbo.Detalle_Compra ADD CONSTRAINT FK_Detalle_Compra_Producto FOREIGN KEY (Producto_ID) REFERENCES libreria.dbo.Producto (Id);
ALTER TABLE libreria.dbo.Detalle_Pedido_Proveedor ADD CONSTRAINT FK_Detalle_Pedido_Proveedor_Pedido FOREIGN KEY (Pedido_Proveedor_ID) REFERENCES libreria.dbo.Pedido_Proveedor (Id);
ALTER TABLE libreria.dbo.Detalle_Pedido_Proveedor ADD CONSTRAINT FK_Detalle_Pedido_Proveedor_Producto FOREIGN KEY (Producto_ID) REFERENCES libreria.dbo.Producto (Id);
ALTER TABLE libreria.dbo.Inventario ADD CONSTRAINT FK_Inventario_Producto FOREIGN KEY (Producto_ID) REFERENCES libreria.dbo.Producto (Id);
ALTER TABLE libreria.dbo.Inventario ADD CONSTRAINT FK_Inventario_Proveedor FOREIGN KEY (Proveedor_ID) REFERENCES libreria.dbo.Proveedor (Id);
ALTER TABLE libreria.dbo.Pedido_Proveedor ADD CONSTRAINT FK_Pedido_Proveedor_Proveedor FOREIGN KEY (Proveedor_ID) REFERENCES libreria.dbo.Proveedor (Id);
ALTER TABLE libreria.dbo.Producto ADD CONSTRAINT FK_Producto_Categoría FOREIGN KEY (Categoría_ID) REFERENCES libreria.dbo.Categoría (Id);
ALTER TABLE libreria.dbo.Producto ADD CONSTRAINT FK_Producto_Proveedor FOREIGN KEY (Proveedor_ID) REFERENCES libreria.dbo.Proveedor (Id);
ALTER TABLE libreria.dbo.Promociones ADD CONSTRAINT FK_Promociones_Producto FOREIGN KEY (Productos_Aplicados) REFERENCES libreria.dbo.Producto (Id);