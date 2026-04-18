using CentroSalud.Application.DTOs.Horario;

namespace CentroSalud.Application.DTOs.Medico;
public class MedicoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Tipo { get; set; } = "";

    public List<HorarioDto> Horarios { get; set; } = new();
}