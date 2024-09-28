-- Creación de la base de datos
CREATE DATABASE Libreria;

USE Libreria;

-- Tabla Cliente
CREATE TABLE
    Cliente (
        Id INT IDENTITY (1, 1) NOT NULL,
        NombreCliente NVARCHAR (100) NOT NULL,
        CorreoElectronico NVARCHAR (100) NOT NULL,
        FechaRegistro DATE NOT NULL,
        PRIMARY KEY (Id)
    );

-- Tabla Carrito
CREATE TABLE
    Carrito (
        Id INT IDENTITY (1, 1) NOT NULL,
        ClienteID INT NOT NULL,
        FechaCreacion DATE NOT NULL,
        EstadoCarrito NVARCHAR (50) NOT NULL,
        PRIMARY KEY (Id),
        CONSTRAINT FK_Carrito_Cliente FOREIGN KEY (ClienteID) REFERENCES Cliente (Id)
    );

-- Tabla Categoria
CREATE TABLE
    Categoria (
        Id INT IDENTITY (1, 1) NOT NULL,
        NombreCategoria NVARCHAR (100) NOT NULL,
        Descripcion NVARCHAR (255),
        PRIMARY KEY (Id)
    );

-- Tabla Compra
CREATE TABLE
    Compra (
        Id INT IDENTITY (1, 1) NOT NULL,
        FechaCompra DATE NOT NULL,
        ClienteID INT NOT NULL,
        TotalCompra DECIMAL(10, 2) NOT NULL,
        Estado NVARCHAR (50) NOT NULL,
        PRIMARY KEY (Id),
        CONSTRAINT FK_Compra_Cliente FOREIGN KEY (ClienteID) REFERENCES Cliente (Id)
    );

-- Tabla Cupones
CREATE TABLE
    Cupon (
        Id INT IDENTITY (1, 1) NOT NULL,
        CodigoCupon NVARCHAR (50) NOT NULL,
        Descripcion NVARCHAR (255),
        Descuento DECIMAL(5, 2) NOT NULL,
        FechaExpiracion DATE NOT NULL,
        Estado NVARCHAR (50) NOT NULL,
        PRIMARY KEY (Id)
    );

-- Tabla DetalleCarrito
CREATE TABLE
    DetalleCarrito (
        Id INT IDENTITY (1, 1) NOT NULL,
        CarritoID INT NOT NULL,
        ProductoID INT NOT NULL,
        Cantidad INT NOT NULL,
        PrecioUnitario DECIMAL(10, 2) NOT NULL,
        PRIMARY KEY (Id),
        CONSTRAINT FK_DetalleCarrito_Carrito FOREIGN KEY (CarritoID) REFERENCES Carrito (Id),
        CONSTRAINT FK_DetalleCarrito_Producto FOREIGN KEY (ProductoID) REFERENCES Producto (Id)
    );

-- Tabla DetalleCompra
CREATE TABLE
    DetalleCompra (
        Id INT IDENTITY (1, 1) NOT NULL,
        CompraID INT NOT NULL,
        ProductoID INT NOT NULL,
        Cantidad INT NOT NULL,
        PrecioUnitario DECIMAL(10, 2) NOT NULL,
        Subtotal DECIMAL(10, 2) NOT NULL,
        PRIMARY KEY (Id),
        CONSTRAINT FK_DetalleCompra_Compra FOREIGN KEY (CompraID) REFERENCES Compra (Id),
        CONSTRAINT FK_DetalleCompra_Producto FOREIGN KEY (ProductoID) REFERENCES Producto (Id)
    );

-- Tabla DetallePedidoProveedor
CREATE TABLE
    DetallePedidoProveedor (
        Id INT IDENTITY (1, 1) NOT NULL,
        PedidoProveedorID INT NOT NULL,
        ProductoID INT NOT NULL,
        Cantidad INT NOT NULL,
        PrecioUnitario DECIMAL(10, 2) NOT NULL,
        Subtotal DECIMAL(10, 2) NOT NULL,
        PRIMARY KEY (Id),
        CONSTRAINT FK_DetallePedidoProveedor_Pedido FOREIGN KEY (PedidoProveedorID) REFERENCES PedidoProveedor (Id),
        CONSTRAINT FK_DetallePedidoProveedor_Producto FOREIGN KEY (ProductoID) REFERENCES Producto (Id)
    );

-- Tabla Empleado
CREATE TABLE
    Empleado (
        Id INT IDENTITY (1, 1) NOT NULL,
        NombreEmpleado NVARCHAR (100) NOT NULL,
        CorreoElectronico NVARCHAR (100) NOT NULL,
        Telefono NVARCHAR (15),
        Cargo NVARCHAR (50) NOT NULL,
        FechaContratacion DATE NOT NULL,
        PRIMARY KEY (Id)
    );

