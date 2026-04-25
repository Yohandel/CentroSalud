using CentroSalud.Domain.Entities;


namespace CentroSalud.Domain.Interfaces
{
    public interface IHorarioRepository
    {
        Task<List<Horario?>> GetAllAsync();
        Task<Horario?> GetByIdAsync(int id);
        Task<List<Horario?>> GetByMedicoIdAsync(int medicoId);
        Task<Horario?> AddAsync(Horario horario);
        Task<Horario?> UpdateAsync(Horario horario);
        Task<Horario?> DeleteAsync(int id);


    }
}
