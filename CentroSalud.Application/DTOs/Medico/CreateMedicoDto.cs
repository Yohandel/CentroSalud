namespace CentroSalud.Application.DTOs.Medico;

public class CreateMedicoDto
{
    public string Nombre { get; set; } = "";
    public string Direccion { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Poblacion { get; set; } = "";
    public string Provincia { get; set; } = "";
    public string CodigoPostal { get; set; } = "";
    public string NIF { get; set; } = "";
    public string NumeroSeguridadSocial { get; set; } = "";
    public string NumeroColegiado { get; set; } = "";
    public int Tipo { get; set; }
}