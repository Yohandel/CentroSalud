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

    public async Task AsignarAsync(int medicoId, int reemplazadoId)
    {
        if (medicoId == reemplazadoId)
            throw new Exception("No puede sustituirse a sí mismo");

        var sustitucion = new Sustitucion
        {
            MedicoSustitutoId = medicoId,
            MedicoReemplazadoId = reemplazadoId,
            FechaInicio = DateTime.Now
        };

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