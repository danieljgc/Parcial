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
    }
}
