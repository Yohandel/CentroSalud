using CentroSalud.Application.DTOs.Horario;

namespace CentroSalud.Application.DTOs.Medico;
public class MedicoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Tipo { get; set; } = "";
    public string Direccion { get; set; } = "";
    public string Poblacion { get; set; } = "";
    public string Provincia { get; set; } = ""; 
    public string CodigoPostal { get; set; } = "";
    public string NIF { get; set; } = "";
    public string NumeroSeguridadSocial { get; set; } = "";
    public string NumeroColegiado { get; set; } = "";

    public List<HorarioDto> Horarios { get; set; } = new();
    public List<SustitucionDto> Sustituciones { get; set; } = new();
}