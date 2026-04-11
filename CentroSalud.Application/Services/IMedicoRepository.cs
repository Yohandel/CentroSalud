using CentroSalud.Domain.Entities;

public interface IMedicoRepository
{
    // Cambia IEnumerable<object> por IEnumerable<Medico> o Task<List<Medico>>
    Task<IEnumerable<Medico>> GetAllAsync();

    // Necesitas un método para buscar por ID en el repositorio
    Task<Medico?> GetByIdAsync(int id);

    Task AddAsync(Medico medico);

    // Cambia object por Medico
    Task UpdateAsync(Medico medico);

    Task DeleteAsync(int id);
}