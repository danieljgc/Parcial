using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace ParcialDaniel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ventasController : ControllerBase
    {
        public readonly iVentasRepository _ventasRepository;
        public ventasController(iVentasRepository ventasRepository)
        {
            _ventasRepository = ventasRepository;
        }
        [HttpPost]
        public async Task <IActionResult> insertVentas([FromBody] ventas ventas)
        {
            if(ventas == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool created = await _ventasRepository.insertVentas(ventas);
            return Ok(created);
        }
    }
}
