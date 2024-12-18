-- 1. Tabla Rol
CREATE TABLE
    Rol (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        NombreRol NVARCHAR (50) NOT NULL UNIQUE,
        Descripcion NVARCHAR (255)
    );

-- 2. Tabla Usuario
CREATE TABLE
    Usuario (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        NombreUsuario NVARCHAR (100) NOT NULL,
        CorreoElectronico NVARCHAR (100) NOT NULL UNIQUE,
        Contrasena NVARCHAR (255) NOT NULL, -- Almacenar hash de contraseña
        RolID INT NOT NULL,
        FechaRegistro DATE NOT NULL,
        Telefono NVARCHAR (15),
        Estado BIT DEFAULT 1, -- Activo/Inactivo
        CONSTRAINT FK_Usuario_Rol FOREIGN KEY (RolID) REFERENCES Rol (Id)
    );

-- 3. Tabla Categoria
CREATE TABLE
    Categoria (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        NombreCategoria NVARCHAR (100) NOT NULL,
        Descripcion NVARCHAR (255)
    );

-- 4. Tabla Proveedor
CREATE TABLE
    Proveedor (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        Telefono NVARCHAR (15),
        CorreoElectronico NVARCHAR (100),
        Direccion NVARCHAR (255)
    );

-- 5. Tabla Sucursal
CREATE TABLE
    Sucursal (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        NombreSucursal NVARCHAR (100) NOT NULL,
        Direccion NVARCHAR (255)
    );

-- 6. Tabla Producto
CREATE TABLE
    Producto (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        NombreProducto NVARCHAR (100) NOT NULL,
        Descripcion NVARCHAR (255),
        Precio DECIMAL(10, 2) NOT NULL,
        CantidadStock INT NOT NULL,
        CategoriaID INT NOT NULL,
        FechaIngreso DATE NOT NULL,
        ProveedorID INT NOT NULL,
        CONSTRAINT FK_Producto_Categoria FOREIGN KEY (CategoriaID) REFERENCES Categoria (Id),
        CONSTRAINT FK_Producto_Proveedor FOREIGN KEY (ProveedorID) REFERENCES Proveedor (Id)
    );

-- 7. Tabla Carrito
CREATE TABLE
    Carrito (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        UsuarioID INT NOT NULL,
        FechaCreacion DATE NOT NULL,
        EstadoCarrito NVARCHAR (50) NOT NULL,
        CONSTRAINT FK_Carrito_Usuario FOREIGN KEY (UsuarioID) REFERENCES Usuario (Id)
    );

-- 8. Tabla DetalleCarrito
CREATE TABLE
    DetalleCarrito (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        CarritoID INT NOT NULL,
        ProductoID INT NOT NULL,
        Cantidad INT NOT NULL,
        PrecioUnitario DECIMAL(10, 2) NOT NULL,
        CONSTRAINT FK_DetalleCarrito_Carrito FOREIGN KEY (CarritoID) REFERENCES Carrito (Id),
        CONSTRAINT FK_DetalleCarrito_Producto FOREIGN KEY (ProductoID) REFERENCES Producto (Id)
    );

-- 9. Tabla Compra
CREATE TABLE
    Compra (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        UsuarioID INT NOT NULL,
        FechaCompra DATE NOT NULL,
        TotalCompra DECIMAL(10, 2) NOT NULL,
        Estado NVARCHAR (50) NOT NULL,
        CONSTRAINT FK_Compra_Usuario FOREIGN KEY (UsuarioID) REFERENCES Usuario (Id)
    );

-- 10. Tabla DetalleCompra
CREATE TABLE
    DetalleCompra (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        CompraID INT NOT NULL,
        ProductoID INT NOT NULL,
        Cantidad INT NOT NULL,
        PrecioUnitario DECIMAL(10, 2) NOT NULL,
        Subtotal DECIMAL(10, 2) NOT NULL,
        CONSTRAINT FK_DetalleCompra_Compra FOREIGN KEY (CompraID) REFERENCES Compra (Id),
        CONSTRAINT FK_DetalleCompra_Producto FOREIGN KEY (ProductoID) REFERENCES Producto (Id)
    );

-- 11. Tabla Cupon
CREATE TABLE
    Cupon (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        CodigoCupon NVARCHAR (50) NOT NULL,
        Descripcion NVARCHAR (255),
        Descuento DECIMAL(5, 2) NOT NULL,
        FechaExpiracion DATE NOT NULL,
        Estado NVARCHAR (50) NOT NULL
    );

