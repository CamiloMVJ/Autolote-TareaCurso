using Autolote.Controllers;
using Autolote.Models.DTO;
using Autolote.Models;
using Autolote.Repository.IRepository;
using AutoloteAPI.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AutoloteAPI.Models;
using AutoloteAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace AutoloteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ClienteController> _logger;
        private readonly IUserRepository _userRepos;

        public UserController(IMapper mapper, ILogger<ClienteController> logger, IUserRepository repository)
        {
            _mapper = mapper;
            _logger = logger;
            _userRepos = repository;
        }

        [HttpGet("{username}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDTO>> GetUser(string username)
        {
            if (username == "" || username == null)
            {
                _logger.LogError($"Error al traer User con Id {username}");
                return BadRequest();
            }
            var user = await _userRepos.Get(s => s.Username == username);

            if (user == null)
            {
                _logger.LogError($"Error al traer User con Id {username}");
                return NotFound();
            }

            return Ok(_mapper.Map<User>(user));
        }
        
        [HttpGet( Name = "GetUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var user = await _userRepos.GetAll();

            if (user == null)
            {
                _logger.LogError($"Error al traer la lista de Users");
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<User>>(user));
        }


    }
}
