using CentroSalud.Domain.Common;

namespace CentroSalud.Domain.Entities
{
    public class Horario : BaseEntity
    {
        public int MedicoId { get; set; }

        public Medico Medico { get; set; } = null!; // 🔥 IMPORTANTE

        public DayOfWeek Dia { get; set; }

        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}