-- 12. Tabla Envio
CREATE TABLE
    Envio (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        CompraID INT NOT NULL,
        SucursalID INT NOT NULL,
        FechaEnvio DATE NOT NULL,
        EstadoEnvio NVARCHAR (50) NOT NULL,
        CONSTRAINT FK_Envio_Compra FOREIGN KEY (CompraID) REFERENCES Compra (Id),
        CONSTRAINT FK_Envio_Sucursal FOREIGN KEY (SucursalID) REFERENCES Sucursal (Id)
    );

-- 13. Tabla Inventario
CREATE TABLE
    Inventario (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        ProductoID INT NOT NULL,
        CantidadEntrante INT NOT NULL,
        FechaEntrada DATE NOT NULL,
        ProveedorID INT NOT NULL,
        CONSTRAINT FK_Inventario_Producto FOREIGN KEY (ProductoID) REFERENCES Producto (Id),
        CONSTRAINT FK_Inventario_Proveedor FOREIGN KEY (ProveedorID) REFERENCES Proveedor (Id)
    );

-- 14. Tabla Promocion
CREATE TABLE
    Promocion (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        NombrePromocion NVARCHAR (100) NOT NULL,
        Descripcion NVARCHAR (255),
        FechaInicio DATE NOT NULL,
        FechaFin DATE NOT NULL,
        Descuento DECIMAL(5, 2) NOT NULL,
        ProductoID INT NOT NULL,
        CONSTRAINT FK_Promocion_Producto FOREIGN KEY (ProductoID) REFERENCES Producto (Id)
    );

-- 15. Tabla PedidoProveedor
CREATE TABLE
    PedidoProveedor (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        ProveedorID INT NOT NULL,
        FechaPedido DATE NOT NULL,
        EstadoPedido NVARCHAR (50) NOT NULL,
        TotalPedido DECIMAL(10, 2) NOT NULL,
        CONSTRAINT FK_PedidoProveedor_Proveedor FOREIGN KEY (ProveedorID) REFERENCES Proveedor (Id)
    );

-- 16. Tabla DetallePedidoProveedor
CREATE TABLE
    DetallePedidoProveedor (
        Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
        PedidoProveedorID INT NOT NULL,
        ProductoID INT NOT NULL,
        Cantidad INT NOT NULL,
        PrecioUnitario DECIMAL(10, 2) NOT NULL,
        Subtotal DECIMAL(10, 2) NOT NULL,
        CONSTRAINT FK_DetallePedidoProveedor_Pedido FOREIGN KEY (PedidoProveedorID) REFERENCES PedidoProveedor (Id),
        CONSTRAINT FK_DetallePedidoProveedor_Producto FOREIGN KEY (ProductoID) REFERENCES Producto (Id)
    );

-- DATA
INSERT INTO
    Rol (NombreRol, Descripcion)
VALUES
    (
        'Administrador',
        'Gestiona todos los aspectos del sistema'
    ),
    ('Cliente', 'Usuario que realiza compras'),
    (
        'Proveedor',
        'Usuario que abastece productos al sistema'
    );

INSERT INTO
    Usuario (
        NombreUsuario,
        CorreoElectronico,
        Contrasena,
        RolID,
        FechaRegistro,
        Telefono,
        Estado
    )
VALUES
    (
        'admin',
        'admin@tienda.com',
        'hashed_password_1',
        1,
        '2023-01-01',
        '123456789',
        1
    ),
    (
        'cliente1',
        'cliente1@tienda.com',
        'hashed_password_2',
        2,
        '2023-05-10',
        '987654321',
        1
    ),
    (
        'proveedor1',
        'proveedor1@tienda.com',
        'hashed_password_3',
        3,
        '2023-06-15',
        '555555555',
        1
    );

INSERT INTO
    Categoria (NombreCategoria, Descripcion)
VALUES
    (
        'Electrónica',
        'Dispositivos electrónicos y gadgets'
    ),
    ('Ropa', 'Prendas de vestir para todas las edades'),
    (
        'Hogar',
        'Artículos para el hogar y la decoración'
    ),
    ('Deportes', 'Equipamiento y ropa deportiva');

INSERT INTO
    Proveedor (Telefono, CorreoElectronico, Direccion)