-- Tabla Inventario
CREATE TABLE
    Inventario (
        Id INT IDENTITY (1, 1) NOT NULL,
        ProductoID INT NOT NULL,
        CantidadEntrante INT NOT NULL,
        FechaEntrada DATE NOT NULL,
        ProveedorID INT NOT NULL,
        PRIMARY KEY (Id),
        CONSTRAINT FK_Inventario_Producto FOREIGN KEY (ProductoID) REFERENCES Producto (Id),
        CONSTRAINT FK_Inventario_Proveedor FOREIGN KEY (ProveedorID) REFERENCES Proveedor (Id)
    );

-- Tabla PedidoProveedor
CREATE TABLE
    PedidoProveedor (
        Id INT IDENTITY (1, 1) NOT NULL,
        ProveedorID INT NOT NULL,
        FechaPedido DATE NOT NULL,
        EstadoPedido NVARCHAR (50) NOT NULL,
        TotalPedido DECIMAL(10, 2) NOT NULL,
        PRIMARY KEY (Id),
        CONSTRAINT FK_PedidoProveedor_Proveedor FOREIGN KEY (ProveedorID) REFERENCES Proveedor (Id)
    );

-- Tabla Producto
CREATE TABLE
    Producto (
        Id INT IDENTITY (1, 1) NOT NULL,
        NombreProducto NVARCHAR (100) NOT NULL,
        Descripcion NVARCHAR (255),
        Precio DECIMAL(10, 2) NOT NULL,
        CantidadStock INT NOT NULL,
        CategoriaID INT NOT NULL,
        FechaIngreso DATE NOT NULL,
        ProveedorID INT NOT NULL,
        PRIMARY KEY (Id),
        CONSTRAINT FK_Producto_Categoria FOREIGN KEY (CategoriaID) REFERENCES Categoria (Id),
        CONSTRAINT FK_Producto_Proveedor FOREIGN KEY (ProveedorID) REFERENCES Proveedor (Id)
    );

-- Tabla Promocion
CREATE TABLE
    Promocion (
        Id INT IDENTITY (1, 1) NOT NULL,
        NombrePromocion NVARCHAR (100) NOT NULL,
        Descripcion NVARCHAR (255),
        FechaInicio DATE NOT NULL,
        FechaFin DATE NOT NULL,
        Descuento DECIMAL(5, 2) NOT NULL,
        ProductoID INT NOT NULL,
        PRIMARY KEY (Id),
        CONSTRAINT FK_Promocion_Producto FOREIGN KEY (ProductoID) REFERENCES Producto (Id)
    );

-- Tabla Proveedor
CREATE TABLE
    Proveedor (
        Id INT IDENTITY (1, 1) NOT NULL,
        Telefono NVARCHAR (15),
        CorreoElectronico NVARCHAR (100),
        Direccion NVARCHAR (255),
        PRIMARY KEY (Id)
    );

-- Nuevas tablas agregadas
-- Tabla Sucursal
CREATE TABLE
    Sucursal (
        Id INT IDENTITY (1, 1) NOT NULL,
        NombreSucursal NVARCHAR (100) NOT NULL,
        Direccion NVARCHAR (255),
        PRIMARY KEY (Id)
    );

-- Tabla Envio (Relacion con Sucursal y Compra)
CREATE TABLE
    Envio (
        Id INT IDENTITY (1, 1) NOT NULL,
        CompraID INT NOT NULL,
        SucursalID INT NOT NULL,
        FechaEnvio DATE NOT NULL,
        EstadoEnvio NVARCHAR (50) NOT NULL,
        PRIMARY KEY (Id),
        CONSTRAINT FK_Envio_Compra FOREIGN KEY (CompraID) REFERENCES Compra (Id),
        CONSTRAINT FK_Envio_Sucursal FOREIGN KEY (SucursalID) REFERENCES Sucursal (Id)
    );

-- Tabla DireccionCliente (Relacion con Cliente y Sucursal)
CREATE TABLE
    DireccionCliente (
        Id INT IDENTITY (1, 1) NOT NULL,
        ClienteID INT NOT NULL,
        Direccion NVARCHAR (255) NOT NULL,
        Ciudad NVARCHAR (100),
        Estado NVARCHAR (100),
        CodigoPostal NVARCHAR (10),
        PRIMARY KEY (Id),
        CONSTRAINT FK_DireccionCliente_Cliente FOREIGN KEY (ClienteID) REFERENCES Cliente (Id)
    );

-- Insertar datos en la tabla Cliente
INSERT INTO
    Cliente (NombreCliente, CorreoElectronico, FechaRegistro)
VALUES
    (
        'Juan Pérez',
        'juan.perez@email.com',
        '2024-01-15'
    ),
    (
        'María García',
        'maria.garcia@email.com',
        '2024-02-20'
    ),
    (
        'Carlos López',
        'carlos.lopez@email.com',
        '2024-03-10'
    );

-- Insertar datos en la tabla Categoria
INSERT INTO
    Categoria (NombreCategoria, Descripcion)
VALUES
    (
        'Ficción',
        'Libros de ficción incluyendo novelas y cuentos'
    ),
    ('No ficción', 'Libros informativos y educativos'),
    ('Infantil', 'Libros para niños y jóvenes');

