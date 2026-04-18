using CentroSalud.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentroSalud.Domain.Entities
{
    public class Paciente : BaseEntity
    {
        public string Nombre { get; set; } = "";
        public string Direccion { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string CodigoPostal { get; set; } = "";
        public string NIF { get; set; } = "";
        public string NumeroSeguridadSocial { get; set; } = "";

        public int MedicoId { get; set; }
        public Medico Medico { get; set; } = null!;
    }
}
