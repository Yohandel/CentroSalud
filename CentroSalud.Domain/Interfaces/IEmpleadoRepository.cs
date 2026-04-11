using CentroSalud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentroSalud.Domain.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<List<Empleado?>> GetAllAsync();
        Task<Empleado?> GetByIdAsync(int id);
        Task<Empleado?> AddAsync(Empleado? empleado);
        Task<Empleado?> UpdateAsync(Empleado? empleado);
        Task<Empleado?> DeleteAsync(int id);


    }
}
