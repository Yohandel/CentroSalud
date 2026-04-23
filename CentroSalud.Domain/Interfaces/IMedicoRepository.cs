using CentroSalud.Domain.Entities;

namespace CentroSalud.Domain.Interfaces
{
    public interface IMedicoRepository
    {
        Task<List<Medico>> GetAllAsync();
        Task<Medico?> GetByIdAsync(int id); // Agregamos ? porque puede no existir
        Task AddAsync(Medico medico);       // Cambiamos a Task (void) para que coincida con tu clase
        Task UpdateAsync(Medico medico);    // Cambiamos a Task
        Task DeleteAsync(int id);           // Cambiamos a Task
    }
}