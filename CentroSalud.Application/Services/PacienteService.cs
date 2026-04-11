using CentroSalud.Application.DTOs.Paciente;
using CentroSalud.Domain.Entities;
using CentroSalud.Domain.Interfaces;

public class PacienteService : IPacienteService
{
    private readonly IPacienteRepository _repo;

    public PacienteService(IPacienteRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<PacienteDto>> GetAllAsync()
    {
        var pacientes = await _repo.GetAllAsync();

        return pacientes.Select(p => new PacienteDto
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Telefono = p.Telefono,
            MedicoId = p.MedicoId
        }).ToList();
    }

    public async Task<PacienteDto?> GetByIdAsync(int id)
    {
        var p = await _repo.GetByIdAsync(id);
        if (p == null) return null;

        return new PacienteDto
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Telefono = p.Telefono,
            MedicoId = p.MedicoId
        };
    }

    public async Task CreateAsync(CreatePacienteDto dto)
    {
        var paciente = new Paciente
        {
            Nombre = dto.Nombre,
            Telefono = dto.Telefono,
            MedicoId = dto.MedicoId
        };

        await _repo.AddAsync(paciente);
    }

    public async Task UpdateAsync(int id, UpdatePacienteDto dto)
    {
        var paciente = await _repo.GetByIdAsync(id);
        if (paciente == null) throw new Exception("Paciente no encontrado");

        paciente.Nombre = dto.Nombre;
        paciente.Telefono = dto.Telefono;

        await _repo.UpdateAsync(paciente);
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }
}