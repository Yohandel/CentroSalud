using CentroSalud.Application.DTOs.Shared;

public interface IVacacionService
{
    Task<List<VacacionDto>> GetALL();
    Task<VacacionDto?> GetByIdAsync(int id);
    Task<List<VacacionDto>> GetAsync(int? empleadoId, int? medicoId);
    Task CreateAsync(CreateVacacionDto dto);
    Task<int> GetDiasDisponibles(int? empleadoId, int? medicoId);
    Task UpdateAsync(UpdateVacacionDto dto);
    Task CancelAsync(CancelVacacionDto dto);
}