using CasaDePasoAWSDemo.Core.Application.Interfaces.IRepositories;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IServices;
using CasaDePasoAWSDemo.Core.Application.Services;
using CasaDePasoAWSDemo.Core.Infrastructure.Configurations.Persistence;
using CasaDePasoAWSDemo.Core.Infrastructure.Configurations.Security;
using CasaDePasoAWSDemo.Core.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar la capa de infraestructura
builder.Services.AddInfrastructure();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Contextos
// Configurar la cadena de conexión a PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CasaDePasoContext>(options =>
    options.UseNpgsql(connectionString));

#endregion

builder.Services.AddTransient<ITokenServices, TokenServices>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddTransient<ErrorBD>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
