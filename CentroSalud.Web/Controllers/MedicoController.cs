using Microsoft.AspNetCore.Mvc;
using CentroSalud.Application.DTOs.Medico;
using CentroSalud.Application.Interfaces;

namespace CentroSalud.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicoController : ControllerBase
{
    private readonly IMedicoService _medicoService;
    private readonly ISustitucionService _sustitucionService;

    public MedicoController(
        IMedicoService medicoService,
        ISustitucionService sustitucionService)
    {
        _medicoService = medicoService;
        _sustitucionService = sustitucionService;
    }

    // =========================
    // CRUD MÉDICOS
    // =========================

    // GET: api/medico
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var medicos = await _medicoService.GetAllAsync();
        return Ok(medicos);
    }

    // GET: api/medico/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var medico = await _medicoService.GetByIdAsync(id);

        if (medico == null)
            return NotFound();

        return Ok(medico);
    }

    // POST: api/medico
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMedicoDto dto)
    {
        await _medicoService.CreateAsync(dto);
        return Ok(new { message = "Médico creado correctamente" });
    }

    // PUT: api/medico/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateMedicoDto dto)
    {
        await _medicoService.UpdateAsync(id, dto);
        return Ok(new { message = "Médico actualizado correctamente" });
    }

    // DELETE: api/medico/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _medicoService.DeleteAsync(id);
        return Ok(new { message = "Médico eliminado correctamente" });
    }

    // =========================
    // HORARIOS
    // =========================

    // GET: api/medico/5/horarios
    [HttpGet("{id}/horarios")]
    public async Task<IActionResult> GetHorarios(int id)
    {
        var medico = await _medicoService.GetByIdAsync(id);

        if (medico == null)
            return NotFound();

        return Ok(medico.Horarios);
    }

    // =========================
    // SUSTITUCIONES
    // =========================

    // POST: api/medico/sustitucion
    [HttpPost("sustitucion")]
    public async Task<IActionResult> AsignarSustitucion(
        int medicoId,
        int reemplazadoId)
    {
        await _sustitucionService.AsignarAsync(medicoId, reemplazadoId);

        return Ok(new { message = "Sustitución asignada correctamente" });
    }

    // PUT: api/medico/sustitucion/5/finalizar
    [HttpPut("sustitucion/{id}/finalizar")]
    public async Task<IActionResult> FinalizarSustitucion(int id)
    {
        await _sustitucionService.FinalizarAsync(id);

        return Ok(new { message = "Sustitución finalizada correctamente" });
    }
}