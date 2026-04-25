namespace CentroSalud.Application.DTOs.Shared;

public class VacacionDto
{
    public int Id { get; set; }
    public int? EmpleadoId { get; set; }
     public string? NombreEmpleado { get; set; } // Agregado
    public int? MedicoId { get; set; }
     public string? NombreMedico { get; set; } // Agregado
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int DiasTomados { get; set; }
    public int DiasRestantes { get; set; }
    public bool Activa { get; set; }
}

public class CreateVacacionDto
{
    public int? EmpleadoId { get; set; }
    public int? MedicoId { get; set; }

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
}

public class UpdateVacacionDto
{
    public int Id { get; set; }

    public int? EmpleadoId { get; set; }
    public int? MedicoId { get; set; }

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
}

public class CancelVacacionDto
{
    public int VacacionId { get; set; }

    public DateTime FechaCancelacion { get; set; } // hasta donde llegó
}