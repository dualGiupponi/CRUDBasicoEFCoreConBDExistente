using CRUDBasico.Dominio.Repositorios;
using CRUDBasico.Repositorio;
using CRUDBasico.Repositorio.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CRUDBasicoContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("postgre")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Add services to the container.
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
