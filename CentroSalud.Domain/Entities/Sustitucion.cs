using CentroSalud.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentroSalud.Domain.Entities
{
    public class Sustitucion : BaseEntity
    {
        public int MedicoId { get; set; }

        public int MedicoReemplazadoId { get; set; }

        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
