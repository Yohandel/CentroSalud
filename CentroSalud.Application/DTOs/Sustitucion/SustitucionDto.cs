namespace CentroSalud.Application.DTOs.Medico;

public class SustitucionDto
{
    public int MedicoId { get; set; }
    public string MedicoNombre { get; set; } = "";
    public int MedicoReemplazadoId { get; set; }
    public string MedicoReemplazadoNombre { get; set; } = "";

    public DateTime FechaAlta { get; set; }
    public DateTime? FechaBaja { get; set; }
}