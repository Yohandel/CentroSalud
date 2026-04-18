using CentroSalud.Application.DTOs.Horario;
using CentroSalud.Application.DTOs.Medico;

namespace CentroSalud.Application.Interfaces;

    public interface IHorarioService
    {
        Task<List<HorarioDto>> GetAllAsync();
        Task<HorarioDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateHorarioDto dto);
        Task UpdateAsync(int id, UpdateHorarioDto dto);
        Task DeleteAsync(int id);
    }

