using CentroSalud.Domain.Enums;
namespace CentroSalud.Domain.Entities
{
    public class Medico : Persona
    {

        public string NumeroColegiado { get; set; } = "";

        public TipoMedico Tipo { get; set; }

        // Relaciones
        public List<Horario> Horarios { get; set; } = new();
        public List<Sustitucion> SustitucionesComoSustituto { get; set; } = new();
        public List<Sustitucion> SustitucionesComoReemplazado { get; set; } = new();
        public List<Vacacion> Vacaciones { get; set; } = new();
    }
}
