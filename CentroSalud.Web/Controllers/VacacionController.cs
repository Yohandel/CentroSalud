using CentroSalud.Application.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VacacionController : ControllerBase
{
    private readonly IVacacionService _service;

    public VacacionController(IVacacionService service)
    {
        _service = service;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetALL();
        return Ok(result);
    }
    // 🔹 Obtener vacaciones de un empleado
    [HttpGet("GetAllByPerson")]
    public async Task<IActionResult> Get(int? empleadoId, int? medicoId)
    {
        var result = await _service.GetAsync(empleadoId, medicoId);
        return Ok(result);
    }

    // 🔹 Crear vacaciones
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateVacacionDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok("Vacación registrada correctamente");
    }

    // 🔹 Ver días disponibles
    [HttpGet("saldo")]
    public async Task<IActionResult> GetSaldo(int? empleadoId, int? medicoId)
    {
        var dias = await _service.GetDiasDisponibles(empleadoId, medicoId);
        return Ok(new { diasDisponibles = dias });
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateVacacionDto dto)
    {
        await _service.UpdateAsync(dto);
        return Ok("Vacación actualizada");
    }

    [HttpPost("Cancel")]
    public async Task<IActionResult> Cancel(CancelVacacionDto dto)
    {
        await _service.CancelAsync(dto);
        return Ok("Vacación cancelada");
    }
}