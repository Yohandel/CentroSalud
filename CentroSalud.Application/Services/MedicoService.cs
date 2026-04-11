using CentroSalud.Application.DTOs.Medico;
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
            Tipo = m.Tipo.ToString()
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
            Tipo = m.Tipo.ToString()
        };
    }

    public async Task CreateAsync(CreateMedicoDto dto)
    {
        var medico = new Medico
        {
            Nombre = dto.Nombre,
            Direccion = dto.Direccion,
            Telefono = dto.Telefono,
            Tipo = (CentroSalud.Domain.Enums.TipoMedico)dto.Tipo
        };

        await _repo.AddAsync(medico);
    }

    public async Task UpdateAsync(int id, UpdateMedicoDto dto)
    {
        var medico = await _repo.GetByIdAsync(id);
        if (medico == null) throw new Exception("Médico no encontrado");

        medico.Nombre = dto.Nombre;
        medico.Telefono = dto.Telefono;

        await _repo.UpdateAsync(medico);
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }
}