using Microsoft.EntityFrameworkCore;
using TiendaProductosAPI.Data;
using TiendaProductosAPI.Interfaces;
using TiendaProductosAPI.Repositories;
using TiendaProductosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Se configura Entity Framework para utilizar SQL Server.
builder.Services.AddDbContext<TiendaDbContext>(opciones =>
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("TiendaConnection")));

// Se relaciona la interfaz con la clase que realiza las consultas.
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

// Se relaciona la interfaz del Service con su implementación.
builder.Services.AddScoped<IProductoService, ProductoService>();

var app = builder.Build();

// Swagger se deja habilitado para probar los endpoints de forma sencilla.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
