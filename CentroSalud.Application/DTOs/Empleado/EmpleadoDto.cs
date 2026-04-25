using System;
using System.Collections.Generic;
using System.Text;

namespace CentroSalud.Application.DTOs
{
    public class EmpleadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Tipo { get; set; } = "";
        public string Direccion { get; set; } = "";
        public string Poblacion { get; set; } = "";
        public string Provincia { get; set; } = "";
        public string CodigoPostal { get; set; } = "";
        public string NIF { get; set; } = "";
        public string NumeroSeguridadSocial { get; set; } = "";
    }
}
