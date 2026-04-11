using CentroSalud.Application.DTOs;
using CentroSalud.Application.DTOs.Empleado;
using Microsoft.AspNetCore.Mvc;

namespace CentroSalud.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadoController : ControllerBase
{
    private readonly IEmpleadoService _service;

    public EmpleadoController(IEmpleadoService service)
    {
        _service = service;
    }

    // GET: api/empleado
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var empleados = await _service.GetAllAsync();
        return Ok(empleados);
    }

    // GET: api/empleado/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var empleado = await _service.GetByIdAsync(id);

        if (empleado == null)
            return NotFound();

        return Ok(empleado);
    }

    // POST: api/empleado
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmpleadoDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok(new { message = "Empleado creado correctamente" });
    }

    // PUT: api/empleado/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateEmpleadoDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return Ok(new { message = "Empleado actualizado correctamente" });
    }

    // DELETE: api/empleado/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok(new { message = "Empleado eliminado correctamente" });
    }
}