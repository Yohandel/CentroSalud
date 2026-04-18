using CentroSalud.Domain.Common;


namespace CentroSalud.Domain.Entities
{
    public class Sustitucion : BaseEntity
    {
        public int MedicoSustitutoId { get; set; }
        public Medico MedicoSustituto { get; set; } = null!;

        public int MedicoReemplazadoId { get; set; }
        public Medico MedicoReemplazado { get; set; } = null!;

        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
