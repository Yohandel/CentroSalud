using CentroSalud.Application.DTOs.Shared;
using CentroSalud.Domain.Entities;
using CentroSalud.Domain.Interfaces;

public class VacacionService : IVacacionService
{
    private readonly IVacacionRepository _repo;

    public VacacionService(IVacacionRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<VacacionDto>> GetALL()
    {
        var vacacions = await _repo.GetALL();

        return vacacions.Select(v => new VacacionDto
        {
            Id = v.Id,
            EmpleadoId = v.EmpleadoId,
            NombreEmpleado = v.Empleado != null ? v.Empleado.Nombre : null,
            MedicoId = v.MedicoId,
            NombreMedico = v.Medico != null ? v.Medico.Nombre : null,
            FechaInicio = v.FechaInicio,
            FechaFin = v.FechaFin,
            DiasTomados = v.DiasTomados,
            DiasRestantes = 15 - v.DiasTomados, // Cálculo simple, se puede mejorar
            Activa = v.Activa
        }).ToList();
    }


    // Obtención de vacaciones, sumando los días tomados para calcular los restantes
    public async Task<List<VacacionDto>> GetAsync(int? empleadoId, int? medicoId)
    {
        List<Vacacion> vacaciones;

        if (empleadoId != null)
            vacaciones = await _repo.GetByEmpleadoIdAsync(empleadoId.Value);
        else if (medicoId != null)
            vacaciones = await _repo.GetByMedicoIdAsync(medicoId.Value);
        else
            throw new Exception("Debe enviar EmpleadoId o MedicoId");
        int usados = vacaciones.Sum(v => v.DiasTomados);
        int restantes = 15 - usados;

        return vacaciones.Select(v => new VacacionDto
        {
            Id = v.Id,
            FechaInicio = v.FechaInicio,
            FechaFin = v.FechaFin,
            DiasTomados = v.DiasTomados,
            DiasRestantes = restantes
        }).ToList();
    }


    //Creación de vacaciones, validando que no se excedan los 15 días disponibles y que las fechas sean correctas
    public async Task CreateAsync(CreateVacacionDto dto)
    {
        if (dto.FechaInicio > dto.FechaFin)
            throw new Exception("Fecha inválida");

        if (dto.EmpleadoId == null && dto.MedicoId == null)
            throw new Exception("Debe especificar Empleado o Medico");

        if (dto.EmpleadoId != null && dto.MedicoId != null)
            throw new Exception("Solo uno puede tener valor");

        int dias = (dto.FechaFin - dto.FechaInicio).Days + 1;

        List<Vacacion> existentes;

        if (dto.EmpleadoId != null)
            existentes = await _repo.GetByEmpleadoIdAsync(dto.EmpleadoId.Value);
        else
            existentes = await _repo.GetByMedicoIdAsync(dto.MedicoId.Value);

        // 🔥 VALIDAR SOLAPAMIENTO
        ValidarSolapamiento(existentes, dto.FechaInicio, dto.FechaFin);

        int usados = existentes.Sum(v => v.DiasTomados);

        if (usados + dias > 15)
            throw new Exception("No tiene días disponibles");

        var vacacion = new Vacacion
        {
            EmpleadoId = dto.EmpleadoId,
            MedicoId = dto.MedicoId,
            FechaInicio = dto.FechaInicio,
            FechaFin = dto.FechaFin,
            DiasTomados = dias,
            Activa = true
        };

        await _repo.AddAsync(vacacion);
    }

    public async Task<int> GetDiasDisponibles(int? empleadoId, int? medicoId)
    {
        List<Vacacion> vacaciones;

        if (empleadoId != null)
            vacaciones = await _repo.GetByEmpleadoIdAsync(empleadoId.Value);
        else if (medicoId != null)
            vacaciones = await _repo.GetByMedicoIdAsync(medicoId.Value);
        else
            throw new Exception("Debe enviar EmpleadoId o MedicoId");

        int usados = vacaciones.Sum(v => v.DiasTomados);

        return 15 - usados;
    }

    public async Task UpdateAsync(UpdateVacacionDto dto)
    {
        var vacacion = await _repo.GetByIdAsync(dto.Id);

        if (vacacion == null)
            throw new Exception("Vacación no encontrada");

        if (dto.FechaInicio > dto.FechaFin)
            throw new Exception("Fechas inválidas");

        int dias = (dto.FechaFin - dto.FechaInicio).Days + 1;

        List<Vacacion> existentes;

        if (dto.EmpleadoId != null)
            existentes = await _repo.GetByEmpleadoIdAsync(dto.EmpleadoId.Value);
        else
            existentes = await _repo.GetByMedicoIdAsync(dto.MedicoId.Value);

        // 🔥 VALIDAR SOLAPAMIENTO (EXCLUYENDO LA MISMA)
        ValidarSolapamiento(existentes, dto.FechaInicio, dto.FechaFin, dto.Id);

        int usados = existentes.Where(v => v.Id != dto.Id).Sum(v => v.DiasTomados);

        if (usados + dias > 15)
            throw new Exception("No tiene días disponibles");

        vacacion.EmpleadoId = dto.EmpleadoId;
        vacacion.MedicoId = dto.MedicoId;
        vacacion.FechaInicio = dto.FechaInicio;
        vacacion.FechaFin = dto.FechaFin;
        vacacion.DiasTomados = dias;
        vacacion.Activa = true;

        await _repo.UpdateAsync(vacacion);
    }


    public async Task CancelAsync(CancelVacacionDto dto)
    {
        var vacacion = await _repo.GetByIdAsync(dto.VacacionId);

        if (vacacion == null)
            throw new Exception("Vacación no encontrada");

        if (!vacacion.Activa)
            throw new Exception("Ya está cancelada");

        if (dto.FechaCancelacion < vacacion.FechaInicio)
            throw new Exception("Fecha inválida");

        // 🔥 DIAS REALMENTE TOMADOS
        int diasTomados = (dto.FechaCancelacion - vacacion.FechaInicio).Days + 1;

        if (diasTomados >= vacacion.DiasTomados)
        {
            // Cancelación total
            vacacion.Activa = false;
        }
        else
        {
            // Cancelación parcial 🔥
            vacacion.FechaFin = dto.FechaCancelacion;
            vacacion.DiasTomados = diasTomados;
        }

        await _repo.UpdateAsync(vacacion);
    }

    private void ValidarSolapamiento(List<Vacacion> existentes, DateTime inicio, DateTime fin, int? idExcluir = null)
    {
        bool haySolapamiento = existentes.Any(v =>
            (idExcluir == null || v.Id != idExcluir) &&
            inicio <= v.FechaFin &&
            fin >= v.FechaInicio
        );

        if (haySolapamiento)
            throw new Exception("Las fechas se solapan con otra vacación existente");
    }


}