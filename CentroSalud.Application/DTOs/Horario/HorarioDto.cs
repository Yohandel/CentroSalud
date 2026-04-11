namespace CentroSalud.Application.DTOs.Medico;

public class HorarioDto
{
    public DayOfWeek Dia { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
}