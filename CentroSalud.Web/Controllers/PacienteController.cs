using CentroSalud.Application.DTOs;
using CentroSalud.Application.DTOs.Paciente;
using CentroSalud.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CentroSalud.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _service;

        public PacienteController(IPacienteService service)
        {
            _service = service;
        }

        // GET: api/<PacienteController>
        [HttpGet("GetAll")]
        public async Task<IEnumerable<PacienteDto>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<PacienteController>/5
        [HttpGet("GetById/{id}")] 
        public async Task<PacienteDto?> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        // POST api/<PacienteController>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreatePacienteDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(new { message = "Paciente creado correctamente" });
        }

        // PUT api/<PacienteController>/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePacienteDto dto   )
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        // DELETE api/<PacienteController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
