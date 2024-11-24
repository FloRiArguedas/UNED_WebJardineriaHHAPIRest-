using Microsoft.EntityFrameworkCore;
using P2_FloricelaArguedas_WebApplication.Controllers;
using P2_FloricelaArguedas_WebApplication.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyecto la configuración al contexto.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Registro el contexto como servicio para inyectarlo 
builder.Services.AddDbContext<P2_FloricelaArguedas_WebApplication.Data.BDContexto>(x => x.UseSqlServer(connectionString));

//Registros de servicios con instancias
builder.Services.AddScoped<BDContexto>();
builder.Services.AddScoped<MemoriaCliente>();
builder.Services.AddScoped<MemoriaEmpleado>();
builder.Services.AddScoped<MemoriaMantenimiento>();
builder.Services.AddScoped<MemoriaMaquinaria>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
