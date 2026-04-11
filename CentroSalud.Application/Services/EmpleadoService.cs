using CentroSalud.Application.DTOs;
using CentroSalud.Application.DTOs.Empleado;
using CentroSalud.Domain.Entities;
using CentroSalud.Domain.Interfaces;

public class EmpleadoService : IEmpleadoService
{
    private readonly IEmpleadoRepository _repo;

    public EmpleadoService(IEmpleadoRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<EmpleadoDto>> GetAllAsync()
    {
        var empleados = await _repo.GetAllAsync();

        return empleados.Select(e => new EmpleadoDto
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Telefono = e.Telefono,
            Tipo = e.Tipo.ToString()
        }).ToList();
    }

    public async Task<EmpleadoDto?> GetByIdAsync(int id)
    {
        var e = await _repo.GetByIdAsync(id);
        if (e == null) return null;

        return new EmpleadoDto
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Telefono = e.Telefono,
            Tipo = e.Tipo.ToString()
        };
    }

    public async Task CreateAsync(CreateEmpleadoDto dto)
    {
        var empleado = new Empleado
        {
            Nombre = dto.Nombre,
            Direccion = dto.Direccion,
            Telefono = dto.Telefono,
            Tipo = (CentroSalud.Domain.Enums.TipoEmpleado)dto.Tipo
        };

        await _repo.AddAsync(empleado);
    }

    public async Task UpdateAsync(int id, UpdateEmpleadoDto dto)
    {
        var empleado = await _repo.GetByIdAsync(id);
        if (empleado == null) throw new Exception("Empleado no encontrado");

        empleado.Nombre = dto.Nombre;
        empleado.Direccion = dto.Direccion;
        empleado.Telefono = dto.Telefono;

        await _repo.UpdateAsync(empleado);
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }

    Task<IEnumerable<EmpleadoDto>> IEmpleadoService.GetAllAsync()
    {
        throw new NotImplementedException();
    }
}