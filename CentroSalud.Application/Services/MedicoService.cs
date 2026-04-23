using CentroSalud.Application.DTOs.Horario;
using CentroSalud.Application.DTOs.Medico;
using CentroSalud.Application.Interfaces;
using CentroSalud.Domain.Entities;
using CentroSalud.Domain.Interfaces;

public class MedicoService : IMedicoService
{
    private readonly IMedicoRepository _repo;

    public MedicoService(IMedicoRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<MedicoDto>> GetAllAsync()
    {
        var medicos = await _repo.GetAllAsync();

        return medicos.Select(m => new MedicoDto
        {


            Id = m.Id,
            Nombre = m.Nombre,
            Telefono = m.Telefono,
            Tipo = m.Tipo.ToString(),
              
        }).ToList();

    }

    public async Task<MedicoDto?> GetByIdAsync(int id)
    {
        var m = await _repo.GetByIdAsync(id);
        if (m == null) return null;

        return new MedicoDto
        {
            Id = m.Id,
            Nombre = m.Nombre,
            Telefono = m.Telefono,
            Tipo = m.Tipo.ToString(),
             Horarios = m.Horarios.Select(h => new HorarioDto
             {

                 Id = h.Id,
                 Dia = h.Dia.ToString(),
                 HoraInicio = h.HoraInicio.ToString(),
                 HoraFin = h.HoraFin.ToString()


             }).ToList(),
                Sustituciones = m.SustitucionesComoSustituto.Select(s => new SustitucionDto
                {
                    MedicoId = s.Id,
                    MedicoReemplazadoId = s.MedicoReemplazadoId,
                    FechaAlta = s.FechaInicio,
                    FechaBaja = s.FechaFin
                }).ToList()
        };
    }

    public async Task CreateAsync(CreateMedicoDto dto)
    {
        var medico = new Medico
        {
            Nombre = dto.Nombre,
            Direccion = dto.Direccion,
            Telefono = dto.Telefono,
            Poblacion = dto.Poblacion,
            Provincia = dto.Provincia,
            CodigoPostal = dto.CodigoPostal,
            NIF = dto.NIF,
            NumeroSeguridadSocial = dto.NumeroSeguridadSocial,
            NumeroColegiado = dto.NumeroColegiado,
            Tipo = (CentroSalud.Domain.Enums.TipoMedico)dto.Tipo,

        Horarios = dto.Horarios.Select(h =>
        {
            if (h.HoraInicio >= h.HoraFin)
                throw new ArgumentException("HoraInicio debe ser menor que HoraFin");

            return new Horario
            {
                Dia = h.Dia,
                HoraInicio = h.HoraInicio,
                HoraFin = h.HoraFin
            };
        }).ToList()

        };

        await _repo.AddAsync(medico);
    }

    public async Task UpdateAsync(int id, UpdateMedicoDto dto)
    {
        var medico = await _repo.GetByIdAsync(id);
        if (medico == null) throw new Exception("Médico no encontrado");

        medico.Nombre = dto.Nombre;
        medico.Direccion = dto.Direccion;
        medico.Telefono = dto.Telefono;

        await _repo.UpdateAsync(medico);
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }

}