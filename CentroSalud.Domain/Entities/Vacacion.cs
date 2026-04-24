using CentroSalud.Domain.Common;

namespace CentroSalud.Domain.Entities
{
    public class Vacacion : BaseEntity
    {
      public int? EmpleadoId { get; set; }
    public Empleado? Empleado { get; set; }

    public int? MedicoId { get; set; }
    public Medico? Medico { get; set; }

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public int DiasTomados { get; set; }

    public bool Activa { get; set; }
    }
}