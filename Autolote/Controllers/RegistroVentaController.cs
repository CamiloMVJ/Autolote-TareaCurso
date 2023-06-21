using Autolote.Models;
using Autolote.Models.DTO;
using Autolote.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autolote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegistroVentaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<RegistroVentaController> _logger;
        private readonly IRegistroRepository _RegistroRepos;
        private readonly IClienteRepository _ClienteRepository;
        private readonly IVehiculoRepository _VehiculoRepository;

        public RegistroVentaController(ILogger<RegistroVentaController> logger, IRegistroRepository repos, IMapper mapper, IClienteRepository clienteRepository, IVehiculoRepository vehiculoRepository)
        {
            _RegistroRepos = repos;
            _logger = logger;
            _mapper = mapper;
            _ClienteRepository = clienteRepository;
            _VehiculoRepository = vehiculoRepository;
        }

        [HttpGet(Name = "ListaRegistros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<RegistroVentaDTO>>> GetAllRegistros()
        {
            _logger.LogInformation("Solicitando lista de registros");
            var registros = await _RegistroRepos.GetAll();
            return Ok(_mapper.Map<IEnumerable<RegistroVentaDTO>>(registros));
        }

        [HttpGet("{id:int}", Name = "GetRegistro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<RegistroVentaDTO>> GetRegistro(int id)
        {
            var registro = await _RegistroRepos.Get(s => s.RegistroId == id);
            return Ok(_mapper.Map<RegistroVenta>(registro));
        }

        [HttpPost(Name = "AgregarRegistro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RegistroVentaDTO>> PostRegistro([FromBody] RegistroVentaCreateDTO registro)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("No se pudo crear el registro");
                return BadRequest();
            }
            if (registro.VerificarDatos())
                return BadRequest();
            if (registro == null)
                return BadRequest(registro);

            Vehiculo coche = await _VehiculoRepository.Get(s => s.VehiculoId == registro.VehiculoId);
            Cliente cliente = await _ClienteRepository.Get(s => s.CedulaId == registro.CedulaId);
            if (coche == null || cliente == null)
                return BadRequest();

            RegistroVenta modelo = new RegistroVenta(cliente, coche, registro.Capitalizacion, registro.AñosDelContrato, registro.TipoDePago);
            modelo.CalcularCouta(); 
            await _RegistroRepos.Create(modelo);

            var lista = await _RegistroRepos.GetAll();
            _logger.LogInformation("Registro creado con exito");
            return Ok(lista.Last());
        }

        [HttpDelete(Name = "BorarRegistro")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteRegistro(int id)
        {
            if (id == 0)
                return BadRequest();
            var registro = await _RegistroRepos.Get(s => s.RegistroId == id);
            if (registro == null)
            {
                ModelState.AddModelError("Registro no encontrado", "El id ingresado no corresponde para ningun registro");
                return NotFound(ModelState);
            }

            await _RegistroRepos.Remove(registro);
            return NoContent();
        }

        [HttpPut(Name = "ActualizarRegistro")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateRegistro(int id, [FromBody] RegistroVentaUpdateDTO registro)
        {
            if (id == 0)
                return BadRequest(id);
            if (registro == null)
                return BadRequest(registro);
            if (registro.RegistroId != id)
                return BadRequest();

            Vehiculo coche = await _VehiculoRepository.Get(s => s.VehiculoId == registro.VehiculoId);
            Cliente cliente = await _ClienteRepository.Get(s => s.CedulaId == registro.CedulaId);
            if (coche == null || cliente == null)
                return BadRequest();

            RegistroVenta modelo = new RegistroVenta(cliente, coche, registro.Capitalizacion, registro.AñosDelContrato, registro.TipoDePago);
            if (modelo.VerificarDatos())
                return BadRequest();
            modelo.CalcularCouta();
            modelo.RegistroId = id;

            await _RegistroRepos.UpdateRegistro(modelo);
            return NoContent();
        }
    }
}
