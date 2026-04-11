using CentroSalud.Domain.Common;
using CentroSalud.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentroSalud.Domain.Entities
{
    public class Empleado : BaseEntity
    {
        public string Nombre { get; set; } = "";
        public string Direccion { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Poblacion { get; set; } = "";
        public string Provincia { get; set; } = "";
        public string CodigoPostal { get; set; } = "";
        public string NIF { get; set; } = "";
        public string NumeroSeguridadSocial { get; set; } = "";

        public TipoEmpleado Tipo { get; set; }

        public List<Vacacion> Vacaciones { get; set; } = new();
    }
}
