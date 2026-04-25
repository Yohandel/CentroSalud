namespace CentroSalud.Application.DTOs.Horario;

public class HorarioDto
{
    public int Id { get; set; }

    public int MedicoId { get; set; }
    public string MedicoNombre { get; set; } = "";

    public DayOfWeek Dia { get; set; }

    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }

    
}

public class CreateHorarioDto
{
    public DayOfWeek Dia { get; set; }

    public int MedicoId { get; set; }

    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
}

public class UpdateHorarioDto : CreateHorarioDto
{
}