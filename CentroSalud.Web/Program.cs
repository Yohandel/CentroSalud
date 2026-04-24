using CentroSalud.Application.Interfaces;
using CentroSalud.Infrastructure;
using CentroSalud.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CentroSalud.Domain.Interfaces;
using CentroSalud.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<ISustitucionService, SustitucionService>();
builder.Services.AddScoped<IHorarioService, HorarioService>();
builder.Services.AddScoped<IHorarioRepository, HorarioRepository>();

// 🔐 Autorización
builder.Services.AddAuthorization();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

// Middleware

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();