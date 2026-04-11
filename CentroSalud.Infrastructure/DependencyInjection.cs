using CentroSalud.Domain.Interfaces;
using CentroSalud.Infrastructure.Data;
using CentroSalud.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentroSalud.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Asegúrate de que IEmpleadoRepository venga de CentroSalud.Domain.Interfaces
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();

            return services;
        }
    }
}
