namespace CentroSalud.Application.DTOs.Medico;

public class SustitucionDto
{
    public int MedicoId { get; set; }
    public int MedicoReemplazadoId { get; set; }

    public DateTime FechaAlta { get; set; }
    public DateTime? FechaBaja { get; set; }
}