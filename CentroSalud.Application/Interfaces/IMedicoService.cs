using CentroSalud.Application.DTOs.Medico;

namespace CentroSalud.Application.Interfaces;

public interface IMedicoService
{
    Task<List<MedicoDto>> GetAllAsync();

    Task<MedicoDto?> GetByIdAsync(int id);

    Task CreateAsync(CreateMedicoDto dto);

    Task UpdateAsync(int id, UpdateMedicoDto dto);

    Task DeleteAsync(int id);
}