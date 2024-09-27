using Libreria.BusinessLogicLayer.Servicios;
using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ConnectionString")
));

builder.Services.AddScoped<IGenericRepository<Promocione>, PromocionesRepository>();
builder.Services.AddScoped<IGenericRepository<Proveedor>, ProveedorRepository>();
builder.Services.AddScoped<IGenericRepository<Producto>, ProductoRepository>();
builder.Services.AddScoped<IGenericRepository<PedidoProveedor>, PredidoProveedorRepository>();
builder.Services.AddScoped<IGenericRepository<Inventario>, InventarioRepository>();
builder.Services.AddScoped<IGenericRepository<Empleado>, EmpleadoRepository>();
builder.Services.AddScoped<IGenericRepository<DetallePedidoProveedor>, DetallePedidoProveedorRepository>();
builder.Services.AddScoped<IGenericRepository<DetalleCompra>, DetalleCompraRepository>();
builder.Services.AddScoped<IGenericRepository<DetalleCarrito>, DetalleCarritoRepository>();
builder.Services.AddScoped<IGenericRepository<Cupone>, CuponesRepository>();


builder.Services.AddScoped<IPromocionesService, PromocionesService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IProductosService, ProductosService>();
builder.Services.AddScoped<IPedidoProveedorService, PedidoProveedorService>();
builder.Services.AddScoped<IInventarioService, InventarioService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IDetallePedidoProveedorService, DetallePedidoProveedorService>();
builder.Services.AddScoped<IDetalleCompraService, DetalleCompraService>();
builder.Services.AddScoped<IDetalleCarritoService, DetalleCarritoService>();
builder.Services.AddScoped<ICuponesService, CuponesService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
