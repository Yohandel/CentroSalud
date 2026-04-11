using CentroSalud.Domain.Common;
using CentroSalud.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentroSalud.Domain.Entities
{
    public class Medico : BaseEntity
    {
        public string Nombre { get; set; } = "";
        public string Direccion { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Poblacion { get; set; } = "";
        public string Provincia { get; set; } = "";
        public string CodigoPostal { get; set; } = "";
        public string NIF { get; set; } = "";
        public string NumeroSeguridadSocial { get; set; } = "";

        public string NumeroColegiado { get; set; } = "";

        public TipoMedico Tipo { get; set; }

        // Relaciones
        public List<Horario> Horarios { get; set; } = new();
        public List<Sustitucion> Sustituciones { get; set; } = new();
        public List<Vacacion> Vacaciones { get; set; } = new();
    }
}
