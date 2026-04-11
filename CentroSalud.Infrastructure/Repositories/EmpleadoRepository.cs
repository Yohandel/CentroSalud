using CentroSalud.Domain.Entities;
using CentroSalud.Domain.Interfaces;
using CentroSalud.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CentroSalud.Infrastructure.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Empleado?>> GetAllAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        public async Task<Empleado?> AddAsync(Empleado? empleado)
        {
            if (empleado == null) return null;

            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();
            return empleado; // Ahora sí devuelve el empleado
        }

        public async Task<Empleado?> UpdateAsync(Empleado? empleado)
        {
            if (empleado == null) return null;

            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();
            return empleado; // Ahora sí devuelve el empleado
        }

        public async Task<Empleado?> DeleteAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
            return empleado; // Devuelve el empleado eliminado (o null si no existía)
        }
    }
}