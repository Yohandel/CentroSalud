using CentroSalud.Application.DTOs.Paciente;

namespace CentroSalud.Application.Interfaces;

public interface IPacienteService
{
    Task<List<PacienteDto>> GetAllAsync();

    Task<PacienteDto?> GetByIdAsync(int id);

    Task CreateAsync(CreatePacienteDto dto);

    Task UpdateAsync(int id, UpdatePacienteDto dto);

    Task DeleteAsync(int id);
}