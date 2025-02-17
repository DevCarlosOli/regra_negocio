using Regra_Negocio.API.Application.Services;
using Regra_Negocio.API.Application.Services.Interfaces;
using Regra_Negocio.API.Infra.DbContext;
using Regra_Negocio.API.Infra.Repositories;
using Regra_Negocio.API.Infra.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Banco de dados PostgreSQL
builder.Services.AddSingleton<ConexaoPostreSQL>();

// Add services to the container.
builder.Services.AddScoped<IRegraNegocioService, RegraNegocioService>();
builder.Services.AddScoped<IRegraNegocioRepository, RegraNegocioRepository>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
