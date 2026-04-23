using CentroSalud.Domain.Entities;
using CentroSalud.Domain.Interfaces;
using CentroSalud.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CentroSalud.Infrastructure.Repositories;

public class SustitucionRepository : ISustitucionRepository
{
    private readonly ApplicationDbContext _context;

    public SustitucionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Sustitucion>> GetAllAsync()
    {
        return await _context.Sustituciones
            .Include(s => s.MedicoSustituto)
            .Include(s => s.MedicoReemplazado)
            .ToListAsync();
    }

    public async Task<Sustitucion?> GetByIdAsync(int id)
    {
        return await _context.Sustituciones
            .Include(s => s.MedicoSustituto)
            .Include(s => s.MedicoReemplazado)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Sustitucion sustitucion)
    {
        await _context.Sustituciones.AddAsync(sustitucion);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sustitucion sustitucion)
    {
        _context.Sustituciones.Update(sustitucion);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var sustitucion = await _context.Sustituciones.FindAsync(id);

        if (sustitucion != null)
        {
            _context.Sustituciones.Remove(sustitucion);
            await _context.SaveChangesAsync();
        }
    }
}