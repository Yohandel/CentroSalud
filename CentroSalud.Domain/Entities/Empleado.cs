using CentroSalud.Domain.Enums;

namespace CentroSalud.Domain.Entities
{
    public class Empleado : Persona
    {

        public TipoEmpleado Tipo { get; set; }

        public List<Vacacion> Vacaciones { get; set; } = new();
    }
}
