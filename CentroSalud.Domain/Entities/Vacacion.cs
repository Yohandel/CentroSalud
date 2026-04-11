using CentroSalud.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentroSalud.Domain.Entities
{
    public class Vacacion : BaseEntity
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        // Puede pertenecer a médico o empleado
        public int? MedicoId { get; set; }
        public int? EmpleadoId { get; set; }
    }
}
