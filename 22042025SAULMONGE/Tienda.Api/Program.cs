
using Microsoft.EntityFrameworkCore;
using Tienda.Application.Services;
using Tienda.Domain.Repositories;
using Tienda.Infrastructure.Data;
using Tienda.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar DbContext (ajusta la cadena en appsettings.json)
builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Registrar repositorio y servicio de aplicación
builder.Services.AddScoped<IProductoRepositorio, ProductRepository>();
builder.Services.AddScoped<ProductService>();

// 3. Agregar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
