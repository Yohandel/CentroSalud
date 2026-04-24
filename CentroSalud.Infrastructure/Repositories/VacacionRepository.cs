using CentroSalud.Domain.Entities;
using CentroSalud.Domain.Interfaces;
using CentroSalud.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class VacacionRepository : IVacacionRepository
{
    private readonly ApplicationDbContext _context;

    public VacacionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Vacacion>> GetByEmpleadoIdAsync(int empleadoId)
    {
        return await _context.Vacaciones
            .Where(v => v.EmpleadoId == empleadoId)
            .ToListAsync();
    }

    public async Task<List<Vacacion>> GetByMedicoIdAsync(int medicoId)
    {
        return await _context.Vacaciones
            .Where(v => v.MedicoId == medicoId)
            .ToListAsync();
    }

    public async Task AddAsync(Vacacion vacacion)
    {
        _context.Vacaciones.Add(vacacion);
        await _context.SaveChangesAsync();
    }

    public async Task<Vacacion?> GetByIdAsync(int id)
    {
        return await _context.Vacaciones.FindAsync(id);
    }

    public async Task UpdateAsync(Vacacion vacacion)
    {
        _context.Vacaciones.Update(vacacion);
        await _context.SaveChangesAsync();
    }
}