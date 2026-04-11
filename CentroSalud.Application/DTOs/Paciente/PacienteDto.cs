namespace CentroSalud.Application.DTOs.Paciente;

public class PacienteDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Telefono { get; set; } = "";
    public int MedicoId { get; set; }
}