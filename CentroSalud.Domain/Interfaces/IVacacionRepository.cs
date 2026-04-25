using CentroSalud.Domain.Entities;

public interface IVacacionRepository
{
    Task<List<Vacacion>> GetByEmpleadoIdAsync(int empleadoId);
    Task<List<Vacacion>> GetByMedicoIdAsync(int medicoId);
    Task<List<Vacacion>> GetALL();
    Task AddAsync(Vacacion vacacion);
    Task<Vacacion?> GetByIdAsync(int id);
    Task UpdateAsync(Vacacion vacacion);
}