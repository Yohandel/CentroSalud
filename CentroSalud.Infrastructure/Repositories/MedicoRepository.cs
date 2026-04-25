using CentroSalud.Domain.Entities;
using CentroSalud.Domain.Interfaces;
using CentroSalud.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CentroSalud.Infrastructure.Repositories;

public class MedicoRepository : IMedicoRepository
{
    private readonly ApplicationDbContext _context;

    public MedicoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Medico>> GetAllAsync()
    {
        return await _context.Medicos
            .Include(m => m.Horarios)
            .Include(m => m.SustitucionesComoSustituto)
            .Include(m => m.SustitucionesComoReemplazado)
            .ToListAsync();
    }

    public async Task<Medico?> GetByIdAsync(int id)
    {
        return await _context.Medicos
            .Include(m => m.Horarios)
            .Include(m => m.SustitucionesComoSustituto)
                .ThenInclude(s => s.MedicoReemplazado)
            .Include(m => m.SustitucionesComoReemplazado)
                .ThenInclude(s => s.MedicoSustituto)

            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Medico medico)
    {
        await _context.Medicos.AddAsync(medico);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Medico medico)
    {
        _context.Medicos.Update(medico);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var medico = await _context.Medicos.FindAsync(id);

        if (medico != null)
        {
            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
        }
    }
}