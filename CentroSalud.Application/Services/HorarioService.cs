using CentroSalud.Application.DTOs;
using CentroSalud.Application.DTOs.Empleado;
using CentroSalud.Application.DTOs.Horario;
using CentroSalud.Application.DTOs.Medico;
using CentroSalud.Application.Interfaces;
using CentroSalud.Domain.Entities;
using CentroSalud.Domain.Interfaces;

public class HorarioService : IHorarioService
{
    private readonly IHorarioRepository _repo;

    public HorarioService(IHorarioRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<HorarioDto>> GetAllAsync()
    {
        var horarios = await _repo.GetAllAsync();

        return horarios.Select(h => new HorarioDto
        {
            Id = h.Id,
            Dia = h.Dia.ToString(),
            HoraInicio = h.HoraInicio.ToString(),
            HoraFin = h.HoraFin.ToString(),
        }).ToList();
    }

    public async Task<HorarioDto?> GetByIdAsync(int id)
    {
        var h = await _repo.GetByIdAsync(id);
        if (h == null) return null;

        return new HorarioDto
        {
            Id = h.Id,
            Dia = h.Dia.ToString(),
            HoraInicio = h.HoraInicio.ToString(),
            HoraFin = h.HoraFin.ToString()
        };
    }

    public async Task CreateAsync(CreateHorarioDto dto)
    {
        var horario = new Horario
        {
            Dia = dto.Dia,
            HoraInicio = dto.HoraInicio,
            HoraFin = dto.HoraFin,
            MedicoId = dto.MedicoId
        };

        await _repo.AddAsync(horario);
    }

    public async Task UpdateAsync(int id, UpdateHorarioDto dto)
    {
        var horario = await _repo.GetByIdAsync(id);
        if (horario == null) throw new Exception("Horario no encontrado");

        horario.Dia = dto.Dia;
        horario.HoraInicio = dto.HoraInicio;
        horario.HoraFin = dto.HoraFin;

        await _repo.UpdateAsync(horario);
    }


    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }
}