VALUES
    (
        '555123456',
        'contacto@proveedor1.com',
        'Av. Central #123'
    ),
    (
        '555987654',
        'ventas@proveedor2.com',
        'Calle Falsa #456'
    ),
    (
        '555654321',
        'info@proveedor3.com',
        'Av. Industrial #789'
    );

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
        'Smartphone X1',
        'Teléfono inteligente con pantalla OLED',
        699.99,
        50,
        1,
        '2023-07-01',
        1
    ),
    (
        'Laptop Gamer Y2',
        'Laptop de alto rendimiento para videojuegos',
        1299.99,
        30,
        1,
        '2023-07-05',
        1
    ),
    (
        'Camisa Casual',
        'Camisa de algodón para uso diario',
        19.99,
        100,
        2,
        '2023-06-20',
        2
    ),
    (
        'Pantalón Deportivo',
        'Pantalón elástico para actividades físicas',
        29.99,
        75,
        4,
        '2023-06-25',
        2
    ),
    (
        'Silla Ergonomica',
        'Silla con soporte lumbar y ajustable',
        149.99,
        20,
        3,
        '2023-07-10',
        3
    ),
    (
        'Cafetera Automática',
        'Máquina para café con múltiples funciones',
        89.99,
        15,
        3,
        '2023-07-15',
        3
    );

INSERT INTO
    Sucursal (NombreSucursal, Direccion)
VALUES
    ('Sucursal Central', 'Av. Central #123'),
    ('Sucursal Norte', 'Av. Norte #456'),
    ('Sucursal Sur', 'Av. Sur #789');

INSERT INTO
    Inventario (
        ProductoID,
        CantidadEntrante,
        FechaEntrada,
        ProveedorID
    )
VALUES
    (1, 20, '2023-07-01', 1),
    (2, 15, '2023-07-05', 1),
    (3, 50, '2023-06-20', 2),
    (4, 30, '2023-06-25', 2),
    (5, 10, '2023-07-10', 3),
    (6, 5, '2023-07-15', 3);

INSERT INTO
    Carrito (UsuarioID, FechaCreacion, EstadoCarrito)
VALUES
    (2, '2023-08-01', 'Activo'),
    (2, '2023-08-02', 'Finalizado');

INSERT INTO
    DetalleCarrito (CarritoID, ProductoID, Cantidad, PrecioUnitario)
VALUES
    (1, 1, 1, 699.99),
    (1, 3, 2, 19.99),
    (2, 2, 1, 1299.99);

INSERT INTO
    Compra (UsuarioID, FechaCompra, TotalCompra, Estado)
VALUES
    (2, '2023-08-02', 1339.97, 'Completada');

INSERT INTO
    DetalleCompra (
        CompraID,
        ProductoID,
        Cantidad,
        PrecioUnitario,
        Subtotal
    )
VALUES
    (1, 1, 1, 699.99, 699.99),
    (1, 3, 2, 19.99, 39.98),
    (1, 2, 1, 1299.99, 1299.99);

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
        'DESCUENTO10',
        '10% de descuento en toda la tienda',
        10.00,
        '2023-12-31',
        'Activo'
    ),
    (
        'ENVIOGRATIS',
        'Envío gratis en compras mayores a $50',
        0.00,
        '2023-12-31',
        'Activo'
    );

INSERT INTO
    Envio (CompraID, SucursalID, FechaEnvio, EstadoEnvio)
VALUES
    (1, 1, '2023-08-03', 'Enviado');

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
        'Black Friday',
        'Descuento especial por Black Friday',
        '2023-11-01',
        '2023-11-30',
        20.00,
        1
    ),
    (
        'Cyber Monday',
        'Promoción exclusiva de tecnología',
        '2023-11-27',
        '2023-11-28',
        15.00,
        2
    );

INSERT INTO
    PedidoProveedor (
        ProveedorID,
        FechaPedido,
        EstadoPedido,
        TotalPedido
    )
VALUES
    (1, '2023-07-01', 'Completado', 2000.00),
    (2, '2023-07-05', 'Pendiente', 500.00);

INSERT INTO
    DetallePedidoProveedor (
        PedidoProveedorID,
        ProductoID,
        Cantidad,
        PrecioUnitario,
        Subtotal
    )
VALUES
    (1, 1, 20, 100.00, 2000.00),
    (2, 3, 50, 10.00, 500.00);