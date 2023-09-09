using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace ParcialDaniel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class empleadoController : ControllerBase
    {
        public readonly iEmpleadoRepository _empleadoRepository;
        public empleadoController(iEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getEmpleado()
        {
            return Ok(await _empleadoRepository.getEmpleados());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getEmpleadosById(int id)
        {
            return Ok(await _empleadoRepository.getEmpleadoById(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmpleado([FromBody] empleado empleado)
        {
            if(empleado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool created = await _empleadoRepository.insertEmpleado(empleado);
            return Ok(created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmpleado([FromBody] empleado empleado)
        {
            if (empleado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool update = await _empleadoRepository.updateEmpleado(empleado);
            return Ok(update);
        }
    }
}
