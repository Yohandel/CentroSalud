using CentroSalud.Application.DTOs;
using CentroSalud.Application.DTOs.Empleado;

public interface IEmpleadoService
{
    Task<List<EmpleadoDto>> GetAllAsync();
    Task<EmpleadoDto?> GetByIdAsync(int id);
    Task CreateAsync(CreateEmpleadoDto dto);
    Task UpdateAsync(int id, UpdateEmpleadoDto dto);
    Task DeleteAsync(int id);
}