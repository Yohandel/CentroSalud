using CentroSalud.Application.DTOs;
using CentroSalud.Application.DTOs.Horario;
using CentroSalud.Application.DTOs.Medico;
using CentroSalud.Application.DTOs.Paciente;
using CentroSalud.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CentroSalud.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly IHorarioService _service;

        public HorarioController(IHorarioService service)
        {
            _service = service;
        }

        // GET: api/<HorarioController>
        [HttpGet]
        public async Task<IEnumerable<HorarioDto>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<HorarioController>/5
        [HttpGet("{id}")]
        public async Task<HorarioDto?> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        // POST api/<HorarioController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHorarioDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(new { message = "Horario creado correctamente" });
        }

        // PUT api/<HorarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateHorarioDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        // DELETE api/<HorarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
