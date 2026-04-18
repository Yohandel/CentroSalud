namespace CentroSalud.Application.Interfaces;

public interface ISustitucionService
{
    Task AsignarAsync(int medicoId, int reemplazadoId);

    Task FinalizarAsync(int sustitucionId);
}