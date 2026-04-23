using CentroSalud.Domain.Entities;

namespace CentroSalud.Domain.Interfaces
{
    public interface ISustitucionRepository
    {
        Task<Sustitucion?> GetByIdAsync(int id);
        Task AddAsync(Sustitucion sustitucion);
        Task UpdateAsync(Sustitucion sustitucion);
        Task<List<Sustitucion>> GetAllAsync();
    }
}