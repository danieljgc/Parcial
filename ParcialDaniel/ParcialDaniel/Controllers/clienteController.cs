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

        [HttpGet]
        public async Task<IActionResult> getClientes()
        {
            return Ok(await _clienteRepository.getClientes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getClientebyId(int id)
        {
            return Ok(await _clienteRepository.getClienteById(id));
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

        [HttpPut]
        public async Task <IActionResult> UpdateCliente([FromBody] cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            
            bool update = await _clienteRepository.updateCliente(cliente);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult>DeleteClienteById(int id)
        {
            return Ok(await _clienteRepository.deleteCliente(id));
        }
    }
}
