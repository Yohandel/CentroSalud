using CentroSalud.Application.DTOs.Medico;
using CentroSalud.Application.Interfaces;
using CentroSalud.Domain.Entities;
using CentroSalud.Domain.Interfaces;

public class SustitucionService : ISustitucionService
{
    private readonly ISustitucionRepository _repo;

    public SustitucionService(ISustitucionRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<SustitucionDto>> GetSustitucionesVigentesAsync() 
    {
        var sustituciones = await _repo.GetAllAsync();
        return sustituciones.Select(s => new SustitucionDto
        {
            MedicoId = s.MedicoSustitutoId,
            MedicoReemplazadoId = s.MedicoReemplazadoId,
            FechaAlta = s.FechaInicio,
            FechaBaja = s.FechaFin
        }).ToList();
    }

    public async Task AsignarAsync(SustitucionDto dto)
    {
        if (dto.MedicoId == dto.MedicoReemplazadoId)
            throw new Exception("No puede sustituirse a sí mismo");

        var sustitucion = new Sustitucion
        {
            MedicoSustitutoId = dto.MedicoId,
            MedicoReemplazadoId = dto.MedicoReemplazadoId,
            FechaInicio = dto.FechaAlta,
            FechaFin = dto.FechaBaja
        };
        if (dto.FechaBaja <= dto.FechaAlta) { throw new Exception("La fecha de fin debe ser posterior a la fecha de inicio"); }

        await _repo.AddAsync(sustitucion);
    }

    public async Task FinalizarAsync(int sustitucionId)
    {
        var s = await _repo.GetByIdAsync(sustitucionId);
        if (s == null) throw new Exception("No encontrada");

        s.FechaFin = DateTime.Now;

        await _repo.UpdateAsync(s);
    }
}