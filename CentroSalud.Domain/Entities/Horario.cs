using CentroSalud.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentroSalud.Domain.Entities
{
    public class Horario : BaseEntity
    {
        public int MedicoId { get; set; }

        public DayOfWeek Dia { get; set; }

        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
