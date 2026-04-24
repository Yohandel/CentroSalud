using CentroSalud.Domain.Common;

public abstract class Persona : BaseEntity
{
    public string Nombre { get; set; } = "";
    public string Direccion { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Poblacion { get; set; } = "";
    public string Provincia { get; set; } = "";
    public string CodigoPostal { get; set; } = "";
    public string NIF { get; set; } = "";
    public string NumeroSeguridadSocial { get; set; } = "";
}