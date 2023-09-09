using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace ParcialDaniel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clienteController : ControllerBase
    {
        public readonly iClienteRepository _clienteRepository;
        public clienteController(iClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        [HttpPost]
        public async Task<IActionResult> InsertCliente([FromBody] cliente cliente)
        {
            if(cliente == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool created = await _clienteRepository.insertCliente(cliente);
            return Ok(created);
        }
    }
}