-- Insertar datos en la tabla Proveedor
INSERT INTO
    Proveedor (Telefono, CorreoElectronico, Direccion)
VALUES
    (
        '555-1234',
        'proveedor1@email.com',
        'Calle Principal 123'
    ),
    (
        '555-5678',
        'proveedor2@email.com',
        'Avenida Central 456'
    );

-- Insertar datos en la tabla Producto
INSERT INTO
    Producto (
        NombreProducto,
        Descripcion,
        Precio,
        CantidadStock,
        CategoriaID,
        FechaIngreso,
        ProveedorID
    )
VALUES
    (
        'El Quijote',
        'Clásico de la literatura española',
        25.99,
        50,
        1,
        '2024-01-01',
        1
    ),
    (
        'Historia del Mundo',
        'Libro de historia general',
        35.50,
        30,
        2,
        '2024-02-01',
        2
    ),
    (
        'Cuentos Infantiles',
        'Colección de cuentos para niños',
        15.75,
        100,
        3,
        '2024-03-01',
        1
    );

-- Insertar datos en la tabla Carrito
INSERT INTO
    Carrito (ClienteID, FechaCreacion, EstadoCarrito)
VALUES
    (1, '2024-09-01', 'Activo'),
    (2, '2024-09-05', 'Completado');

-- Insertar datos en la tabla DetalleCarrito
INSERT INTO
    DetalleCarrito (CarritoID, ProductoID, Cantidad, PrecioUnitario)
VALUES
    (1, 1, 2, 25.99),
    (1, 3, 1, 15.75),
    (2, 2, 1, 35.50);

-- Insertar datos en la tabla Compra
INSERT INTO
    Compra (FechaCompra, ClienteID, TotalCompra, Estado)
VALUES
    ('2024-09-10', 2, 35.50, 'Completada');

-- Insertar datos en la tabla DetalleCompra
INSERT INTO
    DetalleCompra (
        CompraID,
        ProductoID,
        Cantidad,
        PrecioUnitario,
        Subtotal
    )
VALUES
    (1, 2, 1, 35.50, 35.50);

-- Insertar datos en la tabla Cupon
INSERT INTO
    Cupon (
        CodigoCupon,
        Descripcion,
        Descuento,
        FechaExpiracion,
        Estado
    )
VALUES
    (
        'VERANO2024',
        'Descuento de verano',
        10.00,
        '2024-08-31',
        'Activo'
    );

-- Insertar datos en la tabla Empleado
INSERT INTO
    Empleado (
        NombreEmpleado,
        CorreoElectronico,
        Telefono,
        Cargo,
        FechaContratacion
    )
VALUES
    (
        'Ana Martínez',
        'ana.martinez@libreria.com',
        '555-9876',
        'Vendedor',
        '2024-01-01'
    );

-- Insertar datos en la tabla Inventario
INSERT INTO
    Inventario (
        ProductoID,
        CantidadEntrante,
        FechaEntrada,
        ProveedorID
    )
VALUES
    (1, 50, '2024-01-01', 1),
    (2, 30, '2024-02-01', 2),
    (3, 100, '2024-03-01', 1);

-- Insertar datos en la tabla PedidoProveedor
INSERT INTO
    PedidoProveedor (
        ProveedorID,
        FechaPedido,
        EstadoPedido,
        TotalPedido
    )
VALUES
    (1, '2024-08-15', 'Pendiente', 1000.00);

-- Insertar datos en la tabla DetallePedidoProveedor
INSERT INTO
    DetallePedidoProveedor (
        PedidoProveedorID,
        ProductoID,
        Cantidad,
        PrecioUnitario,
        Subtotal
    )
VALUES
    (1, 1, 20, 20.00, 400.00),
    (1, 3, 40, 15.00, 600.00);

-- Insertar datos en la tabla Promocion
INSERT INTO
    Promocion (
        NombrePromocion,
        Descripcion,
        FechaInicio,
        FechaFin,
        Descuento,
        ProductoID
    )
VALUES
    (
        'Oferta Verano',
        'Descuento en libros de ficción',
        '2024-06-01',
        '2024-08-31',
        15.00,
        1
    );

-- Insertar datos en la tabla Sucursal
INSERT INTO
    Sucursal (NombreSucursal, Direccion)
VALUES
    ('Sucursal Centro', 'Plaza Mayor 1');

-- Insertar datos en la tabla Envio
INSERT INTO
    Envio (CompraID, SucursalID, FechaEnvio, EstadoEnvio)
VALUES
    (1, 1, '2024-09-11', 'En camino');

-- Insertar datos en la tabla DireccionCliente
INSERT INTO
    DireccionCliente (
        ClienteID,
        Direccion,
        Ciudad,
        Estado,
        CodigoPostal
    )
VALUES
    (
        1,
        'Calle Alegría 123',
        'Madrid',
        'Madrid',
        '28001'
    ),
    (
        2,
        'Avenida Libertad 456',
        'Barcelona',
        'Cataluña',
        '08001'
    );