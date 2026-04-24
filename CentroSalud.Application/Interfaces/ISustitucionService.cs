using CentroSalud.Application.DTOs.Medico;

namespace CentroSalud.Application.Interfaces;

public interface ISustitucionService
{
    Task AsignarAsync(SustitucionDto dto);

    Task FinalizarAsync(int sustitucionId);

    Task<IEnumerable<SustitucionDto>> GetSustitucionesVigentesAsync();    
}