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

    public class VehiculoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ClienteController> _logger;
        private readonly IVehiculoRepository _VehiculoRepos;

        public VehiculoController(ILogger<ClienteController> logger, IVehiculoRepository repos, IMapper mapper)
        {
            _VehiculoRepos = repos;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet(Name = "ListaVehiculos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<VehiculoDTO>>> GetVehiculos()
        {
            _logger.LogInformation("Obteniendo lista de vehiculos");
            var vehiculos = await _VehiculoRepos.GetAll();
            return Ok(_mapper.Map<IEnumerable<Vehiculo>>(vehiculos));
        }
        [HttpGet("{id:int}", Name = "GetVehiculo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<VehiculoDTO>> GetVehiculo(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Error al traer Vehiculo con Id {id}");
                return BadRequest();
            }
            var vehiculo = await _VehiculoRepos.Get(s => s.VehiculoId == id);

            if (vehiculo == null)
            {
                _logger.LogError($"Error al traer Vehiculo con Id {id}");
                return NotFound();
            }

            return Ok(_mapper.Map<Vehiculo>(vehiculo));
        }

        [HttpPost(Name = "AgregarVehiculo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehiculoDTO>> PostVehiculo([FromBody] VehiculoCreateDTO vehiculo)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("No se puedo crear el vehiculo");
            }
            if (vehiculo == null)
            {
                _logger.LogError("No ingreso los datos requeridos");
                ModelState.AddModelError("Datos no validos", "Los datos que se ingresaron como parametros no son validos");
                return BadRequest(ModelState);
            }

            Vehiculo modelo = _mapper.Map<Vehiculo>(vehiculo);
            await _VehiculoRepos.Create(modelo);
            _logger.LogInformation("Se agrego el vehiculo con exito!");
            return CreatedAtRoute("GetVehiculo", new { id = modelo.VehiculoId }, modelo);
        }

        [HttpDelete(Name = "BorrarVehiculo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteVehiculo(int id)
        {
            if (id == 0)
                return BadRequest();
            var vehiculo = await _VehiculoRepos.Get(s => s.VehiculoId == id);
            if (vehiculo == null)
            {
                ModelState.AddModelError("Vehiulo no encontrado", "El Id ingresado no corresponde para ningun vehiculo");
                return NotFound(ModelState);
            }

            await _VehiculoRepos.Remove(vehiculo);
            return NoContent();
        }

        [HttpPut(Name = "ActualizarVehiculo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateVehiculo(int id, [FromBody] VehiculoUpdateDTO vehiculo)
        {
            if (id == 0)
                return BadRequest(id);
            if (vehiculo == null)
                return BadRequest(vehiculo);
            if (vehiculo.VehiculoId != id)
                return BadRequest();

            var modelo = _mapper.Map<Vehiculo>(vehiculo);
            await _VehiculoRepos.UpdateVehiculo(modelo);
            return NoContent();
        }
    }
}
