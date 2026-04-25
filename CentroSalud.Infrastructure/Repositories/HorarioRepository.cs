using CentroSalud.Domain.Entities;
using CentroSalud.Domain.Interfaces;
using CentroSalud.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CentroSalud.Infrastructure.Repositories
{
    public class HorarioRepository : IHorarioRepository
    {
        private readonly ApplicationDbContext _context;

        public HorarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Horario?>> GetAllAsync()
        {
            return await _context.Horarios
            .Include(h => h.Medico)
            .ToListAsync();
        }

        public async Task<Horario?> GetByIdAsync(int id)
        {
            return await _context.Horarios
      .Include(h => h.Medico) // 🔥 CLAVE
      .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Horario?> AddAsync(Horario? horario)
        {
            if (horario == null) return null;

            await _context.Horarios.AddAsync(horario);
            await _context.SaveChangesAsync();
            return horario; // Ahora sí devuelve el horario
        }

        public async Task<Horario?> UpdateAsync(Horario? horario)
        {
            if (horario == null) return null;

            _context.Horarios.Update(horario);
            await _context.SaveChangesAsync();
            return horario; // Ahora sí devuelve el horario
        }

        public async Task<Horario?> DeleteAsync(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);

            if (horario != null)
            {
                _context.Horarios.Remove(horario);
                await _context.SaveChangesAsync();
            }
            return horario; // Devuelve el horario eliminado (o null si no existía)
        }

        public async Task<List<Horario?>> GetByMedicoIdAsync(int medicoId)
        {
            return await _context.Horarios
            .Include(h => h.Medico) // 🔥 CLAVE
            .Where(h => h.MedicoId == medicoId)
            .ToListAsync();
        }
    }
}