using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.DataContext;

public partial class LibreriaContext : DbContext
{
    public LibreriaContext()
    {
    }

    public LibreriaContext(DbContextOptions<LibreriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarritoCompra> CarritoCompras { get; set; }

    public virtual DbSet<Categoría> Categorías { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Cupone> Cupones { get; set; }

    public virtual DbSet<DetalleCarrito> DetalleCarritos { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetallePedidoProveedor> DetallePedidoProveedors { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<PedidoProveedor> PedidoProveedors { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Promocione> Promociones { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Libreria;User Id=sa;Password=Sinclave1!;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarritoCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carrito___3214EC07A1880262");

            entity.ToTable("Carrito_Compras");

            entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");
            entity.Property(e => e.EstadoCarrito)
                .HasMaxLength(50)
                .HasColumnName("Estado_Carrito");
            entity.Property(e => e.FechaCreación).HasColumnName("Fecha_Creación");

            entity.HasOne(d => d.Cliente).WithMany(p => p.CarritoCompras)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carrito_Compras_Cliente");
        });

        modelBuilder.Entity<Categoría>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categorí__3214EC07763E2BDD");

            entity.ToTable("Categoría");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Categoria");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC07D6F96D2C");

            entity.ToTable("Cliente");

            entity.Property(e => e.CorreoElectrónico)
                .HasMaxLength(100)
                .HasColumnName("Correo_Electrónico");
            entity.Property(e => e.FechaRegistro).HasColumnName("Fecha_Registro");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Cliente");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Compra__3214EC07271386B0");

            entity.ToTable("Compra");

            entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaCompra).HasColumnName("Fecha_Compra");
            entity.Property(e => e.TotalCompra)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_Compra");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_Cliente");
        });

        modelBuilder.Entity<Cupone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cupones__3214EC0789E1416A");

            entity.Property(e => e.ClientesAplicados).HasColumnName("Clientes_Aplicados");
            entity.Property(e => e.CodigoCupon)
                .HasMaxLength(50)
                .HasColumnName("Codigo_Cupon");
            entity.Property(e => e.Descripción).HasMaxLength(255);
            entity.Property(e => e.Descuento).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaExpiracion).HasColumnName("Fecha_Expiracion");

            entity.HasOne(d => d.ClientesAplicadosNavigation).WithMany(p => p.Cupones)
                .HasForeignKey(d => d.ClientesAplicados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cupones_Cliente");
        });

        modelBuilder.Entity<DetalleCarrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Detalle___3214EC077C4420D0");

            entity.ToTable("Detalle_Carrito");

            entity.Property(e => e.CarritoId).HasColumnName("Carrito_ID");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_Unitario");
            entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");

            entity.HasOne(d => d.Carrito).WithMany(p => p.DetalleCarritos)
                .HasForeignKey(d => d.CarritoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Carrito_Carrito");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleCarritos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Carrito_Producto");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Detalle___3214EC0708539381");

            entity.ToTable("Detalle_Compra");

            entity.Property(e => e.CompraId).HasColumnName("Compra_ID");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_Unitario");
            entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Compra).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.CompraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Compra_Compra");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Compra_Producto");
        });

        modelBuilder.Entity<DetallePedidoProveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Detalle___3214EC07F8FC1FD3");

            entity.ToTable("Detalle_Pedido_Proveedor");

            entity.Property(e => e.PedidoProveedorId).HasColumnName("Pedido_Proveedor_ID");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_Unitario");
            entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.PedidoProveedor).WithMany(p => p.DetallePedidoProveedors)
                .HasForeignKey(d => d.PedidoProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Pedido_Proveedor_Pedido");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallePedidoProveedors)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Pedido_Proveedor_Producto");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleado__3214EC076ADBD413");

            entity.ToTable("Empleado");

            entity.Property(e => e.Cargo).HasMaxLength(50);
            entity.Property(e => e.CorreoElectrónico)
                .HasMaxLength(100)
                .HasColumnName("Correo_Electrónico");
            entity.Property(e => e.FechaContratación).HasColumnName("Fecha_Contratación");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Empleado");
            entity.Property(e => e.Teléfono).HasMaxLength(15);
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventar__3214EC078884C5CC");

            entity.ToTable("Inventario");

            entity.Property(e => e.CantidadEntrante).HasColumnName("Cantidad_Entrante");
            entity.Property(e => e.FechaEntrada).HasColumnName("Fecha_Entrada");
            entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");
            entity.Property(e => e.ProveedorId).HasColumnName("Proveedor_ID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Producto");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Proveedor");
        });

        modelBuilder.Entity<PedidoProveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedido_P__3214EC0741136357");

            entity.ToTable("Pedido_Proveedor");

            entity.Property(e => e.EstadoPedido)
                .HasMaxLength(50)
                .HasColumnName("Estado_Pedido");
            entity.Property(e => e.FechaPedido).HasColumnName("Fecha_Pedido");
            entity.Property(e => e.ProveedorId).HasColumnName("Proveedor_ID");
            entity.Property(e => e.TotalPedido)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_Pedido");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.PedidoProveedors)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Proveedor_Proveedor");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC07C4929CA6");

            entity.ToTable("Producto");

            entity.Property(e => e.CantidadStock).HasColumnName("Cantidad_Stock");
            entity.Property(e => e.CategoríaId).HasColumnName("Categoría_ID");
            entity.Property(e => e.Descripción).HasMaxLength(255);
            entity.Property(e => e.FechaIngreso).HasColumnName("Fecha_Ingreso");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Producto");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProveedorId).HasColumnName("Proveedor_ID");

            entity.HasOne(d => d.Categoría).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoríaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Categoría");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Proveedor");
        });

        modelBuilder.Entity<Promocione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promocio__3214EC07025A0F85");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Descuento).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.FechaFin).HasColumnName("Fecha_Fin");
            entity.Property(e => e.FechaInicio).HasColumnName("Fecha_Inicio");
            entity.Property(e => e.NombrePromocion)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Promocion");
            entity.Property(e => e.ProductosAplicados).HasColumnName("Productos_Aplicados");

            entity.HasOne(d => d.ProductosAplicadosNavigation).WithMany(p => p.Promociones)
                .HasForeignKey(d => d.ProductosAplicados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Promociones_Producto");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proveedo__3214EC07D6B97B6A");

            entity.ToTable("Proveedor");

            entity.Property(e => e.CorreoElectrónico)
                .HasMaxLength(100)
                .HasColumnName("Correo_Electrónico");
            entity.Property(e => e.Dirección).HasMaxLength(255);
            entity.Property(e => e.Teléfono).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
