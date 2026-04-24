using CentroSalud.Application.DTOs.Horario;
using CentroSalud.Application.Interfaces;
using CentroSalud.Domain.Entities;

public class HorarioService : IHorarioService
{
    // Base de datos falsa en memoria
    private static List<Horario> _fakeDb = new();

    //  GET ALL
    public async Task<List<HorarioDto>> GetAllAsync()
    {
        return _fakeDb.Select(h => new HorarioDto
        {
            Id = h.Id,
            Dia = h.Dia.ToString(),
            HoraInicio = h.HoraInicio.ToString(@"hh\:mm"),
            HoraFin = h.HoraFin.ToString(@"hh\:mm"),
        }).ToList();
    }

    // GET BY ID
    public async Task<HorarioDto?> GetByIdAsync(int id)
    {
        var h = _fakeDb.FirstOrDefault(x => x.Id == id);
        if (h == null) return null;

        return new HorarioDto
        {
            Id = h.Id,
            Dia = h.Dia.ToString(),
            HoraInicio = h.HoraInicio.ToString(@"hh\:mm"),
            HoraFin = h.HoraFin.ToString(@"hh\:mm")
        };
    }

    // CREATE
    public async Task CreateAsync(CreateHorarioDto dto)
    {
        if (dto.HoraInicio >= dto.HoraFin)
            throw new Exception("Hora inicio debe ser menor que hora fin");

        var horario = new Horario
        {
            Id = _fakeDb.Count + 1,
            Dia = dto.Dia,
            HoraInicio = dto.HoraInicio,
            HoraFin = dto.HoraFin,
            MedicoId = dto.MedicoId
        };

        _fakeDb.Add(horario);
    }

    // UPDATE
    public async Task UpdateAsync(int id, UpdateHorarioDto dto)
    {
        var horario = _fakeDb.FirstOrDefault(x => x.Id == id);
        if (horario == null) throw new Exception("Horario no encontrado");

        if (dto.HoraInicio >= dto.HoraFin)
            throw new Exception("Hora inicio debe ser menor que hora fin");

        horario.Dia = dto.Dia;
        horario.HoraInicio = dto.HoraInicio;
        horario.HoraFin = dto.HoraFin;
    }

    //  DELETE
    public async Task DeleteAsync(int id)
    {
        var horario = _fakeDb.FirstOrDefault(x => x.Id == id);
        if (horario != null)
            _fakeDb.Remove(horario);
    }
}