using Autolote.Data;
using Autolote.Models;
using Autolote.Models.DTO;
using Autolote.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Autolote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteRepository _ClienteRepos;

        public ClienteController(ILogger<ClienteController> logger, IClienteRepository repos, IMapper mapper)
        {
            _ClienteRepos = repos;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "ListaClientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetAllClientes()
        {
            _logger.LogInformation("Solicitando lista de clientes");
            var clientes = await _ClienteRepos.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClienteDTO>>(clientes));
        }

        [HttpGet("{cedula}", Name = "GetCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ClienteDTO>> GetCliente(string cedula)
        {
            var cliente = await _ClienteRepos.Get(s => s.CedulaId == cedula);
            return Ok(_mapper.Map<Cliente>(cliente));
        }

        [HttpPost(Name = "AgregarCliente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ClienteDTO>> PostCliente([FromBody] ClienteCreateDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("No se pudo crear el cliente");
                return BadRequest();
            }

            if (await _ClienteRepos.Get(s => s.CedulaId == cliente.CedulaId) != null)
            {
                ModelState.AddModelError("Nombre Existe", "!La cedula ingresada ya existe en nuesta base de datos¡");
                return BadRequest(ModelState);
            }
            if (cliente == null)
                return BadRequest(cliente);

            Cliente modelo = _mapper.Map<Cliente>(cliente);
            await _ClienteRepos.Create(modelo);

            _logger.LogInformation("Cliente creado con exito");
            return CreatedAtRoute("GetCliente", new { cedula = modelo.CedulaId }, modelo);
        }

        [HttpDelete(Name = "BorrarCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCliente(string id)
        {
            if (id == null || id == "")
                return BadRequest();
            var cliente = await _ClienteRepos.Get(s => s.CedulaId == id);
            if (cliente == null)
            {
                ModelState.AddModelError("Cliente no encontrado", "El id ingresado no corresponde para ningun cliente");
                return NotFound(ModelState);
            }

            await _ClienteRepos.Remove(cliente);
            return NoContent();
        }

        [HttpPut(Name = "ActualizarCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateCliente(string id, [FromBody] ClienteUpdateDTO cliente)
        {
            if (id == null || id == "")
                return BadRequest(id);
            if (cliente == null)
                return BadRequest(cliente);
            if (cliente.CedulaId != id)
                return BadRequest();

            var modelo = _mapper.Map<Cliente>(cliente);
            await _ClienteRepos.UpdateCliente(modelo);
            return NoContent();
        }
    }
}
