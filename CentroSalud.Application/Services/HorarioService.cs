using CentroSalud.Application.DTOs.Horario;
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

    // GET ALL
    public async Task<List<HorarioDto>> GetAllAsync()
    {
        var horarios = await _repo.GetAllAsync();

        return horarios.Select(h => new HorarioDto
        {
        Id = h.Id,
        MedicoId = h.MedicoId,
        MedicoNombre = h.Medico.Nombre,
        Dia = h.Dia,
        HoraInicio = h.HoraInicio,
        HoraFin = h.HoraFin
        }).ToList();
    }

    //  GET BY ID
    public async Task<HorarioDto?> GetByIdAsync(int id)
    {
        var h = await _repo.GetByIdAsync(id);
        if (h == null) return null;

        return new HorarioDto
        {
            Id = h.Id,
            MedicoId = h.MedicoId,
            MedicoNombre = h.Medico.Nombre,
            Dia = h.Dia,
            HoraInicio = h.HoraInicio,
            HoraFin = h.HoraFin
        };
    }

    // VALIDACIÓN DE SOLAPAMIENTO
    private void ValidarSolapamiento(List<Horario> existentes, Horario nuevo, int? idExcluir = null)
    {
        bool solapa = existentes.Any(h =>
            (idExcluir == null || h.Id != idExcluir) &&
            h.Dia == nuevo.Dia &&
            nuevo.HoraInicio < h.HoraFin &&
            nuevo.HoraFin > h.HoraInicio
        );

        if (solapa)
            throw new Exception("El horario se solapa con otro existente para este médico");
    }

    // CREATE
    public async Task CreateAsync(CreateHorarioDto dto)
    {
        if (dto.HoraInicio >= dto.HoraFin)
            throw new Exception("Hora inicio debe ser menor que hora fin");

        var horarios = await _repo.GetByMedicoIdAsync(dto.MedicoId);

        var nuevo = new Horario
        {
            MedicoId = dto.MedicoId,
            Dia = dto.Dia,
            HoraInicio = dto.HoraInicio,
            HoraFin = dto.HoraFin
        };

        // 🔥 VALIDAR SOLAPAMIENTO
        ValidarSolapamiento(horarios, nuevo);

        await _repo.AddAsync(nuevo);
    }

    // UPDATE
    public async Task UpdateAsync(int id, UpdateHorarioDto dto)
    {
        var horario = await _repo.GetByIdAsync(id);
        if (horario == null)
            throw new Exception("Horario no encontrado");

        if (dto.HoraInicio >= dto.HoraFin)
            throw new Exception("Hora inicio debe ser menor que hora fin");

        var horarios = await _repo.GetByMedicoIdAsync(horario.MedicoId);

        var actualizado = new Horario
        {
            Id = id,
            MedicoId = horario.MedicoId,
            Dia = dto.Dia,
            HoraInicio = dto.HoraInicio,
            HoraFin = dto.HoraFin
        };

        // 🔥 VALIDAR SOLAPAMIENTO (EXCLUYENDO EL MISMO)
        ValidarSolapamiento(horarios, actualizado, id);

        horario.Dia = dto.Dia;
        horario.HoraInicio = dto.HoraInicio;
        horario.HoraFin = dto.HoraFin;

        await _repo.UpdateAsync(horario);
    }

    // DELETE
    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }
}