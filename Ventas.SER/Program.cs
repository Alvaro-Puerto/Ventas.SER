using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Ventas.SER.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
        x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexion Base de datos
builder.Services.AddDbContext<VentaContexto>(opciones =>
        opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDB"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
