using CentroSalud.Domain.Entities;
using CentroSalud.Domain.Interfaces;
using CentroSalud.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CentroSalud.Infrastructure.Repositories;

public class PacienteRepository : IPacienteRepository
{
    private readonly ApplicationDbContext _context;

    public PacienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Paciente>> GetAllAsync()
    {
        return await _context.Pacientes
             .Include(p => p.Medico)
            .ToListAsync();
    }

    public async Task<Paciente?> GetByIdAsync(int id)
    {
        return await _context.Pacientes
            .Include(p => p.Medico)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Paciente paciente)
    {
        await _context.Pacientes.AddAsync(paciente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Paciente paciente)
    {
        _context.Pacientes.Update(paciente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);

        if (paciente != null)
        {
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
        }
    }
}