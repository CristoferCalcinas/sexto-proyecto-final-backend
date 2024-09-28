INSERT INTO
    libreria.dbo.Cliente (
        Nombre_Cliente,
        Correo_Electrónico,
        Fecha_Registro
    )
VALUES
    (
        'Juan Pérez',
        'juan.perez@example.com',
        '2024-01-15'
    ),
    (
        'María González',
        'maria.gonzalez@example.com',
        '2023-12-20'
    ),
    (
        'Carlos Ramírez',
        'carlos.ramirez@example.com',
        '2024-02-10'
    );

INSERT INTO
    libreria.dbo.Carrito_Compras (Cliente_ID, Fecha_Creación, Estado_Carrito)
VALUES
    (1, '2024-09-15', 'Pendiente'),
    (2, '2024-09-10', 'Procesado'),
    (3, '2024-09-12', 'Pendiente');

INSERT INTO
    libreria.dbo.Categoría (Nombre_Categoria, Descripcion)
VALUES
    ('Ficción', 'Libros de narrativa imaginaria'),
    ('Ciencia', 'Libros de ciencias y tecnología'),
    ('Autoayuda', 'Libros de superación personal');

INSERT INTO
    libreria.dbo.Proveedor (Teléfono, Correo_Electrónico, Dirección)
VALUES
    (
        '555-1234',
        'proveedor1@example.com',
        'Calle Falsa 123'
    ),
    (
        '555-5678',
        'proveedor2@example.com',
        'Avenida Siempreviva 742'
    );

INSERT INTO
    libreria.dbo.Producto (
        Nombre_Producto,
        Descripción,
        Precio,
        Cantidad_Stock,
        Categoría_ID,
        Fecha_Ingreso,
        Proveedor_ID
    )
VALUES
    (
        'El Principito',
        'Un clásico de la literatura infantil',
        12.99,
        150,
        1,
        '2024-01-05',
        1
    ),
    (
        'Breve Historia del Tiempo',
        'Un libro sobre cosmología y física',
        18.50,
        120,
        2,
        '2024-02-10',
        2
    ),
    (
        'Los 7 Hábitos de la Gente Altamente Efectiva',
        'Libro de autoayuda',
        14.75,
        100,
        3,
        '2024-01-25',
        1
    );

INSERT INTO
    libreria.dbo.Inventario (
        Producto_ID,
        Cantidad_Entrante,
        Fecha_Entrada,
        Proveedor_ID
    )
VALUES
    (1, 50, '2024-08-01', 1),
    (2, 30, '2024-08-10', 2),
    (3, 40, '2024-08-15', 1);

INSERT INTO
    libreria.dbo.Cupones (
        Codigo_Cupon,
        Descripción,
        Descuento,
        Fecha_Expiracion,
        Estado,
        Clientes_Aplicados
    )
VALUES
    (
        'DESCUENTO10',
        'Cupón de 10% de descuento',
        10.00,
        '2024-12-31',
        'Activo',
        1
    ),
    (
        'OFERTA15',
        'Cupón de 15% de descuento',
        15.00,
        '2024-11-30',
        'Activo',
        2
    ),
    (
        'PROMO20',
        'Cupón de 20% de descuento',
        20.00,
        '2024-10-31',
        'Vencido',
        3
    );

INSERT INTO
    libreria.dbo.Compra (Fecha_Compra, Cliente_ID, Total_Compra, Estado)
VALUES
    ('2024-09-18', 1, 45.23, 'Completado'),
    ('2024-09-16', 2, 25.89, 'Pendiente'),
    ('2024-09-14', 3, 60.50, 'Completado');

INSERT INTO
    libreria.dbo.Detalle_Compra (
        Compra_ID,
        Producto_ID,
        Cantidad,
        Precio_Unitario,
        Subtotal
    )
VALUES
    (1, 1, 2, 12.99, 25.98),
    (1, 2, 1, 18.50, 18.50),
    (2, 3, 1, 14.75, 14.75),
    (3, 1, 3, 12.99, 38.97),
    (3, 2, 1, 18.50, 18.50);

INSERT INTO
    libreria.dbo.Detalle_Carrito (
        Carrito_ID,
        Producto_ID,
        Cantidad,
        Precio_Unitario
    )
VALUES
    (1, 1, 2, 12.99),
    (1, 2, 1, 18.50),
    (2, 3, 1, 14.75),
    (3, 1, 3, 12.99);

INSERT INTO
    libreria.dbo.Promociones (
        Nombre_Promocion,
        Descripcion,
        Fecha_Inicio,
        Fecha_Fin,
        Descuento,
        Productos_Aplicados
    )
VALUES
    (
        'Verano 2024',
        'Promoción de libros para el verano',
        '2024-06-01',
        '2024-09-01',
        10.00,
        1
    ),
    (
        'Ciencia y Tecnología',
        'Descuento en libros de ciencia',
        '2024-05-01',
        '2024-12-31',
        15.00,
        2
    ),
    (
        'Autoayuda',
        'Promoción en libros de autoayuda',
        '2024-07-01',
        '2024-10-01',
        5.00,
        3
    );

INSERT INTO
    libreria.dbo.Empleado (
        Nombre_Empleado,
        Correo_Electrónico,
        Teléfono,
        Cargo,
        Fecha_Contratación
    )
VALUES
    (
        'Ana López',
        'ana.lopez@libreria.com',
        '555-9876',
        'Vendedora',
        '2023-09-01'
    ),
    (
        'Luis Martínez',
        'luis.martinez@libreria.com',
        '555-6543',
        'Cajero',
        '2023-10-15'
    ),
    (
        'Sofía Herrera',
        'sofia.herrera@libreria.com',
        '555-3210',
        'Gerente',
        '2023-11-20'
    );

INSERT INTO
    libreria.dbo.Pedido_Proveedor (
        Proveedor_ID,
        Fecha_Pedido,
        Estado_Pedido,
        Total_Pedido
    )
VALUES
    (1, '2024-07-20', 'Completado', 600.50),
    (2, '2024-08-10', 'Pendiente', 450.75);

INSERT INTO
    libreria.dbo.Detalle_Pedido_Proveedor (
        Pedido_Proveedor_ID,
        Producto_ID,
        Cantidad,
        Precio_Unitario,
        Subtotal
    )
VALUES
    (1, 1, 50, 10.00, 500.00),
    (1, 3, 40, 10.50, 420.00),
    (2, 2, 30, 15.00, 450.00);