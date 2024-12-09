using Libreria.BusinessLogicLayer.Servicios;
using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ConnectionString")
));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});

builder.Services.AddScoped<ICarritoRepository, CarritoRepository>();
builder.Services.AddScoped<ICategoriumRepository, CategoriumRepository>();
builder.Services.AddScoped<IComprasRepository, CompraRepository>();
builder.Services.AddScoped<IDetalleCarritoRepository, DetalleCarritoRepository>();
builder.Services.AddScoped<IGenericRepository<Cupon>, CuponRepository>();
builder.Services.AddScoped<IGenericRepository<DetalleCompra>, DetalleCompraRepository>();
builder.Services.AddScoped<IGenericRepository<DetallePedidoProveedor>, DetallePedidoProveedorRepository>();
builder.Services.AddScoped<IGenericRepository<Envio>, EnvioRepository>();
builder.Services.AddScoped<IGenericRepository<Inventario>, InventarioRepository>();
builder.Services.AddScoped<IGenericRepository<PedidoProveedor>, PedidoProveedorRepository>();
builder.Services.AddScoped<IGenericRepository<Promocion>, PromocionRepository>();
builder.Services.AddScoped<IGenericRepository<Sucursal>, SucursalRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


builder.Services.AddScoped<ICarritoService, CarritoService>();
builder.Services.AddScoped<ICategoriumService, CategoriumService>();
builder.Services.AddScoped<ICompraService, ComprasService>();
builder.Services.AddScoped<ICuponService, CuponService>();
builder.Services.AddScoped<IDetalleCarritoService, DetalleCarritoService>();
builder.Services.AddScoped<IDetalleCompraService, DetalleCompraService>();
builder.Services.AddScoped<IDetallePedidoProveedorService, DetallePedidoProveedorService>();
builder.Services.AddScoped<IEnvioService, EnvioService>();
builder.Services.AddScoped<IInventarioService, InventarioService>();
builder.Services.AddScoped<IPedidoProveedorService, PedidoProveedorService>();
builder.Services.AddScoped<IProductosService, ProductosService>();
builder.Services.AddScoped<IPromocionService, PromocionService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<ISucursalService, SucursalService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();


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

// Aplicar política CORS
app.UseCors("AllowAnyOrigin");

app.MapControllers();

app.Run();
