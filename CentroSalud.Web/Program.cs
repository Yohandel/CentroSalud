using CentroSalud.Domain.Interfaces;
using CentroSalud.Infrastructure;
using CentroSalud.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔌 Application
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
//builder.Services.AddScoped<IMedicoService, MedicoService>();
//builder.Services.AddScoped<ISustitucionService, SustitucionService>();

// 🔌 Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);
//builder.Services.AddScoped<CentroSalud.Domain.Interfaces.IMedicoRepository, MedicoRepository>();
//builder.Services.AddScoped<ISustitucionRepository, SustitucionRepository>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();