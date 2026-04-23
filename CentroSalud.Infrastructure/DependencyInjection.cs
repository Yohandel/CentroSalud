using CentroSalud.Domain.Interfaces;
using CentroSalud.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CentroSalud.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
        services.AddScoped<IMedicoRepository, MedicoRepository>();
        services.AddScoped<IPacienteRepository, PacienteRepository>();
        services.AddScoped<ISustitucionRepository, SustitucionRepository>();

        return services;
    }
}